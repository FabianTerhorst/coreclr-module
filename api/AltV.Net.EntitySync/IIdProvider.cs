namespace AltV.Net.EntitySync
{
    /// <summary>
    /// Custom id provider to generate unique ids
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIdProvider<T>
    {
        /// <summary>
        /// Returns the next free id
        /// </summary>
        /// <returns>Next free id</returns>
        T GetNext();

        /// <summary>
        /// Tell the provider that the given id is not in use anymore and can be reused
        /// </summary>
        /// <param name="id">id to reuse</param>
        void Free(T id);
    }
}