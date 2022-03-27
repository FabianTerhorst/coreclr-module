namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedPlayer : ISharedEntity
    {
        /// <summary>
        /// Returns the players alt:V username
        /// </summary>
        public string Name { get; }
    }
}