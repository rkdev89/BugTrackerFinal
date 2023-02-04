using AutoMapper;
using BugTracker_API.Models;
using BugTracker_API.Repository.IRepository;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker_API.Tests.UserController
{
    public class UserControllerTests
    {
        protected APIResponse _response;
        private readonly IUserRepository _dbUser;
        private readonly IMapper _mapper;

        public UserControllerTests()
        {
            _mapper = A.Fake<IMapper>();
            _dbUser = A.Fake<IUserRepository>();
            this._response = new();
        }
    }
}
