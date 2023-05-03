using FinalProject_RedditClone.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Moderation;
using System.Reflection.Metadata;

namespace FinalProject_RedditClone.Controllers
{
    [Route("UseChatGpt")]
    [ApiController]
    public class ModerationController : ControllerBase
    {
        [HttpGet]
        public async Task<Result> UseChatGpt(string query)
        {
            var openai = new OpenAIAPI(Constants.ApiKey);
            ModerationRequest moderationRequest = new ModerationRequest();
            moderationRequest.Input = query;

            var moderation = openai.Moderation.CallModerationAsync(moderationRequest);

            var result = moderation.Result.Results[0];

            return result;
        }
    }
}