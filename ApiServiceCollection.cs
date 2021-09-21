namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiServiceCollection
    {

        public static IServiceCollection AddBankApiDependencies(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            return services;
        }

    }
}