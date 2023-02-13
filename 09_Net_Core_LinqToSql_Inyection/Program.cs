using _09_Net_Core_LinqToSql_Inyection.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddTransient<Coche>(); --> te genera el objeto cada vez que se ejecuta la peticion
// builder.Services.AddSingleton<Coche>(); --> te lo genera al iniciar y ya esta
// builder.Services.AddSingleton<ICoche, Deportivo>();

//INSTANCIAMOS UN OOBJETO YA CONSTRUIDO Y SERA EL QUE UTILIZARAN LAS CLASES DE LA INYECCION
Coche car = new Coche();
car.Marca = "Nissan";
car.Modelo = "Skyline GTr R34";
car.Imagen = "skyline.jpg";
car.Velocidad = 0;
car.VelocidadMaxima = 265;
builder.Services.AddTransient<ICoche, Coche>(x => car);

builder.Services.AddTransient<IDoctor, Doctor>();

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
    pattern: "{controller=Coches}/{action=Index}/{id?}");
app.Run();