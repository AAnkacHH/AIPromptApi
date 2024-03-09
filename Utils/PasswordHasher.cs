using PromptAPI.Service;

namespace PromptAPI.Utils;

using System;
using System.Security.Cryptography;

public class PasswordHasher : IPasswordHasher
{
    // The following constants may be adjusted depending on the security requirements.
    private const int SaltSize = 16; // 128 bit 
    private const int KeySize = 32; // 256 bit
    private const int Iterations = 10000; // Number of iterations
    private const string HashAlgorithmName = "SHA256"; // Specifying the hash algorithm explicitly
    
    public string HashPassword(string password)
    {
        var salt = new byte[SaltSize];
        RandomNumberGenerator.Fill(salt); // Securely generate a random salt

        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, new HashAlgorithmName(HashAlgorithmName));
        var hash = pbkdf2.GetBytes(KeySize);
        return Convert.ToBase64String(ConcatenateArrays(salt, hash));
    }
    
    public bool VerifyPassword(string password, string hashedPassword)
    {
        var hashBytes = Convert.FromBase64String(hashedPassword);
        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, new HashAlgorithmName(HashAlgorithmName));
        var hash = pbkdf2.GetBytes(KeySize);
        for (var i = 0; i < KeySize; i++) {
            if (hashBytes[i + SaltSize] != hash[i]) {
                return false;
            }
        }
        return true;
    }

    private byte[] ConcatenateArrays(byte[] first, byte[] second)
    {
        var result = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, result, 0, first.Length);
        Buffer.BlockCopy(second, 0, result, first.Length, second.Length);
        return result;
    }
}
