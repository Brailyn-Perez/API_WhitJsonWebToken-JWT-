using API_WhitJsonWebToken_JWT_.API.Context;
using API_WhitJsonWebToken_JWT_.API.Customs;
using API_WhitJsonWebToken_JWT_.API.DTOS.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_WhitJsonWebToken_JWT_.API.Controllers.User
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly ApiJwtContext _context;
        private readonly Utilitys _utilitys;
        public AccessController(ApiJwtContext context, Utilitys utilitys)
        {
            _context = context;
            _utilitys = utilitys;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(CreateUserDTO createUser)
        {
            
            var user = new Entities.User()
            {
                Name = createUser.Name,
                EMail = createUser.EMail,
                Password = _utilitys.encryptSHA256(createUser.Password)
            };

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            if (user.Id != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUsersDTO loginUsers)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false});
            }
            var findUser = await _context.Users
                .Where(
                x => x.EMail == loginUsers.EMail &&
                x.Password == _utilitys.encryptSHA256(loginUsers.Password)
                ).FirstOrDefaultAsync();

            if (findUser == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilitys.generateJWT(findUser) });
        }
    }
}
