using Microsoft.AspNetCore.Mvc;
using Xedekop.Server.Data.Entities;

namespace Xedekop.Server.Data.Interfaces
{
    public interface IPokeOrderItemRepository : IPokeRepository<OrderItem> 
    {
        public OrderItem CreateOrderItem(int pokemonId, decimal unitPrice);

        public OrderItem? UpdateOrderItem(int id, int pokemonId, decimal? unitPrice, int? quantity = null);

        public OrderItem? DeleteOrderItem(int id);
    }
}
