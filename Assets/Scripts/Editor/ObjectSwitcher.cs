#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Reflection;

public class ObjectSwitcher : MonoBehaviour
{

	[MenuItem("ツール/オブジェクト切り替え &F1")]
	private static void SwitchActiveOnOff()
	{
		if (Selection.transforms.Length == 0) return;
		bool flg = Selection.transforms[0].gameObject.activeSelf;
		foreach (var item in Selection.transforms)
		{
			item.gameObject.SetActive(!flg);
		}
	}

	[MenuItem("ツール/InspectorLock_1 &F5")]
	private static void SwitchLockUnLock1()
	{
		InspectorUnlock(0);
	}

	[MenuItem("ツール/InspectorLock_2 &F6")]
	private static void SwitchLockUnLock2()
	{
		InspectorUnlock(1);
	}

	/// <summary>
	/// https://baba-s.hatenablog.com/entry/2017/12/28/145700
	/// </summary>
	private static void InspectorUnlock(int num)
	{
		var window = Resources.FindObjectsOfTypeAll<EditorWindow>();
		var inspectors = ArrayUtility.FindAll(window, c => c.GetType().Name == "InspectorWindow");

		if (inspectors.Count == 0) return;
		if (inspectors.Count < num) return;
		inspectors.Sort((a, b) =>
		{
			if (a.position.x != b.position.x) return (int)(a.position.x - b.position.x);
			if (a.position.y != b.position.y) return (int)(a.position.y - b.position.y);
			return 0;
		});

		var inspector = inspectors[num];
		var inspectorType = inspector.GetType();
		var isLockedPropertyInfo = inspectorType.GetProperty("isLocked", BindingFlags.Public | BindingFlags.Instance);
		var lockFlg = (bool)isLockedPropertyInfo.GetValue(inspector);
		isLockedPropertyInfo.SetValue(inspector, !lockFlg);
		inspector.Repaint();
	}
}

#endif
