using AuthServer.Services;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AuthServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer(options => { })
                .AddTemporarySigningCredential()
                .AddResourceOwnerValidator<CustomResourceOwnerValidator>()
                .AddProfileService<CustomProfileService>()
                .AddInMemoryApiResources(new []
                {
                    new ApiResource("testApi", "Test Api")
                })
                .AddInMemoryClients( new []
                {
                    new Client()
                    {
                        ClientId = "js",
                        ClientName = "JavaScript Client",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        //AllowAccessTokensViaBrowser = true,

                        //RedirectUris = { "http://localhost:5003/callback.html" },
                        //PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
                        //AllowedCorsOrigins = { "http://localhost:5003" },

                        AllowedScopes =
                        {
                            "testApi"
                        },
                    }
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseIdentityServer();
        }
    }
}