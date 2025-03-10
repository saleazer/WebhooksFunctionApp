using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Octokit.Webhooks;
using Octokit.Webhooks.AzureFunctions;

new HostBuilder()
    .ConfigureServices((context, collection) =>
    {
        collection.AddSingleton<WebhookEventProcessor, EventProcessor>();
    })
    .ConfigureGitHubWebhooks()
    .ConfigureFunctionsWorkerDefaults()
    .Build()
    .Run();
