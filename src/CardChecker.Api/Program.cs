using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CardService>();
builder.Services.AddSingleton<AllowedActionsService>();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "CardCheckerApi";
    config.Title = "CardCheckerApi";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "CardCheckerApi";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapPost("/checkAllowedActions", CheckAllowedCardActions)
    .Produces<CardAction[]>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status422UnprocessableEntity)
    .AddEndpointFilter<CheckAllowedCardActionsRequestValidatingFilter>();

app.Run();

static async Task<IResult> CheckAllowedCardActions(
    CheckAllowedCardActionsRequest request,
    CardService cardService,
    AllowedActionsService allowedActionsService
    )
{
    var card = await cardService.GetCardDetails(
        request.UserId,
        request.CardNumber
    );

    return card != null
        ? TypedResults.Ok(allowedActionsService.CheckAllowedActions(card))
        : TypedResults.NotFound();
}

public partial class Program { }