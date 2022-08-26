# to build local image from PowerShell (e.g. when you're authoring this dockerfile):
# docker build -f ./dockerfile . --build-arg APP_ENV=dev

# build backend
FROM mcr.microsoft.com/dotnet/sdk:6.0@sha256:dd19f6aa2774de9fde18c78970bc4fdebc695bd824c73371b6faec306a18b230 AS service-build

# copy backend files into 'service' folder in prep for dotnet commands
COPY service /service

# ensure tests are passing
ARG ASPNETCORE_ENVIRONMENT
WORKDIR /service/Microsoft.DSX.ProjectTemplate.API
# build the service separately to generate the typescript client with better error output
RUN dotnet build 
# skip build on test since it was just done previously
RUN dotnet test --no-build

# setup frontend
FROM node:16@sha256:bf1609ac718dda03940e2be4deae1704fb77cd6de2bed8bf91d4bbbc9e88b497 AS client-build
ARG APP_ENV
RUN echo APP_ENV = ${APP_ENV}
RUN npm config set unsafe-perm true
COPY client /client

# copy auto-generated TS files from API bulid
COPY --from=service-build /client/src/app/generated/. client/src/app/generated/

# build frontend
WORKDIR /client
RUN npm ci
ENV REACT_APP_ENV=${APP_ENV}
RUN npm run build

# copy our frontend into published app's wwwroot folder
FROM service-build AS publisher
COPY --from=client-build /client/build /app/wwwroot/

# build & publish our API
RUN dotnet publish /service/Microsoft.DSX.ProjectTemplate.API/Microsoft.DSX.ProjectTemplate.API.csproj -c Release -o /app

# build runtime image (contains full stack)
FROM mcr.microsoft.com/dotnet/aspnet:6.0@sha256:6ca5c440d36869d4b83059cf16f111bb4dec371c08b6e935186cc696e89cc0ba
WORKDIR /app
COPY --from=publisher /app ./
# run as non-privileged user
RUN groupadd -g 1000 appuser && \
    useradd -r -u 1000 -g appuser appuser && \
    chown -R appuser:appuser /app && \
    chmod -R 755 /app    
USER appuser
# use non-privileged port
ENV ASPNETCORE_URLS="http://+:8080"
EXPOSE 8080
ENTRYPOINT ["dotnet", "Microsoft.DSX.ProjectTemplate.API.dll"]
