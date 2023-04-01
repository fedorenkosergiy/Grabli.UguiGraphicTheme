using System;
using UnityEngine;

namespace Grabli.UguiGraphicTheme
{
	[Serializable]
	public struct AnimatorControllerProperty
	{
		internal const string ControllerFieldName = nameof(controller);
		internal const string LabelHashFieldName = nameof(labelHash);

		[SerializeField] private RuntimeAnimatorController controller;
		[SerializeField] private int labelHash;

		public RuntimeAnimatorController Controller => controller;
		public int LabelHash => labelHash;
	}
}
