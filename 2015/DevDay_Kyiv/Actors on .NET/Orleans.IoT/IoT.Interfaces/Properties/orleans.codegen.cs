//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998

namespace IoT.Interfaces
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System.Collections.Generic;
    using Orleans;
    using Orleans.Runtime;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.10.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public class DeviceGrainFactory
    {
        

            public static IDeviceGrain Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return DeviceGrainReference.Cast(grainRef);
            }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.10.0")]
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
        [System.SerializableAttribute()]
        [global::Orleans.CodeGeneration.GrainReferenceAttribute("IoT.Interfaces.IDeviceGrain")]
        internal class DeviceGrainReference : global::Orleans.Runtime.GrainReference, global::Orleans.Runtime.IAddressable, IoT.Interfaces.IDeviceGrain
        {
            

            public static IDeviceGrain Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return (IDeviceGrain) global::Orleans.Runtime.GrainReference.CastInternal(typeof(IDeviceGrain), (global::Orleans.Runtime.GrainReference gr) => { return new DeviceGrainReference(gr);}, grainRef, 1788928010);
            }
            
            protected internal DeviceGrainReference(global::Orleans.Runtime.GrainReference reference) : 
                    base(reference)
            {
            }
            
            protected internal DeviceGrainReference(SerializationInfo info, StreamingContext context) : 
                    base(info, context)
            {
            }
            
            protected override int InterfaceId
            {
                get
                {
                    return 1788928010;
                }
            }
            
            public override string InterfaceName
            {
                get
                {
                    return "IoT.Interfaces.IDeviceGrain";
                }
            }
            
            [global::Orleans.CodeGeneration.CopierMethodAttribute()]
            public static object _Copier(object original)
            {
                DeviceGrainReference input = ((DeviceGrainReference)(original));
                return ((DeviceGrainReference)(global::Orleans.Runtime.GrainReference.CopyGrainReference(input)));
            }
            
            [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
            public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
            {
                DeviceGrainReference input = ((DeviceGrainReference)(original));
                global::Orleans.Runtime.GrainReference.SerializeGrainReference(input, stream, expected);
            }
            
            [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
            public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
            {
                return DeviceGrainReference.Cast(((global::Orleans.Runtime.GrainReference)(global::Orleans.Runtime.GrainReference.DeserializeGrainReference(expected, stream))));
            }
            
            public override bool IsCompatible(int interfaceId)
            {
                return ((interfaceId == this.InterfaceId) 
                            || (interfaceId == -1277021679));
            }
            
            protected override string GetMethodName(int interfaceId, int methodId)
            {
                return DeviceGrainMethodInvoker.GetMethodName(interfaceId, methodId);
            }
            
            System.Threading.Tasks.Task IoT.Interfaces.IDeviceGrain.JoinSystem(string @name)
            {

                return base.InvokeMethodAsync<object>(-1555867497, new object[] {@name} );
            }
            
            System.Threading.Tasks.Task IoT.Interfaces.IDeviceGrain.SetTemperature(double @value)
            {

                return base.InvokeMethodAsync<object>(-1788431855, new object[] {@value} );
            }
            
            System.Threading.Tasks.Task<double> IoT.Interfaces.IDeviceGrain.GetTemperature()
            {

                return base.InvokeMethodAsync<System.Double>(98774684, null );
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.10.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [global::Orleans.CodeGeneration.MethodInvokerAttribute("IoT.Interfaces.IDeviceGrain", 1788928010)]
    internal class DeviceGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        
        int global::Orleans.CodeGeneration.IGrainMethodInvoker.InterfaceId
        {
            get
            {
                return 1788928010;
            }
        }
        
        global::System.Threading.Tasks.Task<object> global::Orleans.CodeGeneration.IGrainMethodInvoker.Invoke(global::Orleans.Runtime.IAddressable grain, int interfaceId, int methodId, object[] arguments)
        {

            try
            {                    if (grain == null) throw new System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case 1788928010:  // IDeviceGrain
                        switch (methodId)
                        {
                            case -1555867497: 
                                return ((IDeviceGrain)grain).JoinSystem((System.String)arguments[0]).ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)null; });
                            case -1788431855: 
                                return ((IDeviceGrain)grain).SetTemperature((System.Double)arguments[0]).ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)null; });
                            case 98774684: 
                                return ((IDeviceGrain)grain).GetTemperature().ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)t.Result; });
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }case -1277021679:  // IGrainWithStringKey
                        switch (methodId)
                        {
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }
                    default:
                        throw new System.InvalidCastException("interfaceId="+interfaceId);
                }
            }
            catch(Exception ex)
            {
                var t = new System.Threading.Tasks.TaskCompletionSource<object>();
                t.SetException(ex);
                return t.Task;
            }
        }
        
        public static string GetMethodName(int interfaceId, int methodId)
        {

            switch (interfaceId)
            {
                
                case 1788928010:  // IDeviceGrain
                    switch (methodId)
                    {
                        case -1555867497:
                            return "JoinSystem";
                    case -1788431855:
                            return "SetTemperature";
                    case 98774684:
                            return "GetTemperature";
                    
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }
                case -1277021679:  // IGrainWithStringKey
                    switch (methodId)
                    {
                        
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }

                default:
                    throw new System.InvalidCastException("interfaceId="+interfaceId);
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.10.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public class SystemGrainFactory
    {
        

            public static ISystemGrain Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return SystemGrainReference.Cast(grainRef);
            }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.10.0")]
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
        [System.SerializableAttribute()]
        [global::Orleans.CodeGeneration.GrainReferenceAttribute("IoT.Interfaces.ISystemGrain")]
        internal class SystemGrainReference : global::Orleans.Runtime.GrainReference, global::Orleans.Runtime.IAddressable, IoT.Interfaces.ISystemGrain
        {
            

            public static ISystemGrain Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return (ISystemGrain) global::Orleans.Runtime.GrainReference.CastInternal(typeof(ISystemGrain), (global::Orleans.Runtime.GrainReference gr) => { return new SystemGrainReference(gr);}, grainRef, -1784953168);
            }
            
            protected internal SystemGrainReference(global::Orleans.Runtime.GrainReference reference) : 
                    base(reference)
            {
            }
            
            protected internal SystemGrainReference(SerializationInfo info, StreamingContext context) : 
                    base(info, context)
            {
            }
            
            protected override int InterfaceId
            {
                get
                {
                    return -1784953168;
                }
            }
            
            public override string InterfaceName
            {
                get
                {
                    return "IoT.Interfaces.ISystemGrain";
                }
            }
            
            [global::Orleans.CodeGeneration.CopierMethodAttribute()]
            public static object _Copier(object original)
            {
                SystemGrainReference input = ((SystemGrainReference)(original));
                return ((SystemGrainReference)(global::Orleans.Runtime.GrainReference.CopyGrainReference(input)));
            }
            
            [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
            public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
            {
                SystemGrainReference input = ((SystemGrainReference)(original));
                global::Orleans.Runtime.GrainReference.SerializeGrainReference(input, stream, expected);
            }
            
            [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
            public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
            {
                return SystemGrainReference.Cast(((global::Orleans.Runtime.GrainReference)(global::Orleans.Runtime.GrainReference.DeserializeGrainReference(expected, stream))));
            }
            
            public override bool IsCompatible(int interfaceId)
            {
                return ((interfaceId == this.InterfaceId) 
                            || (interfaceId == -1277021679));
            }
            
            protected override string GetMethodName(int interfaceId, int methodId)
            {
                return SystemGrainMethodInvoker.GetMethodName(interfaceId, methodId);
            }
            
            System.Threading.Tasks.Task IoT.Interfaces.ISystemGrain.SetTemperature(double @value, string @deviceId)
            {

                return base.InvokeMethodAsync<object>(-1906793719, new object[] {@value, @deviceId} );
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.10.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [global::Orleans.CodeGeneration.MethodInvokerAttribute("IoT.Interfaces.ISystemGrain", -1784953168)]
    internal class SystemGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        
        int global::Orleans.CodeGeneration.IGrainMethodInvoker.InterfaceId
        {
            get
            {
                return -1784953168;
            }
        }
        
        global::System.Threading.Tasks.Task<object> global::Orleans.CodeGeneration.IGrainMethodInvoker.Invoke(global::Orleans.Runtime.IAddressable grain, int interfaceId, int methodId, object[] arguments)
        {

            try
            {                    if (grain == null) throw new System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case -1784953168:  // ISystemGrain
                        switch (methodId)
                        {
                            case -1906793719: 
                                return ((ISystemGrain)grain).SetTemperature((Double)arguments[0], (String)arguments[1]).ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)null; });
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }case -1277021679:  // IGrainWithStringKey
                        switch (methodId)
                        {
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }
                    default:
                        throw new System.InvalidCastException("interfaceId="+interfaceId);
                }
            }
            catch(Exception ex)
            {
                var t = new System.Threading.Tasks.TaskCompletionSource<object>();
                t.SetException(ex);
                return t.Task;
            }
        }
        
        public static string GetMethodName(int interfaceId, int methodId)
        {

            switch (interfaceId)
            {
                
                case -1784953168:  // ISystemGrain
                    switch (methodId)
                    {
                        case -1906793719:
                            return "SetTemperature";
                    
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }
                case -1277021679:  // IGrainWithStringKey
                    switch (methodId)
                    {
                        
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }

                default:
                    throw new System.InvalidCastException("interfaceId="+interfaceId);
            }
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 649
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
