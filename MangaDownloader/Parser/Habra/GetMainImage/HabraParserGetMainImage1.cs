using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;

namespace MangaDownloader.Parser.Habra
{
    class HabraParserGetMainImage1 : IParser<string[]>
    {
        const string TegImg = "img";
        const string ClassNameImg = "img-fluid";
        const string Attribute = "src";

        const string TegName = "span";
        const string ClassNameName = "post-name";


        public string[] Parser(IHtmlDocument document)
        {
            string[] elements = new string[2];

            elements[0] = document.QuerySelectorAll(TegImg).
                Where(ele => ele.ClassName != null && ele.ClassName == ClassNameImg).First().GetAttribute(Attribute);

            elements[1] = document.QuerySelectorAll(TegName).
                Where(ele => ele.ClassName != null && ele.ClassName == ClassNameName).First().TextContent;

            return elements;
        }
    }
}
