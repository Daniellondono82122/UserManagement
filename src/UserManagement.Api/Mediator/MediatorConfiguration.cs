namespace UserManagement.Api.Mediator
{
    using System.Reflection;
    using MediatR;
    public static class MediatorConfiguration
    {
        private static readonly List<string> AssemblyList = new List<string>
        {
            "UserManagement.Data",
            "UserManagement.Services"
        };

        public static void AddMediatRConf(this IServiceCollection services)
        {
            foreach (var assembly in AssemblyList.Select(Assembly.Load)) services.AddMediatR(assembly);
        }
    }
}
