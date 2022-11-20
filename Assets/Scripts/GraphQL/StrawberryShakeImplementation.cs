using StrawberryShake;
using Microsoft.Extensions.DependencyInjection;
using Demo;
using System;
using System.Threading.Tasks;

public class StrawberryShakeImplementation
{
    private IConferenceClient client;

    public string Init()
    {
        var serviceCollection = new ServiceCollection();
        string url = "https://workshop.chillicream.com/graphql";

        serviceCollection
            .AddConferenceClient()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(url));

        IServiceProvider services = serviceCollection.BuildServiceProvider();

        client = services.GetRequiredService<IConferenceClient>();

        return $"Initialized with {url}" + Environment.NewLine;
    }

    public void Reset()
    {
        client = null;
    }

    public async Task<string> RunQuery()
    {
        var result = await client.GetSessions.ExecuteAsync();
        result.EnsureNoErrors();

        string resultStr = "";
        foreach (var session in result.Data.Sessions.Nodes)
        {
            resultStr += session.Title + Environment.NewLine;
        }
        return resultStr;
    }
}