using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using OpenAI_API;
using OpenAI_API.Models;
using System;
using System.Reflection;

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

        [HttpGet(Name = "GetEmojiPasta")]
        public async Task<String> Get()
        {
            OpenAIAPI api = new OpenAIAPI("API_KEY");

            var chat = api.Chat.CreateConversation();
            chat.Model = new Model("gpt-3.5-turbo");
            chat.RequestParameters.Temperature = 0;

            chat.AppendSystemMessage("Your task is to create emoji pasta. You need to add emojis to the text, following the context and meaning of each significant part of the text. Emphasize key words, phrases, or emotions by adding relevant emojis. Your goal is to make the text lively and expressive through the use of emojis. Get creative and have fun with it!");

            // Sample User Input
            chat.AppendUserInput("I like to creep around my home and act like a goblin\r\n\r\nI don?t know why but I just enjoy doing this. Maybe it?s my way of dealing with stress or something but I just do it about once every week. Generally I?ll carry around a sack and creep around in a sort of crouch-walking position making goblin noises, then I?ll walk around my house and pick up various different ?trinkets? and put them in my bag while saying stuff like ?I?ll be having that? and laughing maniacally in my goblin voice (?trinkets? can include anything from shit I find on the ground to cutlery or other utensils). The other day I was talking with my neighbours and they mentioned hearing weird noises like what I wrote about and I was just internally screaming the entire conversation. I?m 99% sure they don?t know it?s me but god that 1% chance is seriously weighing on my mind.");

            string response = await chat.GetResponseFromChatbotAsync();
            return response;
        }
    }
}

