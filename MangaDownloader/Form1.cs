using MangaDownloader.Models;
using MangaDownloader.Parser;
using MangaDownloader.Parser.Habra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        string GetLink => textBoxLink.Text;

        public Form1()
        {
            InitializeComponent();

            buttonDownload.Enabled = false;

            labelIndicatorChapter.Text = "";
            labelIndicatorPage.Text = "";
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
    }
}
