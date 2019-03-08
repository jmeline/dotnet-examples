using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace httpcontext_demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpContextAccessor();
            services.AddScoped<CustomMiddleware.IDbTester, CustomMiddleware.DbTester>(ctx =>
            {
                return new CustomMiddleware.DbTester();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<CustomMiddleware>();
            app.UseMvc();
        }

        // http://anthonygiretti.com/2018/09/04/asp-net-core-2-1-middlewares-part1-building-a-custom-middleware/

        public class CustomMiddleware
        {
            private readonly RequestDelegate _next;

            public CustomMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    var request = context.Request;
                    context.Response.Headers.Add("Cool", "Stuff");
                    await _next.Invoke(context);
                }
                catch (Exception ex)
                {

                }
            }

            public class DbTester : IDbTester
            {
            }

            public interface IDbTester
            {
            }
        }
    }
}

//            app.UseMiddleware<EnableRequestRewindMiddleware>();
//            app.Use((ctx, next) =>
//                {
//                    ctx.Response.Headers.Add("stuff", "cool");
//                    return next();
//                });
//            app.Run(async context =>
//            {
//                await context.Response.WriteAsync("Sup!");
//            });
//            app.Use(async (context, next) =>
//            {
//                var request = context.Request;
//                await next.Invoke();
//            });


//    public class EnableRequestRewindMiddleware
//    {
//        private readonly RequestDelegate _next;
//
//        public EnableRequestRewindMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }
//
//        public async Task Invoke(HttpContext context)
//        {
//            context.Request.EnableRewind();
//            await _next(context);
//        }
//    }

