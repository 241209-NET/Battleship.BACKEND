
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# COPY from the source to the destination
COPY ./ ./

# image creation
RUN dotnet restore
RUN dotnet publish -c Release -o ./out


# Run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./ 

# ENTRYPOINT commands are the first/default action when creating the container
ENTRYPOINT ["dotnet", "./Battleship.API.dll"]