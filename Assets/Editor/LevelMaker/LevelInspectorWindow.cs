using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SIGameLevel))]
public class LevelInspectorWindow : Editor
{
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector();

	}

}
