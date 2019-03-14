namespace AltV.Net
{
    //TODO: maybe deprecate this, because its a duplicate of the adapters
    public interface IWritable
    {
        void OnWrite(IMValueWriter writer);
    }
}