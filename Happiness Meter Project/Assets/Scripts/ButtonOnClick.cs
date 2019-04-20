using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonOnClick : MonoBehaviour {

	public AddEntryNew addentry;
	
	public Button btn;
	public UnityAction action;

	

	void Start()
	{
		addentry = gameObject.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<AddEntryNew>();


		action = new UnityAction(test);
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(action);
	
	}


	void test()
	{
		addentry.RemoveEntry();
	}

}
