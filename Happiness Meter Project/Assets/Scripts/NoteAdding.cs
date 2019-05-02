using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NoteAdding : MonoBehaviour
{

	public InputField noteField;

	private void Start()
	{
		noteField.lineType = InputField.LineType.MultiLineNewline;
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
	}
}