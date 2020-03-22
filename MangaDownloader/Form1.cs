using MangaDownloader.Models;
using MangaDownloader.Parser;
using MangaDownloader.Parser.Habra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaDownloader
{
    public partial class Form1 : Form
    {
        bool Cheking {
            set
            {
                buttonChecking.Enabled = value;
                buttonDownload.Enabled = value;
            }
        }

        bool Download {
            set
            {
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
                    MessageBox.Show("Downloading is end");

                    progressBarToms.Value = 0;
                    progressBarToms.Maximum = 0;
                    progressBarChapters.Value = 0;
                    progressBarChapters.Maximum = 0;
                    labelIndicatorTom.Text = "";

                    buttonDownload.Enabled = true;
                    buttonChecking.Enabled = true;
                }
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

        private void buttonChecking_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Cheking = false;

            ParserWorker<string[]> parserImg = new ParserWorker<string[]>(
                    new HabraParserGetMainImage(),
                    new HabraSettings(GetLink, "")
                );
            parserImg.OnNewData += Parser_OnNewDataImg;
            parserImg.OnError += ParserImg_OnError;
            parserImg.Start();

            ParserWorker<Chapter[]> parser = new ParserWorker<Chapter[]>(
                    new HabraParserGettingСhapters(),
                    new HabraSettings(GetLink, "chaptersList")
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
                string Link = chapters[i].Link;

                dataGridView1.Rows.Add(false, Tom, chap, Name, Date, Link);
            }

            Cheking = true;
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
        string PathDownload = "";

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
                        Link = (string)rowView.Cells[ColumnLink.Index].Value
                    };

                    Chapters.Add(chapter);
                }
            }
            if (Chapters.Count == 0)
                return;

            progressBarToms.Maximum = Chapters.Count;
            labelIndicatorTom.Text = $"{progressBarToms.Value}/{progressBarToms.Maximum}";

            PathDownload = $"D:\\Anime\\Manga\\{Static.ToSafeFileName(labelName.Text)}";

            Directory.CreateDirectory(PathDownload);

            Download = true;

            foreach (Chapter chap in Chapters)
            {
                ParserWorker<ImagesList> parser = new ParserWorker<ImagesList>(
                    new HabraParserImg(chap),
                    new HabraSettings(GetLink, chap.Link)
                );
                parser.OnNewData += Parser_OnNewData;
                parser.OnError += Parser_OnErrorImgs;

                parser.StartAsyn();
            }

        }

        private void Parser_OnErrorImgs(object obj)
        {
            Invoke(new Action(() => {
                Download = false;
            }));
            MessageBox.Show("Error");
        }

        private void Parser_OnNewData(object arg1, ImagesList listLink)
        {
            Invoke(new Action(() => {
                progressBarChapters.Maximum += listLink.LinksImg.Length;
            }));

            string Path = $"{PathDownload}\\{listLink.Tom}-{listLink.Chapter} {Static.ToSafeFileName(listLink.Name)}";

            using (WebClient client = new WebClient())
            {
                Directory.CreateDirectory(Path);
                for (int i = 0; i<listLink.LinksImg.Length; i++)
                {
                    string name = String.Format("{1}-{2}-page{0:d2}", i, listLink.Tom, listLink.Chapter);
                    client.DownloadFile(listLink.LinksImg[i], $"{Path}\\{name}.jpg");

                    Invoke(new Action(() => {
                        progressBarChapters.Value++;
                    }));
                }

            }

            Invoke(new Action(() => {
                Download = false;
            }));
        }

        #endregion

    }
}
