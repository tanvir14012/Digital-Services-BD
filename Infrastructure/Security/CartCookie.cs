using System.Globalization;
using System.Security.Cryptography;
using Digital_Services_BD.Constants;
using Microsoft.AspNetCore.DataProtection;

namespace Digital_Services_BD.Infrastructure.Security;

public sealed class CartCookie(IDataProtectionProvider provider)
{
    private readonly IDataProtector protector = provider.CreateProtector("Store.Cart.v1");

    public int? Read(HttpRequest request)
    {
        var value = request.Cookies[StoreDefaults.CartCookie];
        if (string.IsNullOrEmpty(value)) return null;
        try
        {
            return int.TryParse(protector.Unprotect(value), NumberStyles.None, CultureInfo.InvariantCulture, out var id) && id > 0 ? id : null;
        }
        catch (CryptographicException) { return null; }
    }

    public void Write(HttpResponse response, long id) => response.Cookies.Append(
        StoreDefaults.CartCookie, protector.Protect(id.ToString(CultureInfo.InvariantCulture)),
        new CookieOptions { HttpOnly = true, Secure = true, SameSite = SameSiteMode.Lax, IsEssential = true,
            Expires = DateTimeOffset.UtcNow.AddMonths(6) });
}
