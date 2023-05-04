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

    public TextLabel(ICore core, IntPtr worldObjectPointer, uint id) : base(core, GetWorldObjectPointer(core, worldObjectPointer), BaseObjectType.TextLabel, id)
    {
        TextLabelNativePointer = worldObjectPointer;
    }

    public TextLabel(ICore core, string name, string fontName, float fontSize, float scale, Position pos,
        Rotation rot, Rgba color, float outlineWidth, Rgba outlineColor, bool useStreaming, uint streamingDistance) : this(core,
        core.CreateTextLabelPtr(out var id, name, fontName, fontSize, scale, pos,
            rot, color, outlineWidth, outlineColor, useStreaming, streamingDistance), id)
    {
        core.PoolManager.TextLabel.Add(this);
    }

    public IntPtr TextLabelNativePointer { get; }
    public override IntPtr NativePointer => TextLabelNativePointer;

    public bool IsRemote
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.TextLabel_IsRemote(TextLabelNativePointer) == 1;
            }
        }
    }

    public ulong RemoteId
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.TextLabel_GetRemoteID(TextLabelNativePointer);
            }
        }
    }

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
}