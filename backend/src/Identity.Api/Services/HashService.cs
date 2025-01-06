using System.Security.Cryptography;
using System.Text;

namespace Identity.Api.Services;

public class HashService
{
    public string GetStringHash(string input)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        
        return BitConverter.ToString(bytes).Replace("-", string.Empty);
    }
}