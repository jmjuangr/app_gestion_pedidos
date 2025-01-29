# 1. Usamos una imagen oficial de .NET 8 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 2. Configuramos el directorio de trabajo dentro del contenedor
WORKDIR /app

# 3. Copiamos todos los archivos del proyecto al contenedor
COPY . .

# 4. Restauramos paquetes y compilamos la aplicación
RUN dotnet restore
RUN dotnet publish -c Release -o out

# 5. Creamos una nueva imagen más liviana con solo lo necesario
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# 6. Configuramos el directorio de trabajo en el contenedor
WORKDIR /app

# 7. Copiamos los archivos compilados desde la imagen anterior
COPY --from=build /app/out .

# 8. Exponemos el puerto 8870
EXPOSE 8870

VOLUME ["/app/data"]

# 9. Definimos el comando para ejecutar la aplicación dentro del contenedor
CMD ["dotnet", "GestApp.dll"]
