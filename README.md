# Projeto CRUD MVC em C# com SQL Server e API

Este projeto é uma aplicação CRUD (Create, Read, Update, Delete) utilizando arquitetura MVC em C#, integrada a um banco de dados relacional SQL Server. Além da interface web, oferece uma API REST para manipulação das tarefas.

---

## Tecnologias utilizadas

- C# com ASP.NET Core MVC  
- SQL Server (localdb)  
- Entity Framework Core (Code First)  
- API REST  
- Postman (para testes da API)  
- SQL Server Management Studio (para gerenciamento do banco)

---

## Requisitos para uso

- Visual Studio (2019 ou superior)  
- SQL Server instalado  
- SQL Server Management Studio  
- Postman (para testes da API)

---

## Como executar o projeto

1. **Abrir a solução no Visual Studio e executar**  
   - Ao executar, se o banco de dados não existir, ele será criado automaticamente.  
   - Para visualizar o banco, conecte no servidor `(localdb)\mssqllocaldb` pelo SQL Server Management Studio.  
   - A aplicação utiliza a tabela `dbo.Tarefas` para armazenar os dados.

2. **Usar a interface web local**  
   - Acesse a aplicação no navegador local.  
   - Você poderá criar, visualizar, editar e apagar tarefas pela interface.  
   - Todas as tarefas criadas via interface ou API assumirão o status padrão: **FILA**.

3. **Testes via API**  
   - O endpoint base da API é (exemplo, ajuste a porta conforme sua execução):  
     `https://localhost:7167/api/tarefas`  
   - Para operações **GET (Read)**, **PUT (Update)** e **DELETE**, é necessário passar o ID da tarefa na rota, por exemplo:  
     `https://localhost:7167/api/tarefas/5`  
   - Para criar ou atualizar (POST/PUT), utilize o formato RAW JSON no corpo da requisição:  
     ```json
     {
       "titulo": "Teste CRUD API",
       "descricao": "teste",
       "dataVencimento": "2025-09-12",
       "status": 2
     }
     ```

---

## Observações

- O banco utiliza o SQL Server LocalDB para facilidade de desenvolvimento.  
- A API segue padrões REST e pode ser testada no Postman ou ferramentas similares.  
- O status inicial das tarefas criadas é definido como **FILA** (valor `0`).

---
