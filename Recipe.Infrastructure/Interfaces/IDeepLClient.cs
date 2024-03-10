﻿using Recipe.Infrastructure.External.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.Interfaces
{
    public interface IDeepLClient
    {
        Task<string> Translate(DeepLTranslationRequest request);
    }
}
