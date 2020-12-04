FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["SocialSolutions.csproj","./"]
RUN dotnet restore "./SocialSolutions.csproj"
COPY . ./															
RUN dotnet build "SocialSolutions.csproj" -c Release -o /app

FROM build as publish
RUN dotnet publish "SocialSolutions.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet","SocialSolutions.dll"]