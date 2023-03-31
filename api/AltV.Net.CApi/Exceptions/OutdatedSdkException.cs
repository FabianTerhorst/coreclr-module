namespace AltV.Net.CApi.Exceptions
{
    public class OutdatedSdkException : Exception
    {
        /** Outdated method or enum name */
        public string OutdatedSubject { get; }
        
        public OutdatedSdkException(string methodName, string message) : base(message)
        {
            OutdatedSubject = methodName;
        }
    }
}