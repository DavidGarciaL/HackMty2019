using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Konfio.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Konfio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller<T, Z> : ControllerBase where T : class where Z : class
    {
        protected readonly IService<T> _service;
        protected readonly IMapper _mapper;

        protected Guid SignedUserId
        {
            get
            {
                // GET UserId
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claimNameIdentifier = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                Guid.TryParse(claimNameIdentifier.Value, out Guid userId);
                return userId;
            }
        }

        protected string SignedRfc
        {
            get
            {
                // GET UserRFC
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claimNameIdentifier = claimsIdentity.FindFirst(ClaimTypes.Name);
                return claimNameIdentifier.Value;
            }
        }

        public Controller(IService<T> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/[controller]
        [HttpGet]
        [Authorize]
        public virtual ActionResult<IEnumerable<Z>> Get()
        {
            var result = _mapper.Map<IEnumerable<Z>>(_service.GetAll());
            return Ok(result);
        }

        // GET api/[controller]/5
        [HttpGet("{id}")]
        [Authorize]
        public virtual async Task<ActionResult<Z>> Get(Guid id)
        {
            var result = _mapper.Map<Z>(await _service.GetAsync(id));
            return Ok(result);
        }
    }
}
