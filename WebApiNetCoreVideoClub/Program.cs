using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using WebApiNetCoreVideoClub;
using WebApiNetCoreVideoClub.Filtros;
using WebApiNetCoreVideoClub.Repositorios;

var builder = WebApplication.CreateBuilder(args);

var configuracion = builder.Configuration;

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var cadenaConexion = configuracion.GetConnectionString("defaultConnection");
    options.UseSqlServer(cadenaConexion);
}
);


builder.Services.AddCors(options =>
    {
        var frontendURL = configuracion.GetValue<string>("Frontend_url");
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader()
            .WithExposedHeaders(new string[] { "cantidadTotalRegistros" });
        }
       );
    }
);



builder.Services.AddResponseCaching();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
// Add services to the container.

builder.Services.AddTransient<IRepositorio, RepositorioEnMemoria>();
//builder.Services.AddSingleton<IRepositorio, RepositorioEnMemoria>();
//builder.Services.AddTransient<IRepositorio, RepositorioRemoto>();

builder.Services.AddTransient<MiFiltroDeAccion>();

builder.Services.AddControllers( options =>
        options.Filters.Add(typeof(FiltroDeException))

    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Map("/miruta", (app)=>
    {
        app.Run(async context =>
        {
            await context.Response.WriteAsync("Estoy interceptando todo");
        });
    });



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseResponseCaching();

app.MapControllers();

app.Run();
