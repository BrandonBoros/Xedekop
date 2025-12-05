using Microsoft.EntityFrameworkCore;
using PokeApiNet;
using Xedekop.Server.Data.Entities;
using Xedekop.Server.Data.Interfaces;

namespace Xedekop.Server.Data.Repositories
{
    public class PokeOrderItemRepository : PokeGenericRepository<OrderItem>, IPokeOrderItemRepository
    {
        /// <summary>
        /// The constructor for the OrderItemRepository.
        /// </summary>
        /// <param name="db">The Db context of the application.</param>
        /// <param name="logger">The logger for the PokeRepository.</param>
        public PokeOrderItemRepository(AppDbContext db, ILogger<PokeGenericRepository<OrderItem>> logger) : base(db, logger) { }

        public OrderItem CreateOrderItem(int pokemonId, decimal unitPrice)
        {
            OrderItem orderItem = new OrderItem()
            {
                PokemonId = pokemonId,
                Quantity = 1,
                UnitPrice = unitPrice,
            };

            _dbSet.AddAsync(orderItem);
            
            _db.SaveChanges();

            return orderItem;
        }

        public OrderItem? UpdateOrderItem(int id, int pokemonId, decimal? unitPrice, int? quantity = null)
        {
            OrderItem? oldOrderItem = _dbSet.Find(id);
            Console.WriteLine(oldOrderItem.Id);
            OrderItem newOrderItem;


            Console.WriteLine(oldOrderItem == null);
            Console.WriteLine(unitPrice != null);

            if (oldOrderItem == null && unitPrice != null)
            {
                Console.WriteLine("YOOOOOOOOOOOOOOO");
                newOrderItem = CreateOrderItem(pokemonId, (decimal)unitPrice);
            }
            else if (oldOrderItem == null) return null;
            else
            {
                oldOrderItem.PokemonId = pokemonId;
                oldOrderItem.Quantity = quantity ?? oldOrderItem.Quantity;
                oldOrderItem.UnitPrice = unitPrice ?? oldOrderItem!.UnitPrice;

                _dbSet.Update(oldOrderItem);

                newOrderItem = oldOrderItem;
            }

            _db.SaveChanges();

            return newOrderItem;
        }

        public OrderItem? DeleteOrderItem(int id)
        {
            OrderItem? deletedOrderItem = _dbSet.Find(id);

            if (deletedOrderItem == null)
            {
                return null;
            }

            _dbSet.Remove(deletedOrderItem);

            _db.SaveChanges();

            return deletedOrderItem;
        }

    }
}
