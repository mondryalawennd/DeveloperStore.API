# DeveloperStore API

API para gerenciamento de vendas, implementada com .NET, seguindo os princípios de DDD (Domain-Driven Design) e usando MediatR, AutoMapper e outras boas práticas.
Este projeto está organizado seguindo boas práticas de arquitetura de software, inspirado em padrões como Clean Architecture, promovendo uma separação clara de responsabilidades para facilitar a manutenção, testes e escalabilidade.

## Funcionalidades

- CRUD completo para vendas (Criar, Buscar, Alterar, Deletar)
- Regras de negócio para descontos baseados na quantidade de itens
- Validação de limites e restrições para vendas
- Eventos de domínio para ações importantes (venda criada, alterada, cancelada)
- Autenticação e autorização (se aplicável)
- Documentação Swagger para fácil teste e entendimento da API

## Tecnologias usadas

- .NET 7
- MediatR
- AutoMapper
- Entity Framework Core
- PostgreSQL 
- Swagger/OpenAPI

## Como usar

### Requisitos

- .NET 7 SDK instalado
- Banco de dados PostgreSQL configurado
- Docker 

### Configuração

1. Clone o repositório:

    ```bash
    git clone https://github.com/seu-usuario/DeveloperStore.git
    cd DeveloperStore
    ```

2. Configure a connection string no `appsettings.json`.

3. Execute as migrations para criar o banco:

    ```bash
    dotnet ef database update
    ```

4. Rode a aplicação:

    ```bash
    dotnet run --project src/DeveloperStore.WebAPI
    ```

5. Acesse a documentação Swagger:

    ```
    http://localhost:5000/swagger
    ```

## Endpoints principais

| Método | Endpoint                 | Descrição                   |
|--------|--------------------------|-----------------------------|
| GET    | /api/BuscarVendas        | Lista todas as vendas        |
| GET    | /api/BuscarVendas/{id}   | Busca venda por ID           |
| POST   | /api/CriarVenda          | Cria nova venda              |
| PUT    | /api/AlterarVenda        | Atualiza venda existente     |
| DELETE | /api/DeletarVenda/{id}   | Deleta venda                 |

## Regras de negócio importantes

- Descontos aplicados somente para compras com 4 ou mais itens iguais
- Desconto de 10% para 4 a 9 itens, 20% para 10 a 20 itens
- Limite máximo de 20 itens por produto na venda
- Itens com quantidade inferior a 4 não recebem desconto

## Contribuição

Pull requests são bem-vindos! Para grandes mudanças, abra uma issue primeiro para discutirmos.

## Licença

MIT License — veja o arquivo LICENSE para detalhes.


