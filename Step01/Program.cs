using eTickets.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// VT için gerekli olacak AppDbContext tanımı yapılıyor.
// (Step01.6)
//builder.Services.AddDbContext<AppDbContext>();

// (Step01.10)
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));  // Connection bilgileri appsettings.json dosyasından okunuyor






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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// VT içine örnek/fake/dummy veri yaratma kısmı

AppDbInitializer.Seed(app);


app.Run(); // Uygulama başlar...
