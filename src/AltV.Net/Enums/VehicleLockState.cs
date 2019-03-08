namespace AltV.Net.Enums
{
    public enum VehicleLockState : byte
    {
        CARLOCK_NONE = 0,
        CARLOCK_UNLOCKED = 1,
        CARLOCK_LOCKOUT_FOR_PLAYER_ONLY = 2,
        CARLOCK_LOCKOUT_PLAYER_ONLY = 3,
        CARLOCK_LOCKED_PLAYER_INSIDE = 4,
        CARLOCK_LOCKED_INITIALLY = 5,
        CARLOCK_FORCE_SHUT_DOORS = 6,
        CARLOCK_LOCKED_BUT_CAN_BE_DAMAGED = 7
    }
}