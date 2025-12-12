using Microsoft.Extensions.Logging;
using Shop.Domain.Core._Common;
using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.OrderAgg.Dtos;
using Shop.Domain.Core.OrderAgg.Entities;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.UserAgg.Contracts;

namespace Shop.Domain.Service.AppService.OrderAgg
{
    public class OrderAppService(
        IOrderDomainService orderDomainService,
        IUserDomainService uerDomainService,
        IProductDomainService productDomainService,
        ILogger<OrderAppService> _logger) : IOrderAppService
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
            var userWallet = await uerDomainService.GetUserWalletBalance(userId);
            var orderTotalPrice = await orderDomainService.GetOrderTotalPrice(orderId);

            if (userWallet < orderTotalPrice && userWallet != orderTotalPrice)
            {
                return Result<bool>.Failure("موجودی برای پرداخت سفارش ناکافی است.");
            }

            var resultDecreaseWallet = await uerDomainService.DecreaseUserWalletBalance(userId, orderTotalPrice);

            if (resultDecreaseWallet)
            {
                var resultPayOrder = await orderDomainService.PayOrder(orderId);
                if (resultPayOrder)
                {
                    var order = await orderDomainService.GetOrderById(orderId);

                    foreach (var item in order.Items)
                    {
                        await productDomainService.DecreaseStock(item.ProductId, item.Quantity);

                        var product = await productDomainService.GetProductById(item.ProductId);

                        if (product.Stock < 10)
                        {
                            _logger.LogWarning(
                                "موجودی محصول '{ProductName}' با شناسه {ProductId} کم شده است. موجودی فعلی: {Stock}",
                                product.Title,
                                product.Id,
                                product.Stock
                            );
                        }
                    }

                    return Result<bool>.Success("سفارش با موفقیت پرداخت شد.");
                }
                else
                {
                    bool resultBackToWallet = false;
                    while (!resultBackToWallet)
                    {
                        resultBackToWallet =
                            await uerDomainService.IncreaseUserWalletBalance(userId, orderTotalPrice);
                    }

                    return Result<bool>.Failure("خطا در پرداخت سفارش ، مبلغ کسر شده ازحساب شما عودت خواهد شد.");
                }
            }

            return Result<bool>.Failure("خطا در انجام عملیات.");
        }

        public async Task<OrderDetailDto> GetOrderWithDetailById(int id)
        {
            return await orderDomainService.GetOrderWithDetailById(id);
        }

        public async Task<List<OrderSummeryDto>> GetAllOrdersAsync()
        {
            return await orderDomainService.GetAllOrdersAsync();
        }
    }
}