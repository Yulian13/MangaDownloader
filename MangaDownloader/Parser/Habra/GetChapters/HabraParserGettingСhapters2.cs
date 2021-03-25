using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp.Html.Dom;
using MangaDownloader.Models;

namespace MangaDownloader.Parser.Habra
{
    class HabraParserGettingСhapters2 : IParser<Chapter[]>
    {
        const string TegChap = "a";
        const string ClassTegChap = "cp-l";
        const string LinkAttrib = "href";

        const string TegData = "td";
        const string ClassTegData = "hidden-xxs date";

        const string MTR_Rrefix = @"?mtr=1";

        public Chapter[] Parser(IHtmlDocument document)
        {
            List<Chapter> ListChapters = document.QuerySelectorAll(TegChap)
                .Where(ele => ele.ClassName != null && ele.ClassName == ClassTegChap)
                .Select(ele => new Chapter(){ Name = ele.TextContent, PrefixToChapter = ele.GetAttribute(LinkAttrib) })
                .ToList();

            ProccesStringChapter(ListChapters);

            string[] dateArr = document.QuerySelectorAll(TegData)
                .Where(ele => ele.ClassName != null && ele.ClassName == ClassTegData)
                .Select(ele => ele.TextContent)
                .ToArray();

            int i = 0;
            foreach (var a in ListChapters)
            {
                try
                {
                    a.Date = dateArr[i].Trim();
                }
                catch
                {
                    a.Date = "";
                }

                i++;
            }

            return ListChapters.ToArray();
        }

        public void ProccesStringChapter(List<Chapter> rawChapters)
        {
            foreach(var a in rawChapters)
            {
                string txt = a.Name.Trim();

                string TomChapt = new Regex(@"\d+ - \d+").Match(txt).Value;

                if(TomChapt == "")
                {
                    a.Tom = "";
                    a.chapter = "";
                    a.Name = new Regex(@"\s+").Replace(txt, " ").Replace("\n","");

                    continue;
                }

                string[] arr = TomChapt.Split(' ');
                a.Tom = arr[0];
                a.chapter = arr[2];

                try
                {
                    char SymChar = (char)(200);
                    txt = txt.Replace(TomChapt, SymChar.ToString());
                    a.Name = txt.Substring(txt.IndexOf(SymChar) + 2);
                }
                catch
                {
                    a.Name = "";
                }

                a.PrefixToChapter += MTR_Rrefix;
            }
               
        }
    }
}
