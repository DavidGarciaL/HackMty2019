using AutoMapper;
using Konfio.API.DTO_s;
using Konfio.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.Helpers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Transactions, TransactionsDTO>();
            CreateMap<TransactionsDTO, Transactions>();
        }
    }
}
