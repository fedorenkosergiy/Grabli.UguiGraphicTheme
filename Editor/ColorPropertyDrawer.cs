using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Grabli.UguiGraphicTheme.Editor
{
	[CustomPropertyDrawer(typeof(ColorProperty))]
	public class ColorPropertyDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);
			DrawChildren(position, property);
			EditorGUI.EndProperty();
		}

		private void DrawChildren(Rect position, SerializedProperty property)
		{
			IEnumerator enumerator = property.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SerializedProperty child = enumerator.Current as SerializedProperty;
				if (child == null)
				{
					continue;
				}

				switch (child.name)
				{
					case ColorProperty.LabelHashFieldName:
						Rect labelPosition = GetPositionForLabel(position);
						DrawLabel(labelPosition, child);
						break;
					case ColorProperty.ColorFieldName:
						Rect colorPosition = GetColorPosition(position);
						DrawColor(colorPosition, child);
						break;
					default:
						EditorGUI.PropertyField(position, child);
						break;
				}
			}
		}

		private Rect GetPositionForLabel(Rect position)
		{
			return new Rect(position.x, position.y, position.width * 0.5f, position.height);
		}

		private void DrawLabel(Rect position, SerializedProperty property)
		{
			property.intValue = EditorGUI.Popup(position, property.intValue, GetAllLabels());
		}

		private string[] GetAllLabels()
		{
			if (!GrabliLabelingApi.IsInitialized)
			{
				return Array.Empty<string>();
			}
			List<string> labels = new List<string>();
			GrabliLabelingApi.Manager.Settings.GetAllLabels(labels);
			return labels.ToArray();
		}

		private Rect GetColorPosition(Rect position)
		{
			return new Rect(position.x + position.width * 0.5f, position.y, position.width * 0.5f, position.height);
		}

		private void DrawColor(Rect position, SerializedProperty property)
		{
			property.colorValue = EditorGUI.ColorField(position, property.colorValue);
		}
	}
}
