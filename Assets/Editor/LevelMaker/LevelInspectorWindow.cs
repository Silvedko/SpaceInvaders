using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CIGameLevel))]
public class LevelInspectorWindow : Editor
{
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector();

	}

}
