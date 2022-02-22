# ComicStore.Api
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

7. Execute as migrações do Entity Framework e update para criação das tabelas, navegue até o diretório do projeto ComicStore.Infrastructure e execute
```
dotnet ef migrations add FirstMigration -p ComicStore.Infrastructure.csproj -s ..\ComicStore.Api\ComicStore.Api.csproj
```

8. Persistindo o update no banco de dados Oracle
```
dotnet ef database update -p ComicStore.Infrastructure.csproj -s ..\ComicStore.Api\ComicStore.Api.csproj
```
