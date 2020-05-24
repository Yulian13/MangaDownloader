using System;
using System.Windows.Forms;

namespace MangaDownloader
{
    partial class Form1
    {
        public void ProgressBarChaptersAddMaximum(int length)
        {
            Invoke(new Action(() => {
                progressBarChapters.Maximum += length;
            }));
        }

        public void ProgressBarChaptersAddValue()
        {
            Invoke(new Action(() => {
                progressBarChapters.Value++;
            }));
        }

        public void Parser_OnErrorImgs(object obj)
        {
            Invoke(new Action(() => {
                Download(false);
            }));
            MessageBox.Show("Error");
        }

        public void DownloadFalse()
        {
            Invoke(new Action(() => {
                Download(false);
            }));

        }
    }
}
