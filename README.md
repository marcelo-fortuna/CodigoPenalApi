## Sobre o projeto
Projeto criado com o objetivo da realização do exercício back-end proposto pela [Cidade Alta](https://cidadealta.gg/)

## Começando
Para colocar uma cópia local em execução, siga estas etapas de exemplo simples.

### Pré-Requisitos
* Microsoft Visual Studio 2019 Comunnity (Preferência de Versão: 16.11.16).
* Microsoft SQL Server Management Studio - 18.12.1 (Preferência de Versão: 15.0.18424.0).
* .NET 5.0

### Instalação

1. Instale o [Microsoft Visual Studio Community 2019](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&rel=16&src=myvs&utm_medium=microsoft&utm_source=my.visualstudio.com&utm_campaign=download&utm_content=vs+community+2019).
2. Instale o [Microsoft SQL Server Management Studio - 18.12.1](https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?redirectedfrom=MSDN&view=sql-server-ver16).
3. Instale o [.NET 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/5.0).

4. Clone o repositorio
   ```sh
   git clone https://github.com/marcelo-fortuna/CodigoPenalApi.git
   ```

### Utilização
1. Vá na até a pasta em que clonou o repositório, abra a pasta **CodigoPenalApi** 
depois dê um duplo clique no arquivo chamado `CodigoPenalApi.sln` para obter a visualização completa da solução.
2. Verifique se a [string de conexão com o banco de dados](https://www.connectionstrings.com/sql-server) 
está com as informações corretas de acordo com sua máquina em `CodigoPenalApi/appsettings.json`.

Será algo parecido com isso: 
  ```json
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=CriminalCodesDB;Trusted_Connection=True;"
  },
  ```
| ATENÇÃO: Não mude o nome da Database (_CriminalCodesDB_) para não causar erros no funcionamento do projeto! |
| --- |

3. Na parte superior do Visual Studio 2019 clique em **Ferramentas > Gerenciador de Pacote do NuGet > Console do Gerenciador de Pacotes**. 
4. No console digite o seguinte comando:
  ```cmd
update-database
  ```
5. Execute o projeto clicando no botão verde (IIS Express).

## Contato
Twitter - [@nutsfpss](https://twitter.com/nutsfpss)

Discord - [Nuts#0007](https://discord.gg) - ID - 793961251331768380

E-Mail - celofortuna@gmail.com

LinkedIn - [Marcelo Fortuna](https://www.linkedin.com/in/marcelofortuna)

Link do projeto: [https://github.com/marcelo-fortuna/CodigoPenalApi.git](https://github.com/marcelo-fortuna/CodigoPenalApi.git)

## Licença
Distribuído sob a licença MIT. Veja o arquivo `LICENSE.txt` para mais informações.
