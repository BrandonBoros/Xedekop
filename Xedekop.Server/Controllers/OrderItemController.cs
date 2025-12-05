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

        [HttpPost("{pokemonId?}/{unitPrice}")]
        public IActionResult CreateOrderItem(int pokemonId, decimal unitPrice)
        {
            var orderItemRepo = _unitOfWork.GetRepository<IPokeOrderItemRepository>();

            OrderItem? orderItem = orderItemRepo.CreateOrderItem(pokemonId, unitPrice);

            if (orderItem is null)
                return BadRequest("Couldn't create OrderItem.");

            return Ok(orderItem);
        }


        [HttpPut("{orderItemId}/{pokemonId?}/{unitPrice?}/{quantity?}")]
        public IActionResult UpdateOrderItem(int orderItemId, int pokemonId, decimal? unitPrice, int? quantity)
        {
            var orderItemRepo = _unitOfWork.GetRepository<IPokeOrderItemRepository>();

            OrderItem? orderItem = orderItemRepo.UpdateOrderItem(orderItemId, pokemonId, unitPrice, quantity);

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
