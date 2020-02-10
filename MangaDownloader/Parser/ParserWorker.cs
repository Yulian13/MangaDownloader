using AngleSharp.Html.Parser;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MangaDownloader.Parser
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        HtmlLoader loader;

        #region Properties

        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnError;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.Settings = parserSettings;
        }

        public void Start()
        {
            Worker();
        }

        public void StartAsyn()
        {
            Thread myThread = new Thread(new ThreadStart(Worker));
            myThread.Start();
        }

        private async void Worker()
        {
            string sourse = null;
            try
            {
                sourse = await loader.GetSourceByPageId();
                if (String.IsNullOrEmpty(sourse))
                    throw new Exception();
            }
            catch
            {
                OnError?.Invoke(this);
                return;
            }
            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(sourse);

            var result = parser.Parser(document);

            OnNewData?.Invoke(this, result);
        }
    }
}
