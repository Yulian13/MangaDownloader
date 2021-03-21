using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;
using MangaDownloader.Models;

namespace MangaDownloader.Parser.Habra
{
    class HabraParserImg : IParser<ImagesList>
    {
        const string Teg = "img";
        const string ClassName = "page-image";
        const string Attribut = "data-src";
        const string FirstAlternativeAttribut = "data-alternative";
        const string AlternativeAttribut = "src";

        Chapter Chapter;

        public HabraParserImg(Chapter chapter)
        {
            Chapter = chapter;
        }

        public ImagesList Parser(IHtmlDocument document)
        {

            var ListLink = new List<string>();

            var HtmlImgs = document.QuerySelectorAll(Teg).
                Where(ele => ele.ClassName != null && ele.ClassName.Contains(ClassName)).ToList();
            
            foreach(var htmlImg in HtmlImgs)
            {
                string link = htmlImg.GetAttribute(FirstAlternativeAttribut);
                if (link == null)
                    link = htmlImg.GetAttribute(Attribut);
                if (link == null)
                    link = htmlImg.GetAttribute(AlternativeAttribut);

                ListLink.Add(link);
            }

            return new ImagesList(Chapter, ListLink.ToArray());
        }
    }
}
