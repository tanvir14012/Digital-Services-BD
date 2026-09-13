using Digital_Services_BD.Constants;
using Digital_Services_BD.Infrastructure.Security;
using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Digital_Services_BD.Infrastructure.Filters;

public sealed class LayoutDataFilter(IProductGroupOps groups, ICartOps carts, CartCookie cookie,
    UserManager<Customer> users, IAuthorizationService authorization) : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ViewResult view && !string.Equals(context.RouteData.Values["action"]?.ToString(), "Error", StringComparison.OrdinalIgnoreCase))
        {
            var user = context.HttpContext.User;
            view.ViewData["LayoutSignedIn"] = user.Identity?.IsAuthenticated == true;
            view.ViewData["LayoutFirstName"] = user.Identity?.IsAuthenticated == true
                ? (await users.GetUserAsync(user))?.FirstName : null;
            view.ViewData["LayoutIsAdmin"] = (await authorization.AuthorizeAsync(user, StoreDefaults.AdminPolicy)).Succeeded;
            if (!string.Equals(context.RouteData.Values["controller"]?.ToString(), "Admin", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(context.RouteData.Values["controller"]?.ToString(), "ProductStocks", StringComparison.OrdinalIgnoreCase))
            {
                view.ViewData["LayoutProductGroups"] = await groups.GetProductGroupsWithNavigation();
                var cartId = cookie.Read(context.HttpContext.Request);
                view.ViewData["LayoutCartCount"] = cartId.HasValue ? await carts.GetCartItemCount(cartId.Value) : 0;
            }
        }
        await next();
    }
}
