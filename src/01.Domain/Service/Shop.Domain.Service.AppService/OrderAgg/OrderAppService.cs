using System.Reflection.Metadata;
using Shop.Domain.Core._Common;
using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.OrderAgg.Entities;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.UserAgg.Contracts;

namespace Shop.Domain.Service.AppService.OrderAgg
{
    public class OrderAppService(IOrderDomainService orderDomainService, IUserAppService userAppService, IProductAppService productAppService) : IOrderAppService
    {
        public async Task<int> CreateOrderFromCart(int userId)
        {
            return await orderDomainService.CreateOrderFromCart(userId);
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await orderDomainService.GetOrderById(orderId);
        }

        public async Task<Result<bool>> PayOrder(int orderId, int userId)
        {
            //مایگریشن استاتوس اوردر یادت نره

            // get user wallet
            // get order total price
            // check if it is allowed
            var userWallet = await userAppService.GetUserWalletBalance(userId);
            var orderTotalPrice = await orderDomainService.GetOrderTotalPrice(orderId);

            if (userWallet < orderTotalPrice && userWallet != orderTotalPrice)
            {
                return Result<bool>.Failure("موجودی برای پرداخت سفارش ناکافی است.");
            }

            //decrease user wallet
            var resultDecreaseWallet = await userAppService.DecreaseUserWalletBalance(userId, orderTotalPrice);

            //update order paid
            if (resultDecreaseWallet)
            {
                var resultPayOrder = await orderDomainService.PayOrder(orderId);
                if (resultPayOrder)
                {
                    // update product stock , product.stock - orderItem.Quantity
                    var order = await orderDomainService.GetOrderById(orderId);

                    foreach (var item in order.Items)
                    {
                        await productAppService.DecreaseStock(item.ProductId, item.Quantity);
                    }

                    return Result<bool>.Success("سفارش با موفقیت پرداخت شد.");
                }
                else
                {
                    bool resultBackToWallet = false;
                    while (!resultBackToWallet)
                    {
                        resultBackToWallet = await userAppService.IncreaseUserWalletBalance(userId, orderTotalPrice);
                    }
                    return Result<bool>.Failure("خطا در پرداخت سفارش ، مبلغ کسر شده ازحساب شما عودت خواهد شد.");
                }
            }

            return Result<bool>.Failure("خطا در انجام عملیات.");
        }
    }
}