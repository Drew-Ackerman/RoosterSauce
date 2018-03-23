using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TextGenerator))]
public class TextGeneratorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		TextGenerator generator = (TextGenerator)target;
		if(GUILayout.Button("Generate!"))
		{
			generator.MakeText();
		}
	}
}