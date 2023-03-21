
# Proyecto blazor wasm To Do

Ejercicio - Aplicación en blazor web assembly consumiendo Api

## Configuración

### Conexión con base de datos - Web Api

En el back-end se necesida agregar la ruta correspondiente al servidor de base de datos en el archivo [appsettings.json](https://github.com/MHobak/Todo-Ejercicio/blob/main/Todo.Api/appsettings.json) del proyecto Todo.Api.

Cambiar la variable: `DBConnection`

### Conexión con Web api - Blazor app

En el el front-end de blazor se necesida agregar la ruta correspondiente a la web api en el archivo [appsettings.json](https://github.com/MHobak/Todo-Ejercicio/blob/main/Todo.Client/wwwroot/appsettings.json) del proyecto Todo.Client

Cambiar el valor de la variable: `TodoServer.Api`.

Solo si la web api del back-end se ejecuta con una ruta diferente a la especificada.

## Creación base de datos
Para crear la base de tados se puede hacer por migraciones ejecutando el siguiente comando en la consola de paquetes de visual studio.
```bash
  Update-Database
```

Pasos a realizar en visual studio:

![alt text](https://github.com/MHobak/Todo-Ejercicio/blob/main/demo/ScreenShot_20230321113336.png?raw=true)

### Creación por script
Opcionalmente se puede crear la base de datos por medio de el script [TodoDbScript.sql](https://github.com/MHobak/Todo-Ejercicio/blob/main/demo/TodoDbScript.sql) el cual es un reslapdo de la base de datos que adicionalmente contiene registros de prueba. Basta con ejecutar el scrippt en el servidor de  SQL Server.
## Ejecutar localmente

Clone el repositorio

```bash
  git clone https://github.com/MHobak/Todo-Ejercicio.git
```

Dirijase al directorio del proyecto

```bash
  cd Todo-Ejercicio
```

Instalar dependencias

```bash
  dotnet build
```

Para ejecutar la web api dirijase al directorio del proyecto

```bash
  cd Todo.Api
```
Ejecutar la aplicación
```bash
  dotnet run
```

Para ejecutar el cliente blazor abra otra terminal y dirijase al directorio del proyecto

```bash
  cd Todo.Client
```
Ejecutar la aplicación
```bash
  dotnet run
```
## Demo
Interfaz de la aplicación

![alt text](https://github.com/MHobak/Todo-Ejercicio/blob/main/demo/ScreenShot_20230320213015.png?raw=true)