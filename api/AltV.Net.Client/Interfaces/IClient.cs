namespace AltV.Net.Client.Interfaces
{
    public interface IClient
    {

        #region Shared
        
        bool IsDebug { get; }
        string Version { get; }
        string Branch { get; }
        
        //MValueNone CreaeMValueNone();
        //MValueNil CreateMValueNil();
        //MValueBool CreateMValueBool(bool val);
        //MValueInt CreateMValueInt(int val);
        //MValueUInt CreateMValueUInt(uint64_t val);
        //MValueDouble CreateMValueDouble(double val);
        //MValueString CreateMValueString(String val);
        //MValueList CreateMValueList(Size size = 0);
        //MValueDict CreateMValueDict();
        //MValueFunction CreateMValueFunction(IntPtr impl);
        //MValueVector2 CreateMValueVector2(Vector2 val);
        //MValueVector3 CreateMValueVector3(Vector3 val);
        //MValueRGBA CreateMValueRGBA(RGBA val);
        //MValueByteArray CreateMValueByteArray(byte[] val);
        //IResource GetResource(string name);
        //IResource GetResource(IntPtr resourcePointer);
        //IEntity GetEntityById(int id);
        //IEntity[] GetEntities();
        //IPlayer[] GetPlayers();
        //IVehicle[] GetVehicles();
        //IBlip[] GetBlips();
        //MValueConst GetMetaData(string key);
        void SetMetaData(string key, object value);
        void DeleteMetaData(string key);
        bool HasSyncedMetaData(string key);
        //MValueConst GetSyncedMetaData(string key);
        //IPermission[] GetRequiredPermissions();
        //IPermission[] GetOptionalPermissions();
        void LogInfo(string message);
        void LogDebug(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogColored(string message);
        uint Hash(string value);
        bool FileExists(string path);
        string ReadFile(string path);
        void TriggerLocalEvent(string eventName, params object[] args);
        bool HasMetaData(string key);
        #endregion
    }
}