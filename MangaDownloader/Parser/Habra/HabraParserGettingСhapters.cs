using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;
using MangaDownloader.Models;

namespace MangaDownloader.Parser.Habra
{
    class HabraParserGettingСhapters : IParser<Chapter[]>
    {
        const string TegChapter = "span";
        const string ClassNameChapter = "chapter-title";

        const string TegDate = "span";
        const string ClassNameDate = "chapter-date ";

        const string TegLink = "a";
        const string ClassNameLink = "";
        const string LinkAttribute = "href";



        public Chapter[] Parser(IHtmlDocument document)
        {
            var HtmlChapterEle = document.QuerySelectorAll(TegChapter).
                Where(ele => ele.ClassName != null && ele.ClassName == ClassNameChapter).ToArray();
            string[] ListEle = TransformToString(HtmlChapterEle);
            SimplePbject[] Element = Delimiter(ListEle);

            var HtmlChapterDate = document.QuerySelectorAll(TegDate).
                Where(ele => ele.ClassName != null && ele.ClassName == ClassNameDate).ToArray();
            string[] ListDate = TransformToString(HtmlChapterDate);

            var HtmlChapterLinks = document.QuerySelectorAll(TegLink).
                Where(ele => ele.ClassName != null && ele.ClassName == ClassNameLink).ToArray();

            string[] Names = replacementName(HtmlChapterLinks, HtmlChapterEle);

            Chapter[] chapters = new Chapter[HtmlChapterLinks.Length];

            for(int i = 0; i< HtmlChapterLinks.Length; i++)
            {
                Chapter chapter = new Chapter() {
                    Tom = Element[i].Tom,
                    chapter = Element[i].chapter,
                    Name = Names[i],
                    Date = ListDate[i],
                    Link = HtmlChapterLinks[i].GetAttribute(LinkAttribute)
                };

                chapters[i] = chapter;
            }

            return chapters;
        }

        string[] TransformToString(AngleSharp.Dom.IElement[] elements)
        {
            string[] list = new string[elements.Length];

            for(int i = 0; i< elements.Length; i++)
            {
                string St = elements[i].TextContent;

                while (St.StartsWith(" ") || St.StartsWith("\n"))
                {
                    St = St.Remove(0, 1);
                }
                while (St.EndsWith(" ") || St.EndsWith("\n"))
                {
                    St = St.Remove(St.Length - 1, 1);
                }
                list[i] = St;
            }
            return list;
        }
        string[] TransformString(string[] elements)
        {
            string[] list = new string[elements.Length];

            for (int i = 0; i < elements.Length; i++)
            {
                string St = elements[i];

                while (St.StartsWith(" ") || St.StartsWith("\n"))
                {
                    St = St.Remove(0, 1);
                }
                while (St.EndsWith(" ") || St.EndsWith("\n"))
                {
                    St = St.Remove(St.Length - 1, 1);
                }
                list[i] = St;
            }
            return list;
        }

        SimplePbject[] Delimiter(string[] elements)
        {
            SimplePbject[] list = new SimplePbject[elements.Length];

            for(int i = 0; i< elements.Length; i++)
            {
                string[] Delim = elements[i].Split(' ');

                for (int j = 0; j < Delim.Length; j++)
                {
                    if (String.IsNullOrWhiteSpace(Delim[j]))
                        continue;

                    if(Delim[j].First() >= 48 && Delim[j].First() <= 57)
                    {
                        if (list[i].Tom == null)
                            list[i].Tom = Delim[j];
                        else if (list[i].chapter == null)
                            list[i].chapter = Delim[j];
                    }
                }

            }

            return list;
        }

        string[] replacementName(AngleSharp.Dom.IElement[] elements, AngleSharp.Dom.IElement[] DeleteElements)
        {
            string[] list = new string[elements.Length];

            for(int i = 0; i< elements.Length; i++)
            {
                list[i] = elements[i].TextContent.Replace(DeleteElements[i].TextContent, "");
            }

            list = TransformString(list);

            return list;
        } 

        struct SimplePbject
        {
            public string Tom { get; set; }

            public string chapter { get; set; }
        }
    }
}