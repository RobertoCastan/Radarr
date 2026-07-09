using NLog;
using NzbDrone.Common.Http;
using NzbDrone.Core.Configuration;
using NzbDrone.Core.Parser;

namespace NzbDrone.Core.Indexers.Ed2k
{
    public class Ed2kRssIndexer : HttpIndexerBase<Ed2kRssIndexerSettings>
    {
        public override string Name => "eD2k RSS Feed";
        public override DownloadProtocol Protocol => DownloadProtocol.Ed2k;
        public override bool SupportsSearch => false;
        public override int PageSize => 0;

        public Ed2kRssIndexer(IHttpClient httpClient, IIndexerStatusService indexerStatusService, IConfigService configService, IParsingService parsingService, Logger logger)
            : base(httpClient, indexerStatusService, configService, parsingService, logger)
        {
        }

        public override IIndexerRequestGenerator GetRequestGenerator()
        {
            return new Ed2kRssIndexerRequestGenerator(Settings.BaseUrl);
        }

        public override IParseIndexerResponse GetParser()
        {
            return new Ed2kRssParser();
        }
    }
}
