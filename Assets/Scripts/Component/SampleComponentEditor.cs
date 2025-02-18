using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SampleComponent))]
public class SampleComponentEditor : EditorEx
{
	public override void OnInspectorGUI()
	{
		EditorGUI.BeginChangeCheck();

		// 通常通りインスペクタ描画する
		base.OnInspectorGUI();
		base.SourceButton();
		base.EditorButton();

		if (EditorGUI.EndChangeCheck())
		{
			// インスペクタで値が変更された
			if (target is SampleComponent component)
			{
				component.Rebuild();
			}
		}

	}
}

