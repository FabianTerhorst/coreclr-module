namespace AltV.Net.Data;

public record WeaponDamageResponse(bool notCancel, uint? Damage) {
    public static implicit operator WeaponDamageResponse(bool val) => new WeaponDamageResponse(val, null);
    public static implicit operator WeaponDamageResponse(uint val) => new WeaponDamageResponse(true, val);
};