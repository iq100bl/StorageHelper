using Core;
using DatabaseAccess;
using DatabaseAccess.Core;
using DatabaseAccess.Core.DbHandlers.Nomenclature;
using DatabaseAccess.Core.DbHandlers.Transaction;
using DatabaseAccess.Core.Handlers.ItemOnStorageHandler;
using DatabaseAccess.Core.Handlers.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ITransferService, TransferService>();

builder.Services.AddTransient<IDbWorker, DbWorker>();
builder.Services.AddTransient<IItemOnStorageDbHandler, ItemOnStorageDbHandler>();
builder.Services.AddTransient<INomenclatureDbHandler, NomenclatureDbHandler>();
builder.Services.AddTransient<IStoragesDbHandlers, StoragesDbHandlers>();
builder.Services.AddTransient<ITransactionDbHandler, TransactionDbHandler>();

builder.Services.AddControllersWithViews();

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

app.Run();
