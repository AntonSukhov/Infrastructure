About

The Infrastructure.AspNetCore package provides a foundational component for structuring the startup logic of ASP.NET Core applications, as well as for building reusable infrastructure modules across multiple projects.

How to Use

Inherit from StartupBase to create your application‑specific startup logic:

    internal class Startup: StartupBase
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment): base(configuration, environment)){}

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            var isDevelopment = Environment.IsDevelopment();

            services.AddHttpLogging(opts => opts.LoggingFields = HttpLoggingFields.All);
            services.AddSingleton<IPersonService, PersonService>();
            services.AddProblemDetails();
        }

        public void ConfigureLogging(ILoggingBuilder logging)
        {
            logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);
        }

        public override void Configure(WebApplication app)
        {
            base.Configure(app);

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler();
            }

            app.UseStaticFiles();
            app.UseRouting();
            
            app.MapPost("/persons", (Person person, IPersonService personService) =>
            {
                personService.AddPerson(person);

                return TypedResults.NoContent();
            });

            app.MapGet("/persons/{id}", ( 
                [AsParameters] SearchModel search) =>
            {
                return search.ToString();
            });

            app.MapPost("/users/", (UserModel userModel)=>
            {
                return userModel.ToString();
            })
            .WithParameterValidation();
        }
    }

Use your Startup class in the main Program.cs file:

    var builder = WebApplication.CreateBuilder(args);
    var startup = new Startup(builder.Configuration, builder.Environment);

    startup.ConfigureServices(builder.Services);
    startup.ConfigureLogging(builder.Logging);

    var app = builder.Build();

    startup.Configure(app);

    app.Run();
    
 
Main Types

The main types provided by this library are:

    Infrastructure.AspNetCore.StartupBase


Feedback & Contributing

Infrastructure.AspNetCore is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.