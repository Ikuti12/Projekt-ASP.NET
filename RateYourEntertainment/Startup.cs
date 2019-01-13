using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using RateYourEntertainment.Auth;
using RateYourEntertainment.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RateYourEntertainment.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;


namespace RateYourEntertainment
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                           .SetBasePath(hostingEnvironment.ContentRootPath)
                           .AddJsonFile("appsettings.json")
                           .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options =>
                                         options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IGameReviewRepository, GameReviewRepository>();

            services.AddAntiforgery();
            //services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            //services.AddMvc();

            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            //services.AddMvc();
            //global filter
            //services.AddMvc
            //    (
            //        config => { config.Filters.AddService(typeof(TimerAction)); }
            //    )
            //    .AddViewLocalization(
            //        LanguageViewLocationExpanderFormat.Suffix,
            //        opts => { opts.ResourcesPath = "Resources"; })
            //    .AddDataAnnotationsLocalization();

            services.AddMvc
                (
                    config =>
                    {
                        config.Filters.AddService(typeof(TimerAction));
                        config.CacheProfiles.Add("Default",
                            new CacheProfile()
                            {
                                Duration = 30,
                                Location = ResponseCacheLocation.Any
                            });
                        config.CacheProfiles.Add("None",
                            new CacheProfile()
                            {
                                Location = ResponseCacheLocation.None,
                                NoStore = true
                            });
                    }
                )
                .AddViewLocalization(
                    LanguageViewLocationExpanderFormat.Suffix,
                    opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization()
                .AddMvcOptions(options =>
                {
                    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(s => $"You can't leave this {s} empty");
                }
            );

            //response compression with gzip (performance chapter)
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/jpeg" });
            });

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);


            //services.Configure<RequestLocalizationOptions>(
            //    options =>
            //    {
            //        var supportedCultures = new List<CultureInfo>
            //        {
            //            new CultureInfo("fr"),
            //            new CultureInfo("fr-FR"),
            //            new CultureInfo("nl"),
            //            new CultureInfo("nl-BE"),
            //            new CultureInfo("en-US")
            //        };

            //        options.DefaultRequestCulture = new RequestCulture("en-US");
            //        options.SupportedCultures = supportedCultures;
            //        options.SupportedUICultures = supportedCultures;
            //    });

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "732283240102-fpro9k7gpd6id31e46nibreakoeerrgc.apps.googleusercontent.com";
                    options.ClientSecret = "7z0NkWGEi0Bm5Xd3GWpqwhQ2";
                });

            //Claims-based
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorOnly", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("DeleteGame", policy => policy.RequireClaim("Delete Game", "Delete Game"));
                options.AddPolicy("AddGame", policy => policy.RequireClaim("Add Game", "Add Game"));
            });

            services.AddMemoryCache();
            services.AddSession();

            //Filters
            services.AddScoped<TimerAction>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Diagnostics

            //app.UseWelcomePage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/AppException");
            }

            //gzip compression
            app.UseResponseCompression();

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddDebug(LogLevel.Debug);


            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "categoryfilter",
                  template: "Game/{action}/{category?}",
                  defaults: new { Controller = "Game", action = "List" });

                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");


            });


            //DbInitializer.Seed(app);

        }
    }
}