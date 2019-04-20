using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EzeriaScreen : MonoBehaviour {

	void Start () {
		StartCoroutine(wait2seconds());
	}
	


	IEnumerator wait2seconds()
	{
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
