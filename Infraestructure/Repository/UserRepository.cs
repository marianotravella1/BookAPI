using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserRepository _userRepository;
        public UserRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
