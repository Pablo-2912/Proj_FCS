# Proj_FCS  

## 📌 Configuração do Ambiente  

Para executar este projeto corretamente, siga os passos abaixo.  

### 🔧 Configuração da Conexão com o Banco de Dados  

1. **Editar o arquivo `appsettings.json`**  
   - Localize a seção `"ConnectionStrings"`.  
   - Atualize o valor de `"DefaultConnection"` com as credenciais do seu servidor SQL Server.  

2. **Banco de Dados**  
   - O Entity Framework Core já está configurado para **SQL Server**.  
   - **Não é necessário executar migrations**, pois a estruturação do banco é feita de forma automatica.  

### 🚀 Tecnologias Utilizadas  
- **.NET Core / .NET**  
- **Entity Framework Core**  
- **SQL Server**  

## 📂 Como Clonar o Repositório  

```sh
git clone https://github.com/seu-usuario/Proj_FCS.git
cd Proj_FCS
