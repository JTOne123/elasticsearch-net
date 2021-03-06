// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	public class GetCategoriesResponse : ResponseBase
	{
		[DataMember(Name ="categories")]
		public IReadOnlyCollection<CategoryDefinition> Categories { get; internal set; } = EmptyReadOnly<CategoryDefinition>.Collection;

		[DataMember(Name ="count")]
		public long Count { get; internal set; }
	}
}
