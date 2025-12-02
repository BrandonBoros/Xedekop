using Xedekop.Server.Controllers.Base;
using Xedekop.Server.Data;
using Xedekop.Server.Data.Entities;
using Xedekop.Server.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Xedekop.Server.Controllers
{
    [Route("api/[controller]")]
    public class OrderItemController : BaseController<OrderItem>
    {
        private IUnitOfWork _unitOfWork;

        public OrderItemController(ILogger<OrderItemController> logger, IUnitOfWork unitOfWork) : base(logger, unitOfWork.GetRepository<IPokeRepository<OrderItem>>())
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("{pokemon}")]
        public IActionResult CreateOrderItem(string pokemon)
        {
            Pokemon? pokemonToAdd = JsonConvert.DeserializeObject<Pokemon>(pokemon);

            if (pokemonToAdd is null)
                return BadRequest("Couldn't create pokemon.");

            var orderItemRepo = _unitOfWork.GetRepository<IPokeOrderItemRepository>();

            OrderItem? orderItem = orderItemRepo.CreateOrderItem(pokemonToAdd);

            if (orderItem is null)
                return BadRequest("Couldn't create OrderItem.");

            return Ok(orderItem);
        }


        [HttpPut("{orderItemId}/{pokemon?}/{quantity?}")]
        public IActionResult CreateOrderItem(int orderItemId, string? pokemon, int? quantity)
        {
            Pokemon? updatedPokemon = JsonConvert.DeserializeObject<Pokemon>(pokemon);

            var orderItemRepo = _unitOfWork.GetRepository<IPokeOrderItemRepository>();

            OrderItem? orderItem = orderItemRepo.UpdateOrderItem(orderItemId, updatedPokemon, quantity);

            if (orderItem is null)
                return BadRequest("Couldn't create OrderItem.");

            return Ok(orderItem);
        }

        [HttpDelete("{orderItemId}")]
        public IActionResult DeleteOrderItem(int orderItemId)
        {
            var orderItemRepo = _unitOfWork.GetRepository<IPokeOrderItemRepository>();

            OrderItem? orderItem = orderItemRepo.DeleteOrderItem(orderItemId);

            if (orderItem is null)
                return BadRequest("Couldn't create OrderItem.");

            return Ok(orderItem);
        }
    }
}
