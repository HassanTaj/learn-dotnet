

using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.SystemTextJson;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TodoServer.Data;
using TodoServer.Graphs.CatsGraph;
using TodoServer.Graphs.ChatGraph;
using TodoServer.Graphs.TodoGraph;
using TodoServer.Models;
using TodoServer.Services.Chat;
using TodoServer.Services.Events;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(ServiceLifetime.Scoped, ServiceLifetime.Scoped);
builder.Services.AddScoped<AppDbContext>();
builder.Services.TryAddSingleton<CatsData>();
builder.Services.TryAddSingleton<IChatService,ChatService>();
builder.Services.TryAddSingleton<IEventService<Todo>,EventService<Todo>>();

builder.Services.AddSingleton<IGraphQLSerializer, GraphQLSerializer>();
builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSingleton<IFieldMiddleware,InstrumentFieldsMiddleware>();

builder.Services.AddCors();

builder.Services.AddGraphQL(b => b
    .AddSchema<CatsSchema>()  // schema
    .AddSchema<TodoSchema>()  // schema
    .AddSchema<ChatSchema>()  // schema
    .AddScopedSubscriptionExecutionStrategy()
    .UseApolloTracing(true)
    .AddAutoClrMappings() //CLR mappings
    .AddSystemTextJson());   // serializer
                             // Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseCors(con => {
    con.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.UseDeveloperExceptionPage();
app.UseWebSockets();

#region Chat Graph

// configure the graphql endpoint at "/cats/graphql"
app.UseGraphQL<CatsSchema>("/cats/graphql", options => {
    options.HandleGet = false;
    options.HandlePost = true;
    options.HandleWebSockets = true;
    //options.AuthorizationRequired = true;   // require authentication for POST/WebSocket connections
});
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
#endregion

#region Todos Graph
// configure the graphql endpoint at "/cats/graphql"
app.UseGraphQL<TodoSchema>("/todos/graphql", options => {
    options.HandleGet = false;
    options.HandlePost = true;
    options.HandleWebSockets = true;
    //options.AuthorizationRequired = true;   // require authentication for POST/WebSocket connections
});
// configure Playground at "/cats/ui/playground" with relative link to api
app.UseGraphQLAltair("/graph/todos",
    new GraphQL.Server.Ui.Altair.AltairOptions {
        GraphQLEndPoint = "../todos/graphql",
        SubscriptionsEndPoint = "../todos/graphql",
    });
app.UseGraphQLGraphiQL(
    "/graph/todos/ql",
    new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions {
        GraphQLEndPoint = "../todos/graphql",
        SubscriptionsEndPoint = "../todos/graphql",
    });

app.UseGraphQLPlayground(
    "/graph/todos/alt",
    new GraphQL.Server.Ui.Playground.PlaygroundOptions {
        GraphQLEndPoint = "../todos/graphql",
        SubscriptionsEndPoint = "../todos/graphql",
    });
#endregion

#region Chat Graph
// configure the graphql endpoint at "/cats/graphql"
app.UseGraphQL<ChatSchema>("/chat/graphql", options => {
    options.HandleGet = false;
    options.HandlePost = true;
    options.HandleWebSockets = true;
    //options.AuthorizationRequired = true;   // require authentication for POST/WebSocket connections
});
// configure Playground at "/cats/ui/playground" with relative link to api
app.UseGraphQLAltair("/graph/chat",
    new GraphQL.Server.Ui.Altair.AltairOptions {
        GraphQLEndPoint = "../chat/graphql",
        SubscriptionsEndPoint = "../chat/graphql",
    });
app.UseGraphQLGraphiQL(
    "/graph/chat/ql",
    new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions {
        GraphQLEndPoint = "../chat/graphql",
        SubscriptionsEndPoint = "../chat/graphql",
    });
#endregion


await app.RunAsync();
