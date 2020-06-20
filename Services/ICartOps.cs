using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface ICartOps
    {
        Cart CreateCart(int? userId);
        CartViewModel GetCart(int? cartId, int? userId);
        CartItem AddCartItemtoCart(int? cartId, int? userId, int productItemId, int quantity);
        CartItem DeleteCartItemFromCart(int cartId, int cartItemId);
        CartItem UpdateQuantity(int cartItemId, int quantity);
        Cart MergeCarts(int anonymousCartId, int userId);
        bool EmptyCart(int cartId);
    }
}
