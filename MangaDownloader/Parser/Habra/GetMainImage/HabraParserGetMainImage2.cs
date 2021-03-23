using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;

namespace MangaDownloader.Parser.Habra
{
    class HabraParserGetMainImage2 : IParser<string[]>
    {
        const string TegDivImg = "div";
        const string TegImg = "img";
        const string ImgClass = "picture-fotorama";
        const string Attribute = "src";

        const string TegName = "span";
        const string ClassNameName = "name";

        public string[] Parser(IHtmlDocument document)
        {
            string[] elements = new string[2];
            elements[0] = document.QuerySelectorAll(TegDivImg)
                .Where(ele => ele.ClassName != null && ele.ClassName == ImgClass).First().Children.First().GetAttribute(Attribute);

            elements[1] = document.QuerySelectorAll(TegName)
                .Where(ele => ele.ClassName != null && ele.ClassName == ClassNameName).First().TextContent;

            return elements;
        }
    }
}
