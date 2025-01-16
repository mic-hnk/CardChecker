public class CheckAllowedCardActionsRequestValidatingFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var request = context.GetArgument<CheckAllowedCardActionsRequest>(0);

        IEnumerable<string> errors = null!;

        if (string.IsNullOrEmpty(request.UserId))
        {
            errors ??= Enumerable.Empty<string>();
            errors = errors.Append("UserId cannot be empty.");
        }

        if (string.IsNullOrEmpty(request.CardNumber))
        {
            errors ??= Enumerable.Empty<string>();
            errors = errors.Append("CardNumber cannot be empty.");
        }

        if (errors is not null && errors.Any())
        {
            return Results.Problem(
                detail: string.Join('\n', errors),
                statusCode: 422);
        }

        return await next(context);
    }
}