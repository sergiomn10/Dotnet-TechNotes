<p align="center">
  <a href="https://dotnet.microsoft.com/es-es/" target="blank"><img src="Microsoft_.NET_logo.png" width="120" alt="TypeScript Logo" /></a>
</p>


# Creación de un nuevo proyecto con Blazor en .NET 9 (TechNotes)

Proyecto Fullstack con Clean Architecture (.NET)

## Estructura de Carpetas

```
Fullstack.sln
TechNotes/                  # Capa de Presentación (Web, UI)
TechNotes.Application/      # Capa de Aplicación (Servicios, lógica de negocio)
TechNotes.Domain/           # Capa de Dominio (Entidades, interfaces)
TechNotes.Infrastructure/   # Capa de Infraestructura (Persistencia, EF Core, Repositorios)
```

## Instalación de Paquetes

Ejecuta los siguientes comandos en la terminal para instalar los paquetes necesarios en cada capa:

### 1. TechNotes.Infrastructure

```sh
dotnet add TechNotes.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add TechNotes.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add TechNotes.Infrastructure package Microsoft.EntityFrameworkCore.Tools
```

### 2. TechNotes.Application

```sh
dotnet add TechNotes.Application package Microsoft.Extensions.DependencyInjection.Abstractions
```

## Configuración de la Base de Datos

Agrega la cadena de conexión en `TechNotes/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TechNotesDb;User ID=SA;Password=MyStrongPass123;TrustServerCertificate=true;MultipleActiveResultSets=true"
}
```

## Migraciones de la Base de Datos

1. Ve a la carpeta `TechNotes.Infrastructure`:
    ```sh
    cd TechNotes.Infrastructure
    ```
2. Crea la migración:
    ```sh
    dotnet ef migrations add CreateTableNotes
    ```
3. Aplica la migración a la base de datos:
    ```sh
    dotnet ef database update
    ```

## Ejecución

Levanta el contenedor de Docker si usas SQL Server en Docker y ejecuta el proyecto desde Visual Studio o con:

```sh
dotnet run --project TechNotes
```

---

**Clean Architecture** implementa separación de responsabilidades en capas para facilitar el mantenimiento y escalabilidad