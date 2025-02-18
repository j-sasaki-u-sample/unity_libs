using UnityEngine;

public class SampleComponent : MonoBehaviour
{
	[SerializeField] private int value;

	// valueが変更された時にこのメソッドを呼び出したい
	public void Rebuild()
	{
		Debug.Log("Rebuild");
	}
}

