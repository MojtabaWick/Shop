using Shop.Domain.Core.UserAgg.Entities;
using Shop.Presentation.RazorPages.Models;

namespace Shop.Presentation.RazorPages.DataBase
{
    public class InMemoryDataBase
    {
        public static OnlineUser? OnlineUser { get; set; }
    }
}