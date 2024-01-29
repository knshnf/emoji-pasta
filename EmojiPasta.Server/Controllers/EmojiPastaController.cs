using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using OpenAI_API;
using OpenAI_API.Models;
using System;
using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EmojiPasta.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmojiPastaController : ControllerBase
    {
        private readonly ILogger<EmojiPastaController> _logger;

        public EmojiPastaController(ILogger<EmojiPastaController> logger)
        {
            _logger = logger;
        }

        [EnableCors]
        [HttpPost(Name = "PostEmojiPasta")]
        public async Task<String> Post([FromBody] JsonElement body)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(body);
            Trace.WriteLine(json);

            OpenAIAPI api = new OpenAIAPI("API_KEY");

            var chat = api.Chat.CreateConversation();
            chat.Model = new Model("gpt-3.5-turbo");
            chat.RequestParameters.Temperature = 0;

            chat.AppendSystemMessage("Your task is to create emoji pasta. You need to add emojis to the text, following the context and meaning of each significant part of the text. Emphasize key words, phrases, or emotions by adding relevant emojis. Your goal is to make the text lively and expressive through the use of emojis. Get creative and have fun with it!");

            // Sample User Input
            chat.AppendUserInput(json);

            string response = await chat.GetResponseFromChatbotAsync();


            return JsonConvert.SerializeObject(response);
        }
    }
}

