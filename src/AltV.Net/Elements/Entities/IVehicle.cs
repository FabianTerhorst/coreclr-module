using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public interface IVehicle : IEntity
    {
        /// <summary>
        /// Get the current driver of the vehicle
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IPlayer Driver { get; }

        /// <summary>
        /// Get or set mod kit of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        byte ModKit { get; set; }

        bool IsPrimaryColorRgb { get; }

        /// <summary>
        /// Get or set primary color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        byte PrimaryColor { get; set; }

        Rgba PrimaryColorRgb { get; set; }

        bool IsSecondaryColorRgb { get; }

        byte SecondaryColor { get; set; }

        Rgba SecondaryColorRgb { get; set; }

        byte PearlColor { get; set; }

        byte WheelColor { get; set; }

        byte InteriorColor { get; set; }

        byte DashboardColor { get; set; }

        Rgba TireSmokeColor { get; set; }

        byte WheelType { get; }
        
        byte WheelVariation { get; }

        bool CustomTires { get; set; }

        byte SpecialDarkness { get; set; }

        /// <summary>
        /// Get or set number plate index of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint NumberPlateIndex { get; set; }

        /// <summary>
        /// Get or set number plate text of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string NumberPlateText { get; set; }

        byte WindowTint { get; set; }

        byte DirtLevel { get; set; }

        Rgba NeonColor { get; set; }

        byte GetMod(byte category);

        byte GetModsCount(byte category);

        bool SetMod(byte category, byte id);

        byte GetModKitsCount();

        void SetWheels(byte type, byte variation);

        bool IsExtraOn(byte extraId);

        void ToggleExtra(byte extraId, bool state);

        void GetNeonActive(ref bool left, ref bool right, ref bool top, ref bool back);

        void SetNeonActive(bool left, bool right, bool top, bool back);
    }
}