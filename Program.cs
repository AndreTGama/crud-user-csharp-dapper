// Está criando um construdor que irá contruir a API com base no argumento que está sendo enviado
// Esse 'args' são as dependencias do projeto

using FiapStore.Interface;
using FiapStore.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Na hora que você liga a sua aplicação ele irá injetar ao UsuarioRepository dentro da interface UsuarioRepository, desse modo, eles compartilham da mesma classe instânciada
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
// Ela funciona somente no contexto da requisição, e vai passando de uma class para a outra,porém ele cria uma nova instância
// builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
// A cada injeção que vocÊ dar ele irá criar uma outra instância, melhor maneira para caso for desacoplar de tudo
// builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Documentação para fazer os testes das routes
    app.UseSwagger();
    // Tela que ira mostrar assim que dar o deploy, nela teremos a visualização das routes
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Assim que termina de contruir a API ele a funtion abaixo irá "expor" a API para o cliente
app.MapControllers();

app.Run();
