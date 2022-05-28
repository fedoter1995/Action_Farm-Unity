using System;
using UnityEngine;

namespace Utils.Attributes
{
	[Serializable]
	public class ClassReferenceAttribute : PropertyAttribute
	{
		public Type type;

		public ClassReferenceAttribute(Type type)
		{
			this.type = type;
		}
	}
}
