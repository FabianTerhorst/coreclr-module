namespace AltV.Net.Client.Exceptions
{
    public class InvalidStatException : Exception
    {
        public string Stat { get; }

        public InvalidStatException(string stat)
        {
            Stat = stat;
        }

        public override string Message => $"Invalid stat: {Stat}";
    }
}