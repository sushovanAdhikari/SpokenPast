using Donde.SpokenPast.Bootstrapper;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Donde.SpokenPast.Core.Services.Services;
using Donde.SpokenPast.Infrastructure.Repositories;
using Donde.SpokenPast.Infrastructure.Repositories;
using Donde.SpokenPast.Web.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System.Reflection;

namespace Donde.SpokenPast.Web
{
    public class Startup
    {

        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            Configuration = config as IConfigurationRoot;        
            CurrentEnvironment = env;
        }

        public IConfigurationRoot Configuration { get; }
        private IHostingEnvironment CurrentEnvironment { get; }
        private Container container = new Container();

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            IntegrateSimpleInjector(services);
            services.AddOptions();

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddDondeOData(Configuration);

            services.AddMvc();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //container.Register<IAugmentObjectService, AugmentObjectService>(Lifestyle.Scoped);

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));

            services.UseSimpleInjectorAspNetRequestScoping(container);

        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));


            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, VersionedODataModelBuilder modelBuilder, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            this.container.RegisterMvcControllers(app);
            app.UseMvc(builder => { builder.BuildDondeOData(modelBuilder); });
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}");
            });
            InitializeAndVerifyContainer(app, loggerFactory);

        }
        private static void InitializeContainer(Container container)
        {
            container.Register<AugmentObjectService>();

        private void InitializeAndVerifyContainer(IApplicationBuilder app, ILoggerFactory loggerFactory)

            // Trying to include Identity into Simple Injector - please ignore
            // container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new Donde.SpokenPast.Infrastructure.Database.DondeContext()));
        }
        private void InitializeAndVerifyContainer(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            var connectionString = Configuration["Donde.SpokenPast.Data:API:ConnectionString"];
            DondeSpokenPastBootstrapper.BootstrapDondeSpokenPast
                (container, 
                Assembly.GetExecutingAssembly(),
                connectionString, 
                CurrentEnvironment.EnvironmentName, loggerFactory);
          
            // Allow Simple Injector to resolve services from ASP.NET Core.
            container.AutoCrossWireAspNetComponents(app);

            container.Verify();
        }
    }
}
