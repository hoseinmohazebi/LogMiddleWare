using LogMiddleWare.Configuration.Middleware.Log;
using LogMiddleWare.Configuration.Middleware.Migration;
using LogMiddleWare.Data;
using LogMiddleWare.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var columnOptions = new ColumnOptions
{
    AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn
            {ColumnName = "Event", PropertyName = "Event", DataType = SqlDbType.NVarChar, DataLength = 64},
    new SqlColumn
            {ColumnName = "UserName", PropertyName = "UserName", DataType = SqlDbType.NVarChar, DataLength = 64},
    new SqlColumn
            {ColumnName = "Ip", PropertyName = "Ip", DataType = SqlDbType.NVarChar, DataLength = 64},
   new SqlColumn
            {ColumnName = "QueryString", PropertyName = "QueryString", DataType = SqlDbType.NVarChar, DataLength = 500},
   new SqlColumn
            {ColumnName = "RequestBody", PropertyName = "RequestBody", DataType = SqlDbType.NVarChar},
   new SqlColumn
            {ColumnName = "ResponseBody", PropertyName = "ResponseBody", DataType = SqlDbType.NVarChar},
    }
};

var logger = new LoggerConfiguration()
   .WriteTo
    .MSSqlServer(
        connectionString: "Server=localhost;Database=LogDb;Integrated Security=SSPI;",
        sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlTable = true },
        columnOptions: columnOptions,
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Fatal)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();
app.ApplyMigration();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseMiddleware<CustomExceptionHandler>();
app.UseRequestResponseLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
