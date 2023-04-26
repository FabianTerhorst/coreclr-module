using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.CApi.ClientEvents
{
    public delegate void TickModuleDelegate();

    public delegate void ClientEventModuleDelegate(string name, IntPtr args, ulong size);
    public delegate void ServerEventModuleDelegate(string name, IntPtr args, ulong size);
    public delegate void WebViewEventModuleDelegate(IntPtr webView, string name, IntPtr args, ulong size);
    public delegate void RmlEventModuleDelegate(IntPtr rmlElement, string name, IntPtr args, ulong size);
    public delegate void WebSocketEventModuleDelegate(IntPtr webSocket, string name, IntPtr args, ulong size);
    public delegate void ConsoleCommandModuleDelegate(string name, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] string[] args, int argsSize);

    public delegate void PlayerSpawnModuleDelegate();
    public delegate void PlayerDisconnectModuleDelegate();
    public delegate void PlayerEnterVehicleModuleDelegate(IntPtr pointer, byte seat);
    public delegate void PlayerLeaveVehicleModuleDelegate(IntPtr pointer, byte seat);
    public delegate void PlayerChangeVehicleSeatModuleDelegate(IntPtr pointer, byte oldSeat, byte newSeat);
    public delegate void PlayerChangeAnimationModuleDelegate(IntPtr pointer, uint oldDict, uint newDict, uint oldName, uint newName);
    public delegate void PlayerChangeInteriorModuleDelegate(IntPtr pointer, uint oldIntLoc, uint newIntLoc);
    public delegate void PlayerWeaponShootModuleDelegate(uint weapon, ushort totalAmmo, ushort ammoInClip);
    public delegate void PlayerWeaponChangeModuleDelegate(uint oldWeapon, uint newWeapon);

    public delegate void GameEntityCreateModuleDelegate(IntPtr pointer, byte type);
    public delegate void GameEntityDestroyModuleDelegate(IntPtr pointer, byte type);

    public delegate void AnyResourceErrorModuleDelegate(string name);
    public delegate void AnyResourceStartModuleDelegate(string name);
    public delegate void AnyResourceStopModuleDelegate(string name);

    public delegate void KeyDownModuleDelegate(uint key);
    public delegate void KeyUpModuleDelegate(uint key);

    public delegate void ScreenshotResultModuleDelegate(IntPtr strPtr);
    public delegate void HttpResponseModuleDelegate(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize);

    public delegate void ConnectionCompleteModuleDelegate();

    public delegate void GlobalMetaChangeModuleDelegate(string key, IntPtr value, IntPtr oldValue);
    public delegate void GlobalSyncedMetaChangeModuleDelegate(string key, IntPtr value, IntPtr oldValue);

    public delegate void LocalMetaChangeModuleDelegate(string key, IntPtr value, IntPtr oldValue);
    public delegate void StreamSyncedMetaChangeModuleDelegate(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldValue);
    public delegate void SyncedMetaChangeModuleDelegate(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldValue);
    public delegate void MetaChangeModuleDelegate(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldValue);

    public delegate void TaskChangeModuleDelegate(int oldTask, int newTask);

    public delegate void WindowFocusChangeModuleDelegate(byte state);
    public delegate void WindowResolutionChangeModuleDelegate(Vector2 oldResolution, Vector2 newResolution);

    public delegate void WorldObjectPositionChangeModuleDelegate(IntPtr target, BaseObjectType type, Position oldPosition);
    public delegate void WorldObjectStreamInModuleDelegate(IntPtr target, BaseObjectType type);
    public delegate void WorldObjectStreamOutModuleDelegate(IntPtr target, BaseObjectType type);


    public delegate void NetOwnerChangeModuleDelegate(IntPtr target, BaseObjectType type, IntPtr newOwner, IntPtr oldOwner);

    public delegate void DiscordOAuth2TokenResultModuleDelegate(bool success, string token);

    public delegate void WeaponDamageModuleDelegate(IntPtr eventPointer, IntPtr entityPointer,
        BaseObjectType entityType, uint weapon, ushort damage, Position shotOffset, BodyPart bodyPart);

    public delegate void CreateBaseObjectModuleDelegate(IntPtr baseObject, BaseObjectType type, uint id);

    public delegate void RemoveBaseObjectModuleDelegate(IntPtr baseObject, BaseObjectType type);

    public delegate void ColShapeModuleDelegate(IntPtr colShapePointer, IntPtr targetEntityPointer, BaseObjectType entityType,
        bool state);
    public delegate void CheckpointModuleDelegate(IntPtr colShapePointer, IntPtr targetEntityPointer, BaseObjectType entityType,
        bool state);
}