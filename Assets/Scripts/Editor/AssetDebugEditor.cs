#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

// https://gamecreate.vatchlog.com/inspector-button/
/// �C�ӂ�Monobehavia�p���N���X��Inspector�Ƀ{�^����ǉ����A�\�[�X�R�[�h���Ƃֈړ��ł���悤�ɂ���
//[CustomEditor(typeof(AssetDebug))]
public class AssetDebugEditor : Editor
{
	public override void OnInspectorGUI()
	{
		//����Inspector������\��
		base.OnInspectorGUI();

		//�{�^����\��
		if (GUILayout.Button("�\�[�X�R�[�h"))
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
