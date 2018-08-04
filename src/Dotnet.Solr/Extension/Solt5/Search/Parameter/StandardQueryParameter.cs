﻿using Newtonsoft.Json.Linq;
using Dotnet.Solr.Search;
using Dotnet.Solr.Search.Parameter;
using Dotnet.Solr.Search.Query;

namespace Dotnet.Solr.Solr5.Search.Parameter
{
    public sealed class StandardQueryParameter<TDocument> : IStandardQueryParameter<TDocument>, ISearchItemExecution<JObject>
        where TDocument : Document
    {
        private JProperty _result;

        public SearchQuery<TDocument> Value { get;set; }

        public void AddResultInContainer(JObject container)
        {
            var jObj = (JObject)container["params"] ?? new JObject();
            jObj.Add(this._result);
            container["params"] = jObj;
        }

        public void Execute()
        {
            this._result = new JProperty("q.alt", this.Value.Execute());
        }
    }
}
