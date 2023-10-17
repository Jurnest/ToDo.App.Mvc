using Microsoft.EntityFrameworkCore;
using Todo.App.Mvc.BusinessLayer.Abstract;
using Todo.App.Mvc.BusinessLayer.Concrete;
using Todo.App.Mvc.DataAccessLayer.Abstract;
using Todo.App.Mvc.DataAccessLayer.Concrete;
using Todo.App.Mvc.DataAccessLayer.EfCore;
using ToDo.App.Mvc.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddScoped<IToDoListDal, EfToDoListDal>();
builder.Services.AddScoped<IToDoListService, ToDoListManager>();

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
