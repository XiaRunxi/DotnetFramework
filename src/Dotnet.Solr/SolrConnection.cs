﻿using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using Dotnet.Solr.Options;
using Dotnet.Solr.Utility;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dotnet.Solr
{
    /// <summary>
    /// SOLR connection
    /// </summary>
    public class SolrConnection : ISolrConnection
    {
        private readonly SolrExpressOptions _options;

        public SolrConnection(SolrExpressOptions options)
        {
            Checker.IsNull(options);

            this._options = options;
        }

        /// <summary>
        /// Set authentication configurations
        /// </summary>
        /// <param name="url">Uri to configure</param>

        private IFlurlRequest SetAuthentication(Url url)
        {
            return new FlurlRequest(url);
        }

        public string Get(string handler, List<string> data)
        {
            var url = this._options.HostAddress
                .AppendPathSegment(handler);

            if (data?.Any() ?? false)
            {
                url = url.SetQueryParams(data);
            }

            return this
                .SetAuthentication(url)
                .GetStringAsync()
                .Result;
        }

        public Stream GetStream(string handler, List<string> data)
        {
            var url = this._options.HostAddress
                .AppendPathSegment(handler);

            if (data?.Any() ?? false)
            {
                url = url.SetQueryParams(data);
            }

            return this
                .SetAuthentication(url)
                .GetStreamAsync()
                .Result;
        }

        public string Post(string handler, JObject data)
        {
            var url = this._options.HostAddress
                .AppendPathSegment(handler);

            return this
                .SetAuthentication(url)
                .PostJsonAsync(data)
                .ReceiveString()
                .Result;
        }

        public Stream PostStream(string handler, JObject data)
        {
            var url = this._options.HostAddress
                .AppendPathSegment(handler);

            return this
                .SetAuthentication(url)
                .PostJsonAsync(data)
                .ReceiveStream()
                .Result;
        }
    }
}
