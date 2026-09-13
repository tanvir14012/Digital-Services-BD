using System.Security.Cryptography;
using System.Text;

namespace Digital_Services_BD.Services;

public static class PaymentVerification
{
    public static bool Matches(string? presented, string? expected) =>
        !string.IsNullOrEmpty(presented) && !string.IsNullOrEmpty(expected)
        && CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(presented), Encoding.UTF8.GetBytes(expected));
}
