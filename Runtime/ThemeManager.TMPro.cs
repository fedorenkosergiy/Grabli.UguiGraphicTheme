#if GRABLI_UGUI_GRAPHIC_THEME_TMPRO_SUPPORT
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
#endif