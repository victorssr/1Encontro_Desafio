# Desafio 1ª encontro 2020 - FIAP
### Desafio proposto
Criar uma solução 100% online para o casamento civil utilizando blockchain.

### Integrantes do grupo
Victor Savoi Silvestrini Rodrigues - RM 81991\
Pedro Henrique Rangel Francisco - RM 82165\
Lucas Oliveira Sanches Leal - RM 82021\
Caio Campos Aureliano- RM 83786\
Pedro Cardo Vasconcellos - RM 82387

### Tecnologias utilizadas
Frontend - Angular\
Backend - .Net Core 3.1 Web API\
IBM Blockchain Platform - Hyperledge

## Instruções para testes
### Pré-requisitos
Siga os passos abaixo e garanta que tudo estará instalado para a execução do projeto.

1. Baixe e instale o VS Code no link https://code.visualstudio.com/ ou o Visual Studio Community 2019 pelo link https://visualstudio.microsoft.com/pt-br/vs/ \
2. Baixe e instale o .Net Core 3.1 pelo link https://dotnet.microsoft.com/download/dotnet-core/3.1 \
3. Baixe e instale o NodeJS pelo link https://nodejs.org/ (selecione a opção "LTS"). \
4. Instale o Angular CLI executando o seguinte comando no terminal: \
**npm i -g @angular/cli**

### Passo a passo
Caso utilize o Visual Studio Community, vá na pasta "server" e abra a solution na IDE, defina o projeto CartorioCasamento.API como o projeto inicializador e depure o projeto.

Caso utilize o VS Code ou qualquer editor de texto que não seja o Visual Studio Community, siga os passos abaixo para executar o projeto:
Após tudo instalado e configurado, abra o prompt de comando e navegue até a pasta do projeto e execute os comandos abaixo respeitando a sequência.

**No terminal acesse a pasta "server" e execute os comandos abaixo:**
- dotnet restore
- dotnet build
- acessar o projeto CartorioCasamento.API (cd CartorioCasamento.API)
- dotnet run

**No terminal acesse a pasta "application" e execute os comandos abaixo:**

- npm install
- ng serve -o

**Lembre-se de verificar se a url da api está correta no arquivo src/environment/environment.ts**
