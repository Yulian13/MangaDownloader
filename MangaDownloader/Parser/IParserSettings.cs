using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaDownloader.Parser
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }
    }
}
