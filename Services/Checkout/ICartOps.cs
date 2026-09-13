using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;

namespace Digital_Services_BD.Services
{
    public interface ICartOps
    {
        Task<Cart> CreateCart(string userId);
        Task<CartViewModel> GetCart(int? cartId);
        Task<int> GetCartItemCount(int cartId);
        Task<AddCartItemViewModel> AddCartItemtoCart(int cartId, string userId, int productItemId, int quantity);
        Task<AddCartItemBundleViewModel> AddProductItemBundletoCart(int cartId, string userId, int productItemBundleId, int quantity);
        Task<bool> DeleteProductItemBundleFromCart(int cartId, int productItemBundleId);
        Task<CartProductItemBundle> UpdateProductItemBundleQuantity(int cartId, int productItemBundleId, int quantity);
        Task<CartItem> DeleteCartItemFromCart(int cartId, int cartItemId);
        Task<CartItem> UpdateQuantity(int cartItemId, int quantity);
        Task<Cart> MergeCarts(int anonymousCartId, string userId);
        Task<bool> EmptyCart(int cartId);
        Task<bool> DoesCartExist(int cartId);
        Task<bool> DeleteCart(int cartId);
        Task<int> GetUserCartId(string userId);
        Task<Cart> RemoveOutOfStockItems(int cartId);
        Task<IList<ProductItemAndQty>> GetOutOfStockCartProductItems(int cartId);
    }
}
