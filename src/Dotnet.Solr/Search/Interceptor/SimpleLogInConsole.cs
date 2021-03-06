﻿using Dotnet.Solr.Options;
using System;
using System.Diagnostics;
using System.Text;

namespace Dotnet.Solr.Search.Interceptor
{
    /// <summary>
    /// Simple solr query interceptor used to log queries
    /// </summary>
    public class SimpleLogInConsole : IResultInterceptor
    {
        private readonly SolrExpressOptions _solrExpressOptions;

        public SimpleLogInConsole(SolrExpressOptions solrExpressOptions)
        {
            this._solrExpressOptions = solrExpressOptions;
        }

        /// <summary>
        /// Get log content
        /// </summary>
        /// <param name="requestHandler">Handler to use in SOLR request</param>
        /// <param name="json">Json to intercept</param>
        /// <returns>Log content</returns>
        private string GetLogContent(string requestHandler, string json)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[SimpleLogInConsole] {DateTime.Now:yyyy-MM-dd HH:mm:ss.zzz}");
            sb.AppendLine($"{this._solrExpressOptions.HostAddress}/{requestHandler}");
            sb.AppendLine(new string('-', 50));
            sb.AppendLine(json);
            sb.AppendLine(new string('-', 50));

            return sb.ToString();
        }

        public void Execute(string requestHandler, ref string json)
        {
            var logContent = this.GetLogContent(requestHandler, json);

            Console.WriteLine(logContent);
            Debug.WriteLine(logContent, "Dotnet.Solr");
        }
    }
}
