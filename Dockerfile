# 1. Imagen oficial de .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 2. Carpeta que se crea dentro del contenedor
WORKDIR /app

# 3. Copia de los archivos
COPY . .

# 4. Restaurar dependencias
RUN dotnet restore
RUN dotnet publish -c Release -o out

# 5. Ahora creamos una imagen 
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# 6. Carpetade la aplicación
WORKDIR /app

# 7. Copiamos los archivos ya compilados de la primera imagen a nueva imagen
COPY --from=build /app/out .

# 8. puerto 8870 (cifras de mi correo San Valero)
EXPOSE 8870

# 9. Se crea un volumen para guardar los datos de facturas, pedidos, productos
VOLUME ["/app/data"]

# 10. Comandos para ejecutar la aplicación en el contendor
CMD ["dotnet", "GestApp.dll"]
