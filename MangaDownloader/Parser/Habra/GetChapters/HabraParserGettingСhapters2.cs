using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;
using MangaDownloader.Models;

namespace MangaDownloader.Parser.Habra
{
    class HabraParserGettingСhapters2 : IParser<Chapter[]>
    {
        const string TegChap = "a";
        const string ClassTegChap = "cp-l";
        const string LinkAttrib = "href";

        public Chapter[] Parser(IHtmlDocument document)
        {
            List<Chapter> ListChapters = document.QuerySelectorAll(TegChap)
                .Where(ele => ele.ClassName != null && ele.ClassName == ClassTegChap)
                .Select(ele => new Chapter(){ Name = ele.TextContent, Link = ele.GetAttribute(LinkAttrib) })
                .ToList();

            ProccesStringChapter(ListChapters);


            return null;
        }

        public void ProccesStringChapter(List<Chapter> rawChapters)
        {
            foreach(var a in rawChapters)
            {
                string strin = a.Name.Split('\n').Where(ele => !String.IsNullOrWhiteSpace(ele)).Last();
                string[] arr = strin.Split(' ');

                // Заполняем поля Tom и Chapter
                int c = 0;
                bool tomChapt = true;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (tomChapt && Int32.TryParse(arr[i], out c))
                    {
                        a.Tom = arr[i];
                        tomChapt = false;
                        continue;
                    }
                    if (!tomChapt && Int32.TryParse(arr[i], out c))
                    {
                        a.chapter = arr[i];
                        break;
                    }
                }
                a.Name = strin.Substring(strin.IndexOf(a[^1])) 

                Chapter chap = new Chapter();
            }
               
        }
    }
}
