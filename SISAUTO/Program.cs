using DB;
using DB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
// Configurar servicios de CORS  los cors se habilitan
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy
            .WithOrigins() // Orígenes permitidos
            .AllowAnyMethod() // Métodos permitidos
            .AllowAnyHeader(); // Encabezados permitidos
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme //para autenticar las urls desde el boton autorize
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>(); // AGREGA EL CANDADO A las peticiones 
});


builder.Services.AddDbContext<SisautoContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("SISAUTOConnection"))); // agregar el contexto al proyecto desde el DB pasandole la cadena de conexion y 

builder.Services.AddAuthorization(); // agregar para proteger las rutas
//proporciona el framework identity
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<SisautoContext>();

//Repositorio
builder.Services.AddScoped<PaisesRepository>();
builder.Services.AddScoped<ClientesRepository>();
builder.Services.AddScoped<OrdenesRepository>();
builder.Services.AddScoped<DetalleOrdenesRepository>();
builder.Services.AddScoped<ServiciosRepository>();
//Servicio
builder.Services.AddScoped<PaisesService>(); // se agrega el servicio como funcion 
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<OrdenesService>();
builder.Services.AddScoped<DetalleOrdenesService>();
builder.Services.AddScoped<ServiciosService>();

builder.Services.AddControllers() // para evitar ciclos
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SisautoContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(); 
        //app.UseDeveloperExceptionPage();
    }
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapIdentityApi<IdentityUser>(); // agregaar cuando se configure AddAuthorization  Para que se muestre en el swager

app.UseHttpsRedirection();  // PARA QUE PUEDA LLAMAR A LAS REDIRECCIONES en swager (tokens)

// Habilitar CORS con la política definida, va arriba de UseAuthorization
app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
