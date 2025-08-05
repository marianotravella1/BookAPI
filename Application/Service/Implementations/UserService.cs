using Application.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Implementations
{
    public class UserService
    {
        private readonly IUserService _userService;
        public UserService(IUserService userService)
        {
            _userService = userService;
        }
    }
}
