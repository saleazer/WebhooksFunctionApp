using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace WebhooksFunctionApp
{
    public class GithubWebhookHandler
    {
        private readonly ILogger<GithubWebhookHandler> _logger;

        public GithubWebhookHandler(ILogger<GithubWebhookHandler> logger)
        {
            _logger = logger;
        }

        [Function("ProcessGithubWebhook")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            _logger.LogInformation($"Request Body: {requestBody}");


            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
