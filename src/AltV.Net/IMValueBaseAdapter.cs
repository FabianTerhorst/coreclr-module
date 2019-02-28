namespace AltV.Net
{
    public interface IMValueBaseAdapter
    {
        object FromMValue(MValueReader reader);

        void ToMValue(object obj, MValueWriter writer);
    }
}