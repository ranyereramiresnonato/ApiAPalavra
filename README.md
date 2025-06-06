# 📖 API A Palavra

Esta é uma API REST que disponibiliza os dados da Bíblia em formato JSON. Os dados foram estruturados com base no projeto **Bíblia Livre** (créditos abaixo). A API está pronta para execução em ambientes de desenvolvimento e produção via Docker.

---

## 🧾 Créditos dos Dados

Os dados utilizados nesta API foram extraídos e formatados a partir de uma versão pública da Bíblia, com os seguintes créditos:

- **Autor do Arquivo**: Everson Silva  
- **Representante**: everScript  
- **Data de Criação**: 17 de janeiro de 2023  
- **Fonte Original**: [Projeto Bíblia Livre](https://sites.google.com/site/biblialivre)  
- **Observação**: O trabalho de Everson Silva consistiu na **formatação do conteúdo bíblico em JSON**. Para mais informações sobre os direitos da versão utilizada, acesse o site oficial.

---

## 🚀 Como executar o projeto

### ✅ Pré-requisitos

- [Docker](https://www.docker.com/)

### 📦 Executando com Docker

#### Ambiente de Desenvolvimento

Após executar os comandos abaixo, a API estará disponível em:  
🔗 **http://localhost:8080**

Para acessar a documentação Swagger:  
📘 **http://localhost:8080/swagger/index.html**

```bash
docker build -t api-a-palavra .
docker run -d -p 8080:8080 -p 8081:8081 --name api-a-palavra-container api-a-palavra
