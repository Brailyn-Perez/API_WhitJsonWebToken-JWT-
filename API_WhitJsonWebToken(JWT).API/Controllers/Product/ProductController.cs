using API_WhitJsonWebToken_JWT_.API.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_WhitJsonWebToken_JWT_.API.Controllers.Product
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiJwtContext _context;
        public ProductController(ApiJwtContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var list = _context.Products.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new {value = list});
        }
    }
}
