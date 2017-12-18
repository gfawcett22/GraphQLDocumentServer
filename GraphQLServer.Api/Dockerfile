FROM microsoft/aspnetcore

WORKDIR /app

COPY publish /app

ENTRYPOINT ["dotnet", "GraphQLServer.Api.dll"]