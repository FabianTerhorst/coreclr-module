// ReSharper disable InconsistentNaming
using AltV.Net.Data;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.CApi.Libraries
{
    public unsafe interface ISharedLibrary
    {
        public bool Outdated { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Audio_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> BaseObject_DestructCache { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> BaseObject_TryCache { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Blip_Fade { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsFriendly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsHighDetail { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsMissionCreator { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsShortRange { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetBright { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetCrewIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, short> Blip_GetDisplay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFlashes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFlashesAlternate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetFlashInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetFlashTimer { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFriendIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Blip_GetGxtName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetHeadingIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Blip_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Blip_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetNumber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetOutlineIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetPulse { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Blip_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetRoute { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Blip_GetRouteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, void> Blip_GetScaleXY { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Blip_GetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetShowCone { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetShrinked { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetSprite { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetTickVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Blip_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsGlobal { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsFriendly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsHighDetail { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsMissionCreator { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsShortRange { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetBright { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetCrewIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, short, void> Blip_SetDisplay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFlashes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFlashesAlternate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetFlashInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetFlashTimer { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFriendIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Blip_SetGxtName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetHeadingIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Blip_SetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetNumber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetOutlineIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetPulse { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Blip_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetRoute { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Blip_SetRouteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, void> Blip_SetScaleXY { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Blip_SetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetShowCone { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetShrinked { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetSprite { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetTickVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_GetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Checkpoint_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Checkpoint_GetColShape { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Checkpoint_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Checkpoint_GetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Checkpoint_GetStreamingDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Checkpoint_SetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Checkpoint_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Checkpoint_SetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Checkpoint_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> ColShape_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> ColShape_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte> ColShape_IsEntityIdIn { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> ColShape_IsEntityIn { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, byte> ColShape_IsPointIn { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Config_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, uint*, nint> Core_CreateColShapeCircle { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, uint*, nint> Core_CreateColShapeCube { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, uint*, nint> Core_CreateColShapeCylinder { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, Vector2[], int, uint*, nint> Core_CreateColShapePolygon { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, uint*, nint> Core_CreateColShapeRectangle { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, uint*, nint> Core_CreateColShapeSphere { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<nint, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, Vector3, uint, nint[], nint[], ulong, uint*, nint> Core_CreateVirtualEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint*, nint> Core_CreateVirtualEntityGroup { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint> Core_FileRead { get; }
        public delegate* unmanaged[Cdecl]<nint, uint*, nint> Core_GetAllResources { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, uint, nint> Core_GetBaseObjectByID { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetBlips { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetBranch { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetCheckpoints { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetColShapes { get; }
        public delegate* unmanaged[Cdecl]<nint> Core_GetCoreInstance { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, nint> Core_GetEntityById { get; }
        public delegate* unmanaged[Cdecl]<byte> Core_GetEventEnumSize { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetMarkers { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetNetworkObjects { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetPeds { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetPlayers { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetVehicles { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetVersion { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetVirtualEntities { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetVirtualEntityGroups { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogError { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogWarning { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Core_ToggleEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerLocalEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Entity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Entity_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Entity_GetNetOwnerID { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Entity_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte> Entity_GetTypeByID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> Entity_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Event_Cancel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Event_WasCancelled { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeBlipArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCharArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCheckpointArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeMValueConstArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeObjectArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreePedArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreePlayerArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeResourceArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeString { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> FreeStringArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeUInt32Array { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeUInt8Array { get; }
        public delegate* unmanaged[Cdecl]<UIntArray*, void> FreeUIntArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeVehicleArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeVirtualEntityArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeVirtualEntityGroupArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeVoidPointerArray { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> FreeWeaponTArray { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetBranchStatic { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetCApiVersion { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetSDKVersion { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetVersionStatic { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> HttpClient_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, MValueFunctionCallback, nint> Invoker_Create { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Invoker_Destroy { get; }
        public delegate* unmanaged[Cdecl]<byte> IsDebugStatic { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPed_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPed_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> LocalPed_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPed_GetStreamingDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPed_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> LocalPed_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> LocalPed_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> LocalPed_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Marker_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Marker_GetDirection { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Marker_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Marker_GetMarkerType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Marker_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Marker_GetScale { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Marker_GetStreamingDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Marker_GetTarget { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Marker_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Marker_IsFaceCamera { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Marker_IsGlobal { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Marker_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Marker_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Marker_SetDirection { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Marker_SetFaceCamera { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Marker_SetMarkerType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> Marker_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Marker_SetScale { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Marker_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> NetworkObject_GetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> NetworkObject_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> NetworkObject_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> NetworkObject_GetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> NetworkObject_GetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Object_ActivatePhysics { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, Vector3, Rotation, byte, byte, byte, void> Object_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, short, Vector3, Rotation, byte, byte, byte, void> Object_AttachToEntity_ScriptId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_GetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Object_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Object_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Object_GetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Object_GetStreamingDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_GetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_HasGravity { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsCollisionEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsDynamic { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Object_PlaceOnGroundProperly { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Object_ResetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Object_SetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetPositionFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Object_ToggleCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_ToggleGravity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Ped_GetArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Ped_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Ped_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Ped_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Ped_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Ped_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetAimPos { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentAnimationDict { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentAnimationName { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, uint*, void> Player_GetCurrentWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Player_GetEntityAimingAt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetEntityAimOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetForwardSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Player_GetHeadRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMoveSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSeat { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetStrafeSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetVehicleID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsAiming { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsDead { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsEnteringVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsFlashlightActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInCover { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInMelee { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInRagdoll { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsJumping { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsLeavingVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsOnLadder { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsReloading { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsShooting { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsSpawned { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetConfig { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetCSharpImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, void> Resource_GetDependants { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Resource_GetDependantsSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, void> Resource_GetDependencies { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Resource_GetDependenciesSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Resource_GetExport { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], void> Resource_GetExports { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Resource_GetExportsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Resource_IsStarted { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void> Resource_SetExport { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], nint[], int, void> Resource_SetExports { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> RmlDocument_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> TextLabel_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> TextLabel_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> TextLabel_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, float> TextLabel_GetScale { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> TextLabel_GetTarget { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> TextLabel_GetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> TextLabel_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> TextLabel_IsGlobal { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> TextLabel_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> TextLabel_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> TextLabel_SetScale { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> TextLabel_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Vehicle_GetPetrolTankHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> VirtualEntity_GetGroup { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntity_GetStreamingDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> VirtualEntity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> VirtualEntity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VirtualEntity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VirtualEntity_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> VirtualEntity_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> VirtualEntityGroup_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntityGroup_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntityGroup_GetStreamingRangeLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VoiceChannel_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> WebSocketClient_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> WebView_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WorldObject_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, int> WorldObject_GetDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> WorldObject_GetPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> WorldObject_SetPosition { get; }
    }

    public unsafe class SharedLibrary : ISharedLibrary
    {
        public readonly uint Methods = 1676;
        public delegate* unmanaged[Cdecl]<nint, uint> Audio_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> BaseObject_DestructCache { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> BaseObject_TryCache { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Blip_Fade { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsFriendly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsHighDetail { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsMissionCreator { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsShortRange { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetBright { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetCrewIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, short> Blip_GetDisplay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFlashes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFlashesAlternate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetFlashInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetFlashTimer { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFriendIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Blip_GetGxtName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetHeadingIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Blip_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Blip_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetNumber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetOutlineIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetPulse { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Blip_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetRoute { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Blip_GetRouteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, void> Blip_GetScaleXY { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Blip_GetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetShowCone { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetShrinked { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetSprite { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetTickVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Blip_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsGlobal { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsFriendly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsHighDetail { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsMissionCreator { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsShortRange { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetBright { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetCrewIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, short, void> Blip_SetDisplay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFlashes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFlashesAlternate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetFlashInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetFlashTimer { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFriendIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Blip_SetGxtName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetHeadingIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Blip_SetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetNumber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetOutlineIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetPulse { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Blip_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetRoute { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Blip_SetRouteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, void> Blip_SetScaleXY { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Blip_SetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetShowCone { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetShrinked { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetSprite { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetTickVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_GetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Checkpoint_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Checkpoint_GetColShape { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Checkpoint_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Checkpoint_GetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Checkpoint_GetStreamingDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Checkpoint_SetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Checkpoint_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Checkpoint_SetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Checkpoint_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> ColShape_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> ColShape_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte> ColShape_IsEntityIdIn { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> ColShape_IsEntityIn { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, byte> ColShape_IsPointIn { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Config_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, uint*, nint> Core_CreateColShapeCircle { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, uint*, nint> Core_CreateColShapeCube { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, uint*, nint> Core_CreateColShapeCylinder { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, Vector2[], int, uint*, nint> Core_CreateColShapePolygon { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, uint*, nint> Core_CreateColShapeRectangle { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, uint*, nint> Core_CreateColShapeSphere { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<nint, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, Vector3, uint, nint[], nint[], ulong, uint*, nint> Core_CreateVirtualEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint*, nint> Core_CreateVirtualEntityGroup { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint> Core_FileRead { get; }
        public delegate* unmanaged[Cdecl]<nint, uint*, nint> Core_GetAllResources { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, uint, nint> Core_GetBaseObjectByID { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetBlips { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetBranch { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetCheckpoints { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetColShapes { get; }
        public delegate* unmanaged[Cdecl]<nint> Core_GetCoreInstance { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, nint> Core_GetEntityById { get; }
        public delegate* unmanaged[Cdecl]<byte> Core_GetEventEnumSize { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetMarkers { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetNetworkObjects { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetPeds { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetPlayers { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetVehicles { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetVersion { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetVirtualEntities { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetVirtualEntityGroups { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogError { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogWarning { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Core_ToggleEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerLocalEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Entity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Entity_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Entity_GetNetOwnerID { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Entity_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte> Entity_GetTypeByID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> Entity_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Event_Cancel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Event_WasCancelled { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeBlipArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCharArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCheckpointArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeMValueConstArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeObjectArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreePedArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreePlayerArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeResourceArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeString { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> FreeStringArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeUInt32Array { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeUInt8Array { get; }
        public delegate* unmanaged[Cdecl]<UIntArray*, void> FreeUIntArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeVehicleArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeVirtualEntityArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeVirtualEntityGroupArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeVoidPointerArray { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> FreeWeaponTArray { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetBranchStatic { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetCApiVersion { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetSDKVersion { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetVersionStatic { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> HttpClient_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, MValueFunctionCallback, nint> Invoker_Create { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Invoker_Destroy { get; }
        public delegate* unmanaged[Cdecl]<byte> IsDebugStatic { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPed_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPed_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> LocalPed_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPed_GetStreamingDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPed_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> LocalPed_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> LocalPed_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> LocalPed_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Marker_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Marker_GetDirection { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Marker_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Marker_GetMarkerType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Marker_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Marker_GetScale { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Marker_GetStreamingDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Marker_GetTarget { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Marker_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Marker_IsFaceCamera { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Marker_IsGlobal { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Marker_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Marker_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Marker_SetDirection { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Marker_SetFaceCamera { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Marker_SetMarkerType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> Marker_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Marker_SetScale { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Marker_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> NetworkObject_GetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> NetworkObject_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> NetworkObject_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> NetworkObject_GetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> NetworkObject_GetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Object_ActivatePhysics { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, Vector3, Rotation, byte, byte, byte, void> Object_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, short, Vector3, Rotation, byte, byte, byte, void> Object_AttachToEntity_ScriptId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_GetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Object_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Object_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Object_GetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Object_GetStreamingDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_GetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_HasGravity { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsCollisionEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsDynamic { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Object_PlaceOnGroundProperly { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Object_ResetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Object_SetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetPositionFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Object_ToggleCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_ToggleGravity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Ped_GetArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Ped_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Ped_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Ped_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Ped_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Ped_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetAimPos { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentAnimationDict { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentAnimationName { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, uint*, void> Player_GetCurrentWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Player_GetEntityAimingAt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetEntityAimOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetForwardSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Player_GetHeadRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMoveSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSeat { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetStrafeSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetVehicleID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsAiming { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsDead { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsEnteringVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsFlashlightActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInCover { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInMelee { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInRagdoll { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsJumping { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsLeavingVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsOnLadder { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsReloading { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsShooting { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsSpawned { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetConfig { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetCSharpImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, void> Resource_GetDependants { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Resource_GetDependantsSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, void> Resource_GetDependencies { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Resource_GetDependenciesSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Resource_GetExport { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], void> Resource_GetExports { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Resource_GetExportsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Resource_IsStarted { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void> Resource_SetExport { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], nint[], int, void> Resource_SetExports { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> RmlDocument_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> TextLabel_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> TextLabel_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> TextLabel_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, float> TextLabel_GetScale { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> TextLabel_GetTarget { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> TextLabel_GetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> TextLabel_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> TextLabel_IsGlobal { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> TextLabel_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> TextLabel_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> TextLabel_SetScale { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> TextLabel_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Vehicle_GetPetrolTankHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> VirtualEntity_GetGroup { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntity_GetStreamingDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> VirtualEntity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> VirtualEntity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VirtualEntity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VirtualEntity_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> VirtualEntity_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> VirtualEntityGroup_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntityGroup_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntityGroup_GetStreamingRangeLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VoiceChannel_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> WebSocketClient_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> WebView_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WorldObject_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, int> WorldObject_GetDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> WorldObject_GetPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> WorldObject_SetPosition { get; }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Audio_GetIDDelegate(nint _audio);
        private static uint Audio_GetIDFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_GetID", "Audio_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void BaseObject_DeleteMetaDataDelegate(nint _baseObject, nint _key);
        private static void BaseObject_DeleteMetaDataFallback(nint _baseObject, nint _key) => throw new Exceptions.OutdatedSdkException("BaseObject_DeleteMetaData", "BaseObject_DeleteMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void BaseObject_DestructCacheDelegate(nint _baseObject);
        private static void BaseObject_DestructCacheFallback(nint _baseObject) => throw new Exceptions.OutdatedSdkException("BaseObject_DestructCache", "BaseObject_DestructCache SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint BaseObject_GetMetaDataDelegate(nint _baseObject, nint _key);
        private static nint BaseObject_GetMetaDataFallback(nint _baseObject, nint _key) => throw new Exceptions.OutdatedSdkException("BaseObject_GetMetaData", "BaseObject_GetMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint BaseObject_GetSyncedMetaDataDelegate(nint _baseObject, nint _key);
        private static nint BaseObject_GetSyncedMetaDataFallback(nint _baseObject, nint _key) => throw new Exceptions.OutdatedSdkException("BaseObject_GetSyncedMetaData", "BaseObject_GetSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte BaseObject_GetTypeDelegate(nint _baseObject);
        private static byte BaseObject_GetTypeFallback(nint _baseObject) => throw new Exceptions.OutdatedSdkException("BaseObject_GetType", "BaseObject_GetType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte BaseObject_HasMetaDataDelegate(nint _baseObject, nint _key);
        private static byte BaseObject_HasMetaDataFallback(nint _baseObject, nint _key) => throw new Exceptions.OutdatedSdkException("BaseObject_HasMetaData", "BaseObject_HasMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte BaseObject_HasSyncedMetaDataDelegate(nint _baseObject, nint _key);
        private static byte BaseObject_HasSyncedMetaDataFallback(nint _baseObject, nint _key) => throw new Exceptions.OutdatedSdkException("BaseObject_HasSyncedMetaData", "BaseObject_HasSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void BaseObject_SetMetaDataDelegate(nint _baseObject, nint _key, nint _value);
        private static void BaseObject_SetMetaDataFallback(nint _baseObject, nint _key, nint _value) => throw new Exceptions.OutdatedSdkException("BaseObject_SetMetaData", "BaseObject_SetMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint BaseObject_TryCacheDelegate(nint _baseObject);
        private static nint BaseObject_TryCacheFallback(nint _baseObject) => throw new Exceptions.OutdatedSdkException("BaseObject_TryCache", "BaseObject_TryCache SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_FadeDelegate(nint _blip, uint _opacity, uint _duration);
        private static void Blip_FadeFallback(nint _blip, uint _opacity, uint _duration) => throw new Exceptions.OutdatedSdkException("Blip_Fade", "Blip_Fade SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetAlphaDelegate(nint _blip);
        private static byte Blip_GetAlphaFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetAlpha", "Blip_GetAlpha SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetAsFriendlyDelegate(nint _blip);
        private static byte Blip_GetAsFriendlyFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetAsFriendly", "Blip_GetAsFriendly SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetAsHighDetailDelegate(nint _blip);
        private static byte Blip_GetAsHighDetailFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetAsHighDetail", "Blip_GetAsHighDetail SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetAsMissionCreatorDelegate(nint _blip);
        private static byte Blip_GetAsMissionCreatorFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetAsMissionCreator", "Blip_GetAsMissionCreator SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetAsShortRangeDelegate(nint _blip);
        private static byte Blip_GetAsShortRangeFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetAsShortRange", "Blip_GetAsShortRange SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetBrightDelegate(nint _blip);
        private static byte Blip_GetBrightFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetBright", "Blip_GetBright SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Blip_GetCategoryDelegate(nint _blip);
        private static ushort Blip_GetCategoryFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetCategory", "Blip_GetCategory SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetColorDelegate(nint _blip);
        private static byte Blip_GetColorFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetColor", "Blip_GetColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetCrewIndicatorVisibleDelegate(nint _blip);
        private static byte Blip_GetCrewIndicatorVisibleFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetCrewIndicatorVisible", "Blip_GetCrewIndicatorVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate short Blip_GetDisplayDelegate(nint _blip);
        private static short Blip_GetDisplayFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetDisplay", "Blip_GetDisplay SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetFlashesDelegate(nint _blip);
        private static byte Blip_GetFlashesFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetFlashes", "Blip_GetFlashes SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetFlashesAlternateDelegate(nint _blip);
        private static byte Blip_GetFlashesAlternateFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetFlashesAlternate", "Blip_GetFlashesAlternate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Blip_GetFlashIntervalDelegate(nint _blip);
        private static ushort Blip_GetFlashIntervalFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetFlashInterval", "Blip_GetFlashInterval SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Blip_GetFlashTimerDelegate(nint _blip);
        private static ushort Blip_GetFlashTimerFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetFlashTimer", "Blip_GetFlashTimer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetFriendIndicatorVisibleDelegate(nint _blip);
        private static byte Blip_GetFriendIndicatorVisibleFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetFriendIndicatorVisible", "Blip_GetFriendIndicatorVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Blip_GetGxtNameDelegate(nint _blip, int* _size);
        private static nint Blip_GetGxtNameFallback(nint _blip, int* _size) => throw new Exceptions.OutdatedSdkException("Blip_GetGxtName", "Blip_GetGxtName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetHeadingIndicatorVisibleDelegate(nint _blip);
        private static byte Blip_GetHeadingIndicatorVisibleFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetHeadingIndicatorVisible", "Blip_GetHeadingIndicatorVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Blip_GetIDDelegate(nint _blip);
        private static uint Blip_GetIDFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetID", "Blip_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Blip_GetNameDelegate(nint _blip, int* _size);
        private static nint Blip_GetNameFallback(nint _blip, int* _size) => throw new Exceptions.OutdatedSdkException("Blip_GetName", "Blip_GetName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Blip_GetNumberDelegate(nint _blip);
        private static ushort Blip_GetNumberFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetNumber", "Blip_GetNumber SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetOutlineIndicatorVisibleDelegate(nint _blip);
        private static byte Blip_GetOutlineIndicatorVisibleFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetOutlineIndicatorVisible", "Blip_GetOutlineIndicatorVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Blip_GetPriorityDelegate(nint _blip);
        private static ushort Blip_GetPriorityFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetPriority", "Blip_GetPriority SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetPulseDelegate(nint _blip);
        private static byte Blip_GetPulseFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetPulse", "Blip_GetPulse SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Blip_GetRotationDelegate(nint _blip);
        private static float Blip_GetRotationFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetRotation", "Blip_GetRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetRouteDelegate(nint _blip);
        private static byte Blip_GetRouteFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetRoute", "Blip_GetRoute SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_GetRouteColorDelegate(nint _blip, Rgba* _color);
        private static void Blip_GetRouteColorFallback(nint _blip, Rgba* _color) => throw new Exceptions.OutdatedSdkException("Blip_GetRouteColor", "Blip_GetRouteColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_GetScaleXYDelegate(nint _blip, Vector2* _scale);
        private static void Blip_GetScaleXYFallback(nint _blip, Vector2* _scale) => throw new Exceptions.OutdatedSdkException("Blip_GetScaleXY", "Blip_GetScaleXY SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_GetSecondaryColorDelegate(nint _blip, Rgba* _color);
        private static void Blip_GetSecondaryColorFallback(nint _blip, Rgba* _color) => throw new Exceptions.OutdatedSdkException("Blip_GetSecondaryColor", "Blip_GetSecondaryColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetShowConeDelegate(nint _blip);
        private static byte Blip_GetShowConeFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetShowCone", "Blip_GetShowCone SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetShrinkedDelegate(nint _blip);
        private static byte Blip_GetShrinkedFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetShrinked", "Blip_GetShrinked SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Blip_GetSpriteDelegate(nint _blip);
        private static ushort Blip_GetSpriteFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetSprite", "Blip_GetSprite SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetTickVisibleDelegate(nint _blip);
        private static byte Blip_GetTickVisibleFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetTickVisible", "Blip_GetTickVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_GetTypeDelegate(nint _blip);
        private static byte Blip_GetTypeFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetType", "Blip_GetType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Blip_GetWorldObjectDelegate(nint _blip);
        private static nint Blip_GetWorldObjectFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetWorldObject", "Blip_GetWorldObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_IsGlobalDelegate(nint _blip);
        private static byte Blip_IsGlobalFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_IsGlobal", "Blip_IsGlobal SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetAlphaDelegate(nint _blip, byte _alpha);
        private static void Blip_SetAlphaFallback(nint _blip, byte _alpha) => throw new Exceptions.OutdatedSdkException("Blip_SetAlpha", "Blip_SetAlpha SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetAsFriendlyDelegate(nint _blip, byte _friendly);
        private static void Blip_SetAsFriendlyFallback(nint _blip, byte _friendly) => throw new Exceptions.OutdatedSdkException("Blip_SetAsFriendly", "Blip_SetAsFriendly SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetAsHighDetailDelegate(nint _blip, byte _state);
        private static void Blip_SetAsHighDetailFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetAsHighDetail", "Blip_SetAsHighDetail SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetAsMissionCreatorDelegate(nint _blip, byte _state);
        private static void Blip_SetAsMissionCreatorFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetAsMissionCreator", "Blip_SetAsMissionCreator SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetAsShortRangeDelegate(nint _blip, byte _state);
        private static void Blip_SetAsShortRangeFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetAsShortRange", "Blip_SetAsShortRange SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetBrightDelegate(nint _blip, byte _state);
        private static void Blip_SetBrightFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetBright", "Blip_SetBright SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetCategoryDelegate(nint _blip, ushort _category);
        private static void Blip_SetCategoryFallback(nint _blip, ushort _category) => throw new Exceptions.OutdatedSdkException("Blip_SetCategory", "Blip_SetCategory SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetColorDelegate(nint _blip, byte _color);
        private static void Blip_SetColorFallback(nint _blip, byte _color) => throw new Exceptions.OutdatedSdkException("Blip_SetColor", "Blip_SetColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetCrewIndicatorVisibleDelegate(nint _blip, byte _state);
        private static void Blip_SetCrewIndicatorVisibleFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetCrewIndicatorVisible", "Blip_SetCrewIndicatorVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetDisplayDelegate(nint _blip, short _display);
        private static void Blip_SetDisplayFallback(nint _blip, short _display) => throw new Exceptions.OutdatedSdkException("Blip_SetDisplay", "Blip_SetDisplay SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetFlashesDelegate(nint _blip, byte _state);
        private static void Blip_SetFlashesFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetFlashes", "Blip_SetFlashes SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetFlashesAlternateDelegate(nint _blip, byte _state);
        private static void Blip_SetFlashesAlternateFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetFlashesAlternate", "Blip_SetFlashesAlternate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetFlashIntervalDelegate(nint _blip, ushort _interval);
        private static void Blip_SetFlashIntervalFallback(nint _blip, ushort _interval) => throw new Exceptions.OutdatedSdkException("Blip_SetFlashInterval", "Blip_SetFlashInterval SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetFlashTimerDelegate(nint _blip, ushort _timer);
        private static void Blip_SetFlashTimerFallback(nint _blip, ushort _timer) => throw new Exceptions.OutdatedSdkException("Blip_SetFlashTimer", "Blip_SetFlashTimer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetFriendIndicatorVisibleDelegate(nint _blip, byte _state);
        private static void Blip_SetFriendIndicatorVisibleFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetFriendIndicatorVisible", "Blip_SetFriendIndicatorVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetGxtNameDelegate(nint _blip, nint _name);
        private static void Blip_SetGxtNameFallback(nint _blip, nint _name) => throw new Exceptions.OutdatedSdkException("Blip_SetGxtName", "Blip_SetGxtName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetHeadingIndicatorVisibleDelegate(nint _blip, byte _state);
        private static void Blip_SetHeadingIndicatorVisibleFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetHeadingIndicatorVisible", "Blip_SetHeadingIndicatorVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetNameDelegate(nint _blip, nint _name);
        private static void Blip_SetNameFallback(nint _blip, nint _name) => throw new Exceptions.OutdatedSdkException("Blip_SetName", "Blip_SetName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetNumberDelegate(nint _blip, ushort _number);
        private static void Blip_SetNumberFallback(nint _blip, ushort _number) => throw new Exceptions.OutdatedSdkException("Blip_SetNumber", "Blip_SetNumber SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetOutlineIndicatorVisibleDelegate(nint _blip, byte _state);
        private static void Blip_SetOutlineIndicatorVisibleFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetOutlineIndicatorVisible", "Blip_SetOutlineIndicatorVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetPriorityDelegate(nint _blip, ushort _priority);
        private static void Blip_SetPriorityFallback(nint _blip, ushort _priority) => throw new Exceptions.OutdatedSdkException("Blip_SetPriority", "Blip_SetPriority SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetPulseDelegate(nint _blip, byte _state);
        private static void Blip_SetPulseFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetPulse", "Blip_SetPulse SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetRotationDelegate(nint _blip, float _rotation);
        private static void Blip_SetRotationFallback(nint _blip, float _rotation) => throw new Exceptions.OutdatedSdkException("Blip_SetRotation", "Blip_SetRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetRouteDelegate(nint _blip, byte _state);
        private static void Blip_SetRouteFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetRoute", "Blip_SetRoute SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetRouteColorDelegate(nint _blip, Rgba _color);
        private static void Blip_SetRouteColorFallback(nint _blip, Rgba _color) => throw new Exceptions.OutdatedSdkException("Blip_SetRouteColor", "Blip_SetRouteColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetScaleXYDelegate(nint _blip, Vector2 _scale);
        private static void Blip_SetScaleXYFallback(nint _blip, Vector2 _scale) => throw new Exceptions.OutdatedSdkException("Blip_SetScaleXY", "Blip_SetScaleXY SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetSecondaryColorDelegate(nint _blip, Rgba _color);
        private static void Blip_SetSecondaryColorFallback(nint _blip, Rgba _color) => throw new Exceptions.OutdatedSdkException("Blip_SetSecondaryColor", "Blip_SetSecondaryColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetShowConeDelegate(nint _blip, byte _state);
        private static void Blip_SetShowConeFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetShowCone", "Blip_SetShowCone SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetShrinkedDelegate(nint _blip, byte _state);
        private static void Blip_SetShrinkedFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetShrinked", "Blip_SetShrinked SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetSpriteDelegate(nint _blip, ushort _sprite);
        private static void Blip_SetSpriteFallback(nint _blip, ushort _sprite) => throw new Exceptions.OutdatedSdkException("Blip_SetSprite", "Blip_SetSprite SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Blip_SetTickVisibleDelegate(nint _blip, byte _state);
        private static void Blip_SetTickVisibleFallback(nint _blip, byte _state) => throw new Exceptions.OutdatedSdkException("Blip_SetTickVisible", "Blip_SetTickVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Checkpoint_GetCheckpointTypeDelegate(nint _checkpoint);
        private static byte Checkpoint_GetCheckpointTypeFallback(nint _checkpoint) => throw new Exceptions.OutdatedSdkException("Checkpoint_GetCheckpointType", "Checkpoint_GetCheckpointType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Checkpoint_GetColorDelegate(nint _checkpoint, Rgba* _color);
        private static void Checkpoint_GetColorFallback(nint _checkpoint, Rgba* _color) => throw new Exceptions.OutdatedSdkException("Checkpoint_GetColor", "Checkpoint_GetColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Checkpoint_GetColShapeDelegate(nint _checkpoint);
        private static nint Checkpoint_GetColShapeFallback(nint _checkpoint) => throw new Exceptions.OutdatedSdkException("Checkpoint_GetColShape", "Checkpoint_GetColShape SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Checkpoint_GetHeightDelegate(nint _checkpoint);
        private static float Checkpoint_GetHeightFallback(nint _checkpoint) => throw new Exceptions.OutdatedSdkException("Checkpoint_GetHeight", "Checkpoint_GetHeight SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Checkpoint_GetIDDelegate(nint _checkpoint);
        private static uint Checkpoint_GetIDFallback(nint _checkpoint) => throw new Exceptions.OutdatedSdkException("Checkpoint_GetID", "Checkpoint_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Checkpoint_GetNextPositionDelegate(nint _checkpoint, Vector3* _pos);
        private static void Checkpoint_GetNextPositionFallback(nint _checkpoint, Vector3* _pos) => throw new Exceptions.OutdatedSdkException("Checkpoint_GetNextPosition", "Checkpoint_GetNextPosition SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Checkpoint_GetRadiusDelegate(nint _checkpoint);
        private static float Checkpoint_GetRadiusFallback(nint _checkpoint) => throw new Exceptions.OutdatedSdkException("Checkpoint_GetRadius", "Checkpoint_GetRadius SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Checkpoint_GetStreamingDistanceDelegate(nint _checkpoint);
        private static uint Checkpoint_GetStreamingDistanceFallback(nint _checkpoint) => throw new Exceptions.OutdatedSdkException("Checkpoint_GetStreamingDistance", "Checkpoint_GetStreamingDistance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Checkpoint_IsVisibleDelegate(nint _checkpoint);
        private static byte Checkpoint_IsVisibleFallback(nint _checkpoint) => throw new Exceptions.OutdatedSdkException("Checkpoint_IsVisible", "Checkpoint_IsVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Checkpoint_SetCheckpointTypeDelegate(nint _checkpoint, byte _type);
        private static void Checkpoint_SetCheckpointTypeFallback(nint _checkpoint, byte _type) => throw new Exceptions.OutdatedSdkException("Checkpoint_SetCheckpointType", "Checkpoint_SetCheckpointType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Checkpoint_SetColorDelegate(nint _checkpoint, Rgba _color);
        private static void Checkpoint_SetColorFallback(nint _checkpoint, Rgba _color) => throw new Exceptions.OutdatedSdkException("Checkpoint_SetColor", "Checkpoint_SetColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Checkpoint_SetHeightDelegate(nint _checkpoint, float _height);
        private static void Checkpoint_SetHeightFallback(nint _checkpoint, float _height) => throw new Exceptions.OutdatedSdkException("Checkpoint_SetHeight", "Checkpoint_SetHeight SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Checkpoint_SetNextPositionDelegate(nint _checkpoint, Vector3 _pos);
        private static void Checkpoint_SetNextPositionFallback(nint _checkpoint, Vector3 _pos) => throw new Exceptions.OutdatedSdkException("Checkpoint_SetNextPosition", "Checkpoint_SetNextPosition SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Checkpoint_SetRadiusDelegate(nint _checkpoint, float _radius);
        private static void Checkpoint_SetRadiusFallback(nint _checkpoint, float _radius) => throw new Exceptions.OutdatedSdkException("Checkpoint_SetRadius", "Checkpoint_SetRadius SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Checkpoint_SetVisibleDelegate(nint _checkpoint, byte _toggle);
        private static void Checkpoint_SetVisibleFallback(nint _checkpoint, byte _toggle) => throw new Exceptions.OutdatedSdkException("Checkpoint_SetVisible", "Checkpoint_SetVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint ColShape_GetIDDelegate(nint _colShape);
        private static uint ColShape_GetIDFallback(nint _colShape) => throw new Exceptions.OutdatedSdkException("ColShape_GetID", "ColShape_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint ColShape_GetWorldObjectDelegate(nint _colShape);
        private static nint ColShape_GetWorldObjectFallback(nint _colShape) => throw new Exceptions.OutdatedSdkException("ColShape_GetWorldObject", "ColShape_GetWorldObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte ColShape_IsEntityIdInDelegate(nint _colShape, ushort _id);
        private static byte ColShape_IsEntityIdInFallback(nint _colShape, ushort _id) => throw new Exceptions.OutdatedSdkException("ColShape_IsEntityIdIn", "ColShape_IsEntityIdIn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte ColShape_IsEntityInDelegate(nint _colShape, nint _entity);
        private static byte ColShape_IsEntityInFallback(nint _colShape, nint _entity) => throw new Exceptions.OutdatedSdkException("ColShape_IsEntityIn", "ColShape_IsEntityIn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte ColShape_IsPointInDelegate(nint _colShape, Vector3 _point);
        private static byte ColShape_IsPointInFallback(nint _colShape, Vector3 _point) => throw new Exceptions.OutdatedSdkException("ColShape_IsPointIn", "ColShape_IsPointIn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Config_DeleteDelegate(nint _node);
        private static void Config_DeleteFallback(nint _node) => throw new Exceptions.OutdatedSdkException("Config_Delete", "Config_Delete SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateColShapeCircleDelegate(nint _server, Vector3 _pos, float _radius, uint* _id);
        private static nint Core_CreateColShapeCircleFallback(nint _server, Vector3 _pos, float _radius, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateColShapeCircle", "Core_CreateColShapeCircle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateColShapeCubeDelegate(nint _server, Vector3 _pos, Vector3 _pos2, uint* _id);
        private static nint Core_CreateColShapeCubeFallback(nint _server, Vector3 _pos, Vector3 _pos2, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateColShapeCube", "Core_CreateColShapeCube SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateColShapeCylinderDelegate(nint _server, Vector3 _pos, float _radius, float _height, uint* _id);
        private static nint Core_CreateColShapeCylinderFallback(nint _server, Vector3 _pos, float _radius, float _height, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateColShapeCylinder", "Core_CreateColShapeCylinder SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateColShapePolygonDelegate(nint _server, float _minZ, float _maxZ, Vector2[] points, int _pointSize, uint* _id);
        private static nint Core_CreateColShapePolygonFallback(nint _server, float _minZ, float _maxZ, Vector2[] points, int _pointSize, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateColShapePolygon", "Core_CreateColShapePolygon SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateColShapeRectangleDelegate(nint _server, float _x1, float _y1, float _x2, float _y2, float _z, uint* _id);
        private static nint Core_CreateColShapeRectangleFallback(nint _server, float _x1, float _y1, float _x2, float _y2, float _z, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateColShapeRectangle", "Core_CreateColShapeRectangle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateColShapeSphereDelegate(nint _server, Vector3 _pos, float _radius, uint* _id);
        private static nint Core_CreateColShapeSphereFallback(nint _server, Vector3 _pos, float _radius, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateColShapeSphere", "Core_CreateColShapeSphere SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueBaseObjectDelegate(nint _core, nint _value);
        private static nint Core_CreateMValueBaseObjectFallback(nint _core, nint _value) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueBaseObject", "Core_CreateMValueBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueBoolDelegate(nint _core, byte _value);
        private static nint Core_CreateMValueBoolFallback(nint _core, byte _value) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueBool", "Core_CreateMValueBool SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueByteArrayDelegate(nint _core, ulong _size, nint _data);
        private static nint Core_CreateMValueByteArrayFallback(nint _core, ulong _size, nint _data) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueByteArray", "Core_CreateMValueByteArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueDictDelegate(nint _core, nint[] keys, nint[] val, ulong _size);
        private static nint Core_CreateMValueDictFallback(nint _core, nint[] keys, nint[] val, ulong _size) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueDict", "Core_CreateMValueDict SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueDoubleDelegate(nint _core, double _value);
        private static nint Core_CreateMValueDoubleFallback(nint _core, double _value) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueDouble", "Core_CreateMValueDouble SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueFunctionDelegate(nint _core, nint _value);
        private static nint Core_CreateMValueFunctionFallback(nint _core, nint _value) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueFunction", "Core_CreateMValueFunction SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueIntDelegate(nint _core, long _value);
        private static nint Core_CreateMValueIntFallback(nint _core, long _value) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueInt", "Core_CreateMValueInt SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueListDelegate(nint _core, nint[] val, ulong _size);
        private static nint Core_CreateMValueListFallback(nint _core, nint[] val, ulong _size) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueList", "Core_CreateMValueList SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueNilDelegate(nint _core);
        private static nint Core_CreateMValueNilFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueNil", "Core_CreateMValueNil SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueRgbaDelegate(nint _core, Rgba _value);
        private static nint Core_CreateMValueRgbaFallback(nint _core, Rgba _value) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueRgba", "Core_CreateMValueRgba SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueStringDelegate(nint _core, nint _value);
        private static nint Core_CreateMValueStringFallback(nint _core, nint _value) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueString", "Core_CreateMValueString SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueUIntDelegate(nint _core, ulong _value);
        private static nint Core_CreateMValueUIntFallback(nint _core, ulong _value) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueUInt", "Core_CreateMValueUInt SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueVector2Delegate(nint _core, Vector2 _value);
        private static nint Core_CreateMValueVector2Fallback(nint _core, Vector2 _value) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueVector2", "Core_CreateMValueVector2 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMValueVector3Delegate(nint _core, Vector3 _value);
        private static nint Core_CreateMValueVector3Fallback(nint _core, Vector3 _value) => throw new Exceptions.OutdatedSdkException("Core_CreateMValueVector3", "Core_CreateMValueVector3 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateVirtualEntityDelegate(nint _core, nint _group, Vector3 _position, uint _streamingDistance, nint[] keys, nint[] values, ulong _size, uint* _id);
        private static nint Core_CreateVirtualEntityFallback(nint _core, nint _group, Vector3 _position, uint _streamingDistance, nint[] keys, nint[] values, ulong _size, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateVirtualEntity", "Core_CreateVirtualEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateVirtualEntityGroupDelegate(nint _core, uint _streamingDistance, uint* _id);
        private static nint Core_CreateVirtualEntityGroupFallback(nint _core, uint _streamingDistance, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateVirtualEntityGroup", "Core_CreateVirtualEntityGroup SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_DeleteMetaDataDelegate(nint _core, nint _key);
        private static void Core_DeleteMetaDataFallback(nint _core, nint _key) => throw new Exceptions.OutdatedSdkException("Core_DeleteMetaData", "Core_DeleteMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_DestroyBaseObjectDelegate(nint _server, nint _baseObject);
        private static void Core_DestroyBaseObjectFallback(nint _server, nint _baseObject) => throw new Exceptions.OutdatedSdkException("Core_DestroyBaseObject", "Core_DestroyBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_FileExistsDelegate(nint _server, nint _path);
        private static byte Core_FileExistsFallback(nint _server, nint _path) => throw new Exceptions.OutdatedSdkException("Core_FileExists", "Core_FileExists SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_FileReadDelegate(nint _server, nint _path, int* _size);
        private static nint Core_FileReadFallback(nint _server, nint _path, int* _size) => throw new Exceptions.OutdatedSdkException("Core_FileRead", "Core_FileRead SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetAllResourcesDelegate(nint _core, uint* _size);
        private static nint Core_GetAllResourcesFallback(nint _core, uint* _size) => throw new Exceptions.OutdatedSdkException("Core_GetAllResources", "Core_GetAllResources SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetBaseObjectByIDDelegate(nint _core, byte _type, uint _id);
        private static nint Core_GetBaseObjectByIDFallback(nint _core, byte _type, uint _id) => throw new Exceptions.OutdatedSdkException("Core_GetBaseObjectByID", "Core_GetBaseObjectByID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetBlipsDelegate(nint _core, ulong* _size);
        private static nint Core_GetBlipsFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetBlips", "Core_GetBlips SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetBranchDelegate(nint _core, int* _size);
        private static nint Core_GetBranchFallback(nint _core, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetBranch", "Core_GetBranch SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetCheckpointsDelegate(nint _core, ulong* _size);
        private static nint Core_GetCheckpointsFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetCheckpoints", "Core_GetCheckpoints SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetColShapesDelegate(nint _core, ulong* _size);
        private static nint Core_GetColShapesFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetColShapes", "Core_GetColShapes SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetCoreInstanceDelegate();
        private static nint Core_GetCoreInstanceFallback() => throw new Exceptions.OutdatedSdkException("Core_GetCoreInstance", "Core_GetCoreInstance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetEntityByIdDelegate(nint _core, ushort _id, byte* _type);
        private static nint Core_GetEntityByIdFallback(nint _core, ushort _id, byte* _type) => throw new Exceptions.OutdatedSdkException("Core_GetEntityById", "Core_GetEntityById SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_GetEventEnumSizeDelegate();
        private static byte Core_GetEventEnumSizeFallback() => throw new Exceptions.OutdatedSdkException("Core_GetEventEnumSize", "Core_GetEventEnumSize SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetMarkersDelegate(nint _core, ulong* _size);
        private static nint Core_GetMarkersFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetMarkers", "Core_GetMarkers SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetMetaDataDelegate(nint _core, nint _key);
        private static nint Core_GetMetaDataFallback(nint _core, nint _key) => throw new Exceptions.OutdatedSdkException("Core_GetMetaData", "Core_GetMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetNetworkObjectsDelegate(nint _core, ulong* _size);
        private static nint Core_GetNetworkObjectsFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetNetworkObjects", "Core_GetNetworkObjects SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetPedsDelegate(nint _core, ulong* _size);
        private static nint Core_GetPedsFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetPeds", "Core_GetPeds SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetPlayersDelegate(nint _core, ulong* _size);
        private static nint Core_GetPlayersFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetPlayers", "Core_GetPlayers SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetResourceDelegate(nint _core, nint _resourceName);
        private static nint Core_GetResourceFallback(nint _core, nint _resourceName) => throw new Exceptions.OutdatedSdkException("Core_GetResource", "Core_GetResource SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetSyncedMetaDataDelegate(nint _core, nint _key);
        private static nint Core_GetSyncedMetaDataFallback(nint _core, nint _key) => throw new Exceptions.OutdatedSdkException("Core_GetSyncedMetaData", "Core_GetSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetVehiclesDelegate(nint _core, ulong* _size);
        private static nint Core_GetVehiclesFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetVehicles", "Core_GetVehicles SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetVersionDelegate(nint _core, int* _size);
        private static nint Core_GetVersionFallback(nint _core, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetVersion", "Core_GetVersion SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetVirtualEntitiesDelegate(nint _core, ulong* _size);
        private static nint Core_GetVirtualEntitiesFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetVirtualEntities", "Core_GetVirtualEntities SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetVirtualEntityGroupsDelegate(nint _core, ulong* _size);
        private static nint Core_GetVirtualEntityGroupsFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetVirtualEntityGroups", "Core_GetVirtualEntityGroups SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_HasMetaDataDelegate(nint _core, nint _key);
        private static byte Core_HasMetaDataFallback(nint _core, nint _key) => throw new Exceptions.OutdatedSdkException("Core_HasMetaData", "Core_HasMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_HasSyncedMetaDataDelegate(nint _core, nint _key);
        private static byte Core_HasSyncedMetaDataFallback(nint _core, nint _key) => throw new Exceptions.OutdatedSdkException("Core_HasSyncedMetaData", "Core_HasSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsDebugDelegate(nint _core);
        private static byte Core_IsDebugFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_IsDebug", "Core_IsDebug SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_LogColoredDelegate(nint _server, nint _str);
        private static void Core_LogColoredFallback(nint _server, nint _str) => throw new Exceptions.OutdatedSdkException("Core_LogColored", "Core_LogColored SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_LogDebugDelegate(nint _server, nint _str);
        private static void Core_LogDebugFallback(nint _server, nint _str) => throw new Exceptions.OutdatedSdkException("Core_LogDebug", "Core_LogDebug SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_LogErrorDelegate(nint _server, nint _str);
        private static void Core_LogErrorFallback(nint _server, nint _str) => throw new Exceptions.OutdatedSdkException("Core_LogError", "Core_LogError SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_LogInfoDelegate(nint _server, nint _str);
        private static void Core_LogInfoFallback(nint _server, nint _str) => throw new Exceptions.OutdatedSdkException("Core_LogInfo", "Core_LogInfo SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_LogWarningDelegate(nint _server, nint _str);
        private static void Core_LogWarningFallback(nint _server, nint _str) => throw new Exceptions.OutdatedSdkException("Core_LogWarning", "Core_LogWarning SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetMetaDataDelegate(nint _core, nint _key, nint _val);
        private static void Core_SetMetaDataFallback(nint _core, nint _key, nint _val) => throw new Exceptions.OutdatedSdkException("Core_SetMetaData", "Core_SetMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ToggleEventDelegate(nint _core, byte _event, byte _state);
        private static void Core_ToggleEventFallback(nint _core, byte _event, byte _state) => throw new Exceptions.OutdatedSdkException("Core_ToggleEvent", "Core_ToggleEvent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerLocalEventDelegate(nint _core, nint _event, nint[] args, int _size);
        private static void Core_TriggerLocalEventFallback(nint _core, nint _event, nint[] args, int _size) => throw new Exceptions.OutdatedSdkException("Core_TriggerLocalEvent", "Core_TriggerLocalEvent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Entity_GetIDDelegate(nint _entity);
        private static ushort Entity_GetIDFallback(nint _entity) => throw new Exceptions.OutdatedSdkException("Entity_GetID", "Entity_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Entity_GetModelDelegate(nint _entity);
        private static uint Entity_GetModelFallback(nint _entity) => throw new Exceptions.OutdatedSdkException("Entity_GetModel", "Entity_GetModel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Entity_GetNetOwnerDelegate(nint _entity);
        private static nint Entity_GetNetOwnerFallback(nint _entity) => throw new Exceptions.OutdatedSdkException("Entity_GetNetOwner", "Entity_GetNetOwner SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Entity_GetNetOwnerIDDelegate(nint _entity, ushort* _id);
        private static byte Entity_GetNetOwnerIDFallback(nint _entity, ushort* _id) => throw new Exceptions.OutdatedSdkException("Entity_GetNetOwnerID", "Entity_GetNetOwnerID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_GetRotationDelegate(nint _entity, Rotation* _rot);
        private static void Entity_GetRotationFallback(nint _entity, Rotation* _rot) => throw new Exceptions.OutdatedSdkException("Entity_GetRotation", "Entity_GetRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Entity_GetStreamSyncedMetaDataDelegate(nint _Entity, nint _key);
        private static nint Entity_GetStreamSyncedMetaDataFallback(nint _Entity, nint _key) => throw new Exceptions.OutdatedSdkException("Entity_GetStreamSyncedMetaData", "Entity_GetStreamSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Entity_GetTypeByIDDelegate(nint _core, ushort _id, byte* _type);
        private static byte Entity_GetTypeByIDFallback(nint _core, ushort _id, byte* _type) => throw new Exceptions.OutdatedSdkException("Entity_GetTypeByID", "Entity_GetTypeByID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Entity_GetWorldObjectDelegate(nint _entity);
        private static nint Entity_GetWorldObjectFallback(nint _entity) => throw new Exceptions.OutdatedSdkException("Entity_GetWorldObject", "Entity_GetWorldObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Entity_HasStreamSyncedMetaDataDelegate(nint _Entity, nint _key);
        private static byte Entity_HasStreamSyncedMetaDataFallback(nint _Entity, nint _key) => throw new Exceptions.OutdatedSdkException("Entity_HasStreamSyncedMetaData", "Entity_HasStreamSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_SetRotationDelegate(nint _entity, Rotation _rot);
        private static void Entity_SetRotationFallback(nint _entity, Rotation _rot) => throw new Exceptions.OutdatedSdkException("Entity_SetRotation", "Entity_SetRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_CancelDelegate(nint _event);
        private static void Event_CancelFallback(nint _event) => throw new Exceptions.OutdatedSdkException("Event_Cancel", "Event_Cancel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Event_WasCancelledDelegate(nint _event);
        private static byte Event_WasCancelledFallback(nint _event) => throw new Exceptions.OutdatedSdkException("Event_WasCancelled", "Event_WasCancelled SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeBlipArrayDelegate(nint _blipArray);
        private static void FreeBlipArrayFallback(nint _blipArray) => throw new Exceptions.OutdatedSdkException("FreeBlipArray", "FreeBlipArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeCharArrayDelegate(nint charArray);
        private static void FreeCharArrayFallback(nint charArray) => throw new Exceptions.OutdatedSdkException("FreeCharArray", "FreeCharArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeCheckpointArrayDelegate(nint _checkpointArray);
        private static void FreeCheckpointArrayFallback(nint _checkpointArray) => throw new Exceptions.OutdatedSdkException("FreeCheckpointArray", "FreeCheckpointArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeMValueConstArrayDelegate(nint _mvalueConstArray);
        private static void FreeMValueConstArrayFallback(nint _mvalueConstArray) => throw new Exceptions.OutdatedSdkException("FreeMValueConstArray", "FreeMValueConstArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeObjectArrayDelegate(nint _objectArray);
        private static void FreeObjectArrayFallback(nint _objectArray) => throw new Exceptions.OutdatedSdkException("FreeObjectArray", "FreeObjectArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreePedArrayDelegate(nint _pedArray);
        private static void FreePedArrayFallback(nint _pedArray) => throw new Exceptions.OutdatedSdkException("FreePedArray", "FreePedArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreePlayerArrayDelegate(nint _playerArray);
        private static void FreePlayerArrayFallback(nint _playerArray) => throw new Exceptions.OutdatedSdkException("FreePlayerArray", "FreePlayerArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeResourceArrayDelegate(nint _resourceArray);
        private static void FreeResourceArrayFallback(nint _resourceArray) => throw new Exceptions.OutdatedSdkException("FreeResourceArray", "FreeResourceArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeStringDelegate(nint _string);
        private static void FreeStringFallback(nint _string) => throw new Exceptions.OutdatedSdkException("FreeString", "FreeString SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeStringArrayDelegate(nint _stringArray, uint _size);
        private static void FreeStringArrayFallback(nint _stringArray, uint _size) => throw new Exceptions.OutdatedSdkException("FreeStringArray", "FreeStringArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeUInt32ArrayDelegate(nint _uInt32Array);
        private static void FreeUInt32ArrayFallback(nint _uInt32Array) => throw new Exceptions.OutdatedSdkException("FreeUInt32Array", "FreeUInt32Array SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeUInt8ArrayDelegate(nint _uInt8Array);
        private static void FreeUInt8ArrayFallback(nint _uInt8Array) => throw new Exceptions.OutdatedSdkException("FreeUInt8Array", "FreeUInt8Array SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeUIntArrayDelegate(UIntArray* _array);
        private static void FreeUIntArrayFallback(UIntArray* _array) => throw new Exceptions.OutdatedSdkException("FreeUIntArray", "FreeUIntArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeVehicleArrayDelegate(nint _vehicleArray);
        private static void FreeVehicleArrayFallback(nint _vehicleArray) => throw new Exceptions.OutdatedSdkException("FreeVehicleArray", "FreeVehicleArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeVirtualEntityArrayDelegate(nint _virtualEntityArray);
        private static void FreeVirtualEntityArrayFallback(nint _virtualEntityArray) => throw new Exceptions.OutdatedSdkException("FreeVirtualEntityArray", "FreeVirtualEntityArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeVirtualEntityGroupArrayDelegate(nint _virtualEntityGroupArray);
        private static void FreeVirtualEntityGroupArrayFallback(nint _virtualEntityGroupArray) => throw new Exceptions.OutdatedSdkException("FreeVirtualEntityGroupArray", "FreeVirtualEntityGroupArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeVoidPointerArrayDelegate(nint _voidPointerArray);
        private static void FreeVoidPointerArrayFallback(nint _voidPointerArray) => throw new Exceptions.OutdatedSdkException("FreeVoidPointerArray", "FreeVoidPointerArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeWeaponTArrayDelegate(nint _weaponArray, uint _size);
        private static void FreeWeaponTArrayFallback(nint _weaponArray, uint _size) => throw new Exceptions.OutdatedSdkException("FreeWeaponTArray", "FreeWeaponTArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint GetBranchStaticDelegate(int* _size);
        private static nint GetBranchStaticFallback(int* _size) => throw new Exceptions.OutdatedSdkException("GetBranchStatic", "GetBranchStatic SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint GetCApiVersionDelegate(int* _size);
        private static nint GetCApiVersionFallback(int* _size) => throw new Exceptions.OutdatedSdkException("GetCApiVersion", "GetCApiVersion SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint GetSDKVersionDelegate(int* _size);
        private static nint GetSDKVersionFallback(int* _size) => throw new Exceptions.OutdatedSdkException("GetSDKVersion", "GetSDKVersion SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint GetVersionStaticDelegate(int* _size);
        private static nint GetVersionStaticFallback(int* _size) => throw new Exceptions.OutdatedSdkException("GetVersionStatic", "GetVersionStatic SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint HttpClient_GetIDDelegate(nint _httpClient);
        private static uint HttpClient_GetIDFallback(nint _httpClient) => throw new Exceptions.OutdatedSdkException("HttpClient_GetID", "HttpClient_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Invoker_CreateDelegate(nint _resource, MValueFunctionCallback _val);
        private static nint Invoker_CreateFallback(nint _resource, MValueFunctionCallback _val) => throw new Exceptions.OutdatedSdkException("Invoker_Create", "Invoker_Create SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Invoker_DestroyDelegate(nint _resource, nint _val);
        private static void Invoker_DestroyFallback(nint _resource, nint _val) => throw new Exceptions.OutdatedSdkException("Invoker_Destroy", "Invoker_Destroy SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte IsDebugStaticDelegate();
        private static byte IsDebugStaticFallback() => throw new Exceptions.OutdatedSdkException("IsDebugStatic", "IsDebugStatic SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint LocalPed_GetIDDelegate(nint _localPed);
        private static uint LocalPed_GetIDFallback(nint _localPed) => throw new Exceptions.OutdatedSdkException("LocalPed_GetID", "LocalPed_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint LocalPed_GetModelDelegate(nint _localPed);
        private static uint LocalPed_GetModelFallback(nint _localPed) => throw new Exceptions.OutdatedSdkException("LocalPed_GetModel", "LocalPed_GetModel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalPed_GetRotationDelegate(nint _localPed, Rotation* _rot);
        private static void LocalPed_GetRotationFallback(nint _localPed, Rotation* _rot) => throw new Exceptions.OutdatedSdkException("LocalPed_GetRotation", "LocalPed_GetRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint LocalPed_GetStreamingDistanceDelegate(nint _localPed);
        private static uint LocalPed_GetStreamingDistanceFallback(nint _localPed) => throw new Exceptions.OutdatedSdkException("LocalPed_GetStreamingDistance", "LocalPed_GetStreamingDistance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint LocalPed_GetWorldObjectDelegate(nint _localPed);
        private static nint LocalPed_GetWorldObjectFallback(nint _localPed) => throw new Exceptions.OutdatedSdkException("LocalPed_GetWorldObject", "LocalPed_GetWorldObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte LocalPed_IsVisibleDelegate(nint _localPed);
        private static byte LocalPed_IsVisibleFallback(nint _localPed) => throw new Exceptions.OutdatedSdkException("LocalPed_IsVisible", "LocalPed_IsVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalPed_SetRotationDelegate(nint _localPed, Rotation _rot);
        private static void LocalPed_SetRotationFallback(nint _localPed, Rotation _rot) => throw new Exceptions.OutdatedSdkException("LocalPed_SetRotation", "LocalPed_SetRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalPed_SetVisibleDelegate(nint _localPed, byte _toggle);
        private static void LocalPed_SetVisibleFallback(nint _localPed, byte _toggle) => throw new Exceptions.OutdatedSdkException("LocalPed_SetVisible", "LocalPed_SetVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_GetColorDelegate(nint _marker, Rgba* _color);
        private static void Marker_GetColorFallback(nint _marker, Rgba* _color) => throw new Exceptions.OutdatedSdkException("Marker_GetColor", "Marker_GetColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_GetDirectionDelegate(nint _marker, Vector3* _dir);
        private static void Marker_GetDirectionFallback(nint _marker, Vector3* _dir) => throw new Exceptions.OutdatedSdkException("Marker_GetDirection", "Marker_GetDirection SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Marker_GetIDDelegate(nint _marker);
        private static uint Marker_GetIDFallback(nint _marker) => throw new Exceptions.OutdatedSdkException("Marker_GetID", "Marker_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Marker_GetMarkerTypeDelegate(nint _marker);
        private static byte Marker_GetMarkerTypeFallback(nint _marker) => throw new Exceptions.OutdatedSdkException("Marker_GetMarkerType", "Marker_GetMarkerType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_GetRotationDelegate(nint _marker, Rotation* _rot);
        private static void Marker_GetRotationFallback(nint _marker, Rotation* _rot) => throw new Exceptions.OutdatedSdkException("Marker_GetRotation", "Marker_GetRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_GetScaleDelegate(nint _marker, Vector3* _scale);
        private static void Marker_GetScaleFallback(nint _marker, Vector3* _scale) => throw new Exceptions.OutdatedSdkException("Marker_GetScale", "Marker_GetScale SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Marker_GetStreamingDistanceDelegate(nint _marker);
        private static uint Marker_GetStreamingDistanceFallback(nint _marker) => throw new Exceptions.OutdatedSdkException("Marker_GetStreamingDistance", "Marker_GetStreamingDistance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Marker_GetTargetDelegate(nint _marker);
        private static nint Marker_GetTargetFallback(nint _marker) => throw new Exceptions.OutdatedSdkException("Marker_GetTarget", "Marker_GetTarget SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Marker_GetWorldObjectDelegate(nint _marker);
        private static nint Marker_GetWorldObjectFallback(nint _marker) => throw new Exceptions.OutdatedSdkException("Marker_GetWorldObject", "Marker_GetWorldObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Marker_IsFaceCameraDelegate(nint _marker);
        private static byte Marker_IsFaceCameraFallback(nint _marker) => throw new Exceptions.OutdatedSdkException("Marker_IsFaceCamera", "Marker_IsFaceCamera SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Marker_IsGlobalDelegate(nint _marker);
        private static uint Marker_IsGlobalFallback(nint _marker) => throw new Exceptions.OutdatedSdkException("Marker_IsGlobal", "Marker_IsGlobal SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Marker_IsVisibleDelegate(nint _marker);
        private static byte Marker_IsVisibleFallback(nint _marker) => throw new Exceptions.OutdatedSdkException("Marker_IsVisible", "Marker_IsVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_SetColorDelegate(nint _marker, Rgba _color);
        private static void Marker_SetColorFallback(nint _marker, Rgba _color) => throw new Exceptions.OutdatedSdkException("Marker_SetColor", "Marker_SetColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_SetDirectionDelegate(nint _marker, Vector3 _dir);
        private static void Marker_SetDirectionFallback(nint _marker, Vector3 _dir) => throw new Exceptions.OutdatedSdkException("Marker_SetDirection", "Marker_SetDirection SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_SetFaceCameraDelegate(nint _marker, byte _faceCamera);
        private static void Marker_SetFaceCameraFallback(nint _marker, byte _faceCamera) => throw new Exceptions.OutdatedSdkException("Marker_SetFaceCamera", "Marker_SetFaceCamera SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_SetMarkerTypeDelegate(nint _marker, byte _type);
        private static void Marker_SetMarkerTypeFallback(nint _marker, byte _type) => throw new Exceptions.OutdatedSdkException("Marker_SetMarkerType", "Marker_SetMarkerType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_SetRotationDelegate(nint _marker, Rotation _rot);
        private static void Marker_SetRotationFallback(nint _marker, Rotation _rot) => throw new Exceptions.OutdatedSdkException("Marker_SetRotation", "Marker_SetRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_SetScaleDelegate(nint _marker, Vector3 _scale);
        private static void Marker_SetScaleFallback(nint _marker, Vector3 _scale) => throw new Exceptions.OutdatedSdkException("Marker_SetScale", "Marker_SetScale SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Marker_SetVisibleDelegate(nint _marker, byte _visible);
        private static void Marker_SetVisibleFallback(nint _marker, byte _visible) => throw new Exceptions.OutdatedSdkException("Marker_SetVisible", "Marker_SetVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MValueConst_AddRefDelegate(nint _mValueConst);
        private static void MValueConst_AddRefFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_AddRef", "MValueConst_AddRef SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint MValueConst_CallFunctionDelegate(nint _core, nint _mValueConst, nint[] val, ulong _size);
        private static nint MValueConst_CallFunctionFallback(nint _core, nint _mValueConst, nint[] val, ulong _size) => throw new Exceptions.OutdatedSdkException("MValueConst_CallFunction", "MValueConst_CallFunction SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MValueConst_DeleteDelegate(nint _mValueConst);
        private static void MValueConst_DeleteFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_Delete", "MValueConst_Delete SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte MValueConst_GetBoolDelegate(nint _mValueConst);
        private static byte MValueConst_GetBoolFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_GetBool", "MValueConst_GetBool SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MValueConst_GetByteArrayDelegate(nint _mValueConst, ulong _size, nint _data);
        private static void MValueConst_GetByteArrayFallback(nint _mValueConst, ulong _size, nint _data) => throw new Exceptions.OutdatedSdkException("MValueConst_GetByteArray", "MValueConst_GetByteArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong MValueConst_GetByteArraySizeDelegate(nint _mValueConst);
        private static ulong MValueConst_GetByteArraySizeFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_GetByteArraySize", "MValueConst_GetByteArraySize SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte MValueConst_GetDictDelegate(nint _mValueConst, nint[] keys, nint[] values);
        private static byte MValueConst_GetDictFallback(nint _mValueConst, nint[] keys, nint[] values) => throw new Exceptions.OutdatedSdkException("MValueConst_GetDict", "MValueConst_GetDict SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong MValueConst_GetDictSizeDelegate(nint _mValueConst);
        private static ulong MValueConst_GetDictSizeFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_GetDictSize", "MValueConst_GetDictSize SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate double MValueConst_GetDoubleDelegate(nint _mValueConst);
        private static double MValueConst_GetDoubleFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_GetDouble", "MValueConst_GetDouble SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint MValueConst_GetEntityDelegate(nint _mValueConst, BaseObjectType* _type);
        private static nint MValueConst_GetEntityFallback(nint _mValueConst, BaseObjectType* _type) => throw new Exceptions.OutdatedSdkException("MValueConst_GetEntity", "MValueConst_GetEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate long MValueConst_GetIntDelegate(nint _mValueConst);
        private static long MValueConst_GetIntFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_GetInt", "MValueConst_GetInt SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte MValueConst_GetListDelegate(nint _mValueConst, nint[] values);
        private static byte MValueConst_GetListFallback(nint _mValueConst, nint[] values) => throw new Exceptions.OutdatedSdkException("MValueConst_GetList", "MValueConst_GetList SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong MValueConst_GetListSizeDelegate(nint _mValueConst);
        private static ulong MValueConst_GetListSizeFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_GetListSize", "MValueConst_GetListSize SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MValueConst_GetRGBADelegate(nint _mValueConst, Rgba* _rgba);
        private static void MValueConst_GetRGBAFallback(nint _mValueConst, Rgba* _rgba) => throw new Exceptions.OutdatedSdkException("MValueConst_GetRGBA", "MValueConst_GetRGBA SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint MValueConst_GetStringDelegate(nint _mValueConst, int* _size);
        private static nint MValueConst_GetStringFallback(nint _mValueConst, int* _size) => throw new Exceptions.OutdatedSdkException("MValueConst_GetString", "MValueConst_GetString SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte MValueConst_GetTypeDelegate(nint _mValueConst);
        private static byte MValueConst_GetTypeFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_GetType", "MValueConst_GetType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong MValueConst_GetUIntDelegate(nint _mValueConst);
        private static ulong MValueConst_GetUIntFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_GetUInt", "MValueConst_GetUInt SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MValueConst_GetVector3Delegate(nint _mValueConst, Vector3* _position);
        private static void MValueConst_GetVector3Fallback(nint _mValueConst, Vector3* _position) => throw new Exceptions.OutdatedSdkException("MValueConst_GetVector3", "MValueConst_GetVector3 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MValueConst_RemoveRefDelegate(nint _mValueConst);
        private static void MValueConst_RemoveRefFallback(nint _mValueConst) => throw new Exceptions.OutdatedSdkException("MValueConst_RemoveRef", "MValueConst_RemoveRef SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte NetworkObject_GetAlphaDelegate(nint _networkObject);
        private static byte NetworkObject_GetAlphaFallback(nint _networkObject) => throw new Exceptions.OutdatedSdkException("NetworkObject_GetAlpha", "NetworkObject_GetAlpha SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint NetworkObject_GetEntityDelegate(nint _networkObject);
        private static nint NetworkObject_GetEntityFallback(nint _networkObject) => throw new Exceptions.OutdatedSdkException("NetworkObject_GetEntity", "NetworkObject_GetEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort NetworkObject_GetIDDelegate(nint _networkObject);
        private static ushort NetworkObject_GetIDFallback(nint _networkObject) => throw new Exceptions.OutdatedSdkException("NetworkObject_GetID", "NetworkObject_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort NetworkObject_GetLodDistanceDelegate(nint _networkObject);
        private static ushort NetworkObject_GetLodDistanceFallback(nint _networkObject) => throw new Exceptions.OutdatedSdkException("NetworkObject_GetLodDistance", "NetworkObject_GetLodDistance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte NetworkObject_GetTextureVariationDelegate(nint _networkObject);
        private static byte NetworkObject_GetTextureVariationFallback(nint _networkObject) => throw new Exceptions.OutdatedSdkException("NetworkObject_GetTextureVariation", "NetworkObject_GetTextureVariation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_ActivatePhysicsDelegate(nint _object);
        private static void Object_ActivatePhysicsFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_ActivatePhysics", "Object_ActivatePhysics SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_AttachToEntityDelegate(nint _object, nint _entity, short _bone, Vector3 _pos, Rotation _rot, byte _useSoftPinning, byte _collision, byte _fixedRot);
        private static void Object_AttachToEntityFallback(nint _object, nint _entity, short _bone, Vector3 _pos, Rotation _rot, byte _useSoftPinning, byte _collision, byte _fixedRot) => throw new Exceptions.OutdatedSdkException("Object_AttachToEntity", "Object_AttachToEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_AttachToEntity_ScriptIdDelegate(nint _object, uint _scriptId, short _bone, Vector3 _pos, Rotation _rot, byte _useSoftPinning, byte _collision, byte _fixedRot);
        private static void Object_AttachToEntity_ScriptIdFallback(nint _object, uint _scriptId, short _bone, Vector3 _pos, Rotation _rot, byte _useSoftPinning, byte _collision, byte _fixedRot) => throw new Exceptions.OutdatedSdkException("Object_AttachToEntity_ScriptId", "Object_AttachToEntity_ScriptId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_DetachDelegate(nint _object, byte _dynamic);
        private static void Object_DetachFallback(nint _object, byte _dynamic) => throw new Exceptions.OutdatedSdkException("Object_Detach", "Object_Detach SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Object_GetAlphaDelegate(nint _object);
        private static byte Object_GetAlphaFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_GetAlpha", "Object_GetAlpha SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Object_GetEntityDelegate(nint _object);
        private static nint Object_GetEntityFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_GetEntity", "Object_GetEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Object_GetIDDelegate(nint _object);
        private static ushort Object_GetIDFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_GetID", "Object_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Object_GetLodDistanceDelegate(nint _object);
        private static ushort Object_GetLodDistanceFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_GetLodDistance", "Object_GetLodDistance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Object_GetStreamingDistanceDelegate(nint _object);
        private static uint Object_GetStreamingDistanceFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_GetStreamingDistance", "Object_GetStreamingDistance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Object_GetTextureVariationDelegate(nint _object);
        private static byte Object_GetTextureVariationFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_GetTextureVariation", "Object_GetTextureVariation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Object_HasGravityDelegate(nint _object);
        private static byte Object_HasGravityFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_HasGravity", "Object_HasGravity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Object_IsCollisionEnabledDelegate(nint _object);
        private static byte Object_IsCollisionEnabledFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_IsCollisionEnabled", "Object_IsCollisionEnabled SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Object_IsDynamicDelegate(nint _object);
        private static byte Object_IsDynamicFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_IsDynamic", "Object_IsDynamic SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Object_IsVisibleDelegate(nint _object);
        private static byte Object_IsVisibleFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_IsVisible", "Object_IsVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Object_IsWorldObjectDelegate(nint _object);
        private static byte Object_IsWorldObjectFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_IsWorldObject", "Object_IsWorldObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_PlaceOnGroundProperlyDelegate(nint _object);
        private static void Object_PlaceOnGroundProperlyFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_PlaceOnGroundProperly", "Object_PlaceOnGroundProperly SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_ResetAlphaDelegate(nint _object);
        private static void Object_ResetAlphaFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_ResetAlpha", "Object_ResetAlpha SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_SetAlphaDelegate(nint _object, byte _alpha);
        private static void Object_SetAlphaFallback(nint _object, byte _alpha) => throw new Exceptions.OutdatedSdkException("Object_SetAlpha", "Object_SetAlpha SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_SetLodDistanceDelegate(nint _object, ushort _distance);
        private static void Object_SetLodDistanceFallback(nint _object, ushort _distance) => throw new Exceptions.OutdatedSdkException("Object_SetLodDistance", "Object_SetLodDistance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_SetPositionFrozenDelegate(nint _object, byte _toggle);
        private static void Object_SetPositionFrozenFallback(nint _object, byte _toggle) => throw new Exceptions.OutdatedSdkException("Object_SetPositionFrozen", "Object_SetPositionFrozen SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_SetTextureVariationDelegate(nint _object, byte _variation);
        private static void Object_SetTextureVariationFallback(nint _object, byte _variation) => throw new Exceptions.OutdatedSdkException("Object_SetTextureVariation", "Object_SetTextureVariation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_SetVisibleDelegate(nint _object, byte _toggle);
        private static void Object_SetVisibleFallback(nint _object, byte _toggle) => throw new Exceptions.OutdatedSdkException("Object_SetVisible", "Object_SetVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_ToggleCollisionDelegate(nint _object, byte _toggle, byte _keepPhysics);
        private static void Object_ToggleCollisionFallback(nint _object, byte _toggle, byte _keepPhysics) => throw new Exceptions.OutdatedSdkException("Object_ToggleCollision", "Object_ToggleCollision SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Object_ToggleGravityDelegate(nint _object, byte _toggle);
        private static void Object_ToggleGravityFallback(nint _object, byte _toggle) => throw new Exceptions.OutdatedSdkException("Object_ToggleGravity", "Object_ToggleGravity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Ped_GetArmourDelegate(nint _ped);
        private static ushort Ped_GetArmourFallback(nint _ped) => throw new Exceptions.OutdatedSdkException("Ped_GetArmour", "Ped_GetArmour SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Ped_GetCurrentWeaponDelegate(nint _ped);
        private static uint Ped_GetCurrentWeaponFallback(nint _ped) => throw new Exceptions.OutdatedSdkException("Ped_GetCurrentWeapon", "Ped_GetCurrentWeapon SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Ped_GetEntityDelegate(nint _ped);
        private static nint Ped_GetEntityFallback(nint _ped) => throw new Exceptions.OutdatedSdkException("Ped_GetEntity", "Ped_GetEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Ped_GetHealthDelegate(nint _ped);
        private static ushort Ped_GetHealthFallback(nint _ped) => throw new Exceptions.OutdatedSdkException("Ped_GetHealth", "Ped_GetHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Ped_GetIDDelegate(nint _ped);
        private static ushort Ped_GetIDFallback(nint _ped) => throw new Exceptions.OutdatedSdkException("Ped_GetID", "Ped_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Ped_GetMaxHealthDelegate(nint _ped);
        private static ushort Ped_GetMaxHealthFallback(nint _ped) => throw new Exceptions.OutdatedSdkException("Ped_GetMaxHealth", "Ped_GetMaxHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetAimPosDelegate(nint _player, Vector3* _aimPosition);
        private static void Player_GetAimPosFallback(nint _player, Vector3* _aimPosition) => throw new Exceptions.OutdatedSdkException("Player_GetAimPos", "Player_GetAimPos SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Player_GetArmorDelegate(nint _player);
        private static ushort Player_GetArmorFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetArmor", "Player_GetArmor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Player_GetCurrentAnimationDictDelegate(nint _player);
        private static uint Player_GetCurrentAnimationDictFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetCurrentAnimationDict", "Player_GetCurrentAnimationDict SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Player_GetCurrentAnimationNameDelegate(nint _player);
        private static uint Player_GetCurrentAnimationNameFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetCurrentAnimationName", "Player_GetCurrentAnimationName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Player_GetCurrentWeaponDelegate(nint _player);
        private static uint Player_GetCurrentWeaponFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetCurrentWeapon", "Player_GetCurrentWeapon SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetCurrentWeaponComponentsDelegate(nint _player, nint* _weaponComponents, uint* _size);
        private static void Player_GetCurrentWeaponComponentsFallback(nint _player, nint* _weaponComponents, uint* _size) => throw new Exceptions.OutdatedSdkException("Player_GetCurrentWeaponComponents", "Player_GetCurrentWeaponComponents SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Player_GetEntityDelegate(nint _player);
        private static nint Player_GetEntityFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetEntity", "Player_GetEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Player_GetEntityAimingAtDelegate(nint _player, BaseObjectType* _type);
        private static nint Player_GetEntityAimingAtFallback(nint _player, BaseObjectType* _type) => throw new Exceptions.OutdatedSdkException("Player_GetEntityAimingAt", "Player_GetEntityAimingAt SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetEntityAimOffsetDelegate(nint _player, Vector3* _position);
        private static void Player_GetEntityAimOffsetFallback(nint _player, Vector3* _position) => throw new Exceptions.OutdatedSdkException("Player_GetEntityAimOffset", "Player_GetEntityAimOffset SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Player_GetForwardSpeedDelegate(nint _player);
        private static float Player_GetForwardSpeedFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetForwardSpeed", "Player_GetForwardSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetHeadRotationDelegate(nint _player, Rotation* _headRotation);
        private static void Player_GetHeadRotationFallback(nint _player, Rotation* _headRotation) => throw new Exceptions.OutdatedSdkException("Player_GetHeadRotation", "Player_GetHeadRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Player_GetHealthDelegate(nint _player);
        private static ushort Player_GetHealthFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetHealth", "Player_GetHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Player_GetIDDelegate(nint _player);
        private static ushort Player_GetIDFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetID", "Player_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Player_GetMaxArmorDelegate(nint _player);
        private static ushort Player_GetMaxArmorFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetMaxArmor", "Player_GetMaxArmor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Player_GetMaxHealthDelegate(nint _player);
        private static ushort Player_GetMaxHealthFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetMaxHealth", "Player_GetMaxHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Player_GetMoveSpeedDelegate(nint _player);
        private static float Player_GetMoveSpeedFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetMoveSpeed", "Player_GetMoveSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Player_GetNameDelegate(nint _player, int* _size);
        private static nint Player_GetNameFallback(nint _player, int* _size) => throw new Exceptions.OutdatedSdkException("Player_GetName", "Player_GetName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_GetSeatDelegate(nint _player);
        private static byte Player_GetSeatFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetSeat", "Player_GetSeat SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Player_GetStrafeSpeedDelegate(nint _player);
        private static float Player_GetStrafeSpeedFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetStrafeSpeed", "Player_GetStrafeSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Player_GetVehicleDelegate(nint _player);
        private static nint Player_GetVehicleFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetVehicle", "Player_GetVehicle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_GetVehicleIDDelegate(nint _player, ushort* _id);
        private static byte Player_GetVehicleIDFallback(nint _player, ushort* _id) => throw new Exceptions.OutdatedSdkException("Player_GetVehicleID", "Player_GetVehicleID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsAimingDelegate(nint _player);
        private static byte Player_IsAimingFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsAiming", "Player_IsAiming SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsDeadDelegate(nint _player);
        private static byte Player_IsDeadFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsDead", "Player_IsDead SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsEnteringVehicleDelegate(nint _player);
        private static byte Player_IsEnteringVehicleFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsEnteringVehicle", "Player_IsEnteringVehicle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsFlashlightActiveDelegate(nint _player);
        private static byte Player_IsFlashlightActiveFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsFlashlightActive", "Player_IsFlashlightActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsInCoverDelegate(nint _player);
        private static byte Player_IsInCoverFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsInCover", "Player_IsInCover SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsInMeleeDelegate(nint _player);
        private static byte Player_IsInMeleeFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsInMelee", "Player_IsInMelee SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsInRagdollDelegate(nint _player);
        private static byte Player_IsInRagdollFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsInRagdoll", "Player_IsInRagdoll SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsInVehicleDelegate(nint _player);
        private static byte Player_IsInVehicleFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsInVehicle", "Player_IsInVehicle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsJumpingDelegate(nint _player);
        private static byte Player_IsJumpingFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsJumping", "Player_IsJumping SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsLeavingVehicleDelegate(nint _player);
        private static byte Player_IsLeavingVehicleFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsLeavingVehicle", "Player_IsLeavingVehicle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsOnLadderDelegate(nint _player);
        private static byte Player_IsOnLadderFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsOnLadder", "Player_IsOnLadder SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsReloadingDelegate(nint _player);
        private static byte Player_IsReloadingFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsReloading", "Player_IsReloading SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsShootingDelegate(nint _player);
        private static byte Player_IsShootingFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsShooting", "Player_IsShooting SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsSpawnedDelegate(nint _player);
        private static byte Player_IsSpawnedFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsSpawned", "Player_IsSpawned SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Resource_GetConfigDelegate(nint _resource);
        private static nint Resource_GetConfigFallback(nint _resource) => throw new Exceptions.OutdatedSdkException("Resource_GetConfig", "Resource_GetConfig SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Resource_GetCSharpImplDelegate(nint _resource);
        private static nint Resource_GetCSharpImplFallback(nint _resource) => throw new Exceptions.OutdatedSdkException("Resource_GetCSharpImpl", "Resource_GetCSharpImpl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Resource_GetDependantsDelegate(nint _resource, nint[] dependencies, int _size);
        private static void Resource_GetDependantsFallback(nint _resource, nint[] dependencies, int _size) => throw new Exceptions.OutdatedSdkException("Resource_GetDependants", "Resource_GetDependants SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int Resource_GetDependantsSizeDelegate(nint _resource);
        private static int Resource_GetDependantsSizeFallback(nint _resource) => throw new Exceptions.OutdatedSdkException("Resource_GetDependantsSize", "Resource_GetDependantsSize SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Resource_GetDependenciesDelegate(nint _resource, nint[] dependencies, int _size);
        private static void Resource_GetDependenciesFallback(nint _resource, nint[] dependencies, int _size) => throw new Exceptions.OutdatedSdkException("Resource_GetDependencies", "Resource_GetDependencies SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int Resource_GetDependenciesSizeDelegate(nint _resource);
        private static int Resource_GetDependenciesSizeFallback(nint _resource) => throw new Exceptions.OutdatedSdkException("Resource_GetDependenciesSize", "Resource_GetDependenciesSize SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Resource_GetExportDelegate(nint _resource, nint _key);
        private static nint Resource_GetExportFallback(nint _resource, nint _key) => throw new Exceptions.OutdatedSdkException("Resource_GetExport", "Resource_GetExport SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Resource_GetExportsDelegate(nint _resource, nint[] keys, nint[] values);
        private static void Resource_GetExportsFallback(nint _resource, nint[] keys, nint[] values) => throw new Exceptions.OutdatedSdkException("Resource_GetExports", "Resource_GetExports SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Resource_GetExportsCountDelegate(nint _resource);
        private static ulong Resource_GetExportsCountFallback(nint _resource) => throw new Exceptions.OutdatedSdkException("Resource_GetExportsCount", "Resource_GetExportsCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Resource_GetImplDelegate(nint _resource);
        private static nint Resource_GetImplFallback(nint _resource) => throw new Exceptions.OutdatedSdkException("Resource_GetImpl", "Resource_GetImpl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Resource_GetNameDelegate(nint _resource, int* _size);
        private static nint Resource_GetNameFallback(nint _resource, int* _size) => throw new Exceptions.OutdatedSdkException("Resource_GetName", "Resource_GetName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Resource_GetTypeDelegate(nint _resource, int* _size);
        private static nint Resource_GetTypeFallback(nint _resource, int* _size) => throw new Exceptions.OutdatedSdkException("Resource_GetType", "Resource_GetType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Resource_IsStartedDelegate(nint _resource);
        private static byte Resource_IsStartedFallback(nint _resource) => throw new Exceptions.OutdatedSdkException("Resource_IsStarted", "Resource_IsStarted SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Resource_SetExportDelegate(nint _core, nint _resource, nint _key, nint _val);
        private static void Resource_SetExportFallback(nint _core, nint _resource, nint _key, nint _val) => throw new Exceptions.OutdatedSdkException("Resource_SetExport", "Resource_SetExport SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Resource_SetExportsDelegate(nint _core, nint _resource, nint[] val, nint[] keys, int _size);
        private static void Resource_SetExportsFallback(nint _core, nint _resource, nint[] val, nint[] keys, int _size) => throw new Exceptions.OutdatedSdkException("Resource_SetExports", "Resource_SetExports SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint RmlDocument_GetIDDelegate(nint _rmlDocument);
        private static uint RmlDocument_GetIDFallback(nint _rmlDocument) => throw new Exceptions.OutdatedSdkException("RmlDocument_GetID", "RmlDocument_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void TextLabel_GetColorDelegate(nint _textLabel, Rgba* _color);
        private static void TextLabel_GetColorFallback(nint _textLabel, Rgba* _color) => throw new Exceptions.OutdatedSdkException("TextLabel_GetColor", "TextLabel_GetColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint TextLabel_GetIDDelegate(nint _textLabel);
        private static uint TextLabel_GetIDFallback(nint _textLabel) => throw new Exceptions.OutdatedSdkException("TextLabel_GetID", "TextLabel_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void TextLabel_GetRotationDelegate(nint _textLabel, Rotation* _rot);
        private static void TextLabel_GetRotationFallback(nint _textLabel, Rotation* _rot) => throw new Exceptions.OutdatedSdkException("TextLabel_GetRotation", "TextLabel_GetRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float TextLabel_GetScaleDelegate(nint _textLabel);
        private static float TextLabel_GetScaleFallback(nint _textLabel) => throw new Exceptions.OutdatedSdkException("TextLabel_GetScale", "TextLabel_GetScale SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint TextLabel_GetTargetDelegate(nint _textLabel);
        private static nint TextLabel_GetTargetFallback(nint _textLabel) => throw new Exceptions.OutdatedSdkException("TextLabel_GetTarget", "TextLabel_GetTarget SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte TextLabel_GetVisibleDelegate(nint _textLabel);
        private static byte TextLabel_GetVisibleFallback(nint _textLabel) => throw new Exceptions.OutdatedSdkException("TextLabel_GetVisible", "TextLabel_GetVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint TextLabel_GetWorldObjectDelegate(nint _textLabel);
        private static nint TextLabel_GetWorldObjectFallback(nint _textLabel) => throw new Exceptions.OutdatedSdkException("TextLabel_GetWorldObject", "TextLabel_GetWorldObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte TextLabel_IsGlobalDelegate(nint _textLabel);
        private static byte TextLabel_IsGlobalFallback(nint _textLabel) => throw new Exceptions.OutdatedSdkException("TextLabel_IsGlobal", "TextLabel_IsGlobal SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void TextLabel_SetColorDelegate(nint _textLabel, Rgba _color);
        private static void TextLabel_SetColorFallback(nint _textLabel, Rgba _color) => throw new Exceptions.OutdatedSdkException("TextLabel_SetColor", "TextLabel_SetColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void TextLabel_SetRotationDelegate(nint _textLabel, Rotation _rot);
        private static void TextLabel_SetRotationFallback(nint _textLabel, Rotation _rot) => throw new Exceptions.OutdatedSdkException("TextLabel_SetRotation", "TextLabel_SetRotation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void TextLabel_SetScaleDelegate(nint _textLabel, float _scale);
        private static void TextLabel_SetScaleFallback(nint _textLabel, float _scale) => throw new Exceptions.OutdatedSdkException("TextLabel_SetScale", "TextLabel_SetScale SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void TextLabel_SetVisibleDelegate(nint _textLabel, byte _visible);
        private static void TextLabel_SetVisibleFallback(nint _textLabel, byte _visible) => throw new Exceptions.OutdatedSdkException("TextLabel_SetVisible", "TextLabel_SetVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetEntityDelegate(nint _vehicle);
        private static nint Vehicle_GetEntityFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetEntity", "Vehicle_GetEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Vehicle_GetIDDelegate(nint _vehicle);
        private static ushort Vehicle_GetIDFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetID", "Vehicle_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int Vehicle_GetPetrolTankHealthDelegate(nint _vehicle);
        private static int Vehicle_GetPetrolTankHealthFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetPetrolTankHealth", "Vehicle_GetPetrolTankHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetWheelsCountDelegate(nint _vehicle);
        private static byte Vehicle_GetWheelsCountFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelsCount", "Vehicle_GetWheelsCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint VirtualEntity_GetGroupDelegate(nint _virtualEntity);
        private static nint VirtualEntity_GetGroupFallback(nint _virtualEntity) => throw new Exceptions.OutdatedSdkException("VirtualEntity_GetGroup", "VirtualEntity_GetGroup SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint VirtualEntity_GetIDDelegate(nint _virtualEntity);
        private static uint VirtualEntity_GetIDFallback(nint _virtualEntity) => throw new Exceptions.OutdatedSdkException("VirtualEntity_GetID", "VirtualEntity_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint VirtualEntity_GetStreamingDistanceDelegate(nint _virtualEntity);
        private static uint VirtualEntity_GetStreamingDistanceFallback(nint _virtualEntity) => throw new Exceptions.OutdatedSdkException("VirtualEntity_GetStreamingDistance", "VirtualEntity_GetStreamingDistance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint VirtualEntity_GetStreamSyncedMetaDataDelegate(nint _virtualEntity, nint _key);
        private static nint VirtualEntity_GetStreamSyncedMetaDataFallback(nint _virtualEntity, nint _key) => throw new Exceptions.OutdatedSdkException("VirtualEntity_GetStreamSyncedMetaData", "VirtualEntity_GetStreamSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint VirtualEntity_GetWorldObjectDelegate(nint _virtualEntity);
        private static nint VirtualEntity_GetWorldObjectFallback(nint _virtualEntity) => throw new Exceptions.OutdatedSdkException("VirtualEntity_GetWorldObject", "VirtualEntity_GetWorldObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte VirtualEntity_HasStreamSyncedMetaDataDelegate(nint _virtualEntity, nint _key);
        private static byte VirtualEntity_HasStreamSyncedMetaDataFallback(nint _virtualEntity, nint _key) => throw new Exceptions.OutdatedSdkException("VirtualEntity_HasStreamSyncedMetaData", "VirtualEntity_HasStreamSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte VirtualEntity_IsVisibleDelegate(nint _virtualEntity);
        private static byte VirtualEntity_IsVisibleFallback(nint _virtualEntity) => throw new Exceptions.OutdatedSdkException("VirtualEntity_IsVisible", "VirtualEntity_IsVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VirtualEntity_SetVisibleDelegate(nint _virtualEntity, byte _toggle);
        private static void VirtualEntity_SetVisibleFallback(nint _virtualEntity, byte _toggle) => throw new Exceptions.OutdatedSdkException("VirtualEntity_SetVisible", "VirtualEntity_SetVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint VirtualEntityGroup_GetBaseObjectDelegate(nint _virtualEntityGroup);
        private static nint VirtualEntityGroup_GetBaseObjectFallback(nint _virtualEntityGroup) => throw new Exceptions.OutdatedSdkException("VirtualEntityGroup_GetBaseObject", "VirtualEntityGroup_GetBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint VirtualEntityGroup_GetIDDelegate(nint _virtualEntityGroup);
        private static uint VirtualEntityGroup_GetIDFallback(nint _virtualEntityGroup) => throw new Exceptions.OutdatedSdkException("VirtualEntityGroup_GetID", "VirtualEntityGroup_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint VirtualEntityGroup_GetStreamingRangeLimitDelegate(nint _virtualEntityGroup);
        private static uint VirtualEntityGroup_GetStreamingRangeLimitFallback(nint _virtualEntityGroup) => throw new Exceptions.OutdatedSdkException("VirtualEntityGroup_GetStreamingRangeLimit", "VirtualEntityGroup_GetStreamingRangeLimit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint VoiceChannel_GetIDDelegate(nint _voiceChannel);
        private static uint VoiceChannel_GetIDFallback(nint _voiceChannel) => throw new Exceptions.OutdatedSdkException("VoiceChannel_GetID", "VoiceChannel_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint WebSocketClient_GetIDDelegate(nint _webSocketClient);
        private static uint WebSocketClient_GetIDFallback(nint _webSocketClient) => throw new Exceptions.OutdatedSdkException("WebSocketClient_GetID", "WebSocketClient_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint WebView_GetIDDelegate(nint _webView);
        private static uint WebView_GetIDFallback(nint _webView) => throw new Exceptions.OutdatedSdkException("WebView_GetID", "WebView_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint WorldObject_GetBaseObjectDelegate(nint _worldObject);
        private static nint WorldObject_GetBaseObjectFallback(nint _worldObject) => throw new Exceptions.OutdatedSdkException("WorldObject_GetBaseObject", "WorldObject_GetBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int WorldObject_GetDimensionDelegate(nint _worldObject);
        private static int WorldObject_GetDimensionFallback(nint _worldObject) => throw new Exceptions.OutdatedSdkException("WorldObject_GetDimension", "WorldObject_GetDimension SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WorldObject_GetPositionDelegate(nint _worldObject, Vector3* _position);
        private static void WorldObject_GetPositionFallback(nint _worldObject, Vector3* _position) => throw new Exceptions.OutdatedSdkException("WorldObject_GetPosition", "WorldObject_GetPosition SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WorldObject_SetPositionDelegate(nint _worldObject, Vector3 _pos);
        private static void WorldObject_SetPositionFallback(nint _worldObject, Vector3 _pos) => throw new Exceptions.OutdatedSdkException("WorldObject_SetPosition", "WorldObject_SetPosition SDK method is outdated. Please update your module nuget");
        public bool Outdated { get; private set; }
        private IntPtr GetUnmanagedPtr<T>(IDictionary<ulong, IntPtr> funcTable, ulong hash, T fn) where T : Delegate {
            if (funcTable.TryGetValue(hash, out var ptr)) return ptr;
            Outdated = true;
            return Marshal.GetFunctionPointerForDelegate<T>(fn);
        }
        public SharedLibrary(Dictionary<ulong, IntPtr> funcTable)
        {
            if (!funcTable.TryGetValue(0, out var capiHash)) Outdated = true;
            else if (capiHash == IntPtr.Zero || *(ulong*)capiHash != 14817668500749310216UL) Outdated = true;
            Audio_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Audio_GetIDDelegate>(funcTable, 4464042055475980737UL, Audio_GetIDFallback);
            BaseObject_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<BaseObject_DeleteMetaDataDelegate>(funcTable, 8032676411671743849UL, BaseObject_DeleteMetaDataFallback);
            BaseObject_DestructCache = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<BaseObject_DestructCacheDelegate>(funcTable, 6691163275156255752UL, BaseObject_DestructCacheFallback);
            BaseObject_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<BaseObject_GetMetaDataDelegate>(funcTable, 4252038112636547538UL, BaseObject_GetMetaDataFallback);
            BaseObject_GetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<BaseObject_GetSyncedMetaDataDelegate>(funcTable, 9969742611088283312UL, BaseObject_GetSyncedMetaDataFallback);
            BaseObject_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<BaseObject_GetTypeDelegate>(funcTable, 11119569299180581449UL, BaseObject_GetTypeFallback);
            BaseObject_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<BaseObject_HasMetaDataDelegate>(funcTable, 12910917014607931813UL, BaseObject_HasMetaDataFallback);
            BaseObject_HasSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<BaseObject_HasSyncedMetaDataDelegate>(funcTable, 8915505876415161659UL, BaseObject_HasSyncedMetaDataFallback);
            BaseObject_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<BaseObject_SetMetaDataDelegate>(funcTable, 16937583073895837697UL, BaseObject_SetMetaDataFallback);
            BaseObject_TryCache = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<BaseObject_TryCacheDelegate>(funcTable, 4805394792054199783UL, BaseObject_TryCacheFallback);
            Blip_Fade = (delegate* unmanaged[Cdecl]<nint, uint, uint, void>) GetUnmanagedPtr<Blip_FadeDelegate>(funcTable, 6633196698544279732UL, Blip_FadeFallback);
            Blip_GetAlpha = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetAlphaDelegate>(funcTable, 6843645795272198929UL, Blip_GetAlphaFallback);
            Blip_GetAsFriendly = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetAsFriendlyDelegate>(funcTable, 17219371041825610064UL, Blip_GetAsFriendlyFallback);
            Blip_GetAsHighDetail = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetAsHighDetailDelegate>(funcTable, 863349328139479326UL, Blip_GetAsHighDetailFallback);
            Blip_GetAsMissionCreator = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetAsMissionCreatorDelegate>(funcTable, 3312069114747260361UL, Blip_GetAsMissionCreatorFallback);
            Blip_GetAsShortRange = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetAsShortRangeDelegate>(funcTable, 16552705327821240660UL, Blip_GetAsShortRangeFallback);
            Blip_GetBright = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetBrightDelegate>(funcTable, 2526538415404116827UL, Blip_GetBrightFallback);
            Blip_GetCategory = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Blip_GetCategoryDelegate>(funcTable, 15826245482034845008UL, Blip_GetCategoryFallback);
            Blip_GetColor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetColorDelegate>(funcTable, 14163622853607831498UL, Blip_GetColorFallback);
            Blip_GetCrewIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetCrewIndicatorVisibleDelegate>(funcTable, 17442773926209484835UL, Blip_GetCrewIndicatorVisibleFallback);
            Blip_GetDisplay = (delegate* unmanaged[Cdecl]<nint, short>) GetUnmanagedPtr<Blip_GetDisplayDelegate>(funcTable, 15574158573141716857UL, Blip_GetDisplayFallback);
            Blip_GetFlashes = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetFlashesDelegate>(funcTable, 11765645294402416523UL, Blip_GetFlashesFallback);
            Blip_GetFlashesAlternate = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetFlashesAlternateDelegate>(funcTable, 11720962242561452875UL, Blip_GetFlashesAlternateFallback);
            Blip_GetFlashInterval = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Blip_GetFlashIntervalDelegate>(funcTable, 322371892157657415UL, Blip_GetFlashIntervalFallback);
            Blip_GetFlashTimer = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Blip_GetFlashTimerDelegate>(funcTable, 13873968998292454625UL, Blip_GetFlashTimerFallback);
            Blip_GetFriendIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetFriendIndicatorVisibleDelegate>(funcTable, 1385159393766883122UL, Blip_GetFriendIndicatorVisibleFallback);
            Blip_GetGxtName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Blip_GetGxtNameDelegate>(funcTable, 548174503258268102UL, Blip_GetGxtNameFallback);
            Blip_GetHeadingIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetHeadingIndicatorVisibleDelegate>(funcTable, 10301029944480990066UL, Blip_GetHeadingIndicatorVisibleFallback);
            Blip_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Blip_GetIDDelegate>(funcTable, 13569575290390530797UL, Blip_GetIDFallback);
            Blip_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Blip_GetNameDelegate>(funcTable, 4819731547457026911UL, Blip_GetNameFallback);
            Blip_GetNumber = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Blip_GetNumberDelegate>(funcTable, 15343935413119710131UL, Blip_GetNumberFallback);
            Blip_GetOutlineIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetOutlineIndicatorVisibleDelegate>(funcTable, 575049905357744794UL, Blip_GetOutlineIndicatorVisibleFallback);
            Blip_GetPriority = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Blip_GetPriorityDelegate>(funcTable, 4864043781529557736UL, Blip_GetPriorityFallback);
            Blip_GetPulse = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetPulseDelegate>(funcTable, 17223773161333574288UL, Blip_GetPulseFallback);
            Blip_GetRotation = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Blip_GetRotationDelegate>(funcTable, 10691298001359635004UL, Blip_GetRotationFallback);
            Blip_GetRoute = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetRouteDelegate>(funcTable, 15186182545001328952UL, Blip_GetRouteFallback);
            Blip_GetRouteColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) GetUnmanagedPtr<Blip_GetRouteColorDelegate>(funcTable, 2174331309202984324UL, Blip_GetRouteColorFallback);
            Blip_GetScaleXY = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) GetUnmanagedPtr<Blip_GetScaleXYDelegate>(funcTable, 15976662414401779390UL, Blip_GetScaleXYFallback);
            Blip_GetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) GetUnmanagedPtr<Blip_GetSecondaryColorDelegate>(funcTable, 8879470316118394091UL, Blip_GetSecondaryColorFallback);
            Blip_GetShowCone = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetShowConeDelegate>(funcTable, 10181814840743433653UL, Blip_GetShowConeFallback);
            Blip_GetShrinked = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetShrinkedDelegate>(funcTable, 874639805267190271UL, Blip_GetShrinkedFallback);
            Blip_GetSprite = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Blip_GetSpriteDelegate>(funcTable, 3015598652144014783UL, Blip_GetSpriteFallback);
            Blip_GetTickVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetTickVisibleDelegate>(funcTable, 9177752480633874416UL, Blip_GetTickVisibleFallback);
            Blip_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_GetTypeDelegate>(funcTable, 10138433409986786803UL, Blip_GetTypeFallback);
            Blip_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Blip_GetWorldObjectDelegate>(funcTable, 13229691291523371538UL, Blip_GetWorldObjectFallback);
            Blip_IsGlobal = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_IsGlobalDelegate>(funcTable, 7092827764366153462UL, Blip_IsGlobalFallback);
            Blip_SetAlpha = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetAlphaDelegate>(funcTable, 17368444473958225900UL, Blip_SetAlphaFallback);
            Blip_SetAsFriendly = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetAsFriendlyDelegate>(funcTable, 16165053809546733271UL, Blip_SetAsFriendlyFallback);
            Blip_SetAsHighDetail = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetAsHighDetailDelegate>(funcTable, 1539266922863640261UL, Blip_SetAsHighDetailFallback);
            Blip_SetAsMissionCreator = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetAsMissionCreatorDelegate>(funcTable, 17757648939429219636UL, Blip_SetAsMissionCreatorFallback);
            Blip_SetAsShortRange = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetAsShortRangeDelegate>(funcTable, 11735946879215707723UL, Blip_SetAsShortRangeFallback);
            Blip_SetBright = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetBrightDelegate>(funcTable, 11739900699062103126UL, Blip_SetBrightFallback);
            Blip_SetCategory = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Blip_SetCategoryDelegate>(funcTable, 16976533959290405247UL, Blip_SetCategoryFallback);
            Blip_SetColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetColorDelegate>(funcTable, 16889550679750230985UL, Blip_SetColorFallback);
            Blip_SetCrewIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetCrewIndicatorVisibleDelegate>(funcTable, 4346269309200056118UL, Blip_SetCrewIndicatorVisibleFallback);
            Blip_SetDisplay = (delegate* unmanaged[Cdecl]<nint, short, void>) GetUnmanagedPtr<Blip_SetDisplayDelegate>(funcTable, 13876263361348749692UL, Blip_SetDisplayFallback);
            Blip_SetFlashes = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetFlashesDelegate>(funcTable, 18345273073053294614UL, Blip_SetFlashesFallback);
            Blip_SetFlashesAlternate = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetFlashesAlternateDelegate>(funcTable, 4124278006586753710UL, Blip_SetFlashesAlternateFallback);
            Blip_SetFlashInterval = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Blip_SetFlashIntervalDelegate>(funcTable, 4106723800653859026UL, Blip_SetFlashIntervalFallback);
            Blip_SetFlashTimer = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Blip_SetFlashTimerDelegate>(funcTable, 14264874127019030452UL, Blip_SetFlashTimerFallback);
            Blip_SetFriendIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetFriendIndicatorVisibleDelegate>(funcTable, 404648410580457609UL, Blip_SetFriendIndicatorVisibleFallback);
            Blip_SetGxtName = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Blip_SetGxtNameDelegate>(funcTable, 2896057006158947493UL, Blip_SetGxtNameFallback);
            Blip_SetHeadingIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetHeadingIndicatorVisibleDelegate>(funcTable, 4233956000658665489UL, Blip_SetHeadingIndicatorVisibleFallback);
            Blip_SetName = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Blip_SetNameDelegate>(funcTable, 5356057624401803688UL, Blip_SetNameFallback);
            Blip_SetNumber = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Blip_SetNumberDelegate>(funcTable, 9620549539065647630UL, Blip_SetNumberFallback);
            Blip_SetOutlineIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetOutlineIndicatorVisibleDelegate>(funcTable, 3029230684693548297UL, Blip_SetOutlineIndicatorVisibleFallback);
            Blip_SetPriority = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Blip_SetPriorityDelegate>(funcTable, 12010941159221668871UL, Blip_SetPriorityFallback);
            Blip_SetPulse = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetPulseDelegate>(funcTable, 14678607532216221087UL, Blip_SetPulseFallback);
            Blip_SetRotation = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Blip_SetRotationDelegate>(funcTable, 2088091673313235227UL, Blip_SetRotationFallback);
            Blip_SetRoute = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetRouteDelegate>(funcTable, 13955731389093058303UL, Blip_SetRouteFallback);
            Blip_SetRouteColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) GetUnmanagedPtr<Blip_SetRouteColorDelegate>(funcTable, 17353536904559002124UL, Blip_SetRouteColorFallback);
            Blip_SetScaleXY = (delegate* unmanaged[Cdecl]<nint, Vector2, void>) GetUnmanagedPtr<Blip_SetScaleXYDelegate>(funcTable, 3872766200123588510UL, Blip_SetScaleXYFallback);
            Blip_SetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) GetUnmanagedPtr<Blip_SetSecondaryColorDelegate>(funcTable, 45946054247045837UL, Blip_SetSecondaryColorFallback);
            Blip_SetShowCone = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetShowConeDelegate>(funcTable, 453472537370220232UL, Blip_SetShowConeFallback);
            Blip_SetShrinked = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetShrinkedDelegate>(funcTable, 7210906801683447458UL, Blip_SetShrinkedFallback);
            Blip_SetSprite = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Blip_SetSpriteDelegate>(funcTable, 14378285759569019370UL, Blip_SetSpriteFallback);
            Blip_SetTickVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Blip_SetTickVisibleDelegate>(funcTable, 3561326935454553655UL, Blip_SetTickVisibleFallback);
            Checkpoint_GetCheckpointType = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Checkpoint_GetCheckpointTypeDelegate>(funcTable, 14827405605973883979UL, Checkpoint_GetCheckpointTypeFallback);
            Checkpoint_GetColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) GetUnmanagedPtr<Checkpoint_GetColorDelegate>(funcTable, 3775073332217131787UL, Checkpoint_GetColorFallback);
            Checkpoint_GetColShape = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Checkpoint_GetColShapeDelegate>(funcTable, 17482162811317800600UL, Checkpoint_GetColShapeFallback);
            Checkpoint_GetHeight = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Checkpoint_GetHeightDelegate>(funcTable, 13557625551244465639UL, Checkpoint_GetHeightFallback);
            Checkpoint_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Checkpoint_GetIDDelegate>(funcTable, 16405184437105084835UL, Checkpoint_GetIDFallback);
            Checkpoint_GetNextPosition = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Checkpoint_GetNextPositionDelegate>(funcTable, 17089941913478571218UL, Checkpoint_GetNextPositionFallback);
            Checkpoint_GetRadius = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Checkpoint_GetRadiusDelegate>(funcTable, 16135548078550245994UL, Checkpoint_GetRadiusFallback);
            Checkpoint_GetStreamingDistance = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Checkpoint_GetStreamingDistanceDelegate>(funcTable, 14309418926871386149UL, Checkpoint_GetStreamingDistanceFallback);
            Checkpoint_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Checkpoint_IsVisibleDelegate>(funcTable, 17019284587126980779UL, Checkpoint_IsVisibleFallback);
            Checkpoint_SetCheckpointType = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Checkpoint_SetCheckpointTypeDelegate>(funcTable, 13843018058835105286UL, Checkpoint_SetCheckpointTypeFallback);
            Checkpoint_SetColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) GetUnmanagedPtr<Checkpoint_SetColorDelegate>(funcTable, 17754703024704790805UL, Checkpoint_SetColorFallback);
            Checkpoint_SetHeight = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Checkpoint_SetHeightDelegate>(funcTable, 12891628734474300322UL, Checkpoint_SetHeightFallback);
            Checkpoint_SetNextPosition = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) GetUnmanagedPtr<Checkpoint_SetNextPositionDelegate>(funcTable, 11203997981133723426UL, Checkpoint_SetNextPositionFallback);
            Checkpoint_SetRadius = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Checkpoint_SetRadiusDelegate>(funcTable, 1352429280367984961UL, Checkpoint_SetRadiusFallback);
            Checkpoint_SetVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Checkpoint_SetVisibleDelegate>(funcTable, 10440317907789505010UL, Checkpoint_SetVisibleFallback);
            ColShape_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<ColShape_GetIDDelegate>(funcTable, 14808638423192174437UL, ColShape_GetIDFallback);
            ColShape_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<ColShape_GetWorldObjectDelegate>(funcTable, 12063803817393523050UL, ColShape_GetWorldObjectFallback);
            ColShape_IsEntityIdIn = (delegate* unmanaged[Cdecl]<nint, ushort, byte>) GetUnmanagedPtr<ColShape_IsEntityIdInDelegate>(funcTable, 11663630185962538197UL, ColShape_IsEntityIdInFallback);
            ColShape_IsEntityIn = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<ColShape_IsEntityInDelegate>(funcTable, 14246921758262831479UL, ColShape_IsEntityInFallback);
            ColShape_IsPointIn = (delegate* unmanaged[Cdecl]<nint, Vector3, byte>) GetUnmanagedPtr<ColShape_IsPointInDelegate>(funcTable, 5532487930936127510UL, ColShape_IsPointInFallback);
            Config_Delete = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Config_DeleteDelegate>(funcTable, 2262811344498570156UL, Config_DeleteFallback);
            Core_CreateColShapeCircle = (delegate* unmanaged[Cdecl]<nint, Vector3, float, uint*, nint>) GetUnmanagedPtr<Core_CreateColShapeCircleDelegate>(funcTable, 18432832866125084195UL, Core_CreateColShapeCircleFallback);
            Core_CreateColShapeCube = (delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, uint*, nint>) GetUnmanagedPtr<Core_CreateColShapeCubeDelegate>(funcTable, 15224790072082250352UL, Core_CreateColShapeCubeFallback);
            Core_CreateColShapeCylinder = (delegate* unmanaged[Cdecl]<nint, Vector3, float, float, uint*, nint>) GetUnmanagedPtr<Core_CreateColShapeCylinderDelegate>(funcTable, 8670479227339890324UL, Core_CreateColShapeCylinderFallback);
            Core_CreateColShapePolygon = (delegate* unmanaged[Cdecl]<nint, float, float, Vector2[], int, uint*, nint>) GetUnmanagedPtr<Core_CreateColShapePolygonDelegate>(funcTable, 613831897340233176UL, Core_CreateColShapePolygonFallback);
            Core_CreateColShapeRectangle = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, uint*, nint>) GetUnmanagedPtr<Core_CreateColShapeRectangleDelegate>(funcTable, 646579018104092947UL, Core_CreateColShapeRectangleFallback);
            Core_CreateColShapeSphere = (delegate* unmanaged[Cdecl]<nint, Vector3, float, uint*, nint>) GetUnmanagedPtr<Core_CreateColShapeSphereDelegate>(funcTable, 2469653109981943492UL, Core_CreateColShapeSphereFallback);
            Core_CreateMValueBaseObject = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Core_CreateMValueBaseObjectDelegate>(funcTable, 4584378219312895289UL, Core_CreateMValueBaseObjectFallback);
            Core_CreateMValueBool = (delegate* unmanaged[Cdecl]<nint, byte, nint>) GetUnmanagedPtr<Core_CreateMValueBoolDelegate>(funcTable, 15746428410885594662UL, Core_CreateMValueBoolFallback);
            Core_CreateMValueByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, nint, nint>) GetUnmanagedPtr<Core_CreateMValueByteArrayDelegate>(funcTable, 13926064973915625040UL, Core_CreateMValueByteArrayFallback);
            Core_CreateMValueDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint>) GetUnmanagedPtr<Core_CreateMValueDictDelegate>(funcTable, 15368774857641140110UL, Core_CreateMValueDictFallback);
            Core_CreateMValueDouble = (delegate* unmanaged[Cdecl]<nint, double, nint>) GetUnmanagedPtr<Core_CreateMValueDoubleDelegate>(funcTable, 1882390361049016267UL, Core_CreateMValueDoubleFallback);
            Core_CreateMValueFunction = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Core_CreateMValueFunctionDelegate>(funcTable, 11902152537215198618UL, Core_CreateMValueFunctionFallback);
            Core_CreateMValueInt = (delegate* unmanaged[Cdecl]<nint, long, nint>) GetUnmanagedPtr<Core_CreateMValueIntDelegate>(funcTable, 4856451965197820806UL, Core_CreateMValueIntFallback);
            Core_CreateMValueList = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint>) GetUnmanagedPtr<Core_CreateMValueListDelegate>(funcTable, 9113028347303902605UL, Core_CreateMValueListFallback);
            Core_CreateMValueNil = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Core_CreateMValueNilDelegate>(funcTable, 16512941520029131283UL, Core_CreateMValueNilFallback);
            Core_CreateMValueRgba = (delegate* unmanaged[Cdecl]<nint, Rgba, nint>) GetUnmanagedPtr<Core_CreateMValueRgbaDelegate>(funcTable, 9220192531397651202UL, Core_CreateMValueRgbaFallback);
            Core_CreateMValueString = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Core_CreateMValueStringDelegate>(funcTable, 15411039852549673274UL, Core_CreateMValueStringFallback);
            Core_CreateMValueUInt = (delegate* unmanaged[Cdecl]<nint, ulong, nint>) GetUnmanagedPtr<Core_CreateMValueUIntDelegate>(funcTable, 6163221229160271460UL, Core_CreateMValueUIntFallback);
            Core_CreateMValueVector2 = (delegate* unmanaged[Cdecl]<nint, Vector2, nint>) GetUnmanagedPtr<Core_CreateMValueVector2Delegate>(funcTable, 14147992496612914836UL, Core_CreateMValueVector2Fallback);
            Core_CreateMValueVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3, nint>) GetUnmanagedPtr<Core_CreateMValueVector3Delegate>(funcTable, 5009905671684942563UL, Core_CreateMValueVector3Fallback);
            Core_CreateVirtualEntity = (delegate* unmanaged[Cdecl]<nint, nint, Vector3, uint, nint[], nint[], ulong, uint*, nint>) GetUnmanagedPtr<Core_CreateVirtualEntityDelegate>(funcTable, 10333382199506434722UL, Core_CreateVirtualEntityFallback);
            Core_CreateVirtualEntityGroup = (delegate* unmanaged[Cdecl]<nint, uint, uint*, nint>) GetUnmanagedPtr<Core_CreateVirtualEntityGroupDelegate>(funcTable, 17562251304729686304UL, Core_CreateVirtualEntityGroupFallback);
            Core_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_DeleteMetaDataDelegate>(funcTable, 13221743936666214985UL, Core_DeleteMetaDataFallback);
            Core_DestroyBaseObject = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_DestroyBaseObjectDelegate>(funcTable, 18388140590159782277UL, Core_DestroyBaseObjectFallback);
            Core_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_FileExistsDelegate>(funcTable, 15661057563805869574UL, Core_FileExistsFallback);
            Core_FileRead = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) GetUnmanagedPtr<Core_FileReadDelegate>(funcTable, 13630176403103570557UL, Core_FileReadFallback);
            Core_GetAllResources = (delegate* unmanaged[Cdecl]<nint, uint*, nint>) GetUnmanagedPtr<Core_GetAllResourcesDelegate>(funcTable, 3926770362965932159UL, Core_GetAllResourcesFallback);
            Core_GetBaseObjectByID = (delegate* unmanaged[Cdecl]<nint, byte, uint, nint>) GetUnmanagedPtr<Core_GetBaseObjectByIDDelegate>(funcTable, 7276494048261315747UL, Core_GetBaseObjectByIDFallback);
            Core_GetBlips = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetBlipsDelegate>(funcTable, 11611786081777275389UL, Core_GetBlipsFallback);
            Core_GetBranch = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Core_GetBranchDelegate>(funcTable, 12434012012299018294UL, Core_GetBranchFallback);
            Core_GetCheckpoints = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetCheckpointsDelegate>(funcTable, 14291068473487208197UL, Core_GetCheckpointsFallback);
            Core_GetColShapes = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetColShapesDelegate>(funcTable, 9480713887250028309UL, Core_GetColShapesFallback);
            Core_GetCoreInstance = (delegate* unmanaged[Cdecl]<nint>) GetUnmanagedPtr<Core_GetCoreInstanceDelegate>(funcTable, 16862996593036574459UL, Core_GetCoreInstanceFallback);
            Core_GetEntityById = (delegate* unmanaged[Cdecl]<nint, ushort, byte*, nint>) GetUnmanagedPtr<Core_GetEntityByIdDelegate>(funcTable, 5700771154374947006UL, Core_GetEntityByIdFallback);
            Core_GetEventEnumSize = (delegate* unmanaged[Cdecl]<byte>) GetUnmanagedPtr<Core_GetEventEnumSizeDelegate>(funcTable, 6921054663232355759UL, Core_GetEventEnumSizeFallback);
            Core_GetMarkers = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetMarkersDelegate>(funcTable, 7482854450085275693UL, Core_GetMarkersFallback);
            Core_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Core_GetMetaDataDelegate>(funcTable, 2139798095052897524UL, Core_GetMetaDataFallback);
            Core_GetNetworkObjects = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetNetworkObjectsDelegate>(funcTable, 9012743733720232375UL, Core_GetNetworkObjectsFallback);
            Core_GetPeds = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetPedsDelegate>(funcTable, 5411021830103603795UL, Core_GetPedsFallback);
            Core_GetPlayers = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetPlayersDelegate>(funcTable, 6799731000550763773UL, Core_GetPlayersFallback);
            Core_GetResource = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Core_GetResourceDelegate>(funcTable, 2104206599506704309UL, Core_GetResourceFallback);
            Core_GetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Core_GetSyncedMetaDataDelegate>(funcTable, 11801041189958959698UL, Core_GetSyncedMetaDataFallback);
            Core_GetVehicles = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetVehiclesDelegate>(funcTable, 5149247920306783181UL, Core_GetVehiclesFallback);
            Core_GetVersion = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Core_GetVersionDelegate>(funcTable, 7504892851555999456UL, Core_GetVersionFallback);
            Core_GetVirtualEntities = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetVirtualEntitiesDelegate>(funcTable, 4476532196756880454UL, Core_GetVirtualEntitiesFallback);
            Core_GetVirtualEntityGroups = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetVirtualEntityGroupsDelegate>(funcTable, 17770187578627250877UL, Core_GetVirtualEntityGroupsFallback);
            Core_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_HasMetaDataDelegate>(funcTable, 11163152091545864047UL, Core_HasMetaDataFallback);
            Core_HasSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_HasSyncedMetaDataDelegate>(funcTable, 11681507067991184733UL, Core_HasSyncedMetaDataFallback);
            Core_IsDebug = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_IsDebugDelegate>(funcTable, 14872081069683452488UL, Core_IsDebugFallback);
            Core_LogColored = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_LogColoredDelegate>(funcTable, 4907513399110597611UL, Core_LogColoredFallback);
            Core_LogDebug = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_LogDebugDelegate>(funcTable, 16207264539355256088UL, Core_LogDebugFallback);
            Core_LogError = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_LogErrorDelegate>(funcTable, 10708570634236392131UL, Core_LogErrorFallback);
            Core_LogInfo = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_LogInfoDelegate>(funcTable, 3068398960225557583UL, Core_LogInfoFallback);
            Core_LogWarning = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_LogWarningDelegate>(funcTable, 15034650039982382601UL, Core_LogWarningFallback);
            Core_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<Core_SetMetaDataDelegate>(funcTable, 4905441971289102819UL, Core_SetMetaDataFallback);
            Core_ToggleEvent = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Core_ToggleEventDelegate>(funcTable, 17798706175912111294UL, Core_ToggleEventFallback);
            Core_TriggerLocalEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerLocalEventDelegate>(funcTable, 2095655564565809781UL, Core_TriggerLocalEventFallback);
            Entity_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Entity_GetIDDelegate>(funcTable, 12913447266302910987UL, Entity_GetIDFallback);
            Entity_GetModel = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Entity_GetModelDelegate>(funcTable, 6111944054700936115UL, Entity_GetModelFallback);
            Entity_GetNetOwner = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Entity_GetNetOwnerDelegate>(funcTable, 7130354370478174789UL, Entity_GetNetOwnerFallback);
            Entity_GetNetOwnerID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) GetUnmanagedPtr<Entity_GetNetOwnerIDDelegate>(funcTable, 10262653550309861069UL, Entity_GetNetOwnerIDFallback);
            Entity_GetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) GetUnmanagedPtr<Entity_GetRotationDelegate>(funcTable, 13365378745805996598UL, Entity_GetRotationFallback);
            Entity_GetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Entity_GetStreamSyncedMetaDataDelegate>(funcTable, 11045454806874783898UL, Entity_GetStreamSyncedMetaDataFallback);
            Entity_GetTypeByID = (delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte>) GetUnmanagedPtr<Entity_GetTypeByIDDelegate>(funcTable, 16194706534247749750UL, Entity_GetTypeByIDFallback);
            Entity_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Entity_GetWorldObjectDelegate>(funcTable, 15286200049861980882UL, Entity_GetWorldObjectFallback);
            Entity_HasStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Entity_HasStreamSyncedMetaDataDelegate>(funcTable, 2664435930066837893UL, Entity_HasStreamSyncedMetaDataFallback);
            Entity_SetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation, void>) GetUnmanagedPtr<Entity_SetRotationDelegate>(funcTable, 7991844148745066430UL, Entity_SetRotationFallback);
            Event_Cancel = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Event_CancelDelegate>(funcTable, 4913360914395691424UL, Event_CancelFallback);
            Event_WasCancelled = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Event_WasCancelledDelegate>(funcTable, 15923635865693275395UL, Event_WasCancelledFallback);
            FreeBlipArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeBlipArrayDelegate>(funcTable, 12999641840922984330UL, FreeBlipArrayFallback);
            FreeCharArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeCharArrayDelegate>(funcTable, 1943718755920302008UL, FreeCharArrayFallback);
            FreeCheckpointArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeCheckpointArrayDelegate>(funcTable, 16715093567839162130UL, FreeCheckpointArrayFallback);
            FreeMValueConstArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeMValueConstArrayDelegate>(funcTable, 10875848896530643353UL, FreeMValueConstArrayFallback);
            FreeObjectArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeObjectArrayDelegate>(funcTable, 12324137626706269838UL, FreeObjectArrayFallback);
            FreePedArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreePedArrayDelegate>(funcTable, 15264987216922552928UL, FreePedArrayFallback);
            FreePlayerArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreePlayerArrayDelegate>(funcTable, 2825758299761506526UL, FreePlayerArrayFallback);
            FreeResourceArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeResourceArrayDelegate>(funcTable, 7782187912558785270UL, FreeResourceArrayFallback);
            FreeString = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeStringDelegate>(funcTable, 10646355260907021718UL, FreeStringFallback);
            FreeStringArray = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<FreeStringArrayDelegate>(funcTable, 9817201133426969670UL, FreeStringArrayFallback);
            FreeUInt32Array = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeUInt32ArrayDelegate>(funcTable, 2025110884526748511UL, FreeUInt32ArrayFallback);
            FreeUInt8Array = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeUInt8ArrayDelegate>(funcTable, 15676846424137302955UL, FreeUInt8ArrayFallback);
            FreeUIntArray = (delegate* unmanaged[Cdecl]<UIntArray*, void>) GetUnmanagedPtr<FreeUIntArrayDelegate>(funcTable, 18177610684891912620UL, FreeUIntArrayFallback);
            FreeVehicleArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeVehicleArrayDelegate>(funcTable, 17333862921555331722UL, FreeVehicleArrayFallback);
            FreeVirtualEntityArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeVirtualEntityArrayDelegate>(funcTable, 5578132044888672654UL, FreeVirtualEntityArrayFallback);
            FreeVirtualEntityGroupArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeVirtualEntityGroupArrayDelegate>(funcTable, 13356841008999093930UL, FreeVirtualEntityGroupArrayFallback);
            FreeVoidPointerArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeVoidPointerArrayDelegate>(funcTable, 14409547959528391761UL, FreeVoidPointerArrayFallback);
            FreeWeaponTArray = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<FreeWeaponTArrayDelegate>(funcTable, 14701143750997334716UL, FreeWeaponTArrayFallback);
            GetBranchStatic = (delegate* unmanaged[Cdecl]<int*, nint>) GetUnmanagedPtr<GetBranchStaticDelegate>(funcTable, 15513118297531919712UL, GetBranchStaticFallback);
            GetCApiVersion = (delegate* unmanaged[Cdecl]<int*, nint>) GetUnmanagedPtr<GetCApiVersionDelegate>(funcTable, 10580384701439081299UL, GetCApiVersionFallback);
            GetSDKVersion = (delegate* unmanaged[Cdecl]<int*, nint>) GetUnmanagedPtr<GetSDKVersionDelegate>(funcTable, 13147849555054061682UL, GetSDKVersionFallback);
            GetVersionStatic = (delegate* unmanaged[Cdecl]<int*, nint>) GetUnmanagedPtr<GetVersionStaticDelegate>(funcTable, 9678603713250235246UL, GetVersionStaticFallback);
            HttpClient_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<HttpClient_GetIDDelegate>(funcTable, 7288206209717487889UL, HttpClient_GetIDFallback);
            Invoker_Create = (delegate* unmanaged[Cdecl]<nint, MValueFunctionCallback, nint>) GetUnmanagedPtr<Invoker_CreateDelegate>(funcTable, 15107945359232289520UL, Invoker_CreateFallback);
            Invoker_Destroy = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Invoker_DestroyDelegate>(funcTable, 13472547340675883247UL, Invoker_DestroyFallback);
            IsDebugStatic = (delegate* unmanaged[Cdecl]<byte>) GetUnmanagedPtr<IsDebugStaticDelegate>(funcTable, 7118542945065902334UL, IsDebugStaticFallback);
            LocalPed_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<LocalPed_GetIDDelegate>(funcTable, 15318682494636002455UL, LocalPed_GetIDFallback);
            LocalPed_GetModel = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<LocalPed_GetModelDelegate>(funcTable, 18280414601745814655UL, LocalPed_GetModelFallback);
            LocalPed_GetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) GetUnmanagedPtr<LocalPed_GetRotationDelegate>(funcTable, 10372449682549700708UL, LocalPed_GetRotationFallback);
            LocalPed_GetStreamingDistance = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<LocalPed_GetStreamingDistanceDelegate>(funcTable, 7484443958305306909UL, LocalPed_GetStreamingDistanceFallback);
            LocalPed_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<LocalPed_GetWorldObjectDelegate>(funcTable, 195138720060470930UL, LocalPed_GetWorldObjectFallback);
            LocalPed_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<LocalPed_IsVisibleDelegate>(funcTable, 16733779175982679523UL, LocalPed_IsVisibleFallback);
            LocalPed_SetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation, void>) GetUnmanagedPtr<LocalPed_SetRotationDelegate>(funcTable, 12736827587977303188UL, LocalPed_SetRotationFallback);
            LocalPed_SetVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<LocalPed_SetVisibleDelegate>(funcTable, 7437063190905143438UL, LocalPed_SetVisibleFallback);
            Marker_GetColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) GetUnmanagedPtr<Marker_GetColorDelegate>(funcTable, 6193914507030990415UL, Marker_GetColorFallback);
            Marker_GetDirection = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Marker_GetDirectionDelegate>(funcTable, 9123839521259778880UL, Marker_GetDirectionFallback);
            Marker_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Marker_GetIDDelegate>(funcTable, 16696466665661187791UL, Marker_GetIDFallback);
            Marker_GetMarkerType = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Marker_GetMarkerTypeDelegate>(funcTable, 5240420572409205647UL, Marker_GetMarkerTypeFallback);
            Marker_GetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) GetUnmanagedPtr<Marker_GetRotationDelegate>(funcTable, 6072515882787059448UL, Marker_GetRotationFallback);
            Marker_GetScale = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Marker_GetScaleDelegate>(funcTable, 14616096740054666449UL, Marker_GetScaleFallback);
            Marker_GetStreamingDistance = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Marker_GetStreamingDistanceDelegate>(funcTable, 5405050753430155401UL, Marker_GetStreamingDistanceFallback);
            Marker_GetTarget = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Marker_GetTargetDelegate>(funcTable, 15442851779455932452UL, Marker_GetTargetFallback);
            Marker_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Marker_GetWorldObjectDelegate>(funcTable, 14796952389729553182UL, Marker_GetWorldObjectFallback);
            Marker_IsFaceCamera = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Marker_IsFaceCameraDelegate>(funcTable, 3331151536932433603UL, Marker_IsFaceCameraFallback);
            Marker_IsGlobal = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Marker_IsGlobalDelegate>(funcTable, 15394588070881330329UL, Marker_IsGlobalFallback);
            Marker_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Marker_IsVisibleDelegate>(funcTable, 7638321216817832459UL, Marker_IsVisibleFallback);
            Marker_SetColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) GetUnmanagedPtr<Marker_SetColorDelegate>(funcTable, 16990441478007898825UL, Marker_SetColorFallback);
            Marker_SetDirection = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) GetUnmanagedPtr<Marker_SetDirectionDelegate>(funcTable, 5238646959486818104UL, Marker_SetDirectionFallback);
            Marker_SetFaceCamera = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Marker_SetFaceCameraDelegate>(funcTable, 9437043437809276362UL, Marker_SetFaceCameraFallback);
            Marker_SetMarkerType = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Marker_SetMarkerTypeDelegate>(funcTable, 17542761621503411994UL, Marker_SetMarkerTypeFallback);
            Marker_SetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation, void>) GetUnmanagedPtr<Marker_SetRotationDelegate>(funcTable, 12229547285560302608UL, Marker_SetRotationFallback);
            Marker_SetScale = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) GetUnmanagedPtr<Marker_SetScaleDelegate>(funcTable, 7129171957282455779UL, Marker_SetScaleFallback);
            Marker_SetVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Marker_SetVisibleDelegate>(funcTable, 7158984024495559554UL, Marker_SetVisibleFallback);
            MValueConst_AddRef = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<MValueConst_AddRefDelegate>(funcTable, 8024965565519351537UL, MValueConst_AddRefFallback);
            MValueConst_CallFunction = (delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint>) GetUnmanagedPtr<MValueConst_CallFunctionDelegate>(funcTable, 385248565149432234UL, MValueConst_CallFunctionFallback);
            MValueConst_Delete = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<MValueConst_DeleteDelegate>(funcTable, 1868060259381368328UL, MValueConst_DeleteFallback);
            MValueConst_GetBool = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<MValueConst_GetBoolDelegate>(funcTable, 10166810469874461064UL, MValueConst_GetBoolFallback);
            MValueConst_GetByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, nint, void>) GetUnmanagedPtr<MValueConst_GetByteArrayDelegate>(funcTable, 2500403761842775751UL, MValueConst_GetByteArrayFallback);
            MValueConst_GetByteArraySize = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<MValueConst_GetByteArraySizeDelegate>(funcTable, 17908722150843651652UL, MValueConst_GetByteArraySizeFallback);
            MValueConst_GetDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte>) GetUnmanagedPtr<MValueConst_GetDictDelegate>(funcTable, 10019897816970500190UL, MValueConst_GetDictFallback);
            MValueConst_GetDictSize = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<MValueConst_GetDictSizeDelegate>(funcTable, 13554388714363276015UL, MValueConst_GetDictSizeFallback);
            MValueConst_GetDouble = (delegate* unmanaged[Cdecl]<nint, double>) GetUnmanagedPtr<MValueConst_GetDoubleDelegate>(funcTable, 17870549512330820827UL, MValueConst_GetDoubleFallback);
            MValueConst_GetEntity = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) GetUnmanagedPtr<MValueConst_GetEntityDelegate>(funcTable, 9819692566092084121UL, MValueConst_GetEntityFallback);
            MValueConst_GetInt = (delegate* unmanaged[Cdecl]<nint, long>) GetUnmanagedPtr<MValueConst_GetIntDelegate>(funcTable, 16982613083748675336UL, MValueConst_GetIntFallback);
            MValueConst_GetList = (delegate* unmanaged[Cdecl]<nint, nint[], byte>) GetUnmanagedPtr<MValueConst_GetListDelegate>(funcTable, 12014367499988455631UL, MValueConst_GetListFallback);
            MValueConst_GetListSize = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<MValueConst_GetListSizeDelegate>(funcTable, 15201882533294867639UL, MValueConst_GetListSizeFallback);
            MValueConst_GetRGBA = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) GetUnmanagedPtr<MValueConst_GetRGBADelegate>(funcTable, 6831937237238862815UL, MValueConst_GetRGBAFallback);
            MValueConst_GetString = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<MValueConst_GetStringDelegate>(funcTable, 15737840967499726676UL, MValueConst_GetStringFallback);
            MValueConst_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<MValueConst_GetTypeDelegate>(funcTable, 12478373194927884UL, MValueConst_GetTypeFallback);
            MValueConst_GetUInt = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<MValueConst_GetUIntDelegate>(funcTable, 13668837850312303780UL, MValueConst_GetUIntFallback);
            MValueConst_GetVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<MValueConst_GetVector3Delegate>(funcTable, 1239177284695633462UL, MValueConst_GetVector3Fallback);
            MValueConst_RemoveRef = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<MValueConst_RemoveRefDelegate>(funcTable, 2951895109234703784UL, MValueConst_RemoveRefFallback);
            NetworkObject_GetAlpha = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<NetworkObject_GetAlphaDelegate>(funcTable, 18209568442352195431UL, NetworkObject_GetAlphaFallback);
            NetworkObject_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<NetworkObject_GetEntityDelegate>(funcTable, 3666678297771395934UL, NetworkObject_GetEntityFallback);
            NetworkObject_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<NetworkObject_GetIDDelegate>(funcTable, 2185059533142172527UL, NetworkObject_GetIDFallback);
            NetworkObject_GetLodDistance = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<NetworkObject_GetLodDistanceDelegate>(funcTable, 12809257540355991912UL, NetworkObject_GetLodDistanceFallback);
            NetworkObject_GetTextureVariation = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<NetworkObject_GetTextureVariationDelegate>(funcTable, 105893559881092449UL, NetworkObject_GetTextureVariationFallback);
            Object_ActivatePhysics = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Object_ActivatePhysicsDelegate>(funcTable, 17585830173881425980UL, Object_ActivatePhysicsFallback);
            Object_AttachToEntity = (delegate* unmanaged[Cdecl]<nint, nint, short, Vector3, Rotation, byte, byte, byte, void>) GetUnmanagedPtr<Object_AttachToEntityDelegate>(funcTable, 15073840091519902240UL, Object_AttachToEntityFallback);
            Object_AttachToEntity_ScriptId = (delegate* unmanaged[Cdecl]<nint, uint, short, Vector3, Rotation, byte, byte, byte, void>) GetUnmanagedPtr<Object_AttachToEntity_ScriptIdDelegate>(funcTable, 5601925715555707412UL, Object_AttachToEntity_ScriptIdFallback);
            Object_Detach = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Object_DetachDelegate>(funcTable, 5181875162525913117UL, Object_DetachFallback);
            Object_GetAlpha = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Object_GetAlphaDelegate>(funcTable, 4782965940294523501UL, Object_GetAlphaFallback);
            Object_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Object_GetEntityDelegate>(funcTable, 4934471410579771998UL, Object_GetEntityFallback);
            Object_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Object_GetIDDelegate>(funcTable, 12916172794746864343UL, Object_GetIDFallback);
            Object_GetLodDistance = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Object_GetLodDistanceDelegate>(funcTable, 9053583879265260950UL, Object_GetLodDistanceFallback);
            Object_GetStreamingDistance = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Object_GetStreamingDistanceDelegate>(funcTable, 16226032668510538965UL, Object_GetStreamingDistanceFallback);
            Object_GetTextureVariation = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Object_GetTextureVariationDelegate>(funcTable, 4660664364773957039UL, Object_GetTextureVariationFallback);
            Object_HasGravity = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Object_HasGravityDelegate>(funcTable, 8859174657854274703UL, Object_HasGravityFallback);
            Object_IsCollisionEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Object_IsCollisionEnabledDelegate>(funcTable, 6249145685868994012UL, Object_IsCollisionEnabledFallback);
            Object_IsDynamic = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Object_IsDynamicDelegate>(funcTable, 8584793846210143026UL, Object_IsDynamicFallback);
            Object_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Object_IsVisibleDelegate>(funcTable, 5337252315976841077UL, Object_IsVisibleFallback);
            Object_IsWorldObject = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Object_IsWorldObjectDelegate>(funcTable, 17619976092247149204UL, Object_IsWorldObjectFallback);
            Object_PlaceOnGroundProperly = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Object_PlaceOnGroundProperlyDelegate>(funcTable, 16593704804065749058UL, Object_PlaceOnGroundProperlyFallback);
            Object_ResetAlpha = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Object_ResetAlphaDelegate>(funcTable, 15582803191049029347UL, Object_ResetAlphaFallback);
            Object_SetAlpha = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Object_SetAlphaDelegate>(funcTable, 1335394386529232328UL, Object_SetAlphaFallback);
            Object_SetLodDistance = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Object_SetLodDistanceDelegate>(funcTable, 14785658894799737749UL, Object_SetLodDistanceFallback);
            Object_SetPositionFrozen = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Object_SetPositionFrozenDelegate>(funcTable, 13625864371790276101UL, Object_SetPositionFrozenFallback);
            Object_SetTextureVariation = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Object_SetTextureVariationDelegate>(funcTable, 2992998067089316658UL, Object_SetTextureVariationFallback);
            Object_SetVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Object_SetVisibleDelegate>(funcTable, 15473217416258516370UL, Object_SetVisibleFallback);
            Object_ToggleCollision = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Object_ToggleCollisionDelegate>(funcTable, 6986264234974696038UL, Object_ToggleCollisionFallback);
            Object_ToggleGravity = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Object_ToggleGravityDelegate>(funcTable, 4853716554374183752UL, Object_ToggleGravityFallback);
            Ped_GetArmour = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Ped_GetArmourDelegate>(funcTable, 4106400780828488738UL, Ped_GetArmourFallback);
            Ped_GetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Ped_GetCurrentWeaponDelegate>(funcTable, 446737373633343515UL, Ped_GetCurrentWeaponFallback);
            Ped_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Ped_GetEntityDelegate>(funcTable, 17974792644403470118UL, Ped_GetEntityFallback);
            Ped_GetHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Ped_GetHealthDelegate>(funcTable, 7104729899977702888UL, Ped_GetHealthFallback);
            Ped_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Ped_GetIDDelegate>(funcTable, 4733988892192620155UL, Ped_GetIDFallback);
            Ped_GetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Ped_GetMaxHealthDelegate>(funcTable, 18375756057324289044UL, Ped_GetMaxHealthFallback);
            Player_GetAimPos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Player_GetAimPosDelegate>(funcTable, 6124580830261182834UL, Player_GetAimPosFallback);
            Player_GetArmor = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Player_GetArmorDelegate>(funcTable, 343339663996265887UL, Player_GetArmorFallback);
            Player_GetCurrentAnimationDict = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Player_GetCurrentAnimationDictDelegate>(funcTable, 15205133691822968917UL, Player_GetCurrentAnimationDictFallback);
            Player_GetCurrentAnimationName = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Player_GetCurrentAnimationNameDelegate>(funcTable, 847135236698778676UL, Player_GetCurrentAnimationNameFallback);
            Player_GetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Player_GetCurrentWeaponDelegate>(funcTable, 12018000172190072043UL, Player_GetCurrentWeaponFallback);
            Player_GetCurrentWeaponComponents = (delegate* unmanaged[Cdecl]<nint, nint*, uint*, void>) GetUnmanagedPtr<Player_GetCurrentWeaponComponentsDelegate>(funcTable, 7226011814452181359UL, Player_GetCurrentWeaponComponentsFallback);
            Player_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Player_GetEntityDelegate>(funcTable, 1487476147175255146UL, Player_GetEntityFallback);
            Player_GetEntityAimingAt = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) GetUnmanagedPtr<Player_GetEntityAimingAtDelegate>(funcTable, 6876118188667194676UL, Player_GetEntityAimingAtFallback);
            Player_GetEntityAimOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Player_GetEntityAimOffsetDelegate>(funcTable, 12947171231505309434UL, Player_GetEntityAimOffsetFallback);
            Player_GetForwardSpeed = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Player_GetForwardSpeedDelegate>(funcTable, 12498998920879213674UL, Player_GetForwardSpeedFallback);
            Player_GetHeadRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) GetUnmanagedPtr<Player_GetHeadRotationDelegate>(funcTable, 17222204554789096264UL, Player_GetHeadRotationFallback);
            Player_GetHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Player_GetHealthDelegate>(funcTable, 14695407730559477910UL, Player_GetHealthFallback);
            Player_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Player_GetIDDelegate>(funcTable, 2649376720891219187UL, Player_GetIDFallback);
            Player_GetMaxArmor = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Player_GetMaxArmorDelegate>(funcTable, 4693803817659874615UL, Player_GetMaxArmorFallback);
            Player_GetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Player_GetMaxHealthDelegate>(funcTable, 4164549052335308174UL, Player_GetMaxHealthFallback);
            Player_GetMoveSpeed = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Player_GetMoveSpeedDelegate>(funcTable, 10963946276172720740UL, Player_GetMoveSpeedFallback);
            Player_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Player_GetNameDelegate>(funcTable, 3887330110002916483UL, Player_GetNameFallback);
            Player_GetSeat = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_GetSeatDelegate>(funcTable, 17967431958788515966UL, Player_GetSeatFallback);
            Player_GetStrafeSpeed = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Player_GetStrafeSpeedDelegate>(funcTable, 1143043326764832914UL, Player_GetStrafeSpeedFallback);
            Player_GetVehicle = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Player_GetVehicleDelegate>(funcTable, 363172629361906086UL, Player_GetVehicleFallback);
            Player_GetVehicleID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) GetUnmanagedPtr<Player_GetVehicleIDDelegate>(funcTable, 11104420334782135737UL, Player_GetVehicleIDFallback);
            Player_IsAiming = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsAimingDelegate>(funcTable, 10629421607559924898UL, Player_IsAimingFallback);
            Player_IsDead = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsDeadDelegate>(funcTable, 15471399568854208587UL, Player_IsDeadFallback);
            Player_IsEnteringVehicle = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsEnteringVehicleDelegate>(funcTable, 5834290451374801205UL, Player_IsEnteringVehicleFallback);
            Player_IsFlashlightActive = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsFlashlightActiveDelegate>(funcTable, 7201780704292694361UL, Player_IsFlashlightActiveFallback);
            Player_IsInCover = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsInCoverDelegate>(funcTable, 16532300556983837945UL, Player_IsInCoverFallback);
            Player_IsInMelee = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsInMeleeDelegate>(funcTable, 9656359974229471670UL, Player_IsInMeleeFallback);
            Player_IsInRagdoll = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsInRagdollDelegate>(funcTable, 13866510163503569909UL, Player_IsInRagdollFallback);
            Player_IsInVehicle = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsInVehicleDelegate>(funcTable, 3966288765716642074UL, Player_IsInVehicleFallback);
            Player_IsJumping = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsJumpingDelegate>(funcTable, 8318404148061760703UL, Player_IsJumpingFallback);
            Player_IsLeavingVehicle = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsLeavingVehicleDelegate>(funcTable, 7801590821162478013UL, Player_IsLeavingVehicleFallback);
            Player_IsOnLadder = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsOnLadderDelegate>(funcTable, 3159353707403506220UL, Player_IsOnLadderFallback);
            Player_IsReloading = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsReloadingDelegate>(funcTable, 4971155693566520612UL, Player_IsReloadingFallback);
            Player_IsShooting = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsShootingDelegate>(funcTable, 877598797571784312UL, Player_IsShootingFallback);
            Player_IsSpawned = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsSpawnedDelegate>(funcTable, 4945769591274906861UL, Player_IsSpawnedFallback);
            Resource_GetConfig = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Resource_GetConfigDelegate>(funcTable, 15645223790185503409UL, Resource_GetConfigFallback);
            Resource_GetCSharpImpl = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Resource_GetCSharpImplDelegate>(funcTable, 10686918322243859526UL, Resource_GetCSharpImplFallback);
            Resource_GetDependants = (delegate* unmanaged[Cdecl]<nint, nint[], int, void>) GetUnmanagedPtr<Resource_GetDependantsDelegate>(funcTable, 4404156737102642473UL, Resource_GetDependantsFallback);
            Resource_GetDependantsSize = (delegate* unmanaged[Cdecl]<nint, int>) GetUnmanagedPtr<Resource_GetDependantsSizeDelegate>(funcTable, 10674428892947305822UL, Resource_GetDependantsSizeFallback);
            Resource_GetDependencies = (delegate* unmanaged[Cdecl]<nint, nint[], int, void>) GetUnmanagedPtr<Resource_GetDependenciesDelegate>(funcTable, 11206926904976161430UL, Resource_GetDependenciesFallback);
            Resource_GetDependenciesSize = (delegate* unmanaged[Cdecl]<nint, int>) GetUnmanagedPtr<Resource_GetDependenciesSizeDelegate>(funcTable, 15677938698042982787UL, Resource_GetDependenciesSizeFallback);
            Resource_GetExport = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Resource_GetExportDelegate>(funcTable, 3953842985170148609UL, Resource_GetExportFallback);
            Resource_GetExports = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], void>) GetUnmanagedPtr<Resource_GetExportsDelegate>(funcTable, 12754801534406772523UL, Resource_GetExportsFallback);
            Resource_GetExportsCount = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<Resource_GetExportsCountDelegate>(funcTable, 2432388310076694681UL, Resource_GetExportsCountFallback);
            Resource_GetImpl = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Resource_GetImplDelegate>(funcTable, 14018893268644185902UL, Resource_GetImplFallback);
            Resource_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Resource_GetNameDelegate>(funcTable, 6005318913847190117UL, Resource_GetNameFallback);
            Resource_GetType = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Resource_GetTypeDelegate>(funcTable, 15497014170537413316UL, Resource_GetTypeFallback);
            Resource_IsStarted = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Resource_IsStartedDelegate>(funcTable, 13917417294839234600UL, Resource_IsStartedFallback);
            Resource_SetExport = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void>) GetUnmanagedPtr<Resource_SetExportDelegate>(funcTable, 15249221947393767886UL, Resource_SetExportFallback);
            Resource_SetExports = (delegate* unmanaged[Cdecl]<nint, nint, nint[], nint[], int, void>) GetUnmanagedPtr<Resource_SetExportsDelegate>(funcTable, 14077927656531124451UL, Resource_SetExportsFallback);
            RmlDocument_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<RmlDocument_GetIDDelegate>(funcTable, 4296832302534320657UL, RmlDocument_GetIDFallback);
            TextLabel_GetColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) GetUnmanagedPtr<TextLabel_GetColorDelegate>(funcTable, 71661853310303691UL, TextLabel_GetColorFallback);
            TextLabel_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<TextLabel_GetIDDelegate>(funcTable, 17469426826709697373UL, TextLabel_GetIDFallback);
            TextLabel_GetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) GetUnmanagedPtr<TextLabel_GetRotationDelegate>(funcTable, 7785535667614932812UL, TextLabel_GetRotationFallback);
            TextLabel_GetScale = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<TextLabel_GetScaleDelegate>(funcTable, 13329021670959257864UL, TextLabel_GetScaleFallback);
            TextLabel_GetTarget = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<TextLabel_GetTargetDelegate>(funcTable, 6781195795327060290UL, TextLabel_GetTargetFallback);
            TextLabel_GetVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<TextLabel_GetVisibleDelegate>(funcTable, 6945663332870319437UL, TextLabel_GetVisibleFallback);
            TextLabel_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<TextLabel_GetWorldObjectDelegate>(funcTable, 8297185820527489834UL, TextLabel_GetWorldObjectFallback);
            TextLabel_IsGlobal = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<TextLabel_IsGlobalDelegate>(funcTable, 17978851917355436422UL, TextLabel_IsGlobalFallback);
            TextLabel_SetColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) GetUnmanagedPtr<TextLabel_SetColorDelegate>(funcTable, 1694191866473087021UL, TextLabel_SetColorFallback);
            TextLabel_SetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation, void>) GetUnmanagedPtr<TextLabel_SetRotationDelegate>(funcTable, 6102843265505169340UL, TextLabel_SetRotationFallback);
            TextLabel_SetScale = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<TextLabel_SetScaleDelegate>(funcTable, 3918260719528326415UL, TextLabel_SetScaleFallback);
            TextLabel_SetVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<TextLabel_SetVisibleDelegate>(funcTable, 2302278843105157392UL, TextLabel_SetVisibleFallback);
            Vehicle_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Vehicle_GetEntityDelegate>(funcTable, 8318093389193375258UL, Vehicle_GetEntityFallback);
            Vehicle_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Vehicle_GetIDDelegate>(funcTable, 17687301249122992283UL, Vehicle_GetIDFallback);
            Vehicle_GetPetrolTankHealth = (delegate* unmanaged[Cdecl]<nint, int>) GetUnmanagedPtr<Vehicle_GetPetrolTankHealthDelegate>(funcTable, 18440829979133890169UL, Vehicle_GetPetrolTankHealthFallback);
            Vehicle_GetWheelsCount = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetWheelsCountDelegate>(funcTable, 6954962557541059864UL, Vehicle_GetWheelsCountFallback);
            VirtualEntity_GetGroup = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<VirtualEntity_GetGroupDelegate>(funcTable, 11281256725988059002UL, VirtualEntity_GetGroupFallback);
            VirtualEntity_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<VirtualEntity_GetIDDelegate>(funcTable, 17591737229607710977UL, VirtualEntity_GetIDFallback);
            VirtualEntity_GetStreamingDistance = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<VirtualEntity_GetStreamingDistanceDelegate>(funcTable, 10283452716932486351UL, VirtualEntity_GetStreamingDistanceFallback);
            VirtualEntity_GetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<VirtualEntity_GetStreamSyncedMetaDataDelegate>(funcTable, 3404456618180296238UL, VirtualEntity_GetStreamSyncedMetaDataFallback);
            VirtualEntity_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<VirtualEntity_GetWorldObjectDelegate>(funcTable, 8487360424823817212UL, VirtualEntity_GetWorldObjectFallback);
            VirtualEntity_HasStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<VirtualEntity_HasStreamSyncedMetaDataDelegate>(funcTable, 15881093532900450049UL, VirtualEntity_HasStreamSyncedMetaDataFallback);
            VirtualEntity_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<VirtualEntity_IsVisibleDelegate>(funcTable, 10693307505511667779UL, VirtualEntity_IsVisibleFallback);
            VirtualEntity_SetVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<VirtualEntity_SetVisibleDelegate>(funcTable, 16962249384814735578UL, VirtualEntity_SetVisibleFallback);
            VirtualEntityGroup_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<VirtualEntityGroup_GetBaseObjectDelegate>(funcTable, 9683760387923149316UL, VirtualEntityGroup_GetBaseObjectFallback);
            VirtualEntityGroup_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<VirtualEntityGroup_GetIDDelegate>(funcTable, 6854495250887664593UL, VirtualEntityGroup_GetIDFallback);
            VirtualEntityGroup_GetStreamingRangeLimit = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<VirtualEntityGroup_GetStreamingRangeLimitDelegate>(funcTable, 2450774800813411012UL, VirtualEntityGroup_GetStreamingRangeLimitFallback);
            VoiceChannel_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<VoiceChannel_GetIDDelegate>(funcTable, 15809352227459172029UL, VoiceChannel_GetIDFallback);
            WebSocketClient_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<WebSocketClient_GetIDDelegate>(funcTable, 5853373970270474941UL, WebSocketClient_GetIDFallback);
            WebView_GetID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<WebView_GetIDDelegate>(funcTable, 5926308654627541549UL, WebView_GetIDFallback);
            WorldObject_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<WorldObject_GetBaseObjectDelegate>(funcTable, 7682733547279772474UL, WorldObject_GetBaseObjectFallback);
            WorldObject_GetDimension = (delegate* unmanaged[Cdecl]<nint, int>) GetUnmanagedPtr<WorldObject_GetDimensionDelegate>(funcTable, 17276300057698662707UL, WorldObject_GetDimensionFallback);
            WorldObject_GetPosition = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<WorldObject_GetPositionDelegate>(funcTable, 13069539607851095701UL, WorldObject_GetPositionFallback);
            WorldObject_SetPosition = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) GetUnmanagedPtr<WorldObject_SetPositionDelegate>(funcTable, 15027192667173077188UL, WorldObject_SetPositionFallback);
        }
    }
}