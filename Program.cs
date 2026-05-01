using Microsoft.EntityFrameworkCore;
using Tarea3_GestionEmpleados_C06225.Data;
using Tarea3_GestionEmpleados_C06225.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agrega el soporte para el patrón MVC: controladores y vistas.
builder.Services.AddControllersWithViews();

// Configura Entity Framework Core para usar SQLite.
// La cadena de conexión se obtiene desde appsettings.json.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra el repositorio de empleados.
// Cuando el controlador necesite IEmpleadoRepository, ASP.NET usará EmpleadoRepository.
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

var app = builder.Build();

// Aplica automáticamente las migraciones pendientes al iniciar la aplicación.
// Esto permite crear o actualizar la base de datos empleados.db según el modelo.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al aplicar las migraciones.");
    }
}

// Configura el manejo de errores y seguridad cuando la app no está en modo desarrollo.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redirige solicitudes HTTP a HTTPS.
app.UseHttpsRedirection();

// Permite cargar archivos estáticos como CSS, JavaScript, imágenes y librerías.
app.UseStaticFiles();

// Activa el sistema de rutas.
app.UseRouting();

// Activa la autorización. En este proyecto no se usa login, pero se mantiene la configuración estándar.
app.UseAuthorization();

// Define la ruta principal.
// Al abrir la raíz del sitio, carga Empleados/Index.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empleados}/{action=Index}/{id?}");

// Inicia la aplicación.
app.Run();