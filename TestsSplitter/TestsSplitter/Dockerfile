FROM mcr.microsoft.com/dotnet/framework/samples:dotnetapp as build-env

COPY . .
RUN dotnet publish ./TestsSplitter/TestsSplitter/TestsSplitter.csproj -c Release -o out --no-self-contained
RUN dotnet publish ./TestsSplitter/TestsSplitter.Tests/TestsSplitter.Tests.csproj -c Release -o out --no-self-contained

RUN dotnet test ./TestProject1/TestProject1.csproj --logger "trx;LogFileName=test-result.trx"


# Relayer the .NET SDK, anew with the build output
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8
COPY --from=build-env /out .
ENTRYPOINT [ "dotnet", "/TestsSplitter.dll" ]