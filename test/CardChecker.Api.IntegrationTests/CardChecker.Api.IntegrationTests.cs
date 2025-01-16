using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace CardChecker.Api.IntegrationTests;

public class IntegrationTests : IClassFixture<IntegrationTestsFixture>
{
    private readonly HttpClient _client;

    public IntegrationTests(IntegrationTestsFixture fixture)
    {
        _client = fixture.Client;
    }

    [Fact]
    public async Task CheckAllowedActions_WhenCardNotFound_Returns404()
    {
        var request = new CheckAllowedCardActionsRequest("U", "C");

        var response = await _client.PostAsJsonAsync("/checkAllowedActions", request);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CheckAllowedActions_WhenEmptyContent_Returns422()
    {
        var response = await _client.PostAsJsonAsync("/checkAllowedActions", new StringContent(string.Empty));

        Assert.Equal(HttpStatusCode.UnprocessableContent, response.StatusCode);
    }

    public static IEnumerable<object[]> InvalidRequests =>
    [
        [ new CheckAllowedCardActionsRequest("", "CardNumber"), "UserId cannot be empty." ],
        [ new CheckAllowedCardActionsRequest(null!, "CardNumber"), "UserId cannot be empty." ],
        [ new CheckAllowedCardActionsRequest("UserId", ""), "CardNumber cannot be empty." ],
        [ new CheckAllowedCardActionsRequest("UserId", null!), "CardNumber cannot be empty." ],
        [ new CheckAllowedCardActionsRequest("", ""), "UserId cannot be empty.\nCardNumber cannot be empty."],
        [ new CheckAllowedCardActionsRequest(null!, null!), "UserId cannot be empty.\nCardNumber cannot be empty."],
    ];

    [Theory]
    [MemberData(nameof(InvalidRequests))]
    public async Task CheckAllowedActions_WhenRequestInvalid_Returns422(CheckAllowedCardActionsRequest request, string errorMessage)
    {
        var response = await _client.PostAsJsonAsync("/checkAllowedActions", request);

        Assert.Equal(HttpStatusCode.UnprocessableContent, response.StatusCode);

        var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        Assert.NotNull(problemDetails);
        Assert.Equal(errorMessage, problemDetails.Detail);
    }

    [Fact]
    public async Task CheckAllowedActions_WhenRequestValid_ReturnsActions()
    {
        var response = await _client.PostAsJsonAsync(
            "/checkAllowedActions",
            new CheckAllowedCardActionsRequest("User1", "Card11")
        );

        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadFromJsonAsync<CardAction[]>(
            new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
            }
        );

        Assert.NotEmpty(content!);
    }
}
