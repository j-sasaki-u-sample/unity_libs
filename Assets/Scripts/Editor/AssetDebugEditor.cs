#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

// https://gamecreate.vatchlog.com/inspector-button/
/// 任意のMonobehavia継承クラスのInspectorにボタンを追加し、ソースコードもとへ移動できるようにする
//[CustomEditor(typeof(AssetDebug))]
public class AssetDebugEditor : Editor
{
	public override void OnInspectorGUI()
	{
		//元のInspector部分を表示
		base.OnInspectorGUI();

		//ボタンを表示
		if (GUILayout.Button("ソースコード"))
		{
			var scriptName = target.GetType().Name;

			string[] paths = AssetDatabase.GetAllAssetPaths();
			foreach (string path in paths)
			{
				string fileName = System.IO.Path.GetFileNameWithoutExtension(path);
				if (fileName != scriptName) continue;

				MonoScript script = AssetDatabase.LoadAssetAtPath(path, typeof(MonoScript)) as MonoScript;
				if (script != null)
				{
					if (!AssetDatabase.OpenAsset(script))
					{
						Debug.LogWarning("Couldn't open script : " + scriptName);
					}
					break;
				}
				break;
			}
		}

	}
}
#endif
