using UnityEditor;
using UnityEngine;

public abstract class EditorEx : Editor
{
    /**
     * ソースコードへのリンクを表示する
     */
    public void SourceButton()
    {
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

	/**
     * コンポーネントエディターへのリンクを表示する
     */
	public void EditorButton()
	{
		//ボタンを表示
		if (GUILayout.Button("エディター"))
		{
			var scriptName = this.GetType().Name;

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
