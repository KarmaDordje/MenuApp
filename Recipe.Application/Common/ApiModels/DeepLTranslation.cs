﻿namespace Recipe.Application.ApiModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class DeepLTranslation
    {
        [JsonPropertyName("detected_source_language")]
        public string? DetectedSourceLanguage { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
