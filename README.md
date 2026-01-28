# 🚀 Pagamentos – Sistema Assíncrono de Processamento de Pagamentos com RabbitMQ e MongoDB

Este repositório contém um **projeto de estudo em C# (.NET)** que demonstra a construção de um **sistema de pagamentos assíncrono**, utilizando **RabbitMQ para mensageria** e **MongoDB como banco de dados NoSQL** para persistência dos pagamentos.

O foco principal do projeto é **aprendizado prático** de arquitetura distribuída, mensageria e persistência em NoSQL, simulando um cenário real de processamento de pagamentos.

---

## 📌 Objetivo do Projeto

O objetivo deste projeto é:

- Estudar **mensageria assíncrona com RabbitMQ**
- Aplicar **desacoplamento entre serviços** (Producer x Consumer)
- Persistir dados de pagamentos em um **banco NoSQL (MongoDB)** de forma simples e objetiva
- Simular um **fluxo real de processamento de pagamentos**
- Aplicar boas práticas de organização de projeto em **C# / .NET**

> ⚠️ **Importante:** Este é um projeto de estudo e aprendizado. Não possui foco em regras fiscais, segurança bancária ou certificações de produção.

---

## 🧠 Tecnologias e Conceitos Utilizados

| Tecnologia | Finalidade |
|-----------|-----------|
| **C# / .NET** | Plataforma principal de desenvolvimento |
| **RabbitMQ** | Broker de mensagens para comunicação assíncrona |
| **MongoDB** | Banco de dados NoSQL para persistência dos pagamentos |
| **Mensageria (AMQP)** | Processamento desacoplado e escalável |
| **NoSQL** | Armazenamento flexível de dados de pagamento |
| **Arquitetura por Camadas** | Organização e separação de responsabilidades |

---

## 🧩 Arquitetura do Sistema

O sistema é dividido em responsabilidades bem definidas:

1. **Emitter (Producer)**
   - Responsável por criar e enviar mensagens de pagamento para o RabbitMQ

2. **RabbitMQ (Message Broker)**
   - Responsável por intermediar a comunicação entre os serviços

3. **Consumer**
   - Consome as mensagens da fila
   - Processa os dados do pagamento
   - Salva o pagamento no **MongoDB**

4. **MongoDB (NoSQL)**
   - Armazena os pagamentos processados
   - Utilizado de forma simplificada para fins de estudo

---

## 📂 Estrutura do Repositório

```text
/APIs
  └── Pagamentos.Emitter        -> API responsável por publicar mensagens
/Consumers
  └── Pagamentos.Consumer      -> Serviço que consome mensagens
/Domain
  └── Pagamentos.Domain        -> Entidades e regras de negócio
/Infrastructure
  └── Pagamentos.Infrastructure-> MongoDB, RabbitMQ e infraestrutura
/Shared
  └── Pagamentos.Shared        -> DTOs, notificações e contratos
Pagamentos.sln                 -> Solução principal
```

Essa estrutura facilita manutenção, testes e entendimento do fluxo do sistema.

---

## 🗄️ Persistência com MongoDB (NoSQL)

O **MongoDB** foi escolhido para:

- Estudo de **banco NoSQL orientado a documentos**
- Facilidade de armazenamento de dados semi‑estruturados
- Evitar complexidade de mapeamentos relacionais

### 📌 Como é usado no projeto

- Cada pagamento processado pelo **Consumer** é salvo como um documento
- Não há relacionamentos complexos
- Estrutura simples, focada em aprendizado

Exemplo conceitual de documento salvo:

```json
{
  "_id": "ObjectId",  
  "valor": 150.00,
  "status": "Processado",
  "dataCriacao": "2026-01-27T10:00:00"
}
```

---

## 🚀 Como Executar o Projeto

### 📌 Pré‑requisitos

- .NET SDK
- Docker (opcional, recomendado)
- RabbitMQ
- MongoDB

### ▶️ Subindo RabbitMQ e MongoDB via Docker

```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

docker run -d --name mongodb -p 27017:27017 mongo
```

---

### 📥 Clonar o Repositório

```bash
git clone https://github.com/Mateus-R-De-Lima/Pagamentos.git
cd Pagamentos
```

---

### ⚙️ Build do Projeto

```bash
dotnet restore
dotnet build
```

---

### ▶️ Executar

1. Inicie o **RabbitMQ** e o **MongoDB**
2. Execute o projeto **Pagamentos.Emitter**
3. Execute o projeto **Pagamentos.Consumer**

Ao enviar um pagamento, ele será:

➡️ Publicado no RabbitMQ
➡️ Consumido pelo Consumer
➡️ Persistido no MongoDB

---

## 📈 Aprendizados Abordados

✔ Mensageria com RabbitMQ
✔ Processamento assíncrono
✔ Integração com MongoDB
✔ Arquitetura desacoplada
✔ Organização de projetos em .NET

---

## 🔮 Possíveis Evoluções

- Implementar retry e dead‑letter queue
- Adicionar logs estruturados
- Criar testes unitários e de integração
- Adicionar versionamento de eventos
- Criar dashboard de monitoramento

---
💡 *Projeto desenvolvido por Mateus Lima para fins educacionais e evolução técnica em C# e arquitetura distribuída.*

