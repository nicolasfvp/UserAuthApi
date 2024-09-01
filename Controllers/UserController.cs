using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserAuthApi.Models; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserAuthApi.Context;
using Microsoft.EntityFrameworkCore;

namespace UserAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
         private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly UserDbContext _context;
        public AccountController(UserManager<IdentityUser> userManager, IConfiguration configuration, UserDbContext context)
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            var user = new IdentityUser { UserName = model.Nome, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Senha);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("User created successfully!");
        }

        [HttpPost("login")] 
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Senha))
            {
                var token = TokenService(user);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        [HttpPost("change-password")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByEmailAsync(userEmail);
            var result = await _userManager.ChangePasswordAsync(user, model.SenhaAtual, model.SenhaNova);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Password changed successfully!");
        }

        [HttpGet("get-metrics")]
        public async Task<ActionResult<IEnumerable<Metrics>>> GetMetrics()
        {
            return await _context.Metrics.ToListAsync();
        }

        [HttpPost("post-metrics")]
        public async Task<ActionResult<Metrics>> PostMetrics(Metrics metrics)
        {
            _context.Metrics.Add(metrics);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMetrics), new { id = metrics.Id }, metrics);
        }

        [HttpGet("get-orders")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders
            .Where(order => order.Status != "Inativo")
            .ToListAsync();
        }

        [HttpPost("post-orders")]
        public async Task<ActionResult<Orders>> PostOrders(Orders orders)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrders), new { id = orders.Id }, orders);
        }

        private string TokenService(IdentityUser user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var issuer = _configuration.GetValue<dynamic>("Jwt:Issuer");
            var audience = _configuration.GetValue<dynamic>("Jwt:Audience");
            var KeyJwt = _configuration.GetValue<dynamic>("Jwt:Key");
            var key = Encoding.UTF8.GetBytes(KeyJwt);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
             }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}