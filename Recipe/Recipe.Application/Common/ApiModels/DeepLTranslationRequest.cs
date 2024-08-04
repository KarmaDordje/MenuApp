namespace Recipe.Application.ApiModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class DeepLTranslationRequest
    {
        [JsonPropertyName("text")]
        public List<string>? Text { get; set; }

        [JsonPropertyName("source_lang")]
        public string? SourceLanguage { get; set; }

        [JsonPropertyName("target_lang")]
        public string? TargetLang { get; set; }

        public DeepLTranslationRequest Create(string text, string targetLang)
        {
            return new DeepLTranslationRequest()
            {
                Text = new List<string> { text },
                TargetLang = targetLang,
                SourceLanguage = "pl"
            };
        }
    }
}
