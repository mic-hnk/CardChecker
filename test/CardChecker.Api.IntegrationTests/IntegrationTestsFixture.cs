using Microsoft.AspNetCore.Mvc.Testing;

namespace CardChecker.Api.IntegrationTests;

public class IntegrationTestsFixture
{
    public IntegrationTestsFixture()
    {
        var factory = new WebApplicationFactory<Program>();
        Client = factory.CreateClient();
    }

    public HttpClient Client { get; private set; }
}
