-- Script de creación de base de datos para SQLite
-- Proyecto: Tarea3_GestionEmpleados_C06225

CREATE TABLE IF NOT EXISTS "Empleados" (
    "Id" INTEGER PRIMARY KEY AUTOINCREMENT,
    "Nombre" TEXT NOT NULL,
    "Apellidos" TEXT NOT NULL,
    "Departamento" TEXT NOT NULL,
    "Salario" REAL NOT NULL,
    "FechaIngreso" TEXT NOT NULL,
    "Activo" INTEGER NOT NULL
);

-- Seed data inicial (Opcional, EF Core lo maneja mediante migraciones)
-- INSERT INTO Empleados (Nombre, Apellidos, Departamento, Salario, FechaIngreso, Activo) VALUES ('Juan', 'Pérez', 'TI', 850000, '2022-01-15', 1);
