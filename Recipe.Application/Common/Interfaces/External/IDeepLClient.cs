
using Recipe.Application.ApiModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Interfaces
{
    public interface IDeepLClient
    {
        Task<string> Translate(DeepLTranslationRequest request);
    }
}
