using Grabli.Labeling;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Grabli.UguiGraphicTheme
{
	[CreateAssetMenu(fileName = "GraphicThemeManager.asset", menuName = "Graphic/ThemeManager")]
	public partial class ThemeManager : ScriptableObject, ManagerInitializationListener
	{
		[SerializeField] private List<ThemeConfig> themes;

		private int selectedTheme;

		public ThemeConfig CurrentTheme => themes[selectedTheme];

		private void OnEnable()
		{
			if (GrabliLabelingApi.IsInitialized)
			{
				StartListeningLabelingChanges(GrabliLabelingApi.Manager);
			}
			else
			{
				GrabliLabelingApi.AddListener(this);
			}
		}

		private void StartListeningLabelingChanges(LabelingManager manager)
		{
			manager.OnLabelRegistered += ApplyTheme;
			ApplyTheme(manager);
		}


		private void ApplyTheme(LabelContentPiece piece)
		{
			if (CurrentTheme.TryGetProperty(piece.LabelHash, out ColorProperty color))
			{
				ApplyTheme(piece, color);
			}
			if (CurrentTheme.TryGetProperty(piece.LabelHash, out AnimatorControllerProperty animator))
			{
				ApplyTheme(piece, animator);
			}
		}

		private static void ApplyTheme(LabelContentPiece piece, ColorProperty property)
		{
			if (piece.ComponentType == typeof(Graphic))
			{
				for (int i = 0; i < piece.Count; ++i)
				{
					Graphic component = (Graphic)piece[i];
					component.color = property.Color;
				}
			}
		}

		private static void ApplyTheme(LabelContentPiece piece, MaterialProperty property)
		{
			if (piece.ComponentType == typeof(Graphic))
			{
				for (int i = 0; i < piece.Count; ++i)
				{
					Graphic component = (Graphic)piece[i];
					component.material = property.Material;
				}
			}
		}

		private static void ApplyTheme(LabelContentPiece piece, AnimatorControllerProperty property)
		{
			if (piece.ComponentType == typeof(Animator))
			{
				for (int i = 0; i < piece.Count; ++i)
				{
					Animator component = (Animator)piece[i];
					component.runtimeAnimatorController = property.Controller;
				}
			}
		}


		private void ApplyTheme(LabelingManager manager)
		{
			IList<ColorProperty> colors = new List<ColorProperty>();
			CurrentTheme.GetAllProperties(colors);
			IList<LabelContentPiece> pieces = new List<LabelContentPiece>();
			for (int i = 0; i < colors.Count; ++i)
			{
				pieces.Clear();
				manager.GetLabelContent(colors[i].LabelHash, pieces);
				for (int j = 0; j < pieces.Count; ++j)
				{
					ApplyTheme(pieces[j], colors[i]);
				}
			}

			IList<MaterialProperty> materials = new List<MaterialProperty>();
			CurrentTheme.GetAllProperties(materials);
			for (int i = 0; i < materials.Count; ++i)
			{
				pieces.Clear();
				manager.GetLabelContent(materials[i].LabelHash, pieces);
				for (int j = 0; j < pieces.Count; ++j)
				{
					ApplyTheme(pieces[j], materials[i]);
				}
			}

			IList<AnimatorControllerProperty> animators = new List<AnimatorControllerProperty>();
			CurrentTheme.GetAllProperties(animators);
			for (int i = 0; i < animators.Count; ++i)
			{
				pieces.Clear();
				manager.GetLabelContent(animators[i].LabelHash, pieces);
				for (int j = 0; j < pieces.Count; ++j)
				{
					ApplyTheme(pieces[j], animators[i]);
				}
			}

			ApplyThemeTMPro(manager);
		}

		partial void ApplyThemeTMPro(LabelingManager manager);

		void ManagerInitializationListener.OnInitialized(LabelingManager manager) =>
			StartListeningLabelingChanges(manager);

		public void ApplyTheme(ThemeConfig themeConfig)
		{
			int index = themes.IndexOf(themeConfig);
			if (index >= 0)
			{
				selectedTheme = index;
			}
			else
			{
				selectedTheme = themes.Count;
				themes.Add(themeConfig);
			}

			ApplyTheme(GrabliLabelingApi.Manager);
		}

		[ContextMenu(nameof(ApplyNextTheme))]
		private void ApplyNextTheme()
		{
			if (++selectedTheme == themes.Count)
			{
				selectedTheme = 0;
			}
			ApplyTheme(GrabliLabelingApi.Manager);
		}
	}
}
