using Tactsoft.Service.Services.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tactsoft.Service.Services;

namespace Tactsoft.Service.Dependency
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
           
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IThanaService,ThanaService>();
           
            services.AddScoped<IEmploymentService, EmploymentService>();
            services.AddScoped<IRelativeService, RelativeService>();
            services.AddScoped<IReadingService, ReadingService>();
            services.AddScoped<IWritingService, WritingService>();
            services.AddScoped<ISpeakingService, SpeakingService>();
            services.AddScoped<IIndustryTypeService, IndustryTypeService>();
            services.AddScoped<ICompanySizeService, CompanySizeService>();
            services.AddScoped<ICompanyService, CompanyService>();
        }
    }
}
