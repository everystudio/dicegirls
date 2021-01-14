using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PanelItemRoulette))]
public class PanelItemRouletteEditor : Editor
{
	public override void OnInspectorGUI()
	{
		PanelItemRoulette script = target as PanelItemRoulette;
		base.OnInspectorGUI();
		if(GUILayout.Button("DebugRoulette"))
		{
			script.debugRouletteStart();
		}
	}
}
