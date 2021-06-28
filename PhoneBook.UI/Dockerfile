#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PhoneBook.UI/PhoneBook.UI.csproj", "PhoneBook.UI/"]
RUN dotnet restore "PhoneBook.UI/PhoneBook.UI.csproj"
COPY . .
WORKDIR "/src/PhoneBook.UI"
RUN dotnet build "PhoneBook.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhoneBook.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhoneBook.UI.dll"]
