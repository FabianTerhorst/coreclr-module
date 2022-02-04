namespace AltV.Net.Types;

public interface IRefCountable : INative
{
    bool AddRef();

    bool RemoveRef();
}