# 📦 Pagamentos

> **Projeto de estudos em C# (.NET) com RabbitMQ**  
> Este repositório foi criado **exclusivamente para fins educacionais**, com o objetivo de praticar conceitos de arquitetura, mensageria e boas práticas de desenvolvimento em C#.

---

## 🎯 Objetivo do Projeto

O projeto **Pagamentos** tem como principal finalidade o **aprendizado prático**. Ele simula um fluxo simples de processamento de pagamentos utilizando **mensageria assíncrona**, permitindo estudar:

- Comunicação entre serviços via **RabbitMQ**
- Separação de responsabilidades (Emitter x Consumer)
- Organização de projetos em camadas
- Conceitos básicos de arquitetura orientada a eventos
- Estruturação de soluções em **.NET**

⚠️ **Importante:** este projeto **não deve ser utilizado em produção**. Ele não contempla todas as validações, regras de negócio e requisitos de segurança necessários para um sistema real.

---

## 🧱 Estrutura do Repositório

A solução foi organizada de forma modular para facilitar o entendimento:

```
📂 Pagamentos
 ├── 📁 APIs/
 │   └── Pagamentos.Emitter          # Serviço responsável por publicar eventos de pagamento
 ├── 📁 Communication/
 │   └── Pagamentos.Communication    # Camada de integração com RabbitMQ
 ├── 📁 Domain/
 │   └── Pagamentos.Domain           # Entidades e regras de negócio
 ├── 📁 Infrastructure/
 │   └── Pagamentos.Infrastructure  # Configurações e infraestrutura
 ├── 📁 Shared/
 │   └── Pagamentos.Shared           # Componentes compartilhados
 ├── Pagamentos.Consumer             # Serviço que consome e processa as mensagens
 ├── Pagamentos.sln                  # Solução principal
 └── .gitignore
```

Essa divisão ajuda a entender melhor o papel de cada camada dentro de uma aplicação distribuída.

---

## 🔄 Fluxo de Funcionamento

1. O **Pagamentos.Emitter** envia uma mensagem de pagamento para o RabbitMQ.
2. O **RabbitMQ** atua como intermediário, armazenando e roteando a mensagem.
3. O **Pagamentos.Consumer** consome essa mensagem e executa o processamento.

Esse fluxo representa um cenário comum em arquiteturas modernas baseadas em eventos.

---

## 🛠️ Tecnologias Utilizadas

- **C# / .NET**
- **RabbitMQ** (mensageria)
- **Docker** (opcional, para execução do RabbitMQ)
- **Visual Studio / VS Code**
- **Git & GitHub**

---

## 📋 Pré-requisitos

Para executar o projeto localmente, é necessário:

- .NET SDK 6.0 ou superior
- RabbitMQ em execução (local ou via Docker)
- IDE compatível com .NET (Visual Studio ou VS Code)

---

## ▶️ Como Executar o Projeto

### 1️⃣ Clonar o repositório

```bash
git clone https://github.com/Mateus-R-De-Lima/Pagamentos.git
cd Pagamentos
```

### 2️⃣ Subir o RabbitMQ com Docker (opcional)

```bash
docker run -d --name rabbitmq \
  -p 5672:5672 \
  -p 15672:15672 \
  rabbitmq:3-management
```

A interface de gerenciamento estará disponível em:

```
http://localhost:15672
```
Usuário e senha padrão:
```
guest / guest
```

### 3️⃣ Restaurar e compilar a solução

```bash
dotnet restore
dotnet build
```

### 4️⃣ Executar os serviços

- Inicie o **Pagamentos.Consumer**
- Em seguida, execute o **Pagamentos.Emitter**

Observe no console o envio e o consumo das mensagens.

---

## 📚 Possíveis Evoluções (Estudos Futuros)

Este projeto pode ser expandido para aprofundar os estudos, por exemplo:

- Adicionar persistência em banco de dados
- Criar uma API REST para envio de pagamentos
- Implementar testes unitários e de integração
- Utilizar Dead Letter Queues (DLQ)
- Criar containers Docker para todos os serviços
- Aplicar padrões como Retry, Circuit Breaker e Idempotência

---

## 👨‍💻 Autor

**Mateus R. de Lima**  
Projeto desenvolvido com foco em aprendizado e prática de **C#**, **RabbitMQ** e **arquitetura de software**.

---

⭐ Se este repositório te ajudou de alguma forma, fique à vontade para deixar uma estrela!

