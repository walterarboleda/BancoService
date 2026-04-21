# BancoService SOAP

# Requisitos Previos Visual Studio (2022 o superior).

SQL Server Express instalado con la base de datos BANCO y la tabla Cuenta.

# Estructura de la tabla Cuenta:

NumeroCuenta (varchar)

TipoCuenta (varchar)

Saldo (float)

Ejemplo:

ACC-001

Ahorros

500

# Creación del Servidor (Web Service ASMX)
1. Abre Visual Studio y crea un nuevo proyecto de tipo ASP.NET Web Application (.NET Framework) en C#.

2. Selecciona la plantilla Empty (Vacía).

3. Haz clic derecho en el proyecto -> Add -> New Item -> Web Service (ASMX). Ponle de nombre BancoService.asmx.

4. Digital o pega el Código del Servidor (BancoService.asmx.cs)

5. Ejecuta el proyecto (F5). Se abrirá un navegador con la dirección (ej. http://localhost:54321/BancoService.asmx). Copia esta URL, la necesitarás para el cliente.



