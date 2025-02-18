#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
public class CaptureScreenshotFromEditor : Editor
{
	[MenuItem("ツール/スクリーンショット &F12")]
	private static void CaptureScreenshot()
	{
		var path = Path.Combine(UnityEngine.Application.persistentDataPath, $"sc_{DateTime.Now.ToString("yyyyMMddHHmmss")}.png");
		ScreenCapture.CaptureScreenshot(path);

		var assembly = typeof(UnityEditor.EditorWindow).Assembly;
		var type = assembly.GetType("UnityEditor.GameView");
		var gameview = EditorWindow.GetWindow(type);
		gameview.Repaint();

		Debug.Log($"ScreenShot: <a href=\"{path}\">{path}</a>");

	}
}

#endif
