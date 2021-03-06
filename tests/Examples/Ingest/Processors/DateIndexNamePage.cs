// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Ingest.Processors
{
	public class DateIndexNamePage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("ingest/processors/date-index-name.asciidoc:20")]
		public void Line20()
		{
			// tag::83c8cce0372677857609a2e80e8eb1c4[]
			var response0 = new SearchResponse<object>();
			// end::83c8cce0372677857609a2e80e8eb1c4[]

			response0.MatchesExample(@"PUT _ingest/pipeline/monthlyindex
			{
			  ""description"": ""monthly date-time index naming"",
			  ""processors"" : [
			    {
			      ""date_index_name"" : {
			        ""field"" : ""date1"",
			        ""index_name_prefix"" : ""myindex-"",
			        ""date_rounding"" : ""M""
			      }
			    }
			  ]
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ingest/processors/date-index-name.asciidoc:40")]
		public void Line40()
		{
			// tag::9f3f1b6bd431f6fa40fc17ce9a5a89b8[]
			var response0 = new SearchResponse<object>();
			// end::9f3f1b6bd431f6fa40fc17ce9a5a89b8[]

			response0.MatchesExample(@"PUT /myindex/_doc/1?pipeline=monthlyindex
			{
			  ""date1"" : ""2016-04-25T12:02:01.789Z""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ingest/processors/date-index-name.asciidoc:75")]
		public void Line75()
		{
			// tag::44f672df54c28327070b4ca09999718c[]
			var response0 = new SearchResponse<object>();
			// end::44f672df54c28327070b4ca09999718c[]

			response0.MatchesExample(@"POST _ingest/pipeline/_simulate
			{
			  ""pipeline"" :
			  {
			    ""description"": ""monthly date-time index naming"",
			    ""processors"" : [
			      {
			        ""date_index_name"" : {
			          ""field"" : ""date1"",
			          ""index_name_prefix"" : ""myindex-"",
			          ""date_rounding"" : ""M""
			        }
			      }
			    ]
			  },
			  ""docs"": [
			    {
			      ""_source"": {
			        ""date1"": ""2016-04-25T12:02:01.789Z""
			      }
			    }
			  ]
			}");
		}
	}
}
