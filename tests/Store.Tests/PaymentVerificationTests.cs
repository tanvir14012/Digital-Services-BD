using Digital_Services_BD.Services;
using Xunit;

namespace Store.Tests;

public class PaymentVerificationTests
{
    [Theory]
    [InlineData(null, null, false)]
    [InlineData("", "", false)]
    [InlineData("valid", null, false)]
    [InlineData("forged", "valid", false)]
    [InlineData("valid", "valid", true)]
    public void InvalidDecryptionCannotAuthenticatePaymentReturn(string? presented, string? expected, bool matches)
        => Assert.Equal(matches, PaymentVerification.Matches(presented, expected));
}
