﻿using MangaDownloader.Models;
using MangaDownloader.Parser.Habra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MangaDownloader.Parser
{
    public interface INeedFunctions
    {
        void Download(bool value);
        void ProgressBarChaptersAddMaximum(int length);
        void ProgressBarChaptersAddValue();
        void Parser_OnErrorImgs(object obj);
        void DownloadFalse();
        string PathDownload { get; set; }
    }

    public class ImageDownloader
    {
        List<Chapter> Chapters;
        string Link;
        INeedFunctions Functions;

        bool Cancel = false;

        public ImageDownloader(List<Chapter> chapters, string link, INeedFunctions Functions)
        {
            Chapters = chapters;
            Link = link;
            this.Functions = Functions;
        }

        public void Download()
        {
            foreach (Chapter chap in Chapters)
            {
                ParserWorker<ImagesList> parser = new ParserWorker<ImagesList>(
                    new HabraParserImg(chap),
                    new HabraSettings(Link, chap.Link)
                );
                parser.OnNewData += Parser_OnNewData;
                parser.OnError += Functions.Parser_OnErrorImgs;

                parser.StartAsyn();
            }

        }

        private void Parser_OnNewData(object arg1, ImagesList listLink)
        {
            Functions.ProgressBarChaptersAddMaximum(listLink.LinksImg.Length);

            string Path = $"{Functions.PathDownload}\\{listLink.Tom}-{listLink.Chapter} {Static.ToSafeFileName(listLink.Name)}";

            using (WebClient client = new WebClient())
            {
                Directory.CreateDirectory(Path);
                for (int i = 0; i < listLink.LinksImg.Length; i++)
                {
                    if (Cancel)
                        break;

                    string name = String.Format("{1}-{2}-p{0:d2}", i, listLink.Tom, listLink.Chapter);
                    client.DownloadFile(listLink.LinksImg[i], $"{Path}\\{name}.jpg");

                    Functions.ProgressBarChaptersAddValue();
                }

            }

            Functions.DownloadFalse();
        }

        public void Stop() => Cancel = true;
    }
}
