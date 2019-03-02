namespace AltV.Net
{
    public interface IMValueBaseAdapter
    {
        object FromMValue(IMValueReader reader);

        void ToMValue(object obj, IMValueWriter writer);
    }
}