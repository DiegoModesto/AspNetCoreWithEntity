#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 58604
EXPOSE 44342

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["src/Presentation/Khan.Presentation.WebAPI/Khan.Presentation.WebAPI.csproj", "src/Presentation/Khan.Presentation.WebAPI/"]
RUN dotnet restore "src/Presentation/Khan.Presentation.WebAPI/Khan.Presentation.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Khan.Presentation.WebAPI"
RUN dotnet build "Khan.Presentation.WebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Khan.Presentation.WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Khan.Presentation.WebAPI.dll"]