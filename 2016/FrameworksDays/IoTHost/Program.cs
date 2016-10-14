using Orleans.Runtime.Configuration;
using Orleans.Runtime.Host;
using System;
using System.Net;
using Orleans.Runtime;
using Serilog;
using Topshelf;

namespace IoT.Host
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.AppSettings()
               .Enrich.FromLogContext()
               .Enrich.WithMachineName()
               .CreateLogger();

            // added orleans client log consumer
            LogManager.LogConsumers.Add(new OrleansLogClient());

            HostFactory.Run(x =>
            {
                x.EnableServiceRecovery(a =>
                {
                    a.OnCrashOnly();
                    a.RestartService(delayInMinutes: 1);
                });
                x.Service<SiloApp>(sc =>
                {
                    sc.ConstructUsing(() => new SiloApp(siloName: Dns.GetHostName(),
                                                        configPath: "OrleansCluster.config"));
                    sc.WhenStarted((siloApp, hostControl) => siloApp.Start());
                    sc.WhenStopped((siloApp, hostControl) => siloApp.Stop());
                });
                x.StartAutomatically();

                x.RunAsLocalSystem();

                x.SetDescription("Orleans IoTHost");
                x.SetDisplayName("Orleans IoTHost");
                x.SetServiceName("Orleans IoTHost");
            });
        }
    }

    public class SiloApp
    {
        SiloHost _siloHost;
        readonly string _siloName;
        readonly string _configPath;

        public SiloApp(string siloName, string configPath)
        {
            _siloName = siloName;
            _configPath = configPath;
        }

        public bool Start()
        {
            Console.WriteLine("Starting SiloHost...");

            var config = new ClusterConfiguration();
            config.LoadFromFile(_configPath);

            _siloHost = new SiloHost(_siloName, config);

            try
            {
                // if we run not DEV env, we need special initialization for Consul
                if (_siloHost.Config.Globals.LivenessType != GlobalConfiguration.LivenessProviderType.MembershipTableGrain)
                {
                    _siloHost.Config.Globals.LivenessType = GlobalConfiguration.LivenessProviderType.Custom;
                    _siloHost.Config.Globals.MembershipTableAssembly = "OrleansConsulUtils";
                    _siloHost.Config.Globals.ReminderServiceType = GlobalConfiguration.ReminderServiceProviderType.Disabled;
                }
                _siloHost.InitializeOrleansSilo();
                var ok = _siloHost.StartOrleansSilo();

                Console.WriteLine(ok
                    ? $"Successfully started Orleans silo '{_siloHost.Name}' as a {_siloHost.Type} node."
                    : $"Failed to start Orleans silo '{_siloHost.Name}' as a {_siloHost.Type} node.");

                return ok;
            }
            catch (Exception exc)
            {
                _siloHost.ReportStartupError(exc);
                var msg = $"{exc.GetType().FullName}:\n{exc.Message}\n{exc.StackTrace}";
                Console.WriteLine(msg);
                return false;
            }
        }

        public bool Stop()
        {
            Console.WriteLine("Stopping SiloHost...");

            try
            {
                _siloHost.StopOrleansSilo();
                _siloHost.Dispose();
                GC.SuppressFinalize(_siloHost);
                Console.WriteLine($"Orleans silo '{_siloHost.Name}' shutdown.");
                return true;
            }
            catch (Exception exc)
            {
                _siloHost.ReportStartupError(exc);
                var msg = $"{exc.GetType().FullName}:\n{exc.Message}\n{exc.StackTrace}";
                Console.WriteLine(msg);
                return false;
            }
        }
    }

    class OrleansLogClient : ILogConsumer
    {
        readonly ILogger _logger = Serilog.Log.ForContext<OrleansLogClient>();

        public void Log(Severity severity, LoggerType loggerType, string caller,
                        string message, IPEndPoint myIPEndPoint,
                        Exception exception, int eventCode = 0)
        {
            switch (severity)
            {
                case Severity.Error:
                    _logger.Error(exception, "{@Caller} {@Message}", caller, message);
                    break;
                case Severity.Warning:
                    _logger.Warning(exception, "{@Caller} {@Message}", caller, message);
                    break;
                case Severity.Info:
                    _logger.Information(exception, "{@Caller} {@Message}", caller, message);
                    break;
                case Severity.Verbose:
                    _logger.Debug(exception, "{@Caller} {@Message}", caller, message);
                    break;
                case Severity.Verbose2:
                case Severity.Verbose3:
                    _logger.Verbose(exception, "{@Caller} {@Message}", caller, message);
                    break;
            }
        }
    }
}
