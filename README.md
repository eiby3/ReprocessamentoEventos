# ReprocessamentoEventos

Esse projeto foi pensando para facilitar o reprocessamento de eventos dentro do meu trabalho, utilizando principios da arquitetura limpa e injeção de dependência.

# Arquitetura Limpa e Injeção de Dependência no C#
A arquitetura limpa é um paradigma de desenvolvimento de software que busca a separação de preocupações e a responsabilidade única em cada camada da aplicação. Isso ajuda a manter o código organizado, fácil de manter e escalável.

Já a injeção de dependência é uma técnica que permite que as dependências de uma classe sejam fornecidas externamente, ao invés de serem criadas internamente. Isso permite uma maior flexibilidade e testabilidade, pois as dependências podem ser substituídas facilmente durante o desenvolvimento e testes.

A combinação da arquitetura limpa e injeção de dependência é muito poderosa e é amplamente utilizada em aplicações C#.

# Separação de preocupações
Ao seguir a arquitetura limpa, é importante separar sua aplicação em camadas lógicas, cada uma responsável por uma única preocupação. No caso desse projeto eu separei em três camadas (não precisei da camada infra, pois não será necessário acesso a dados, serviços em nuvem ou integração com outro sistema):

## Core: 
Data Access Objects (DTO): objetos de transporte de dados, geralmente utilizados em retorno de serviços de infra-estrutura (integração com outro sistema), consultas com projeção de dados diferenciadas.
Interfaces (de serviços de infra-estrutura, dominio, repositorios): utilizadas em diferentes camadas, como API, Aplicação e Infraestrutura.
        
## Application:
Camada responsável por código de aplicação, onde as funcionalidades expostas vão estar, em forma de serviços (ou Commands e Queries, dependendo do padrão utilizado). Também contém os modelos de entrada e saída da aplicação, que serão utilizados diretamente na API (seja no retorno da API, ou no corpo da requisição).
        
## API:
Camada responsável pelo código da interface (seja ela uma API, ou a View e Controller do MVC).
Essa camada depende de todas as outras. Nela é feita a configuração de injeção de dependeência envolvendo as interfaces contidas no Core, e das implementações contidas na Infrastructure e Core.
