using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace MangaDownloader.Parser
{
    public interface IParser<T> where T : class
    {
        T Parser(IHtmlDocument document);
    }
}
