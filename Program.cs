// Est� criando um construdor que ir� contruir a API com base no argumento que est� sendo enviado
// Esse 'args' s�o as dependencias do projeto

using FiapStore.Interface;
using FiapStore.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Na hora que voc� liga a sua aplica��o ele ir� injetar ao UsuarioRepository dentro da interface UsuarioRepository, desse modo, eles compartilham da mesma classe inst�nciada
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
// Ela funciona somente no contexto da requisi��o, e vai passando de uma class para a outra,por�m ele cria uma nova inst�ncia
// builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
// A cada inje��o que voc� dar ele ir� criar uma outra inst�ncia, melhor maneira para caso for desacoplar de tudo
// builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Documenta��o para fazer os testes das routes
    app.UseSwagger();
    // Tela que ira mostrar assim que dar o deploy, nela teremos a visualiza��o das routes
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Assim que termina de contruir a API ele a funtion abaixo ir� "expor" a API para o cliente
app.MapControllers();

app.Run();
