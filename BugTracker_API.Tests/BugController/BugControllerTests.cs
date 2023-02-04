using AutoMapper;
using BugTracker_API.Controllers;
using BugTracker_API.Models;
using BugTracker_API.Models.Dto;
using BugTracker_API.Repository.IRepository;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker_API.Tests.BugController
{
    public class BugControllerTests
    {
        private readonly IBugRepository _dbBug;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public BugControllerTests()
        {
            _dbBug = A.Fake<IBugRepository>();
            _mapper = A.Fake<IMapper>();
            this._response= new ();
        }

        [Fact]
        public void BugAPIController_GetBugs_ReturnOk()
        {
            //Arrange
            var apiResponse = new APIResponse();
            var bugsList = A.Fake<IEnumerable<Bug>>();
            var controller = new BugAPIController(_dbBug, _mapper);
            _response.Result = A.CallTo(() =>_mapper.Map<List<BugDTO>>(bugsList));

            //Act
            var result = controller.GetBugs();
            //apiResponse.StatusCode.Should().;

            //Assert
            result.Should().NotBeNull();
            //result.Should().BeOfType(typeof(APIResponse));
        }
    }
}
