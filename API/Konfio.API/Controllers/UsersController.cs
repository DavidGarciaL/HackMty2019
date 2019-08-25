using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Konfio.API.DTO_s;
using Konfio.API.Models;
using Konfio.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Konfio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller<User, UserDTO>
    {
        private readonly IAuthenticateService _authService;

        public UsersController(IService<User> service, IMapper mapper, IAuthenticateService authService) : base(service, mapper)
        {
            _authService = authService;
        }

        // POST api/Users/Authenticate
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public ActionResult Authenticate([FromBody] AuthenticateRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AuthenticateResponseDTO response;
            if (_authService.IsAuthenticated(request, out response))
            {
                return Ok(response);
            }

            return Ok("Invalid request");
        }
    }
}
