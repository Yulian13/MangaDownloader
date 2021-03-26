using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp.Html.Dom;
using MangaDownloader.Models;

namespace MangaDownloader.Parser.Habra
{
    class HabraParserGetImgs2 : IParser<ImagesList>
    {
        const string TegScript = "script";
        const string AttributeTeg = "type";
        const string StyleTegScript = "text/javascript";

        Chapter Chapter;

        public HabraParserGetImgs2(Chapter chapter) => Chapter = chapter;

        public ImagesList Parser(IHtmlDocument document)
        {
            List<string> jsCodes = document.QuerySelectorAll(TegScript)
                .Where(ele => ele.GetAttribute(AttributeTeg) != null && ele.GetAttribute(AttributeTeg) == StyleTegScript)
                .Select(ele => ele.TextContent).ToList();
            
            string jsCode = jsCodes.Where(code => code.Contains("rm_h.init")).First();
            string pattern = @"'https://h\d{1,2}\.mints.rocks/',''," + "\""
                + @"auto.{10,100}(png\?|jpg\?)t=\d{10}.{29}" + "\"";
            MatchCollection matchCollection = new Regex(pattern, RegexOptions.IgnoreCase).Matches(jsCode);

            int countPage = new Regex("\"auto/", RegexOptions.IgnoreCase).Matches(jsCode).Count;
            string[] ListLink = new string[matchCollection.Count];
            if (ListLink.Length != countPage)
            {
                Chapter.Name = "Error";
            }
            for (int i = 0; i < matchCollection.Count; i++)
            {
                string h = matchCollection[i].Value.Substring(1);
                ListLink[i] = h.Remove(h.Length-1).Replace("','',\"", "");
            }
            ImagesList imagesList = new ImagesList(Chapter, ListLink);

            return imagesList;
        }

    }
}
