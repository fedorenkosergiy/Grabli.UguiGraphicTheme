#if GRABLI_UGUI_GRAPHIC_THEME_TMPRO_SUPPORT
using UnityEngine;
using TMPro;

namespace Grabli.UguiGraphicTheme
{
	public partial class ThemeConfig
	{
		[SerializeField] private TMP_StyleSheet textStyles;

		public TMP_StyleSheet TextStyles => textStyles;

	}
}
#endif