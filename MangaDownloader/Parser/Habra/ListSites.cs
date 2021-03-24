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
        static readonly Site[] sites = { new SiteMangapoisk(), new SiteMintmanga() };

        static public Site GetSite(string link)
        {
            for (int i = 0; i < sites.Length; i++)
            {
                if (link.Contains(sites[i].Name))
                    return sites[i];
            }

            return null;
        }
    }
    public abstract class Site
    {
        abstract public int ID { get; protected set; }

        abstract public string Name { get; protected set; }

        abstract public string LinkToChapterList { get; protected set; }

        abstract public IParser<string[]> CreatParserGetMainImg();

        abstract public IParser<Chapter[]> CreatParserGetChapters();

        abstract public IParser<ImagesList> CreatParserGetImgs(Chapter chapter);
    }

    public class SiteMangapoisk : Site
    {
        public override int ID { get; protected set; } = 1;
        public override string Name { get; protected set; } = "mangapoisk.ru";
        public override string LinkToChapterList { get; protected set; } = "chaptersList";

        public override IParser<string[]> CreatParserGetMainImg() => new HabraParserGetMainImage1();

        public override IParser<Chapter[]> CreatParserGetChapters() => new HabraParserGettingСhapters1();

        public override IParser<ImagesList> CreatParserGetImgs(Chapter chapter) => new HabraParserGetImgs1(chapter);
    }

    public class SiteMintmanga : Site
    {
        public override int ID { get; protected set; } = 2;
        public override string Name { get; protected set; } = "mintmanga.live";
        public override string LinkToChapterList { get; protected set; } = "";

        public override IParser<string[]> CreatParserGetMainImg() => new HabraParserGetMainImage2();

        public override IParser<Chapter[]> CreatParserGetChapters() => new HabraParserGettingСhapters2();

        public override IParser<ImagesList> CreatParserGetImgs(Chapter chapter) => new HabraParserGetImgs2(chapter);
    }

}
