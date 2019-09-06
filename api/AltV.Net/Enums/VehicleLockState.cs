namespace AltV.Net.Enums
{
    public enum VehicleLockState : byte
    {
        None = 0,
        Unlocked = 1,
        Locked = 2,
        LockoutPlayerOnly = 3,
        LockPlayerInside = 4,
        InitiallyLocked = 5,
        ForceDoorsShut = 6,
        LockedCanBeDamaged = 7
    }
}