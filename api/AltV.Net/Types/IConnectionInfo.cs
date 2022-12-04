using System.Collections.Generic;

namespace AltV.Net.Types;

public interface IConnectionInfo : INative
{
    string Name { get; }
    ulong SocialClubId { get; }
    ulong HardwareIdHash { get; }
    ulong HardwareIdExHash { get; }
    string AuthToken { get; }
    bool IsDebug { get; }
    string Branch { get; }
    uint Build { get; }
    string CdnUrl { get; }
    ulong PasswordHash { get; }
    string Ip { get; }
    long DiscordUserId { get; }

    void Accept(bool sendNames = true);
    void Decline(string reason);
    
    /// <summary>
    /// Sets a value with a given on an entity.
    /// </summary>
    /// <remarks>Data is accessible only within the resource that set the data.</remarks>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void SetData(string key, object value);

    /// <summary>
    /// Returns data for a given key.
    /// </summary>
    /// <remarks>Data is accessible only within the resource that set the data.</remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    bool GetData<T>(string key, out T result);

    /// <summary>
    /// Checks if the entity has a value for the given key.
    /// </summary>
    /// <remarks>Data is accessible only within the resource that set the data.</remarks>
    /// <param name="key"></param>
    /// <returns></returns>
    bool HasData(string key);

    /// <summary>
    /// Returns all stored data keys retrievable with <see cref="GetData{T}(string, out T)"/>
    /// </summary>
    /// <returns>IEnumerable</returns>
    IEnumerable<string> GetAllDataKeys();

    /// <summary>
    /// Deletes a value by a given key from the entity.
    /// </summary>
    /// <remarks>Data is accessible only within the resource that set the data.</remarks>
    /// <param name="key"></param>
    void DeleteData(string key);

    /// <summary>
    /// Deletes all set data from the entity.
    /// </summary>
    /// <remarks>Data is accessible only within the resource that set the data.</remarks>
    void ClearData();
}
