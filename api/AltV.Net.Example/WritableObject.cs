namespace AltV.Net.Example
{
    public class WritableObject : IWritable
    {
        private readonly string test;

        public WritableObject()
        {
            test = "123";
        }

        public void OnWrite(IMValueWriter writer)
        {
            writer.BeginObject();
            writer.Name("test");
            writer.Value(test);
            writer.EndObject();
        }
    }
}