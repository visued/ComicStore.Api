# Backend Comic Store
Backend do projeto de carrinho de quadrinhos da Marvel.

Stack do projeto
.Net 5 com entity framework core e Banco de dados Oracle rodando no Docker

## Iniciando

1. Faça o clone do projeto

2. Instale o docker 
[Começando com Docker](https://www.docker.com/get-started)

3. Navegue até o diretório raiz onde contem o arquivo Dockerfile usando o terminal do linux ou promp do windows e execute o build para gerar a imagem para o container
```
docker build -t c-api-comic-store .
```
4. Após gerar a a imagem do container execute esse comando para colocar o container em execução
```
docker run c-api-comic-store -p 5000:5000
```
5. Verifique se teu container está em execução executando o comando
```
docker ps
```

6. Esse projeto depende de uma instancia de container do oraclexe, você pode encontrar instruções de instalação no repositório [Subindo uma instância de Oracle](https://github.com/oracle/docker-images/tree/main/OracleDatabase)

7. Certifique-se que possua o sdk do .net core instalado, caso não possua o mesmo pode ser baixado aqui [Download SDK 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-5.0.405-windows-x64-installer) 

8. Instale o dotnet-ef globalmente executando o comando
```
 dotnet tool install --global dotnet-ef
```
9. Execute as migrações do Entity Framework e update para criação das tabelas, navegue até o diretório do projeto ComicStore.Infrastructure e execute
```
dotnet ef migrations add FirstMigration -p ComicStore.Infrastructure.csproj -s ..\ComicStore.Api\ComicStore.Api.csproj
```

10. Persistindo o update no banco de dados Oracle
```
dotnet ef database update -p ComicStore.Infrastructure.csproj -s ..\ComicStore.Api\ComicStore.Api.csproj
```

11. No browser de sua preferência, acesse a url http://localhost:5001/swagger para consultar a documentação da API.
