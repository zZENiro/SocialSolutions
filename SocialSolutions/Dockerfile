FROM mcr.microsoft.com/dotnet/sdk AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SocialSolutions.dll"]