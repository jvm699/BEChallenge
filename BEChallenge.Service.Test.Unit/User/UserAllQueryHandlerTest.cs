using BEChallenge.Domain;
using BEChallenge.Domain.Entities;
using BEChallenge.Domain.View;
using BEChallenge.Service.Queries;
using BEChallenge.Service.QueryHandler;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BEChallenge.Service.Test.Unit
{
    public class UserAllQueryHandlerTest
    {
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly Mock<IRepository<User>> mockUserRepository;

        public UserAllQueryHandlerTest()
        {
            this.mockUnitOfWork = new Mock<IUnitOfWork>();
            this.mockUserRepository = new Mock<IRepository<User>>();
        }

        [Fact]
        public async Task ReturnUsers_WhenExist()
        {
            UserAllQuery query = new UserAllQuery();

            UserAllQueryHandler target = new UserAllQueryHandler(this.mockUnitOfWork.Object);

            this.mockUnitOfWork.Setup(x => x.UserRepository).Returns(this.mockUserRepository.Object);

            List<User> users = new List<User> { new User(1, "test", DateTime.Today, true) };
            this.mockUserRepository.Setup(x => x.AllAsNoTracking()).Returns(users.AsQueryable().BuildMock());

            List<UserView> view = await target.Handle(query);

            // assert
            Assert.NotEmpty(view);
        }
    }
}
