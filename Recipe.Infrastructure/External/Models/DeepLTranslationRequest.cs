using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.External.Models
{
    public class DeepLTranslationRequest
    {
        [JsonPropertyName("text")]
        public List<string>? Text { get; set; }

        [JsonPropertyName("target_lang")]
        public string? TargetLang { get; set; }

        public DeepLTranslationRequest Create(string text, string targetLang)
        {
            return new DeepLTranslationRequest()
            {
                Text = new List<string> { text },
                TargetLang = targetLang
            };
        }
    }
}
