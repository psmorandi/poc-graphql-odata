namespace Upwork.ProductGraphqlAPI
{
    using HotChocolate;
    using HotChocolate.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Product.Data;
    using Product.Data.Repositories;
    using Product.Domain;
    using Upwork.ProductGraphqlAPI.Queries;

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

            app
                .UseRouting()
                .UseWebSockets()
                .UseGraphQL("/graphql");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddDbContext<ProductContext>(
                options =>
                    options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            // Add GraphQL Services
            services.AddGraphQL(
                sp => SchemaBuilder.New()
                    .AddServices(sp)
                    .AddQueryType(d => d.Name("Query"))
                    .AddType<ProductQueries>()
                    .AddType<Product>()
                    .AddType<Color>()
                    .AddType<Category>()
                    .Create());
            services.AddApplicationInsightsTelemetry();
        }
    }
}