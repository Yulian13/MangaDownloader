using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaDownloader.Models
{
    public class Chapter
    {
        static public void RepeatCheck(List<Chapter> Chapters)
        {
            Chapter[] ArrChapter = Chapters.ToArray();

            for(int i = 0; i<ArrChapter.Length; i++)
            {
                for(int j = i+1; j < ArrChapter.Length; j++)
                {
                    if( ArrChapter[i].Tom == ArrChapter[j].Tom && 
                        ArrChapter[i].chapter == ArrChapter[j].chapter &&
                        ArrChapter[i].Name == ArrChapter[j].Name)
                    {
                        Chapters.Remove(ArrChapter[j]);
                    }
                }
            }
        }

        public string Tom { get; set; }

        public string chapter { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string Link { get; set; }
    }
}
