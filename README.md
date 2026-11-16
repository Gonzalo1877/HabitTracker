<div align="center">

# HabitTracker

Aplicación de consola para registrar hábitos y consultar su historial con C# y SQLite.

[Inicio rápido](#-inicio-rápido) · [Uso](#-cómo-usarlo) · [Base de datos](#-base-de-datos) · [Aprendizaje](#-aprendizaje)

</div>

---

## Sobre el proyecto

Proyecto de práctica basado en [Habit Logger de The C# Academy](https://thecsharpacademy.com/project/12/habit-logger), orientado a aprender operaciones CRUD y persistencia de datos mediante ADO.NET, sin Entity Framework ni Dapper.

Permite definir varios hábitos, elegir su unidad de medida y registrar ocurrencias con fecha y cantidad. Por ejemplo: vasos de agua, páginas leídas o repeticiones de una actividad.

## Funcionalidades

- **Crear hábitos** con nombre y unidad de medida.
- **Registrar ocurrencias** con fecha y cantidad entera positiva.
- **Consultar hábitos** y el historial de cada uno.
- **Editar una ocurrencia** seleccionándola por su ID.
- **Eliminar todas las ocurrencias** de un hábito.
- **Eliminar hábitos sin ocurrencias**, preservando la integridad de los datos.
- **Crear automáticamente** el archivo SQLite y las tablas si no existen.
- Validar entradas numéricas, textos obligatorios, fechas e IDs seleccionados.
- Usar consultas parametrizadas para los valores ingresados por el usuario.

> [!WARNING]
> La opción de eliminar ocurrencias borra **todo el historial del hábito elegido**, no un registro individual. Actualmente no solicita confirmación adicional.

## Inicio rápido

### Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- Acceso a NuGet para descargar las dependencias en la primera restauración.

### Ejecutar

Descargá o cloná el repositorio y abrí una terminal en su carpeta raíz, donde está `HabitTracker.sln`.

Entrá a la carpeta de la aplicación:

```bash
cd HabitTracker
```

Restaurá las dependencias y ejecutá:

```bash
dotnet restore
dotnet run
```

`dotnet run` también restaura las dependencias automáticamente si hace falta.

Al iniciar, la aplicación abre o crea `habittracker.db` y prepara las tablas. Los datos se conservan entre ejecuciones.

> [!IMPORTANT]
> La ruta de SQLite es relativa al directorio de trabajo. Seguí estas instrucciones desde la misma carpeta para trabajar siempre con la misma base. Si ejecutás desde otra ubicación o un IDE, comprobá su directorio de trabajo: podrías abrir o crear otro archivo `habittracker.db`.

## Límites y posibles mejoras

Esta versión prioriza la práctica de persistencia y el flujo de una aplicación de consola. Entre las mejoras pendientes se encuentran:

- Separar por completo el acceso a datos de la presentación en consola.
- Unificar el manejo de errores, incluida la apertura de conexiones.
- Mejorar la validación de la opción principal del menú: actualmente una entrada no numérica se interpreta como `0` y sale.
- Comprobar las filas afectadas al actualizar o eliminar para comunicar mejor el resultado.
- Agregar confirmación antes de eliminar datos y permitir borrar una ocurrencia individual.
- Incorporar pruebas automatizadas de validación e integración con SQLite.

<div align="center">

Desarrollado como parte del recorrido de aprendizaje de **The C# Academy**.

[Ver la consigna original](https://thecsharpacademy.com/project/12/habit-logger)

</div>
