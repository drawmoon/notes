using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiVersionDemo
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

            services.AddApiVersioning(options =>
            {
                // ������ Response Headers �з��� "api-supported-versions" �� "api-deprecated-versions"
                options.ReportApiVersions = true;

                // ��ʾ��ָ���汾��ʱ����Ĭ�ϰ汾�����Ϊ false ����ָ��API�İ汾�ţ������� QueryString ������ "?api-version=1.0"
                // options.AssumeDefaultVersionWhenUnspecified = true;
            });

            // ���Ӱ汾���� API ��Դ�������� IApiVersionDescriptionProvider ��������֧�ָ��ݰ汾�ű�¶ Swagger �ĵ�
            services.AddVersionedApiExplorer();

            // Swagger �ĵ�����
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(options =>
            {
                // ���� xml ע���ĵ�
                var files = new DirectoryInfo(AppContext.BaseDirectory).EnumerateFiles().Where(f => f.Extension.Equals(".xml", StringComparison.OrdinalIgnoreCase));
                foreach (var fileInfo in files)
                {
                    options.IncludeXmlComments(fileInfo.FullName);
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
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

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "api-docs";
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
                }
            });
        }
    }
}