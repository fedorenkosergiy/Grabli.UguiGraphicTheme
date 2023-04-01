using System;
using UnityEngine;

namespace Grabli.UguiGraphicTheme
{
	[Serializable]
	public struct ColorProperty
	{
		internal const string ColorFieldName = nameof(color);
		internal const string LabelHashFieldName = nameof(labelHash);

		[SerializeField] private Color color;
		[SerializeField] private int labelHash;

		public Color Color => color;
		public int LabelHash => labelHash;
	}
}
