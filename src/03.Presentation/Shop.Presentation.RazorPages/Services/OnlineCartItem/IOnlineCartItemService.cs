namespace Shop.Presentation.RazorPages.Services.OnlineCartItem
{
    public interface IOnlineCartItemService
    {
        public void AddOnlineCartItem(int productId);

        public void AddOnlineCartItemsToDataBase(int userId);
    }
}