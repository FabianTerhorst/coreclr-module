using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class TextLabel : WorldObject, ITextLabel
{
    public static IntPtr GetWorldObjectPointer(ICore core, IntPtr nativePointer)
    {
        unsafe
        {
            return core.Library.Shared.TextLabel_GetWorldObject(nativePointer);
        }
    }

    public TextLabel(ICore core, IntPtr worldObjectPointer, uint id) : base(core,
        GetWorldObjectPointer(core, worldObjectPointer), BaseObjectType.TextLabel, id)
    {
        TextLabelNativePointer = worldObjectPointer;
    }

    public IntPtr TextLabelNativePointer { get; }
    public override IntPtr NativePointer => TextLabelNativePointer;

    public bool IsGlobal
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.TextLabel_IsGlobal(TextLabelNativePointer) == 1;
            }
        }
    }

    public IPlayer Target
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                var entityPointer = Core.Library.Shared.TextLabel_GetTarget(TextLabelNativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Core.PoolManager.Player.Get(entityPointer);
            }
        }
    }

    public Rgba Color
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                var color = Rgba.Zero;
                Core.Library.Shared.TextLabel_GetColor(TextLabelNativePointer, &color);
                return color;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.TextLabel_SetColor(TextLabelNativePointer, value);
            }
        }
    }

    public bool Visible
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.TextLabel_IsVisible(TextLabelNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.TextLabel_SetVisible(TextLabelNativePointer, (byte) (value ? 1 : 0));
            }
        }
    }

    public float Scale
    {
        get
        {
            unsafe
            {
                return Core.Library.Shared.TextLabel_GetScale(TextLabelNativePointer);
            }
        }
        set
        {
            unsafe
            {
                Core.Library.Shared.TextLabel_SetScale(TextLabelNativePointer, value);
            }
        }
    }

    public Rotation Rotation
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                var directon = Rotation.Zero;
                Core.Library.Shared.TextLabel_GetRotation(TextLabelNativePointer, &directon);
                return directon;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.TextLabel_SetRotation(TextLabelNativePointer, value);
            }
        }
    }

    public uint StreamingDistance
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.TextLabel_GetStreamingDistance(TextLabelNativePointer);
            }
        }
    }

    public bool IsStreamedIn
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.TextLabel_IsStreamedIn(TextLabelNativePointer) == 1;
            }
        }
    }

    public bool IsFacingCamera
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.TextLabel_IsFacingCamera(TextLabelNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.TextLabel_SetFaceCamera(TextLabelNativePointer, value ? (byte) 1 : (byte) 0);
            }
        }
    }
}