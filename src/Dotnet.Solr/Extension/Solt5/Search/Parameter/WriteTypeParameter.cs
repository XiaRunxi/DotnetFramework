﻿using Newtonsoft.Json.Linq;
using Dotnet.Solr.Search;
using Dotnet.Solr.Search.Parameter;

namespace Dotnet.Solr.Solr5.Search.Parameter
{
    public sealed class WriteTypeParameter<TDocument> : IWriteTypeParameter<TDocument>, ISearchItemExecution<JObject>
        where TDocument : Document
    {
        private JProperty _result;

        public WriteType Value { get; set; }

        public void AddResultInContainer(JObject container)
        {
            var jObj = (JObject)container["params"] ?? new JObject();
            jObj.Add(this._result);
            container["params"] = jObj;
        }

        public void Execute()
        {
            this._result = new JProperty("wt", this.Value.ToString().ToLower());
        }
    }
}
