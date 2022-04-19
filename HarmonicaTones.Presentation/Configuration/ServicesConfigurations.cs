using AutoMapper;
using HT.Domain.Entities.View;
using HT.Presentation.Models;
using HT.Service.Interfaces;
using HT.Service.Services;

namespace HT.Presentation.Configuration
{
    public static class ServicesConfigurations
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IHarmonicaService, HarmonicaService>();

            return services;
        }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<HarmonicaView, HarmonicaViewModel>().ReverseMap();
        }
    }
}