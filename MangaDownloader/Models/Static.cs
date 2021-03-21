using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaDownloader.Models
{
    public static class Static
    {
        public static Bitmap GetImageFromUrl(string Url)
        {
            try
            {
                var request = System.Net.WebRequest.Create(Url);
                var response = request.GetResponse();
                Bitmap loadedBitmap = null;
                using (var responseStream = response.GetResponseStream())
                {
                    loadedBitmap = new Bitmap(responseStream);
                }
                return loadedBitmap;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ToSafeFileName(this string s)
        {
            return s
                .Replace("\\","")
                .Replace("/", "")
                .Replace("\"","")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "")
                .Replace("\n","");
        }
    }
}
