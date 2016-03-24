using UnityEngine;
using UnityEditor;
using System.Collections;


public class ItemEditorWindow : EditorWindow {

	string textfield {
		get { return textfield; }
		set { if (value != textfield) textfield = value; }
	}

	[MenuItem("Window/Item Editor")]    
	static void Init()
	{
		ItemEditorWindow window = (ItemEditorWindow)EditorWindow.GetWindow(typeof(ItemEditorWindow));
		window.Show();
	}

	void OnGUI() {
		GUILayout.Label("ItemEditor");

		EditorGUILayout.BeginHorizontal ();
		GUILayout.Label ("Name: ");
		textfield = EditorGUILayout.TextArea ("Default name");

		EditorGUILayout.EndHorizontal ();

		if (GUILayout.Button ("Create")) {

			AssetDatabase.CreateAsset(CreateInstance<MeleeWeapon> (), "Assets/" + textfield + ".asset");
		}
	}
}