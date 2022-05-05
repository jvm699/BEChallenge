using BEChallenge.Domain.View;
using BEChallenge.Service;
using BEChallenge.Service.CommandHandler;
using BEChallenge.Service.Commands;
using BEChallenge.Service.Queries;
using BEChallenge.Service.QueryHandler;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<UserAllQuery, List<UserView>>, UserAllQueryHandler>();

            return services;
        }

        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<UserCreateCommand>, UserCreateCommandHandler>();
            services.AddTransient<ICommandHandler<UserDeleteCommand>, UserDeleteCommandHandler>();
            services.AddTransient<ICommandHandler<UserUpdateCommand>, UserUpdateCommandHandler>();
            
            return services;
        }


        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddQueryHandlers();
            services.AddCommandHandlers();
            return services;
        }
    }
}