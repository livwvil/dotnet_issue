FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY . ./src
RUN cd src \
&& dotnet publish -o .. -c Release \
&& cd .. \
&& rm -rf src
ENTRYPOINT ["dotnet", "issue.dll"]
