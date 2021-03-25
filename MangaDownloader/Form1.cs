using MangaDownloader.Models;
using MangaDownloader.Parser;
using MangaDownloader.Parser.Habra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MangaDownloader
{
    public partial class Form1 : Form, INeedFunctionsForLoad
    {
        bool ChekEnable {
            set
            {
                buttonChecking.Enabled = value;
                buttonDownload.Enabled = value;
            }
        }

        bool Remove = false;
        public void Download(bool value) {
            if (!value){
                progressBarToms.Value++;
                labelIndicatorTom.Text = $"{progressBarToms.Value}/{progressBarToms.Maximum}";
            }

            if (value)
            {
                buttonDownload.Enabled = false;
                buttonChecking.Enabled = false;
            }
            else if (progressBarToms.Value == progressBarToms.Maximum)
            {
                if(!Remove)
                    MessageBox.Show("Downloading is end");

                progressBarToms.Value = 0;
                progressBarToms.Maximum = 0;
                progressBarChapters.Value = 0;
                progressBarChapters.Maximum = 0;
                labelIndicatorTom.Text = "";

                buttonDownload.Enabled = true;
                buttonChecking.Enabled = true;

                if (Remove)
                    Directory.Delete(PathDownload, true);

                Remove = false;
            }
        }

        string GetLink => textBoxLink.Text;

        public Form1()
        {
            InitializeComponent();

            buttonDownload.Enabled = false;

            labelIndicatorTom.Text = "";
            labelName.Text = "";
        }

        Site siteObject;
        private void buttonChecking_Click(object sender, EventArgs e)
        {
            siteObject = ListSites.GetSite(GetLink);

            if (siteObject == null)
                return;

            dataGridView1.Rows.Clear();
            ChekEnable = false;

            ParserWorker<string[]> parserImg = new ParserWorker<string[]>(
                    siteObject.CreatParserGetMainImg(),
                    new HabraSettings(GetLink, "")
                );
            parserImg.OnNewData += Parser_OnNewDataImg;
            parserImg.OnError += ParserImg_OnError;
            parserImg.Start();

            ParserWorker<Chapter[]> parser = new ParserWorker<Chapter[]>(
                    siteObject.CreatParserGetChapters(),
                    new HabraSettings(GetLink, siteObject.LinkToChapterList)
                );
            parser.OnNewData += Parser_OnNewDataChapter;
            parser.OnError += Parser_OnError;
            parser.Start();

        }

        private void ParserImg_OnError(object obj)
        {
            labelName.Text = "Error";
        }

        private void Parser_OnError(object obj)
        {
            dataGridView1.Rows.Add(false, "", "", "Error", "", "");

            buttonChecking.Enabled = true;
        }

        private void Parser_OnNewDataChapter(object arg1, Chapter[] chapters)
        {
            for(int i = 0; i<chapters.Length; i++)
            {
                string Tom  = chapters[i].Tom;
                string chap = chapters[i].chapter;
                string Name = chapters[i].Name;
                string Date = chapters[i].Date;
                string Link = chapters[i].PrefixToChapter;

                dataGridView1.Rows.Add(false, Tom, chap, Name, Date, Link);
            }

            ChekEnable = true;
        }

        private void Parser_OnNewDataImg(object arg1, string[] elements)
        {
            pictureBox1.Image = Static.GetImageFromUrl(elements[0]);

            labelName.Text = elements[1];
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
                return;

            foreach(DataGridViewRow rowView in dataGridView1.SelectedRows)
            {
                dataGridView1[ColumnDownload.Index, rowView.Index].Value = (button == buttonSelect) ? true : false;
            }
        }

        #region Download
        public string PathDownload { get; set; }

        ImageDownloader downloader;

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            List<Chapter> Chapters = new List<Chapter>();

            foreach(DataGridViewRow rowView in dataGridView1.Rows)
            {
                if((bool)rowView.Cells[ColumnDownload.Index].Value)
                {
                    Chapter chapter = new Chapter() {
                        Tom = (string)rowView.Cells[ColumnTom.Index].Value,
                        chapter = (string)rowView.Cells[ColumnChapter.Index].Value,
                        Name = (string)rowView.Cells[ColumnName.Index].Value,
                        PrefixToChapter = (string)rowView.Cells[ColumnLink.Index].Value
                    };

                    Chapters.Add(chapter);
                }
            }
            if (Chapters.Count == 0)
                return;

            Chapter.RepeatCheck(Chapters);

            progressBarToms.Maximum = Chapters.Count;
            labelIndicatorTom.Text = $"{progressBarToms.Value}/{progressBarToms.Maximum}";

            PathDownload = $"D:\\Anime\\Manga\\{Static.ToSafeFileName(labelName.Text)}";

            Directory.CreateDirectory(PathDownload);

            Download(true);

            downloader = new ImageDownloader(Chapters, this, siteObject);
            downloader.Download();
        }    

        #endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            downloader.Stop();
            Remove = true;
        }
    }
}
