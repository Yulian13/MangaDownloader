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
        const string ClassName = "img-fluid page-image lazy-preload";
        const string Attribut = "data-src";
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
                Where(ele => ele.ClassName == ClassName).ToList();
            
            foreach(var htmlImg in HtmlImgs)
            {
                string link = htmlImg.GetAttribute(Attribut);
                if(link == null)
                    link = htmlImg.GetAttribute(AlternativeAttribut);

                ListLink.Add(link);
            }

            return new ImagesList(Chapter, ListLink.ToArray());
        }
    }
}
