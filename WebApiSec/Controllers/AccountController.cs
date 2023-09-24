//#define hours
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApiSec.Model;

namespace WebApiSec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly WebMvcoreSec2DbContext _context;
        private readonly IConfiguration _configuration;

        public AccountController(WebMvcoreSec2DbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        // POST: api/Account/login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("login")]
       
        
        public IActionResult Login(AspNetUser user)
        {
            AspNetUser current;
            
            if (_context.AspNetUsers == null)
            {
                return Problem("Entity set 'WebMvcoreSec2DbContext.AspNetUsers'  is null.");
            }
            current  = _context.AspNetUsers.SingleOrDefault(u=>u.Email==user.Email);
            if(current == null)
            {
                return Problem("User not found");
            }
            else
            {
                var email = new Claim(ClaimTypes.Email, user.Email);
                var role = new Claim(ClaimTypes.Role, "User");
                
                var authClaims = new List<Claim>
                {
                  email, role
                };

                string token = GenerateToken(authClaims);
                
                return Ok(token);
            }
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));
            var _TokenExpiryTimeInHour = Convert.ToInt64(_configuration["JWTKey:TokenExpiryTimeInHour"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWTKey:ValidIssuer"],
                Audience = _configuration["JWTKey:ValidAudience"],
#if hours
                Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
#else
                Expires = DateTime.UtcNow.AddMinutes(1),
#endif
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUser>>> GetUsers()
        {
          if (_context.AspNetUsers == null)
          {
              return NotFound();
          }
            return await _context.AspNetUsers.ToListAsync();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUser>> GetUser(string id)
        {
          if (_context.AspNetUsers == null)
          {
              return NotFound();
          }
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);

            if (aspNetUser == null)
            {
                return NotFound();
            }

            return aspNetUser;
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, AspNetUser aspNetUser)
        {
            if (id != aspNetUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Account
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetUser>> AddUser(AspNetUser aspNetUser)
        {
          if (_context.AspNetUsers == null)
          {
              return Problem("Entity set 'WebMvcoreSec2DbContext.AspNetUsers'  is null.");
          }
            _context.AspNetUsers.Add(aspNetUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserExists(aspNetUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetUser", new { id = aspNetUser.Id }, aspNetUser);
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (_context.AspNetUsers == null)
            {
                return NotFound();
            }
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            _context.AspNetUsers.Remove(aspNetUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetUserExists(string id)
        {
            return (_context.AspNetUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
