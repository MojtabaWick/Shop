using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;
using Shop.Presentation.RazorPages.DataBase;

namespace Shop.Presentation.RazorPages.Services.OnlineCartItem
{
    public class OnlineCartItemService(IUserAppService userAppService) : IOnlineCartItemService
    {
        public void AddOnlineCartItem(int productId)
        {
            var newOnlineCartItem = new Models.OnlineCartItem()
            {
                ProductId = productId,
                Quantity = 1,
            };
            InMemoryDataBase.OnlineCartItems.Add(newOnlineCartItem);
        }

        public void AddOnlineCartItemsToDataBase(int userId)
        {
            var newCatItemsList = new List<CartItemInputDto>();

            foreach (var item in InMemoryDataBase.OnlineCartItems)
            {
                var newCartItemInput = new CartItemInputDto()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UserId = userId,
                };
                newCatItemsList.Add(newCartItemInput);
            }

            userAppService.AddListCartItems(newCatItemsList);
        }
    }
}