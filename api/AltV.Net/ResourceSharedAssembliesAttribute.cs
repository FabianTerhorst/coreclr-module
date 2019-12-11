using System;

namespace AltV.Net
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public sealed class ResourceSharedAssembliesAttribute : Attribute
	{
		private string[] Values { get; set; }

		public ResourceSharedAssembliesAttribute(params string[] values)
		{
			Values = values;
		}
	}
}