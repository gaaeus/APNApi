using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using APN.DBContexts;

namespace APN
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
            services.AddControllers();
            services.Add(new ServiceDescriptor(typeof(NoteDBContext), new NoteDBContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.Add(new ServiceDescriptor(typeof(AudioDBContext), new AudioDBContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.Add(new ServiceDescriptor(typeof(VideoDBContext), new VideoDBContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.Add(new ServiceDescriptor(typeof(ImageDBContext), new ImageDBContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.Add(new ServiceDescriptor(typeof(PhotoDBContext), new PhotoDBContext(Configuration.GetConnectionString("DefaultConnection"))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }         
    }
}
