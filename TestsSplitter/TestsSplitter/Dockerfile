# Set the base image as the .NET 5.0 SDK (this includes the runtime)
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env

# Copy everything and publish the release (publish implicitly restores and builds)
COPY . .
RUN dotnet publish ./TestsSplitter/TestsSplitter.csproj -c Release -o out --no-self-contained
RUN dotnet publish ./TestsSplitter.Tests/TestsSplitter.Tests.csproj -c Release -o out --no-self-contained

RUN dotnet test ./TestProject1/TestProject1.csproj --logger "trx;LogFileName=test-result.trx"

# Label the container
LABEL maintainer="David Pine <david.pine@microsoft.com>"
LABEL repository="https://github.com/dotnet/samples"
LABEL homepage="https://github.com/dotnet/samples"

# Relayer the .NET SDK, anew with the build output
FROM mcr.microsoft.com/dotnet/sdk:5.0
COPY --from=build-env /out .
ENTRYPOINT [ "dotnet", "/TestsSplitter.dll" ]