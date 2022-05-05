using BEChallenge.Domain;
using BEChallenge.Domain.View;
using BEChallenge.Service.Queries;
using Microsoft.EntityFrameworkCore;

namespace BEChallenge.Service.QueryHandler
{
    public class UserAllQueryHandler : IQueryHandler<UserAllQuery, List<UserView>>
    {
        readonly IUnitOfWork unitOfWork;

        public UserAllQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<List<UserView>> Handle(UserAllQuery query)
        {
            return await this.unitOfWork.UserRepository.AllAsNoTracking()
                .Select(x => new UserView() 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    Active = x.Active
                })
                .ToListAsync();
        }
    }
}
