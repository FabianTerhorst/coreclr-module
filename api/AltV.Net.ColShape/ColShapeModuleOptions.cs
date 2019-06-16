namespace AltV.Net.ColShape
{
    public class ColShapeModuleOptions
    {
        /// <summary>
        /// smaller area size => more ram, less cpu
        /// areaSize of 1 requires 10gb ram
        /// areaSize of 10 requires 100mb ram
        /// areaSize of 100 requires 1mb ram
        /// </summary>
        public int AreaSize { get; set; } = 100;
    }
}