
using Delivery.Infraestructure.Persistence.Repositories;
using Delivery.Applications.UsesCases.Interfaces;
using Delivery.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Delivery.Applications.UsesCases.Deliveries;
using Microsoft.Extensions.DependencyInjection;
using Delivery.Applications.Handlers.Deliveries;


//using Delivery.Infraestructure.Persistence;
using MediatR;
//using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Repositorios
//builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
//// MediatR y otros servicios
//builder.Services.AddMediatR(typeof(CreateDeliveryCommand).Assembly);


//// Add services to the container.
//builder.Services.AddRazorPages();


// Agregar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(typeof(CreateDeliveryHandler).Assembly);
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
