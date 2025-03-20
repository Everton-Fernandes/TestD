# Sistema de Autenticação com .NET e Next.js

Este é um projeto de sistema de login completo, utilizando **.NET 9.0** no backend e **Next.js com TypeScript** no frontend. O sistema inclui funcionalidades como **registro de usuários, login, troca de senha, gerenciamento de usuários (admin)** e autenticação via **JWT**.

## 📌 Funcionalidades

### **Backend (.NET 9.0)**
- API REST com **ASP.NET Core**
- Banco de dados **In-Memory**
- **Autenticação JWT**
- Gerenciamento de usuários via **Identity**
- Rotas protegidas por **roles (Admin, User)**
- Swagger para documentação da API

### **Frontend (Next.js + TypeScript + TailwindCSS)**
- Interface responsiva e moderna
- Gerenciamento de estado com **Context API**
- **Login e registro de usuários**
- **Proteção de rotas com autenticação**
- Listagem de usuários no painel Admin
- Botão de **logout**
- Tela de **recuperação de senha**

## 🛠 Tecnologias Utilizadas
- **Backend:** .NET 9.0, Identity, Entity Framework Core, In-Memory DB
- **Frontend:** Next.js, React, TypeScript, TailwindCSS
- **Autenticação:** JSON Web Tokens (JWT)
- **Gerenciamento de estado:** Context API
- **Banco de dados:** In-Memory (para testes)

## 🚀 Como Rodar o Projeto

### **Backend (.NET 9.0)**
1. Instale o **.NET 9.0 SDK**
2. No terminal, navegue até a pasta do backend e instale as dependências:
   ```sh
   dotnet restore
   ```
3. Execute a aplicação:
   ```sh
   dotnet run
   ```
4. A API estará disponível em `http://localhost:5000`
5. Acesse o **Swagger** em: `http://localhost:5000/swagger`

### **Frontend (Next.js)**
1. Instale as dependências:
   ```sh
   npm install
   ```
2. Execute o servidor de desenvolvimento:
   ```sh
   npm run dev
   ```
3. O frontend estará disponível em `http://localhost:3000`

## 🔑 Configuração do JWT
No backend, o JWT é configurado no `appsettings.json`. Certifique-se de definir uma chave segura:
```json
"Jwt": {
  "Key": "sua-chave-secreta-muito-segura-para-jwt"
}
```

## 📡 CORS
Caso o frontend não consiga acessar a API, adicione esta configuração no `Program.cs`:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
app.UseCors("AllowAll");
```

## 🔐 Proteção de Rotas (Roles)
No backend, rotas podem ser protegidas usando **[Authorize(Roles = "Admin")]**:
```csharp
[Authorize(Roles = "Admin")]
[HttpGet("users")]
public IActionResult GetUsers() { /* Retorna lista de usuários */ }
```

## 📩 API Endpoints
### **Autenticação**
- `POST /api/auth/register` - Registrar um novo usuário
- `POST /api/auth/login` - Realizar login
- `POST /api/auth/reset-password` - Esqueci minha senha

### **Usuários**
- `GET /api/users` - Listar todos os usuários (Admin)
- `DELETE /api/users/{id}` - Excluir um usuário (Admin)

## 👨‍💻 Autor
Desenvolvido por **Everton**

