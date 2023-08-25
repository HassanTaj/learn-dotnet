

using GraphQL;
using Microsoft.AspNetCore.Builder;
using TodoServer.Data;
using TodoServer.Graphs.CatsGraph;
using TodoServer.Graphs.TodoGraph;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(ServiceLifetime.Scoped, ServiceLifetime.Scoped);
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<CatsData>();
builder.Services.AddSingleton<TodoService>();

builder.Services.AddCors();

builder.Services.AddGraphQL(b => b
    .AddSchema<CatsSchema>()  // schema
    .AddSchema<TodoSchema>()  // schema
    .AddAutoClrMappings() //CLR mappings
    .AddSystemTextJson());   // serializer
                             // Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseDeveloperExceptionPage();
app.UseWebSockets();
// configure the graphql endpoint at "/cats/graphql"
app.UseGraphQL<CatsSchema>("/cats/graphql");
// configure Playground at "/cats/ui/playground" with relative link to api
app.UseGraphQLPlayground("/graph/cats",
    new GraphQL.Server.Ui.Playground.PlaygroundOptions {
        GraphQLEndPoint = "../cats/graphql",
        SubscriptionsEndPoint = "../cats/graphql",
    });

app.UseGraphQLAltair("/graph/cats/alt",
    new GraphQL.Server.Ui.Altair.AltairOptions {
        GraphQLEndPoint = "../cats/graphql",
        SubscriptionsEndPoint = "../cats/graphql",
    });

app.UseCors(con => {
    con.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
}); 
// configure the graphql endpoint at "/cats/graphql"
app.UseGraphQL<TodoSchema>("/todos/graphql");
// configure Playground at "/cats/ui/playground" with relative link to api
app.UseGraphQLAltair("/graph/todos",
    new GraphQL.Server.Ui.Altair.AltairOptions {
        GraphQLEndPoint = "../todos/graphql",
        SubscriptionsEndPoint = "../todos/graphql",
    });

app.UseGraphQLPlayground(
    "/graph/todos/alt",
    new GraphQL.Server.Ui.Playground.PlaygroundOptions {
        GraphQLEndPoint = "../todos/graphql",
        SubscriptionsEndPoint = "../todos/graphql",
    });




await app.RunAsync();
