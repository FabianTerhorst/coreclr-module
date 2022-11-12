namespace AltV.Net.Client.Elements.Data
{
    public class MapZoomData
    {
        private readonly ICore core;
        private readonly uint id;

        public MapZoomData(ICore core, uint id)
        {
            this.core = core;
            this.id = id;
        }

        public float FScrollSpeed
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.MapData_GetFScrollSpeed(id);
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.MapData_SetFScrollSpeed(id, value);
                }
            }
        }

        public float FZoomScale
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.MapData_GetFZoomScale(id);
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.MapData_SetFZoomScale(id, value);
                }
            }
        }

        public float FZoomSpeed
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.MapData_GetFZoomSpeed(id);
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.MapData_SetFZoomSpeed(id, value);
                }
            }
        }

        public float VTilesX
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.MapData_GetVTilesX(id);
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.MapData_SetVTilesX(id, value);
                }
            }
        }

        public float VTilesY
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.MapData_GetVTilesY(id);
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.MapData_SetVTilesY(id, value);
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