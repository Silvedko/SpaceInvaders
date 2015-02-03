using UnityEngine;
using System.Collections;
using UnityEditor;

//[CustomEditor(typeof(CIGameLevel))]
public class LevelEditor : EditorWindow
{
	static SIGameLevel level;
	static int levelCount; 
	static string outputFileName = "Level_";
	static int outputLevelCounter = 0;


	[MenuItem("Space Invaders/Display level creator window")]
	static void Initialize() 
	{
		EditorWindow.GetWindow(typeof(LevelEditor), true, "My Empty Window");

		level = ScriptableObject.CreateInstance<SIGameLevel> ();
		SetLevelsName ();

	}

	public void OnGUI() 
	{
		if(level)
			level.sortingType = (InvadersSortingType)EditorGUI.EnumPopup(new Rect(3,10,position.width - 6, 15),
														   "Show:",
								                           level.sortingType);
		EditorGUILayout.BeginHorizontal();
		outputFileName = EditorGUILayout.TextField(outputFileName,  GUILayout.Height(position.height/20), GUILayout.Width(position.width * 2 / 3 )); 
		EditorGUILayout.LabelField("File name", GUILayout.Width (position.width / 3));

		EditorGUILayout.EndHorizontal ();

		if(GUILayout.Button("Save"))
		{
			SaveCreatedAsset ();
			Close();
		}
  	}

	/// <summary>
	/// Sets the standert name of the levels.
	/// </summary>
	static void SetLevelsName ()
	{
		string [] foldersForSearch = {"Assets/Levels"};
		string filter = "Level_";
		outputLevelCounter = AssetDatabase.FindAssets(filter, foldersForSearch).Length + 1;
		outputFileName = filter;
		outputFileName = outputFileName + outputLevelCounter.ToString ();
	}


	void SaveCreatedAsset ()
	{
		AssetDatabase.CreateAsset (level, "Assets/Levels/" + outputFileName + ".asset");
		AssetDatabase.SaveAssets();
		
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = level;
		SetLevelsName ();
	}

}
