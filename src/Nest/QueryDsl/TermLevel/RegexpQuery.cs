﻿using System;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IRegexpQuery : IFieldNameQuery
	{
		[JsonProperty("value")]
		string Value { get; set; }

		[JsonProperty("flags")]
		string Flags { get; set; }

		[JsonProperty(PropertyName = "max_determinized_states")]
		int? MaximumDeterminizedStates { get; set; }

		PropertyPathMarker Field { get; set; }

		[JsonProperty("boost")]
		double? Boost { get; set; }
	}

	public class RegexpQuery : PlainQuery, IRegexpQuery
	{
		public string Name { get; set; }
		bool IQuery.IsConditionless { get { return false; } }
		public string Value { get; set; }
		public string Flags { get; set; }
		public int? MaximumDeterminizedStates { get; set; }
		public PropertyPathMarker Field { get; set; }
		public double? Boost { get; set; }

		protected override void WrapInContainer(IQueryContainer container)
		{
			container.Regexp = this;
		}

		PropertyPathMarker IFieldNameQuery.GetFieldName()
		{
			return this.Field;
		}

		void IFieldNameQuery.SetFieldName(string fieldName)
		{
			this.Field = fieldName;
		}
	}

	public class RegexpQueryDescriptor<T> : IRegexpQuery where T : class
	{
		private IRegexpQuery Self => this;
		string IQuery.Name { get; set; }
		bool IQuery.IsConditionless
		{
			get
			{
				return Self.Field.IsConditionless() || Self.Value.IsNullOrEmpty();
			}
		}
		string IRegexpQuery.Value { get; set; }
		string IRegexpQuery.Flags { get; set; }
		int? IRegexpQuery.MaximumDeterminizedStates { get; set; }
		PropertyPathMarker IRegexpQuery.Field { get; set; }
		double? IRegexpQuery.Boost { get; set; }

		public RegexpQueryDescriptor<T> Name(string name)
		{
			Self.Name = name;
			return this;
		}
		
		public RegexpQueryDescriptor<T> MaximumDeterminizedStates(int maxDeterminizedStates)
		{
			Self.MaximumDeterminizedStates = maxDeterminizedStates;
			return this;
		}

		public RegexpQueryDescriptor<T> Value(string regex)
		{
			Self.Value = regex;
			return this;
		}

		public RegexpQueryDescriptor<T> Flags(string flags)
		{
			Self.Flags = flags;
			return this;
		}

		public RegexpQueryDescriptor<T> OnField(string path)
		{
			Self.Field = path;
			return this;
		}

		public RegexpQueryDescriptor<T> Boost(double boost)
		{
			Self.Boost = boost;
			return this;
		}

		public RegexpQueryDescriptor<T> OnField(Expression<Func<T, object>> objectPath)
		{
			Self.Field = objectPath;
			return this;
		}

		void IFieldNameQuery.SetFieldName(string fieldName)
		{
			Self.Field = fieldName;
		}

		PropertyPathMarker IFieldNameQuery.GetFieldName()
		{
			return Self.Field;
		}
	}
}
