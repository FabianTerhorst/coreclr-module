using System.Numerics;
 using WebAssembly;
 
 namespace AltV.Net.Client.Elements.Entities
 {
     public class Entity : WorldObject, IEntity
     {
         public int Id => (int) jsObject.GetObjectProperty("id");
         public int Model => (int) jsObject.GetObjectProperty("model");
         public int ScriptId => (int) jsObject.GetObjectProperty("scriptID");

         public Vector3 Rotation
         {
             get
             {
                 var vector3Obj = (JSObject) jsObject.GetObjectProperty("rot");
                 return new Vector3((float) vector3Obj.GetObjectProperty("x"), (float) vector3Obj.GetObjectProperty("y"),(float) vector3Obj.GetObjectProperty("z"));
             }
             set
             {
                 var vector3Obj = Runtime.NewJSObject();
                 vector3Obj.SetObjectProperty("x", value.X);
                 vector3Obj.SetObjectProperty("y", value.Y);
                 vector3Obj.SetObjectProperty("z", value.Z);
                 jsObject.SetObjectProperty("rot", vector3Obj);
             }
         }

         public Entity(JSObject jsObject): base(jsObject)
         {
             
         }

         public bool TryGetSyncedMetaData<T>(string key, out T value)
         {
             var dataValue = jsObject.Invoke("getSyncedMeta", key);
             if (dataValue is T dataTValue)
             {
                 value = dataTValue;
                 return true;
             }

             value = default;
             return false;
         }
     }
 }