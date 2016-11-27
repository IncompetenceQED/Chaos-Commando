using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public enum State {
		Waiting,
		Selected,
		SelectingGround,
		SelectingClickable,
		Animating
	};

	public State currentState = State.Waiting;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void selectUnit(GameObject unitObject) {
		print ("Selected unit " + unitObject.GetInstanceID ());
	}

	public bool isOwnUnit(GameObject unitObject) {
		return true;
	}
}
