using eTickets.Data;
//using eTickets.Data.Interfaces;
//using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// VT için gerekli olacak AppDbContext tanýmý yapýlýyor.
// (Step01.6) - Önceki durum
//builder.Services.AddDbContext<AppDbContext>();

// (Step01.10) - Düzenleme
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

// 17.7
// Services configuration
//builder.Services.AddScoped<IActorsService, ActorsService>();




// Gerekli tüm ayarlama iþlemlerinden sonra programýn bir anlamda kurulacaðý bölüm.
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

// Browser da ilk gelecek controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}"); // (21)


// VT içine fake/dummy veri yaratma kısmı

AppDbInitializer.Seed(app);


app.Run(); // Uygulama başlar...
