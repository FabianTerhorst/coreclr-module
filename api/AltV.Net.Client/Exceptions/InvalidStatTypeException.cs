namespace AltV.Net.Client.Exceptions
{
    public class InvalidStatTypeException : Exception
    {
        public string StatName { get; }
        public Type ProvidedType { get; }
        public Type NeededType { get; }

        public InvalidStatTypeException(string statName, Type providedType, Type neededType)
        {
            StatName = statName;
            ProvidedType = providedType;
            NeededType = neededType;
        }

        public override string Message => $"Specified type doesn't match stat {StatName} type. Stat type is {NeededType} but specified type is {ProvidedType}";
    }
}