namespace AltV.Net.Client.Elements.Data
{
    public class MapZoomData : IDisposable
    {
        private readonly ICore core;
        private readonly IntPtr nativePointer;
        private readonly uint id;

        public MapZoomData(ICore core, IntPtr nativePointer, uint id)
        {
            this.core = core;
            this.nativePointer = nativePointer;
            this.id = id;
        }

        public void Dispose()
        {
            unsafe
            {
                core.Library.Client.MapData_Destroy(nativePointer);
            }
        }

        public float FScrollSpeed
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.MapData_GetFScrollSpeed(nativePointer);
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.MapData_SetFScrollSpeed(nativePointer, value);
                }
            }
        }

        public float FZoomScale
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.MapData_GetFZoomScale(nativePointer);
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.MapData_SetFZoomScale(nativePointer, value);
                }
            }
        }

        public float FZoomSpeed
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.MapData_GetFZoomSpeed(nativePointer);
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.MapData_SetFZoomSpeed(nativePointer, value);
                }
            }
        }

        public float VTilesX
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.MapData_GetVTilesX(nativePointer);
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.MapData_SetVTilesX(nativePointer, value);
                }
            }
        }

        public float VTilesY
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.MapData_GetVTilesY(nativePointer);
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.MapData_SetVTilesY(nativePointer, value);
                }
            }
        }

        public void Reset()
        {
            unsafe
            {
                core.Library.Client.Core_ResetMapZoomData(core.NativePointer, id);
            }
        }
    }
}