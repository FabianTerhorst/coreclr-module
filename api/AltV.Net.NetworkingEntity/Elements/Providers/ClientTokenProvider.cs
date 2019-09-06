using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AltV.Net.NetworkingEntity.Elements.Providers
{
    /// <summary>
    /// client token provider
    /// </summary>
    public class ClientTokenProvider : IIdProvider<string>
    {
        private readonly HashSet<string> generatedTokens = new HashSet<string>();

        public string GetNext() => GenerateToken(128);

        public void Free(string token)
        {
            generatedTokens.Remove(token);
        }

        private const string CharSet =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789?=:;_+*ß.,<>%$§!&()^°@€-";

        private string GenerateToken(int size)
        {
            while (true)
            {
                var chars = CharSet.ToCharArray();
                var data = new byte[1];
                var crypto = new RNGCryptoServiceProvider();
                crypto.GetNonZeroBytes(data);
                data = new byte[size];
                crypto.GetNonZeroBytes(data);
                var result = new StringBuilder(size);
                foreach (var b in data)
                {
                    result.Append(chars[b % chars.Length]);
                }

                var token = result.ToString();
                if (generatedTokens.Contains(token)) continue;
                generatedTokens.Add(token);
                return token;
            }
        }
    }
}