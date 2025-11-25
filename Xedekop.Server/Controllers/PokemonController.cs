using Xedekop.Server.Controllers.Base;
using Xedekop.Server.Data;
using Xedekop.Server.Data.Entities;
using Xedekop.Server.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Xedekop.Server.Controllers
{
    [Route("api/[controller]")]
    public class PokemonController : BaseController<Pokemon>
    {       
        private IUnitOfWork _unitOfWork;
        public PokemonController(ILogger<PokemonController> logger, IUnitOfWork unitOfWork) : base(logger, unitOfWork.GetRepository<IPokeRepository<Pokemon>>())
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{pageIndex}/{pageSize}")]
        public async Task<PaginatedList<Pokemon>> GetPaginatedPokemon(int pageIndex, int pageSize)
        {
            return await PaginatedList<Pokemon>.CreateAsync(_dbSet, pageIndex, pageSize);
        }
    }
}
