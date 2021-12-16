var builder = WebApplication.CreateBuilder(args);

// Register your services
RegisterServices(builder.Services);

var app = builder.Build();

// App configurations
ConfigureApp(app);

app.Run();

void ConfigureApp(WebApplication app)
{
    var ctx = app.Services.CreateScope().ServiceProvider.GetService<AppDbContext>();
    ctx.Database.EnsureCreated();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    // Configure the Middleware
    var apis = app.Services.GetServices<IContactApi>();
    foreach (var api in apis)
    {
        if (api is null) throw new InvalidProgramException("Apis not found");

        api.Register(app);
    }
}

void RegisterServices(IServiceCollection services)
{
    // Add services to the container.

    services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlite("Data Source=contacts.db");
    });

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Contacts API",
            Description = "Storing and sharing contacts",
            Version = "v1"
        });
    });

    services.AddTransient<IContactApi, ContactApi>();
}
