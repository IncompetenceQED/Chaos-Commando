using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float downAngle;
	public float yAxis;
	public float offset;

	public Vector2 startingPos;

	public float moveSpeed;

	// Use this for initialization
	void Start () {
		setTransformFromParameters ();
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
			gameObject.transform.Translate (motion, Space.World);
		}
	}

	[ContextMenu("Set Parameters")]
	void setParametersFromTransform () {
		downAngle = gameObject.transform.rotation.eulerAngles.x;
		yAxis = gameObject.transform.position.y;
		offset = gameObject.transform.position.z;
	}

	[ContextMenu("Set Positions")]
	void setTransformFromParameters () {
		gameObject.transform.rotation = Quaternion.Euler (downAngle, 0, 0);
		gameObject.transform.position = new Vector3 (startingPos.x,
			yAxis,
			startingPos.y + offset);
	}
}
