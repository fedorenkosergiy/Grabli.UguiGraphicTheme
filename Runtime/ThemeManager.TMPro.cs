using Grabli.Labeling;
using TMPro;

namespace Grabli.UguiGraphicTheme
{
	public partial class ThemeManager
	{
		partial void ApplyThemeTMPro(LabelingManager manager)
		{
			TMP_Settings.defaultStyleSheet = CurrentTheme.TextStyles;
		}
	}
}
