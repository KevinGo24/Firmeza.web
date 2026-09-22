# Firmeza Web

Aplicación web desarrollada con **ASP.NET Core MVC** orientada a la gestión de usuarios y consulta de información mediante una arquitectura organizada por capas.

El proyecto integra un backend desarrollado en **C# y .NET 10**, persistencia de datos mediante **Entity Framework Core**, conexión con **MySQL** y una interfaz web construida con tecnologías modernas de frontend.

## 🚀 Tecnologías utilizadas

### Backend

* **C#**
* **ASP.NET Core MVC**
* **.NET 10**
* **Entity Framework Core**
* **MySQL**
* **Pomelo.EntityFrameworkCore.MySql**
* **BCrypt.Net-Next** para el manejo seguro de contraseñas

### Frontend

* **HTML5**
* **CSS3**
* **JavaScript**
* **Vite**
* **Tailwind CSS**
* **Bootstrap Icons**
* **SweetAlert2**

## 🏗️ Arquitectura

El proyecto utiliza el patrón **MVC (Model-View-Controller)** para separar las responsabilidades de la aplicación.

```text
Firmeza.web/
│
├── Assets/
│
├── Controllers/
│
├── Models/
│
├── ViewModels/
│
├── Views/
│   ├── Client/
│   └── Dashboard/
│
├── data/
│
├── repository/
│
├── service/
│
├── Properties/
│
├── wwwroot/
│
├── Program.cs
├── Firmeza.AppWeb.csproj
├── appsettings.json
├── package.json
└── vite.config.js
```

### Descripción de las principales carpetas

| Carpeta       | Responsabilidad                                                                        |
| ------------- | -------------------------------------------------------------------------------------- |
| `Controllers` | Recibe las solicitudes y coordina la lógica entre las vistas y los datos.              |
| `Models`      | Contiene las entidades y modelos utilizados por la aplicación.                         |
| `ViewModels`  | Modelos destinados al intercambio de información entre las vistas y los controladores. |
| `Views`       | Contiene las interfaces y páginas Razor de la aplicación.                              |
| `data`        | Configuración relacionada con Entity Framework Core y el contexto de base de datos.    |
| `repository`  | Espacio destinado al acceso y manejo de datos.                                         |
| `service`     | Espacio destinado a la lógica de negocio.                                              |
| `wwwroot`     | Archivos estáticos como CSS, JavaScript e imágenes.                                    |
| `Assets`      | Recursos utilizados por el frontend.                                                   |

## 🗄️ Base de datos

La aplicación utiliza **MySQL** como sistema gestor de base de datos.

La conexión se configura mediante `appsettings.json` y se registra en `Program.cs` utilizando Entity Framework Core.

```csharp
builder.Services.AddDbContext<ApplicationsDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));
```

> ⚠️ No publiques credenciales reales de la base de datos en GitHub. Utiliza variables de entorno o archivos de configuración locales para información sensible.

## 🔐 Seguridad

El proyecto utiliza **BCrypt.Net-Next** para el manejo de contraseñas.

Las contraseñas no deberían almacenarse directamente como texto plano. BCrypt permite almacenar un hash de la contraseña para posteriormente verificar las credenciales durante el inicio de sesión.

## 🎨 Frontend

El proyecto utiliza **Vite** como herramienta para gestionar los recursos del frontend.

Entre las tecnologías utilizadas se encuentran:

* Tailwind CSS para estilos.
* Bootstrap Icons para iconografía.
* SweetAlert2 para mensajes y alertas.
* JavaScript para funcionalidades del cliente.

## ⚙️ Requisitos

Antes de ejecutar el proyecto debes tener instalado:

* [.NET 10 SDK](https://dotnet.microsoft.com/)
* [Node.js](https://nodejs.org/)
* MySQL
* Git

## 📥 Instalación

### 1. Clonar el repositorio

```bash
git clone git@github.com:KevinGo24/Firmeza.web.git
```

Entrar al proyecto:

```bash
cd Firmeza.web
```

### 2. Restaurar las dependencias de .NET

```bash
dotnet restore
```

### 3. Instalar las dependencias de Node

```bash
npm install
```

### 4. Configurar la base de datos

Configura la cadena de conexión de MySQL en tu archivo de configuración local.

Ejemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=firmeza;user=root;password=TU_PASSWORD;"
  }
}
```

> Reemplaza los valores de ejemplo con la configuración correspondiente a tu entorno.

### 5. Ejecutar el proyecto

Puedes iniciar la aplicación con:

```bash
dotnet run
```

También puedes utilizar:

```bash
dotnet watch
```

## 🧩 Comandos útiles

### Backend

Restaurar dependencias:

```bash
dotnet restore
```

Compilar:

```bash
dotnet build
```

Ejecutar:

```bash
dotnet run
```

Ejecutar con recarga automática:

```bash
dotnet watch
```

### Frontend

Instalar dependencias:

```bash
npm install
```

Construir los recursos:

```bash
npm run build
```

Ejecutar Vite en modo watch:

```bash
npm run dev
```

## 📌 Estado del proyecto

🚧 **Proyecto en desarrollo**

Actualmente se encuentra en proceso de construcción y organización de sus diferentes módulos, incluyendo:

* Gestión de usuarios.
* Autenticación.
* Dashboard.
* Gestión de clientes.
* Persistencia de información.
* Integración con MySQL.
* Organización mediante MVC.
* Mejoras de interfaz y experiencia de usuario.

## 🎯 Objetivos

El proyecto busca aplicar conocimientos de desarrollo web utilizando tecnologías del ecosistema .NET, implementando una estructura organizada que facilite el mantenimiento, escalabilidad y evolución de la aplicación.

## 👨‍💻 Autor

**Kevin Andres Gonzalez Visbal**

GitHub: [KevinGo24](https://github.com/KevinGo24)

---

⭐ Proyecto desarrollado como parte del proceso de aprendizaje y práctica en desarrollo de software.
