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

        public HabraParserGetImgs2(Chapter chapter)
        {
            Chapter = chapter;
        }


        //rm_h.init( [['https://h25.mints.rocks/','',"auto/10/20/72/img000002.png_res.jpg?t=1616532083&u=0&h=ypecHENxkYMq8J_WX3U3mA",848,1200],['https://h39.mints.rocks/','',"auto/10/20/72/img000004.png?t=1616532083&u=0&h=Y5QN2vz-khZWJoq0QopVpg",848,1200],['https://h25.mints.rocks/','',"auto/10/20/72/img000005.png?t=1616532083&u=0&h=ZBlwhX85JuN4WcPJWbZPCQ",848,1200],['https://h41.mints.rocks/','',"auto/10/20/72/img000006.png?t=1616532083&u=0&h=dy_Y5Bd87NSSGGnbLQAy-Q",848,1200],['https://h39.mints.rocks/','',"auto/10/20/72/img000007.png?t=1616532083&u=0&h=I4W0Hi3c2gOeHPf8b4CnFg",848,1200],['https://h25.mints.rocks/','',"auto/10/20/72/img000008.png?t=1616532083&u=0&h=G8Z-zMgWS33hjlKKB15C1A",848,1200],['https://h9.mints.rocks/','',"auto/10/20/72/img000009.png?t=1616532083&u=0&h=g6y7E_pXeTehfi4JviAG6w",848,1200],['https://h23.mints.rocks/','',"auto/10/20/72/img000010.png?t=1616532083&u=0&h=TGVMrSeSBRR2TuAUtP6n0Q",848,1200],['https://h9.mints.rocks/','',"auto/10/20/72/img000011.png?t=1616532083&u=0&h=lr-qttxqSDA4LxjpfHnS6g",848,1200],['https://h39.mints.rocks/','',"auto/10/20/72/zzzz.png_res.jpg?t=1616532083&u=0&h=te4S4a_TKJWvD7HY41opXQ",682,682]], 0, false, [{"path":"https://h25.mints.rocks/","res":true},{"path":"https://h30.mints.rocks/","res":true},{"path":"https://h39.mints.rocks/","res":true},{"path":"https://h9.mints.rocks/","res":true},{"path":"https://h41.mints.rocks/","res":true},{"path":"https://h23.mints.rocks/","res":true}]);

        public ImagesList Parser(IHtmlDocument document)
        {
            List<string> jsCodes = document.QuerySelectorAll(TegScript)
                .Where(ele => ele.GetAttribute(AttributeTeg) != null && ele.GetAttribute(AttributeTeg) == StyleTegScript)
                .Select(ele => ele.TextContent).ToList();

            string jsCode = jsCodes.Where(code => code.Contains("rm_h.init")).First();
            string pattern = @"'https://h\d{1,2}\.mints.rocks/',''," + "\""
                + @"auto.{10,70}(png_res\.jpg|png|jpg).{42}" + "\"";
            MatchCollection matchCollection = new Regex(pattern, RegexOptions.IgnoreCase).Matches(jsCode);

            string countPage = document.QuerySelectorAll("span").Where(ele => ele.ClassName != null && ele.ClassName == "pages-count").First().TextContent;

            string[] ListLink = new string[matchCollection.Count];
            if (ListLink.Length.ToString() == countPage)
            {
                Chapter.Name = "Error";
            }
            for(int i = 0; i < matchCollection.Count; i++)
            {
                string h = matchCollection[i].Value.Substring(1);
                ListLink[i] = h.Remove(h.Length-1).Replace("','',\"", "");
            }
            ImagesList imagesList = new ImagesList(Chapter, ListLink);

            return imagesList;
        }

    }
}
