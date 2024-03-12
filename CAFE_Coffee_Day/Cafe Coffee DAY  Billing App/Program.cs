using CCD_BusinessAccessLayer.CCD_BusinessAccessLayer;
using CCD_DataAccessLayer.CCD_DbContext;
using CCD_DataAccessLayer.DAL_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI for DBcontext
builder.Services.AddDbContext<CCD_InvoiceContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CCD_Con_String")));
builder.Services.AddTransient<IDataAccessLayer, DataAccessLayer>();
builder.Services.AddTransient<BusinessAccessLayer, BusinessAccessLayer>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CafeCoffeeDay_Billing}/{action=Index}/{id?}");

app.UseRotativa();

app.Run();
