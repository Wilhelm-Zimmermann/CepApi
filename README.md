# Cep Api

## Para rodar o projeto
* Ter o [.NET 8.0](https://dotnet.microsoft.com/pt-br/download) instalado.
* Ter o [Docker](https://docs.docker.com/get-docker/) instalado.
* Ter o entity framework tools, para instalar basta rodar o comando `dotnet tool install --global dotnet-ef`;

* Verificar se as portas 7282, 6603, 6379, 5017 estão disponíveis.
* Clonar este repositório `https://github.com/Wilhelm-Zimmermann/CepApi.git`.
* Na pasta raíz onde está localizado o `docker-compose.yml`, rodar o comando `docker compose up`.
* Abrir outro terminal; entrar na pasta `CepApi.Domain.Api`, rodar o comando `dotnet ef database update`.
  - Este comando criará a tabela de usuários no banco de dados.
  - Também será criado um usuário com as credenciais, `email: adm@gmail.com` `password: 1234`.
* Após finalizado, rodar o comando `dotnet run` na pasta `CepApi.Domain.Api`.
* Agora é so acessar pelo navegador a url `http://localhost:5017/swagger/index.html`, caso rode no vs 2022 ele irá criar uma versão com SSl, para acessar a rota é `https://localhost:7282/swagger/index.html`

## Como fazer a request
* A única rota que não precisa de autenticação é a de `api/v1/User/login`
* Nesta rota é necessário enviar o body com:
```json
{
  "email": "adm@gmail.com",
  "password": "1234"
}
```
Caso o usuário seja válido, será retornado um token
```json
{
  "message": "User logged successfully",
  "data": {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbUBnbWFpbC5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYXRvciIsImNlcnRzZXJpYWxudW1iZXIiOiI5NjhlOTQ3OS00NWY4LTQ4ZDEtYmRmYy1mNjYzOTRiNDI3OTAiLCJuYmYiOjE3MDk4MDM4MjEsImV4cCI6MTcwOTgxMTAyMSwiaWF0IjoxNzA5ODAzODIxfQ.2wyydUGXx7WYNQb84qg4FJO_BZceHsOKmeAB5v_3UNA"
  },
  "success": true
}
```

<br/>

* A rota `api/v1/Cep`, caso seja digitado um cep válido será retornado as informações repectivas do cep.
* Body para enviar:
```json
{
  "cep": "89080260"
}
```
* retorno:
``` json
{
  "message": "Returned from api",
  "data": {
    "cep": "89080-260",
    "logradouro": "Rua La Paz",
    "complemento": "",
    "bairro": "Tapajós",
    "localidade": "Indaial",
    "uf": "SC",
    "ibge": "4207502",
    "gia": "",
    "ddd": "47",
    "siafi": "8147"
  },
  "success": true
}
```
* Caso o mesmo cep seja digitado em um intervalo de 5 minutos, será retornado do cache.
``` json
{
  "message": "Returned from cache",
  "data": {
    "cep": "89080-260",
    "logradouro": "Rua La Paz",
    "complemento": "",
    "bairro": "Tapajós",
    "localidade": "Indaial",
    "uf": "SC",
    "ibge": "4207502",
    "gia": "",
    "ddd": "47",
    "siafi": "8147"
  },
  "success": true
}
```
