using System;

namespace AltV.Net
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	public sealed class ResourceSharedAssembliesAttribute : Attribute
	{
		public string[] Values { get; set; }

		public ResourceSharedAssembliesAttribute(params string[] values)
		{
			Values = values;
		}
	}
}