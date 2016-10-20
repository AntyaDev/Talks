#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute("IoT.Contracts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace IoT.Contracts
{
    using global::Orleans.Async;
    using global::Orleans;
    using global::System.Reflection;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::IoT.Contracts.IDeviceGrain))]
    internal class OrleansCodeGenDeviceGrainReference : global::Orleans.Runtime.GrainReference, global::IoT.Contracts.IDeviceGrain
    {
        protected @OrleansCodeGenDeviceGrainReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenDeviceGrainReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return -673425859;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::IoT.Contracts.IDeviceGrain";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == -673425859 || @interfaceId == -1277021679;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case -673425859:
                    switch (@methodId)
                    {
                        case 1643804736:
                            return "UpdateRunnerState";
                        case 1300480962:
                            return "UpdateMetrics";
                        case 102508388:
                            return "UpdateBattery";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + -673425859 + ",methodId=" + @methodId);
                    }

                case -1277021679:
                    switch (@methodId)
                    {
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + -1277021679 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task @UpdateRunnerState(global::IoT.Contracts.RunnerState @message)
        {
            return base.@InvokeMethodAsync<global::System.Object>(1643804736, new global::System.Object[]{@message});
        }

        public global::System.Threading.Tasks.Task @UpdateMetrics(global::IoT.Contracts.Metrics @message)
        {
            return base.@InvokeMethodAsync<global::System.Object>(1300480962, new global::System.Object[]{@message});
        }

        public global::System.Threading.Tasks.Task @UpdateBattery(global::IoT.Contracts.BatteryCapacity @message)
        {
            return base.@InvokeMethodAsync<global::System.Object>(102508388, new global::System.Object[]{@message});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::IoT.Contracts.IDeviceGrain", -673425859, typeof (global::IoT.Contracts.IDeviceGrain)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenDeviceGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
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
                    case -673425859:
                        switch (methodId)
                        {
                            case 1643804736:
                                return ((global::IoT.Contracts.IDeviceGrain)@grain).@UpdateRunnerState((global::IoT.Contracts.RunnerState)arguments[0]).@Box();
                            case 1300480962:
                                return ((global::IoT.Contracts.IDeviceGrain)@grain).@UpdateMetrics((global::IoT.Contracts.Metrics)arguments[0]).@Box();
                            case 102508388:
                                return ((global::IoT.Contracts.IDeviceGrain)@grain).@UpdateBattery((global::IoT.Contracts.BatteryCapacity)arguments[0]).@Box();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + -673425859 + ",methodId=" + methodId);
                        }

                    case -1277021679:
                        switch (methodId)
                        {
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + -1277021679 + ",methodId=" + methodId);
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
                return -673425859;
            }
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::IoT.Contracts.Metrics)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenIoT_Contracts_MetricsSerializer
    {
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::IoT.Contracts.Metrics input = ((global::IoT.Contracts.Metrics)original);
            global::IoT.Contracts.Metrics result = new global::IoT.Contracts.Metrics();
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            result.@Distance = input.@Distance;
            result.@Duration = input.@Duration;
            result.@Lat = input.@Lat;
            result.@Long = input.@Long;
            result.@StepsCount = input.@StepsCount;
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::IoT.Contracts.Metrics input = (global::IoT.Contracts.Metrics)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Distance, stream, typeof (global::System.Single));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Duration, stream, typeof (global::System.DateTime));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Lat, stream, typeof (global::System.Double));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Long, stream, typeof (global::System.Double));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@StepsCount, stream, typeof (global::System.UInt32));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::IoT.Contracts.Metrics result = new global::IoT.Contracts.Metrics();
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            result.@Distance = (global::System.Single)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Single), stream);
            result.@Duration = (global::System.DateTime)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.DateTime), stream);
            result.@Lat = (global::System.Double)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Double), stream);
            result.@Long = (global::System.Double)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Double), stream);
            result.@StepsCount = (global::System.UInt32)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.UInt32), stream);
            return (global::IoT.Contracts.Metrics)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::IoT.Contracts.Metrics), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenIoT_Contracts_MetricsSerializer()
        {
            Register();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::IoT.Contracts.BatteryCapacity)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenIoT_Contracts_BatteryCapacitySerializer
    {
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::IoT.Contracts.BatteryCapacity input = ((global::IoT.Contracts.BatteryCapacity)original);
            global::IoT.Contracts.BatteryCapacity result = new global::IoT.Contracts.BatteryCapacity();
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            result.@Capacity = input.@Capacity;
            result.@TimeStamp = input.@TimeStamp;
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::IoT.Contracts.BatteryCapacity input = (global::IoT.Contracts.BatteryCapacity)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Capacity, stream, typeof (global::System.UInt32));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@TimeStamp, stream, typeof (global::System.DateTime));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::IoT.Contracts.BatteryCapacity result = new global::IoT.Contracts.BatteryCapacity();
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            result.@Capacity = (global::System.UInt32)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.UInt32), stream);
            result.@TimeStamp = (global::System.DateTime)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.DateTime), stream);
            return (global::IoT.Contracts.BatteryCapacity)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::IoT.Contracts.BatteryCapacity), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenIoT_Contracts_BatteryCapacitySerializer()
        {
            Register();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::IoT.Contracts.UserInfo)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenIoT_Contracts_UserInfoSerializer
    {
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::IoT.Contracts.UserInfo input = ((global::IoT.Contracts.UserInfo)original);
            global::IoT.Contracts.UserInfo result = new global::IoT.Contracts.UserInfo();
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            result.@Distance = input.@Distance;
            result.@Duration = input.@Duration;
            result.@Lat = input.@Lat;
            result.@Long = input.@Long;
            result.@RunnerState = input.@RunnerState;
            result.@StepsCount = input.@StepsCount;
            result.@UserName = input.@UserName;
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::IoT.Contracts.UserInfo input = (global::IoT.Contracts.UserInfo)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Distance, stream, typeof (global::System.Single));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Duration, stream, typeof (global::System.DateTime));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Lat, stream, typeof (global::System.Double));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Long, stream, typeof (global::System.Double));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@RunnerState, stream, typeof (global::IoT.Contracts.RunnerState));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@StepsCount, stream, typeof (global::System.UInt32));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@UserName, stream, typeof (global::System.String));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::IoT.Contracts.UserInfo result = new global::IoT.Contracts.UserInfo();
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            result.@Distance = (global::System.Single)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Single), stream);
            result.@Duration = (global::System.DateTime)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.DateTime), stream);
            result.@Lat = (global::System.Double)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Double), stream);
            result.@Long = (global::System.Double)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Double), stream);
            result.@RunnerState = (global::IoT.Contracts.RunnerState)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::IoT.Contracts.RunnerState), stream);
            result.@StepsCount = (global::System.UInt32)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.UInt32), stream);
            result.@UserName = (global::System.String)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.String), stream);
            return (global::IoT.Contracts.UserInfo)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::IoT.Contracts.UserInfo), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenIoT_Contracts_UserInfoSerializer()
        {
            Register();
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
