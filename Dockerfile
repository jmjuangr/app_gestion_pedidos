# 1. Imagen oficial de .NET SDK para compilar el código
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 2. Carpeta de trabajo dentro del contenedor para compilar la app
WORKDIR /app

# 3. Copiar todos los archivos del proyecto al contenedor
COPY . .

# 4. Restaurar dependencias y compilar la aplicación en modo Release
RUN dotnet restore
RUN dotnet publish -c Release -o out

# 5. Imagen base más ligera para ejecutar la aplicación (sin SDK)
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# 6. Definir la carpeta de trabajo dentro del contenedor
WORKDIR /app

# 7. Copiar los archivos compilados desde la imagen de compilación
COPY --from=build /app/out .

# 8. Configurar la aplicación para que escuche en el puerto 8870
ENV ASPNETCORE_URLS="http://0.0.0.0:8870"

# 9. Exponer el puerto en el contenedor
EXPOSE 8870

# 10. Crear un volumen para almacenar datos persistentes (facturas, pedidos, productos)
VOLUME ["/app/data"]

# 11. Comando para ejecutar la aplicación dentro del contenedor
CMD ["dotnet", "GestApp.dll"]
