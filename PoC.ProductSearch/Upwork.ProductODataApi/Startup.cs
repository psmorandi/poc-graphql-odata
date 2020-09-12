namespace Upwork.ProductODataApi
{
    using System.Linq;
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNet.OData.Formatter;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Net.Http.Headers;
    using Microsoft.OData.Edm;
    using Microsoft.OpenApi.Models;
    using Product.Data;
    using Product.Data.Repositories;
    using Product.Domain;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.EnableDependencyInjection();
                    endpoints.Expand().Select().Count().OrderBy().Filter();
                    endpoints.MapODataRoute("odata", "odata", GetEdmModel());
                });

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product OData API"); });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductContext>(
                options =>
                    options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddControllers();
            
            services.AddOData();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product OData API", Version = "v1" }); });

            services.AddMvcCore(
                options =>
                {
                    var outputFormatters =
                        options.OutputFormatters.OfType<ODataOutputFormatter>()
                            .Where(formatter => formatter.SupportedMediaTypes.Count == 0);

                    foreach (var outputFormatter in outputFormatters) outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
                });
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Product");
            return builder.GetEdmModel();
        }
    }
}