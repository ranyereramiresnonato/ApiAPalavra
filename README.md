# 📖 Api A Palavra

Esta é uma API REST que fornece os dados da Bíblia em formato JSON. Os dados foram baseados no projeto **Bíblia Livre**, com os devidos créditos abaixo. A API está configurada para rodar em ambientes de desenvolvimento e produção via Docker.

---

## 🧾 Créditos dos Dados

Os dados utilizados nesta API foram formatados a partir de uma versão pública da Bíblia, com os seguintes créditos:

- **Autor do Arquivo**: Everson Silva  
- **Representante**: everScript  
- **Data de Criação**: 17 de janeiro de 2023  
- **Fonte da Versão**: [Projeto Bíblia Livre](https://sites.google.com/site/biblialivre)  
- **Nota**: O trabalho realizado por Everson Silva foi a **formatação do conteúdo da Bíblia em JSON**. Para mais informações sobre os direitos da versão, visite o site oficial.

---

## 🚀 Como rodar o projeto

### Pré-requisitos

- [Docker](https://www.docker.com/)

### 📦 Rodando com Docker

#### Ambiente de Desenvolvimento

```bash
docker build --target build -t biblia-api-dev .
docker run -it --rm -p 5001:5001 biblia-api-dev
