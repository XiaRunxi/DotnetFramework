﻿using Dotnet.Solr.Builder;
using System;
using System.Linq.Expressions;

namespace Dotnet.Solr.Search
{
    public interface ISearchItemFieldExpressions<TDocument>
        where TDocument : Document
    {
        /// <summary>
        /// Build expressions engine
        /// </summary>
        ExpressionBuilder<TDocument> ExpressionBuilder { get; set; }

        /// <summary>
        /// Expressions used to find fields name
        /// </summary>
        Expression<Func<TDocument, object>>[] FieldExpressions { get; set; }
    }
}
