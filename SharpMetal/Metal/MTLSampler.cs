using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLSamplerMinMagFilter : ulong
    {
        Nearest = 0,
        Linear = 1,
    }

    public enum MTLSamplerMipFilter : ulong
    {
        NotMipmapped = 0,
        Nearest = 1,
        Linear = 2,
    }

    public enum MTLSamplerAddressMode : ulong
    {
        ClampToEdge = 0,
        MirrorClampToEdge = 1,
        Repeat = 2,
        MirrorRepeat = 3,
        ClampToZero = 4,
        ClampToBorderColor = 5,
    }

    public enum MTLSamplerBorderColor : ulong
    {
        TransparentBlack = 0,
        OpaqueBlack = 1,
        OpaqueWhite = 2,
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLSamplerDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSamplerDescriptor obj) => obj.NativePtr;
        public MTLSamplerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLSamplerDescriptor()
        {
            var cls = new ObjectiveCClass("MTLSamplerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLSamplerMinMagFilter MinFilter
        {
            get => (MTLSamplerMinMagFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_minFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMinFilter, (ulong)value);
        }

        public MTLSamplerMinMagFilter MagFilter
        {
            get => (MTLSamplerMinMagFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_magFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMagFilter, (ulong)value);
        }

        public MTLSamplerMipFilter MipFilter
        {
            get => (MTLSamplerMipFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mipFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMipFilter, (ulong)value);
        }

        public ulong MaxAnisotropy
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxAnisotropy);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxAnisotropy, value);
        }

        public MTLSamplerAddressMode SAddressMode
        {
            get => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sAddressMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSAddressMode, (ulong)value);
        }

        public MTLSamplerAddressMode TAddressMode
        {
            get => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tAddressMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTAddressMode, (ulong)value);
        }

        public MTLSamplerAddressMode RAddressMode
        {
            get => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rAddressMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRAddressMode, (ulong)value);
        }

        public MTLSamplerBorderColor BorderColor
        {
            get => (MTLSamplerBorderColor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_borderColor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBorderColor, (ulong)value);
        }

        public bool NormalizedCoordinates
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_normalizedCoordinates);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setNormalizedCoordinates, value);
        }

        public float LodMinClamp
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_lodMinClamp);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodMinClamp, value);
        }

        public float LodMaxClamp
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_lodMaxClamp);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodMaxClamp, value);
        }

        public bool LodAverage
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_lodAverage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodAverage, value);
        }

        public MTLCompareFunction CompareFunction
        {
            get => (MTLCompareFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_compareFunction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCompareFunction, (ulong)value);
        }

        public bool SupportArgumentBuffers
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportArgumentBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportArgumentBuffers, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public void SetMinFilter(MTLSamplerMinMagFilter minFilter)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMinFilter, (ulong)minFilter);
        }

        public void SetMagFilter(MTLSamplerMinMagFilter magFilter)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMagFilter, (ulong)magFilter);
        }

        public void SetMipFilter(MTLSamplerMipFilter mipFilter)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMipFilter, (ulong)mipFilter);
        }

        public void SetMaxAnisotropy(ulong maxAnisotropy)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxAnisotropy, maxAnisotropy);
        }

        public void SetSAddressMode(MTLSamplerAddressMode sAddressMode)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSAddressMode, (ulong)sAddressMode);
        }

        public void SetTAddressMode(MTLSamplerAddressMode tAddressMode)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTAddressMode, (ulong)tAddressMode);
        }

        public void SetRAddressMode(MTLSamplerAddressMode rAddressMode)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRAddressMode, (ulong)rAddressMode);
        }

        public void SetBorderColor(MTLSamplerBorderColor borderColor)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBorderColor, (ulong)borderColor);
        }

        public void SetNormalizedCoordinates(bool normalizedCoordinates)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setNormalizedCoordinates, normalizedCoordinates);
        }

        public void SetLodMinClamp(float lodMinClamp)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodMinClamp, lodMinClamp);
        }

        public void SetLodMaxClamp(float lodMaxClamp)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodMaxClamp, lodMaxClamp);
        }

        public void SetLodAverage(bool lodAverage)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodAverage, lodAverage);
        }

        public void SetCompareFunction(MTLCompareFunction compareFunction)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCompareFunction, (ulong)compareFunction);
        }

        public void SetSupportArgumentBuffers(bool supportArgumentBuffers)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportArgumentBuffers, supportArgumentBuffers);
        }

        public void SetLabel(NSString label)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, label);
        }

        private static readonly Selector sel_minFilter = "minFilter";
        private static readonly Selector sel_setMinFilter = "setMinFilter:";
        private static readonly Selector sel_magFilter = "magFilter";
        private static readonly Selector sel_setMagFilter = "setMagFilter:";
        private static readonly Selector sel_mipFilter = "mipFilter";
        private static readonly Selector sel_setMipFilter = "setMipFilter:";
        private static readonly Selector sel_maxAnisotropy = "maxAnisotropy";
        private static readonly Selector sel_setMaxAnisotropy = "setMaxAnisotropy:";
        private static readonly Selector sel_sAddressMode = "sAddressMode";
        private static readonly Selector sel_setSAddressMode = "setSAddressMode:";
        private static readonly Selector sel_tAddressMode = "tAddressMode";
        private static readonly Selector sel_setTAddressMode = "setTAddressMode:";
        private static readonly Selector sel_rAddressMode = "rAddressMode";
        private static readonly Selector sel_setRAddressMode = "setRAddressMode:";
        private static readonly Selector sel_borderColor = "borderColor";
        private static readonly Selector sel_setBorderColor = "setBorderColor:";
        private static readonly Selector sel_normalizedCoordinates = "normalizedCoordinates";
        private static readonly Selector sel_setNormalizedCoordinates = "setNormalizedCoordinates:";
        private static readonly Selector sel_lodMinClamp = "lodMinClamp";
        private static readonly Selector sel_setLodMinClamp = "setLodMinClamp:";
        private static readonly Selector sel_lodMaxClamp = "lodMaxClamp";
        private static readonly Selector sel_setLodMaxClamp = "setLodMaxClamp:";
        private static readonly Selector sel_lodAverage = "lodAverage";
        private static readonly Selector sel_setLodAverage = "setLodAverage:";
        private static readonly Selector sel_compareFunction = "compareFunction";
        private static readonly Selector sel_setCompareFunction = "setCompareFunction:";
        private static readonly Selector sel_supportArgumentBuffers = "supportArgumentBuffers";
        private static readonly Selector sel_setSupportArgumentBuffers = "setSupportArgumentBuffers:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLSamplerState
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSamplerState obj) => obj.NativePtr;
        public MTLSamplerState(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
    }
}
