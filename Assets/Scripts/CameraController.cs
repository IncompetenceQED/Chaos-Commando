using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float initialDownAngle;
	public float initialYAxis;
	public float initialOffset;
	public Vector3 startingLookPos;

	public GameController gameController;

	//Layer 8 is clickable
	private int clickableMask = 1 << 8;
	//Layer 9 is ground
	private int groundMask = 1 << 9;
	//Layer 10 is untargetable
	private int untargetableMask = 1 << 10;

	//Camera movement management
	private Vector3 dragPoint;
	private bool holding = false;
	private bool dragging = false;

	//Camera position storage
	public float downAngle;
	public float yAxis;
	public float offset;
	private Vector3 lookPosition;

	//This threshold is in world units
	public float dragThreshold;

	public float moveSpeed;


	// Use this for initialization
	void Start () {
		setTransformFromParameters ();
		downAngle = initialDownAngle;
		yAxis = initialYAxis;
		offset = initialOffset;
		lookPosition = startingLookPos;
		gameController = GameObject.FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Vector3 motion = new Vector3 ();
			if (Input.GetKey (KeyCode.LeftArrow)) {
				motion.x = motion.x - moveSpeed;
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				motion.z = motion.z + moveSpeed;
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				motion.x = motion.x + moveSpeed;
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				motion.z = motion.z - moveSpeed;
			}
			lookPosition = lookPosition + motion;
		}

		if (Input.GetMouseButton (0)) {
			if (holding) {
				RaycastHit hit;
				Ray click = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (click, out hit, 100, groundMask | clickableMask)) {
					if (dragging || Vector3.Distance(hit.point, dragPoint) >= dragThreshold) {
						dragging = true;
						float distanceToPointHeight = (dragPoint.y - click.origin.y)/click.direction.y;
						lookPosition = lookPosition + (dragPoint - click.GetPoint (distanceToPointHeight));
					}
				}
			}
		}

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray click = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (click, out hit, 100, groundMask | clickableMask)) {
				holding = true;
				dragPoint = hit.point;
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			if (!dragging) {
				clickOn (Input.mousePosition);
			}
			holding = false;
			dragging = false;
		}

		positionCamera ();
	}

	private void clickOn(Vector3 mousePosition) {

	}

	private void positionCamera() {
		gameObject.transform.rotation = Quaternion.Euler (downAngle, 0, 0);
		gameObject.transform.position = new Vector3 (lookPosition.x,
													 yAxis,
													 lookPosition.z + offset);
	}

	[ContextMenu("Set Parameters")]
	void setParametersFromTransform () {
		initialDownAngle = gameObject.transform.rotation.eulerAngles.x;
		initialYAxis = gameObject.transform.position.y;
		initialOffset = gameObject.transform.position.z;
	}

	[ContextMenu("Set Position")]
	void setTransformFromParameters () {
		gameObject.transform.rotation = Quaternion.Euler (initialDownAngle, 0, 0);
		gameObject.transform.position = new Vector3 (startingLookPos.x,
			initialYAxis,
			startingLookPos.z + initialOffset);
	}

}
