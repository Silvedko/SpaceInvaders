using UnityEngine;
using System.Collections;
using UnityEditor;

//[CustomEditor(typeof(CIGameLevel))]
public class LevelEditor : EditorWindow
{
	static CIGameLevel level;
	static int levelCount; 
	static string outputFileName = "Level_";
	static int outputLevelCounter = 0;


	[MenuItem("Example/Display level creator window")]
	static void Initialize() 
	{
		EditorWindow.GetWindow(typeof(LevelEditor), true, "My Empty Window");

		level = ScriptableObject.CreateInstance<CIGameLevel> ();
		SetLevelsName ();

	}

	public void OnGUI() 
	{
		if(level)
			level.sortingType = (InvadersSortingType)EditorGUI.EnumPopup(new Rect(3,3,position.width - 6, 15),
														   "Show:",
								                           level.sortingType);
		outputFileName = EditorGUILayout.TextField(outputFileName,  GUILayout.Height(position.height/20)); 

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
