using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NotasManager))]
public class NotasManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (GUILayout.Button("Activar Notas"))
		{
			NotasManager nt = (NotasManager)target;
			nt.Activar();
		}

	}
}
