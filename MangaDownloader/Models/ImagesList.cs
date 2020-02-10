using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaDownloader.Models
{
    class ImagesList
    {
        public ImagesList(string tom, string chapter, string name, string[] linksImg)
        {
            Tom = (tom == null) ? "0" : tom;
            Chapter = chapter;
            Name = name;
            LinksImg = linksImg;
        }

        public ImagesList(Chapter chapter, string[] List) : this(chapter.Tom, chapter.chapter,chapter.Name, List) { }

        public string Tom { get; set; }

        public string Chapter { get; set; }

        public string Name { get; set; }

        public string[] LinksImg { get; set; }

    }
}
