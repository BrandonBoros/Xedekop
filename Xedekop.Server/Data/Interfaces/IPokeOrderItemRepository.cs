using Microsoft.AspNetCore.Mvc;
using Xedekop.Server.Data.Entities;

namespace Xedekop.Server.Data.Interfaces
{
    public interface IPokeOrderItemRepository : IPokeRepository<OrderItem> 
    {
        public OrderItem CreateOrderItem(Pokemon pokemon);

        public OrderItem? UpdateOrderItem(int id, Pokemon? pokemon = null, int? quantity = null);

        public OrderItem? DeleteOrderItem(int id);
    }
}
