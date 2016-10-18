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
                        case -1465479330:
                            return "StartRun";
                        case 2134917235:
                            return "FinishRun";
                        case 1648747664:
                            return "HandleMetrics";
                        case -837205729:
                            return "HandleBattery";
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

        public global::System.Threading.Tasks.Task @StartRun(global::System.String @locationName)
        {
            return base.@InvokeMethodAsync<global::System.Object>(-1465479330, new global::System.Object[]{@locationName});
        }

        public global::System.Threading.Tasks.Task @FinishRun()
        {
            return base.@InvokeMethodAsync<global::System.Object>(2134917235, null);
        }

        public global::System.Threading.Tasks.Task @HandleMetrics(global::IoT.Contracts.Metrics @message)
        {
            return base.@InvokeMethodAsync<global::System.Object>(1648747664, new global::System.Object[]{@message});
        }

        public global::System.Threading.Tasks.Task @HandleBattery(global::IoT.Contracts.BatteryCapacity @message)
        {
            return base.@InvokeMethodAsync<global::System.Object>(-837205729, new global::System.Object[]{@message});
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
                            case -1465479330:
                                return ((global::IoT.Contracts.IDeviceGrain)@grain).@StartRun((global::System.String)arguments[0]).@Box();
                            case 2134917235:
                                return ((global::IoT.Contracts.IDeviceGrain)@grain).@FinishRun().@Box();
                            case 1648747664:
                                return ((global::IoT.Contracts.IDeviceGrain)@grain).@HandleMetrics((global::IoT.Contracts.Metrics)arguments[0]).@Box();
                            case -837205729:
                                return ((global::IoT.Contracts.IDeviceGrain)@grain).@HandleBattery((global::IoT.Contracts.BatteryCapacity)arguments[0]).@Box();
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
            result.@Lat = input.@Lat;
            result.@Long = input.@Long;
            result.@Meters = input.@Meters;
            result.@StepsCounter = input.@StepsCounter;
            result.@Time = input.@Time;
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::IoT.Contracts.Metrics input = (global::IoT.Contracts.Metrics)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Lat, stream, typeof (global::System.Double));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Long, stream, typeof (global::System.Double));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Meters, stream, typeof (global::System.UInt32));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@StepsCounter, stream, typeof (global::System.UInt32));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Time, stream, typeof (global::System.DateTime));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::IoT.Contracts.Metrics result = new global::IoT.Contracts.Metrics();
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            result.@Lat = (global::System.Double)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Double), stream);
            result.@Long = (global::System.Double)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Double), stream);
            result.@Meters = (global::System.UInt32)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.UInt32), stream);
            result.@StepsCounter = (global::System.UInt32)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.UInt32), stream);
            result.@Time = (global::System.DateTime)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.DateTime), stream);
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
            result.@Time = input.@Time;
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::IoT.Contracts.BatteryCapacity input = (global::IoT.Contracts.BatteryCapacity)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Capacity, stream, typeof (global::System.UInt32));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Time, stream, typeof (global::System.DateTime));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::IoT.Contracts.BatteryCapacity result = new global::IoT.Contracts.BatteryCapacity();
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            result.@Capacity = (global::System.UInt32)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.UInt32), stream);
            result.@Time = (global::System.DateTime)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.DateTime), stream);
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
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::IoT.Contracts.UserInfo input = (global::IoT.Contracts.UserInfo)untypedInput;
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::IoT.Contracts.UserInfo result = new global::IoT.Contracts.UserInfo();
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
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

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::IoT.Contracts.Warning)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenIoT_Contracts_WarningSerializer
    {
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::IoT.Contracts.Warning input = ((global::IoT.Contracts.Warning)original);
            global::IoT.Contracts.Warning result = new global::IoT.Contracts.Warning();
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            result.@Text = input.@Text;
            result.@WarningType = input.@WarningType;
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::IoT.Contracts.Warning input = (global::IoT.Contracts.Warning)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Text, stream, typeof (global::System.String));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@WarningType, stream, typeof (global::IoT.Contracts.WarningType));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::IoT.Contracts.Warning result = new global::IoT.Contracts.Warning();
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            result.@Text = (global::System.String)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.String), stream);
            result.@WarningType = (global::IoT.Contracts.WarningType)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::IoT.Contracts.WarningType), stream);
            return (global::IoT.Contracts.Warning)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::IoT.Contracts.Warning), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenIoT_Contracts_WarningSerializer()
        {
            Register();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::IoT.Contracts.IUserGrain))]
    internal class OrleansCodeGenUserGrainReference : global::Orleans.Runtime.GrainReference, global::IoT.Contracts.IUserGrain
    {
        protected @OrleansCodeGenUserGrainReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenUserGrainReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return -588705512;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::IoT.Contracts.IUserGrain";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == -588705512 || @interfaceId == -1277021679;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case -588705512:
                    switch (@methodId)
                    {
                        case 2092661832:
                            return "AddNewDevice";
                        case 1326943879:
                            return "HandleWarning";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + -588705512 + ",methodId=" + @methodId);
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

        public global::System.Threading.Tasks.Task<global::System.Boolean> @AddNewDevice(global::System.String @deviceId)
        {
            return base.@InvokeMethodAsync<global::System.Boolean>(2092661832, new global::System.Object[]{@deviceId});
        }

        public global::System.Threading.Tasks.Task @HandleWarning(global::IoT.Contracts.Warning @message)
        {
            return base.@InvokeMethodAsync<global::System.Object>(1326943879, new global::System.Object[]{@message});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.0.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::IoT.Contracts.IUserGrain", -588705512, typeof (global::IoT.Contracts.IUserGrain)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenUserGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
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
                    case -588705512:
                        switch (methodId)
                        {
                            case 2092661832:
                                return ((global::IoT.Contracts.IUserGrain)@grain).@AddNewDevice((global::System.String)arguments[0]).@Box();
                            case 1326943879:
                                return ((global::IoT.Contracts.IUserGrain)@grain).@HandleWarning((global::IoT.Contracts.Warning)arguments[0]).@Box();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + -588705512 + ",methodId=" + methodId);
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
                return -588705512;
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
