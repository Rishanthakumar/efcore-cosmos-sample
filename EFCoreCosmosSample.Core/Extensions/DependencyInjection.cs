using EFCoreCosmosSample.Core.Interfaces.Services;
using EFCoreCosmosSample.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreCosmosSample.Core.Extensions
{
    public static class DependencyInjection
    {
		public static void AddCoreServices(this IServiceCollection services)
		{
			services
				.AddScoped<IFamliyService, FamilyService>();
		}
	}
}
