using MangaDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaDownloader.Parser.Habra
{
    static class ListSites
    {
        static readonly Site[] sites = { new Site(1, "mangapoisk.ru", new HabraParserGetMainImage1(), new HabraParserGettingСhapters1()) };
        public struct Site
        {
            public Site(int id,string Name, IParser<string[]> ParserGetMainImg, IParser<Chapter[]> ParserGetImgs)
            {
                this.ID = id;
                this.Name = Name;
                this.ParserGetMainImg = ParserGetMainImg;
                this.ParserGetImgs = ParserGetImgs;
            }

            public int ID;

            public string Name;
            public IParser<string[]> ParserGetMainImg;
            public IParser<Chapter[]> ParserGetImgs;
        }

        static public Site GetSite(string link)
        {
            for (int i = 0; i < sites.Length; i++)
            {
                if (link.Contains(sites[i].Name))
                    return sites[i];
            }

            return new Site();
        }
    }
}
