using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Infra;
using MTPrison.Infra.Initializers;
using MTPrison.Infra.Party;
using MTPrisonApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<PrisonDb>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
//builder.Services.AddRazorPages(o => {
//    o.Conventions.AuthorizePage("/Countries/Create");
//    o.Conventions.AuthorizePage("/Countries/Edit");
//    o.Conventions.AuthorizePage("/Countries/Delete");
//    o.Conventions.AuthorizePage("/Currencies/Create");
//    o.Conventions.AuthorizePage("/Currencies/Edit");
//    o.Conventions.AuthorizePage("/Currencies/Delete");
//});

builder.Services.AddTransient<IPrisonersRepo, PrisonersRepo>();
builder.Services.AddTransient<ICellsRepo, CellsRepo>();
builder.Services.AddTransient<ICountriesRepo, CountriesRepo>();
builder.Services.AddTransient<ICurrenciesRepo, CurrenciesRepo>();
builder.Services.AddTransient<IPrisonerCellsRepo, PrisonerCellsRepo>();
builder.Services.AddTransient<ICountryCurrenciesRepo, CountryCurrenciesRepo>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    GetRepo.SetService(app.Services);
    var db = scope.ServiceProvider.GetService<PrisonDb>();
    db?.Database?.EnsureCreated();
    PrisonDbInitializer.Init(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
} else {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
