#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute("Contracts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace Contracts
{
    using global::Orleans.Async;
    using global::Orleans;
    using global::System.Reflection;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::Contracts.IClientGrain))]
    internal class OrleansCodeGenClientGrainReference : global::Orleans.Runtime.GrainReference, global::Contracts.IClientGrain
    {
        protected @OrleansCodeGenClientGrainReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenClientGrainReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return 46771779;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::Contracts.IClientGrain";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == 46771779;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case 46771779:
                    switch (@methodId)
                    {
                        case 1975541297:
                            return "Run";
                        case 33999191:
                            return "Pong";
                        case -374106005:
                            return "Initialize";
                        case -1238941369:
                            return "Subscribe";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 46771779 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task @Run()
        {
            return base.@InvokeMethodAsync<global::System.Object>(1975541297, null);
        }

        public global::System.Threading.Tasks.Task @Pong(global::Contracts.IDestinationGrain @from, global::Contracts.Message @message)
        {
            return base.@InvokeMethodAsync<global::System.Object>(33999191, new global::System.Object[]{@from is global::Orleans.Grain ? @from.@AsReference<global::Contracts.IDestinationGrain>() : @from, @message});
        }

        public global::System.Threading.Tasks.Task @Initialize(global::Contracts.IDestinationGrain @actor, global::System.Int64 @repeats)
        {
            return base.@InvokeMethodAsync<global::System.Object>(-374106005, new global::System.Object[]{@actor is global::Orleans.Grain ? @actor.@AsReference<global::Contracts.IDestinationGrain>() : @actor, @repeats});
        }

        public global::System.Threading.Tasks.Task @Subscribe(global::Contracts.IClientObserver @subscriber)
        {
            global::Orleans.CodeGeneration.GrainFactoryBase.@CheckGrainObserverParamInternal(@subscriber);
            return base.@InvokeMethodAsync<global::System.Object>(-1238941369, new global::System.Object[]{@subscriber is global::Orleans.Grain ? @subscriber.@AsReference<global::Contracts.IClientObserver>() : @subscriber});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::Contracts.IClientGrain", 46771779, typeof (global::Contracts.IClientGrain)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenClientGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::Orleans.CodeGeneration.InvokeMethodRequest @request)
        {
            global::System.Int32 interfaceId = @request.@InterfaceId;
            global::System.Int32 methodId = @request.@MethodId;
            global::System.Object[] arguments = @request.@Arguments;
            try
            {
                if (@grain == null)
                    throw new global::System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case 46771779:
                        switch (methodId)
                        {
                            case 1975541297:
                                return ((global::Contracts.IClientGrain)@grain).@Run().@Box();
                            case 33999191:
                                return ((global::Contracts.IClientGrain)@grain).@Pong((global::Contracts.IDestinationGrain)arguments[0], (global::Contracts.Message)arguments[1]).@Box();
                            case -374106005:
                                return ((global::Contracts.IClientGrain)@grain).@Initialize((global::Contracts.IDestinationGrain)arguments[0], (global::System.Int64)arguments[1]).@Box();
                            case -1238941369:
                                return ((global::Contracts.IClientGrain)@grain).@Subscribe((global::Contracts.IClientObserver)arguments[0]).@Box();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + 46771779 + ",methodId=" + methodId);
                        }

                    default:
                        throw new global::System.NotImplementedException("interfaceId=" + interfaceId);
                }
            }
            catch (global::System.Exception exception)
            {
                return global::Orleans.Async.TaskUtility.@Faulted(exception);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return 46771779;
            }
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::Contracts.Message)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenContracts_MessageSerializer
    {
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            return original;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::Contracts.Message input = (global::Contracts.Message)untypedInput;
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::Contracts.Message result = new global::Contracts.Message();
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            return (global::Contracts.Message)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::Contracts.Message), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenContracts_MessageSerializer()
        {
            Register();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::Contracts.IClientObserver))]
    internal class OrleansCodeGenClientObserverReference : global::Orleans.Runtime.GrainReference, global::Contracts.IClientObserver
    {
        protected @OrleansCodeGenClientObserverReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenClientObserverReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return -1815835083;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::Contracts.IClientObserver";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == -1815835083;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case -1815835083:
                    switch (@methodId)
                    {
                        case -1778340467:
                            return "Done";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + -1815835083 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public void @Done(global::System.Int64 @pings, global::System.Int64 @pongs)
        {
            base.@InvokeOneWayMethod(-1778340467, new global::System.Object[]{@pings, @pongs});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::Contracts.IClientObserver", -1815835083, typeof (global::Contracts.IClientObserver)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenClientObserverMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::Orleans.CodeGeneration.InvokeMethodRequest @request)
        {
            global::System.Int32 interfaceId = @request.@InterfaceId;
            global::System.Int32 methodId = @request.@MethodId;
            global::System.Object[] arguments = @request.@Arguments;
            try
            {
                if (@grain == null)
                    throw new global::System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case -1815835083:
                        switch (methodId)
                        {
                            case -1778340467:
                                ((global::Contracts.IClientObserver)@grain).@Done((global::System.Int64)arguments[0], (global::System.Int64)arguments[1]);
                                return global::Orleans.Async.TaskUtility.@Completed();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + -1815835083 + ",methodId=" + methodId);
                        }

                    default:
                        throw new global::System.NotImplementedException("interfaceId=" + interfaceId);
                }
            }
            catch (global::System.Exception exception)
            {
                return global::Orleans.Async.TaskUtility.@Faulted(exception);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return -1815835083;
            }
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::Contracts.IDestinationGrain))]
    internal class OrleansCodeGenDestinationGrainReference : global::Orleans.Runtime.GrainReference, global::Contracts.IDestinationGrain
    {
        protected @OrleansCodeGenDestinationGrainReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenDestinationGrainReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return 417497818;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::Contracts.IDestinationGrain";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == 417497818;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case 417497818:
                    switch (@methodId)
                    {
                        case 1922695751:
                            return "Ping";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 417497818 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task @Ping(global::Contracts.IClientGrain @from, global::Contracts.Message @message)
        {
            return base.@InvokeMethodAsync<global::System.Object>(1922695751, new global::System.Object[]{@from is global::Orleans.Grain ? @from.@AsReference<global::Contracts.IClientGrain>() : @from, @message});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::Contracts.IDestinationGrain", 417497818, typeof (global::Contracts.IDestinationGrain)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenDestinationGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::Orleans.CodeGeneration.InvokeMethodRequest @request)
        {
            global::System.Int32 interfaceId = @request.@InterfaceId;
            global::System.Int32 methodId = @request.@MethodId;
            global::System.Object[] arguments = @request.@Arguments;
            try
            {
                if (@grain == null)
                    throw new global::System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case 417497818:
                        switch (methodId)
                        {
                            case 1922695751:
                                return ((global::Contracts.IDestinationGrain)@grain).@Ping((global::Contracts.IClientGrain)arguments[0], (global::Contracts.Message)arguments[1]).@Box();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + 417497818 + ",methodId=" + methodId);
                        }

                    default:
                        throw new global::System.NotImplementedException("interfaceId=" + interfaceId);
                }
            }
            catch (global::System.Exception exception)
            {
                return global::Orleans.Async.TaskUtility.@Faulted(exception);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return 417497818;
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
