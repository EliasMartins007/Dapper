# DapperDemoApp - Demonstração de Dapper com .NET Framework

Este projeto é uma aplicação de console simples em .NET Framework 4.8 que demonstra as operações CRUD (Criar, Ler, Atualizar, Excluir) básicas utilizando o micro-ORM Dapper para interagir com um banco de dados SQL Server.

## Pré-requisitos

Antes de executar este projeto, você precisará ter o seguinte instalado:

*   **.NET Framework 4.8 SDK**: Para compilar e executar a aplicação. Você pode baixá-lo do [site da Microsoft](https://dotnet.microsoft.com/download/dotnet-framework/net48).
*   **SQL Server**: Uma instância do SQL Server (qualquer edição, incluindo Express) para hospedar o banco de dados de demonstração.

## Configuração

1.  **Clone o Repositório (se aplicável)**:
    ```bash
    # Se você estiver obtendo este código de um repositório git
    # git clone <url_do_repositorio>
    # cd DapperDemoApp
    ```

2.  **Configure a String de Conexão**:
    *   Abra o arquivo `DapperDemoApp/App.config` no projeto `DapperDemoApp`.
    *   Localize a seção `<connectionStrings>`:
        ```xml
        <connectionStrings>
          <add name="DefaultConnection" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=DapperDemoDB;Integrated Security=True" providerName="System.Data.SqlClient" />
        </connectionStrings>
        ```
    *   **Importante**: Modifique o atributo `connectionString` para apontar para a sua instância do SQL Server e o banco de dados desejado.
        *   `Data Source`: Endereço do seu servidor SQL (ex: `localhost`, `.\SQLEXPRESS` para SQL Express local, `SEU_SERVIDOR\SUA_INSTANCIA`).
        *   `Initial Catalog`: Nome do banco de dados que será usado (ex: `DapperDemoDB`). A aplicação tentará criar a tabela `Produtos` neste banco de dados. O banco de dados em si deve existir.
        *   `Integrated Security=True`: Usa a autenticação do Windows. Se você precisar usar autenticação SQL Server, altere para `User ID=seu_usuario;Password=sua_senha;Integrated Security=False;`.

## Compilando e Executando a Aplicação

Você pode compilar e executar a aplicação de algumas maneiras:

### Usando Visual Studio:

1.  Abra o arquivo de solução `DapperDemoApp.sln` no Visual Studio (2017 ou posterior é recomendado).
2.  Certifique-se de que o projeto `DapperDemoApp` está definido como projeto de inicialização.
3.  Restaure os pacotes NuGet (o Visual Studio geralmente faz isso automaticamente ao abrir a solução, ou você pode clicar com o botão direito na solução no Gerenciador de Soluções e escolher "Restaurar Pacotes NuGet").
4.  Pressione `F5` ou clique no botão "Iniciar" para compilar e executar o projeto.
    Uma janela de console aparecerá, mostrando as operações CRUD sendo executadas.

### Usando MSBuild (Linha de Comando):

1.  Abra um Prompt de Comando do Desenvolvedor para Visual Studio ou certifique-se de que o MSBuild está no seu PATH.
2.  Navegue até o diretório raiz da solução (`DapperDemoApp`).
3.  Execute o seguinte comando para restaurar os pacotes NuGet (requer `nuget.exe` no PATH ou especifique o caminho completo):
    ```bash
    nuget restore DapperDemoApp.sln
    ```
    (Se você não tiver `nuget.exe` configurado, o Visual Studio é a maneira mais fácil de restaurar os pacotes.)
4.  Execute o seguinte comando para compilar o projeto:
    ```bash
    msbuild DapperDemoApp.sln /property:Configuration=Debug
    ```
    Ou para Release:
    ```bash
    msbuild DapperDemoApp.sln /property:Configuration=Release
    ```
5.  Após a compilação bem-sucedida, execute o arquivo `.exe` gerado, que estará localizado em um subdiretório como `DapperDemoApp/bin/Debug/` ou `DapperDemoApp/bin/Release/`:
    ```bash
    DapperDemoApp\bin\Debug\DapperDemoApp.exe
    ```

## Visão Geral da Aplicação

A aplicação demonstra as seguintes operações com uma entidade `Produto`:

1.  **Criação da Tabela**: Verifica se a tabela `Produtos` existe no banco de dados configurado e a cria se não existir.
2.  **Limpeza de Dados**: Remove quaisquer dados existentes da tabela `Produtos` para garantir uma execução limpa da demonstração.
3.  **Adicionar Produtos**: Insere alguns registros de exemplo na tabela `Produtos`.
4.  **Listar Todos os Produtos**: Recupera e exibe todos os produtos da tabela.
5.  **Obter Produto por ID**: Busca e exibe um produto específico pelo seu ID.
6.  **Atualizar Produto**: Modifica os dados de um produto existente.
7.  **Excluir Produto**: Remove um produto da tabela.
8.  **Listar Produtos Novamente**: Mostra o estado final da tabela após as operações.

O código para interagir com o banco de dados usando Dapper está encapsulado na classe `ProdutoRepository.cs`. A classe de modelo é `Produto.cs`, e o `Program.cs` orquestra a demonstração.
