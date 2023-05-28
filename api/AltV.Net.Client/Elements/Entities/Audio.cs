using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client.Elements.Entities
{
    public struct AudioEntity
    {
        public IEntity Entity;
        public uint ScriptId;
    }

    public class Audio : BaseObject, IAudio
    {
        public IntPtr AudioNativePointer { get; }
        public override IntPtr NativePointer => AudioNativePointer;

        public static IntPtr GetBaseObjectNativePointer(ICore core, IntPtr audioNativePointer)
        {
            unsafe
            {
                return core.Library.Client.Audio_GetBaseObject(audioNativePointer);
            }
        }

        public Audio(ICore core, IntPtr audioNativePointer, uint id) : base(core, GetBaseObjectNativePointer(core, audioNativePointer), BaseObjectType.Audio, id)
        {
            AudioNativePointer = audioNativePointer;
        }

        [Obsolete("Use Alt.CreateAudio instead")]
        public Audio(ICore core, string source, float volume, uint category, bool frontend) : this(core, core.CreateAudioPtr(out var id,source, volume, category, frontend), id)
        {
            core.PoolManager.Audio.Add(this);
        }

        public uint AudioCategory
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Audio_GetCategory(AudioNativePointer);
                }
            }

            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Audio_SetCategory(AudioNativePointer, value);
                }
            }
        }

        public bool Looped
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Audio_GetLooped(AudioNativePointer) == 1;
                }
            }

            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Audio_SetLooped(AudioNativePointer, (byte) (value ? 1 : 0));
                }
            }
        }

        public float Volume
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Audio_GetVolume(AudioNativePointer);
                }
            }

            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Audio_SetVolume(AudioNativePointer, value);
                }
            }
        }

        public string Source
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(Core.Library.Client.Audio_GetSource(AudioNativePointer, &size), size);
                }
            }

            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var valuePtr = MemoryUtils.StringToHGlobalUtf8(value);
                    Core.Library.Client.Audio_SetSource(AudioNativePointer, valuePtr);
                    Marshal.FreeHGlobal(valuePtr);
                }
            }
        }

        public double CurrentTime
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Audio_GetCurrentTime(AudioNativePointer);
                }
            }
        }

        public bool FrontendPlay
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Audio_IsFrontendPlay(AudioNativePointer) == 1;
                }
            }
        }

        public double MaxTime
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Audio_GetMaxTime(AudioNativePointer);
                }
            }
        }

        public bool Playing
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Audio_IsPlaying(AudioNativePointer) == 1;
                }
            }
        }

        public void AddOutput(uint scriptId)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.Audio_AddOutput_ScriptId(AudioNativePointer, scriptId);
            }
        }

        public void AddOutput(IEntity entity)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.Audio_AddOutput_Entity(AudioNativePointer, entity.EntityNativePointer);
            }
        }

        public void RemoveOutput(uint scriptId)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.Audio_RemoveOutput_ScriptId(AudioNativePointer, scriptId);
            }
        }

        public void RemoveOutput(IEntity entity)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.Audio_RemoveOutput_Entity(AudioNativePointer, entity.EntityNativePointer);
            }
        }

        public AudioEntity[] GetOutputs()
        {
            unsafe
            {
                CheckIfEntityExists();
                uint size = 0;
                var entityArrayPtr = IntPtr.Zero;
                var entityTypesArrayPtr = IntPtr.Zero;
                var scriptIdArrayPtr = IntPtr.Zero;
                Core.Library.Client.Audio_GetOutputs(AudioNativePointer, &entityArrayPtr, &entityTypesArrayPtr, &scriptIdArrayPtr, &size);

                var entityTypesArray = new byte[size];
                Marshal.Copy(entityTypesArrayPtr, entityTypesArray, 0, (int) size);
                Core.Library.Shared.FreeUInt8Array(entityTypesArrayPtr);

                var entityPtrArray = new IntPtr[size];
                Marshal.Copy(entityArrayPtr, entityPtrArray, 0, (int) size);
                Core.Library.Shared.FreeVoidPointerArray(entityArrayPtr);

                var uintArray = new UIntArray
                {
                    data = scriptIdArrayPtr,
                    size = size,
                    capacity = size
                };

                var scriptIdArray = uintArray.ToArray();
                Core.Library.Shared.FreeUInt32Array(scriptIdArrayPtr);

                var audioEntityArray = new AudioEntity[size];

                for (var i = 0; i < size; i++)
                {
                    var scriptId = scriptIdArray[i];
                    var entityType = (BaseObjectType) entityTypesArray[i];
                    var entityPtr = entityPtrArray[i];
                    var entity = (IEntity) Core.PoolManager.GetOrCreate(Core, entityPtr, entityType);
                    if (entityPtr != IntPtr.Zero && entity is not null)
                    {
                        audioEntityArray[i] = new AudioEntity
                        {
                            Entity = entity,
                            ScriptId = entity.ScriptId
                        };
                    }
                    else
                    {
                        audioEntityArray[i] = new AudioEntity
                        {
                            Entity = null,
                            ScriptId = scriptId
                        };
                    }
                }

                return audioEntityArray;
            }
        }

        public void Pause()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.Audio_Pause(AudioNativePointer);
            }
        }

        public void Play()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.Audio_Play(AudioNativePointer);
            }
        }

        public void Reset()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.Audio_Reset(AudioNativePointer);
            }
        }

        public void Seek(double time)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.Audio_Seek(AudioNativePointer, time);
            }
        }
    }
}