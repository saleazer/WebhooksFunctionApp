using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using Octokit.Webhooks;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Events.PullRequest;

namespace WebhooksFunctionApp.Processors
{
    public sealed class EventProcessor : WebhookEventProcessor
    {
        private readonly ILogger<EventProcessor> _logger;

        public EventProcessor(ILogger<EventProcessor> logger)
        {
            _logger = logger;
        }

        protected override async Task ProcessPullRequestWebhookAsync(WebhookHeaders headers, PullRequestEvent pullRequestEvent, PullRequestAction action)
        {
            _logger.LogInformation("Processing pull request webhook.");

            try
            {
                string headersString = JsonConvert.SerializeObject(headers);
                string pullRequestEventString = JsonConvert.SerializeObject(pullRequestEvent);
                _logger.LogInformation($"Headers: {headersString}");
                _logger.LogInformation($"PR Event: {pullRequestEventString}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the pull request webhook.");
                throw;
            }
        }
    }
}
