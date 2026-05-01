# Tarea 3: Sistema de Gestión de Empleados

**Nombre del estudiante:** Diego  
**Carnet:** C06225  
**Proyecto:** Tarea3_GestionEmpleados_C06225

## Descripción
Este sistema web ha sido desarrollado utilizando ASP.NET Core MVC para administrar empleados de una empresa de consultoría. Permite realizar operaciones CRUD completas (con baja lógica), búsqueda filtrada por múltiples campos y paginación de resultados.

## Tecnologías Utilizadas
- **ASP.NET Core MVC** (Framework web)
- **C#** (Lenguaje de programación)
- **Entity Framework Core** (ORM)
- **SQLite** (Motor de base de datos)
- **Bootstrap 5** (Diseño y responsividad)
- **Patrón Repositorio** (Arquitectura)
- **LINQ** (Consultas de datos)

## Instrucciones para ejecutar
1. Abra una terminal en la carpeta raíz del proyecto.
2. Restaure las dependencias:
   ```bash
   dotnet restore
   ```
3. Compilamos el proyecto:
   ```bash
   dotnet build
   ```
4. Aplicamos las migraciones y cree la base de datos:
   ```bash
   dotnet ef database update
   ```
5. Iniciamos la aplicación:
   ```bash
   dotnet run
   ```
6. Acceda a la aplicación en `https://localhost:5001` (o el puerto indicado por dotnet).

## Características Implementadas

### Búsqueda
La búsqueda se realiza de forma case-insensitive sobre los campos **Nombre**, **Apellidos** y **Departamento**. Se utiliza LINQ `Contains` para encontrar coincidencias parciales.
Ejemplo de URL con búsqueda:
`/Empleados?busqueda=TI&pagina=1`

### Paginación
El sistema utiliza un tamaño de página fijo de **5 registros**. La paginación utiliza los métodos `Skip` y `Take` de LINQ y preserva el estado de la búsqueda al navegar entre páginas.

### ToggleActivo (Baja Lógica)
El sistema no permite la eliminación física de registros desde la interfaz de usuario. En su lugar, se implementa un botón de **Dar de Baja / Activar** que cambia el estado booleano del campo `Activo`. Los empleados dados de baja se muestran con un badge rojo/gris en la tabla.

## Estructura del Proyecto
- `Models/`: Definición del modelo `Empleado` con Data Annotations.
- `Data/`: Contexto de base de datos y configuración de seed.
- `Repositories/`: Abstracción e implementación del acceso a datos.
- `Controllers/`: Lógica de coordinación de peticiones.
- `Views/`: Plantillas Razor para la interfaz de usuario.
- `script sql/`: Script de creación de tabla para SQLite.
