using System.Collections.Generic;
using UnityEngine;

namespace Grabli.UguiGraphicTheme
{
	[CreateAssetMenu(fileName = "ThemeConfig.asset", menuName = "Graphic/ThemeConfig")]
	public partial class ThemeConfig : ScriptableObject
	{
		[SerializeField] private List<ColorProperty> colors;
		[SerializeField] private List<MaterialProperty> materials;
		[SerializeField] private List<AnimatorControllerProperty> animatorControllers;

		public void GetAllProperties(IList<ColorProperty> properties)
		{
			for (int i = 0; i < colors.Count; ++i)
			{
				properties.Add(colors[i]);
			}
		}

		public void GetAllProperties(IList<MaterialProperty> properties)
		{
			for (int i = 0; i < materials.Count; ++i)
			{
				properties.Add(materials[i]);
			}
		}

		public void GetAllProperties(IList<AnimatorControllerProperty> properties)
		{
			for (int i = 0; i < animatorControllers.Count; ++i)
			{
				properties.Add(animatorControllers[i]);
			}
		}

		public bool TryGetProperty(int labelHash, out ColorProperty property)
		{
			for (int i = 0; i < colors.Count; ++i)
			{
				if (colors[i].LabelHash == labelHash)
				{
					property = colors[i];
					return true;
				}
			}

			property = default;
			return false;
		}

		public bool TryGetProperty(int labelHash, out MaterialProperty property)
		{
			for (int i = 0; i < materials.Count; ++i)
			{
				if (materials[i].LabelHash == labelHash)
				{
					property = materials[i];
					return true;
				}
			}

			property = default;
			return false;
		}

		public bool TryGetProperty(int labelHash, out AnimatorControllerProperty property)
		{
			for (int i = 0; i < animatorControllers.Count; ++i)
			{
				if (animatorControllers[i].LabelHash == labelHash)
				{
					property = animatorControllers[i];
					return true;
				}
			}

			property = default;
			return false;
		}
	}
}
