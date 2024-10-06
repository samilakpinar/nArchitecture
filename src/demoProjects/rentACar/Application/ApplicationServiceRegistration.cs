using Application.Features.Brands.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        //Bu dosya application katmaı ile ilgili bütün injectionlarımızı yaptığımız yerdir.
        //ÖRN: belleğe gidip mappleme profillerini ekleyecek.Mediatrın eklenemesi. Bütün assemblyi tarıyor.Refectiona konu olan.
        //AddApplicationServices program.cs içerisine ekledik.
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<BrandBusinessRules>(); //servis ayağa kalkarken bir kere instace oluşturacak

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); //Fluent validation
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>)); //Rol bazlı yetkilendirme
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));  //Redis kullanılacak
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;

        }
    }
}
