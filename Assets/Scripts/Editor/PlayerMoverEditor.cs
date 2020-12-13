using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerMover))]
public class PlayerMoverEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		PlayerMover script = target as PlayerMover;

		GUILayout.Label("TestRequest");

		if (GUILayout.Button("Self Request"))
		{
			script.Request(5, () =>
		   {
			   Debug.Log("テストリクエスト終わり");
		   });

		}

	}
}
