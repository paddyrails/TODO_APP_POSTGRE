# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY TODO.Services.ToDoAPI/*.csproj .
RUN dotnet restore --use-current-runtime

# copy everything else and build app
COPY TODO.Services.ToDoAPI/. .
RUN dotnet publish --use-current-runtime --self-contained false --no-restore -o /app


# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-jammy
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["./TODO.Services.ToDoAPI"]