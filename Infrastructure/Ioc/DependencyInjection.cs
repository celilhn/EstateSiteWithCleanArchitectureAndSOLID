using Application.Extensions;
using Application.Interfaces;
using Application.Logging;
using Application.Mapping;
using Application.Models;
using Application.Services;
using Application.ValidationRules.FluentValidation.MemberShipPlans;
using Application.ValidationRules.FluentValidation.Tag;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration _configuration)
        {
            Configuration configuration = _configuration.Get<Configuration>();
            services.AddSingleton(configuration);
            services.AddDbContext<CacheManagerDbContext>(options => options.UseSqlServer(
                  configuration.DBConnectionText,
                  b => b.MigrationsAssembly(typeof(CacheManagerDbContext).Assembly.FullName)));
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<ICacheManager, CacheManager>();

            /* Cache Manager Services */
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AdressRepository>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IMemberShipPlanService, MemberShipPlanService>();
            services.AddScoped<IMemberShipPlanRepository, MemberShipPlanRepository>();
            
            services.AddScoped<IValidator<Tag>, TagValidator>();
            services.AddScoped<IValidator<MemberShipPlan>, MemberShipPlanValidator>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
