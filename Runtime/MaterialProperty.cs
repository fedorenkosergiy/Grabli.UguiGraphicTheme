using System;
using UnityEngine;

namespace Grabli.UguiGraphicTheme
{
	[Serializable]
	public struct MaterialProperty
	{
		internal const string MaterialFieldName = nameof(material);
		internal const string LabelHashFieldName = nameof(labelHash);

		[SerializeField] private Material material;
		[SerializeField] private int labelHash;

		public Material Material => material;
		public int LabelHash => labelHash;
	}
}
