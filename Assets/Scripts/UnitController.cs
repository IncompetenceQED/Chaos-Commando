using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

	void Start() {
		deselectThis ();
	}

	public void selectThis() {
		gameObject.transform.GetChild (0).GetComponent<Renderer> ().enabled = true;
	}

	public void deselectThis() {
		gameObject.transform.GetChild (0).GetComponent<Renderer> ().enabled = false;
	}
}
