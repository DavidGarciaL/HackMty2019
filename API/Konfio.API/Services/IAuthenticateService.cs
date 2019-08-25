using Konfio.API.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.Services
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(AuthenticateRequestDTO request, out AuthenticateResponseDTO response);
    }
}
