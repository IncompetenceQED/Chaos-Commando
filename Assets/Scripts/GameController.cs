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

	private GameObject selectedUnit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void selectUnit(GameObject unitObject) {
		if (currentState == State.Waiting) {
			if (isOwnUnit(unitObject)) {
				performSelection(unitObject);
			}
		} else if (currentState == State.Selected) {
			if (!unitObject.Equals (selectedUnit)) {
				if (isOwnUnit (unitObject)) {
					deselectCurrent ();
					selectUnit (unitObject);
				}
			}
		} else if (currentState == State.SelectingClickable) {
			//TODO
		}
	}

	private void performSelection(GameObject unitObject) {
		unitObject.GetComponent<UnitController> ().selectThis ();
		selectedUnit = unitObject;
		currentState = State.Selected;
	}

	private void deselectCurrent() {
		selectedUnit.GetComponent<UnitController> ().deselectThis ();
		currentState = State.Waiting;
	}

	public bool isOwnUnit(GameObject unitObject) {
		return true;
	}

	public void selectSquare(int xCoord, int yCoord) {
		if (currentState == State.Selected) {
			deselectCurrent ();
		} else if (currentState == State.SelectingGround) {
			//TODO
		}
	}
}
