using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float downAngle;
	public float yAxis;
	public float offset;

	public Vector2 startingPos;

	// Use this for initialization
	void Start () {
		gameObject.transform.rotation = Quaternion.Euler (downAngle, 0, 0);
		gameObject.transform.position = new Vector3 (startingPos.x,
													 yAxis,
													 startingPos.y + offset);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[ContextMenu("Set Parameters")]
	void setParametersFromTransform () {
		downAngle = gameObject.transform.rotation.eulerAngles.x;
		yAxis = gameObject.transform.position.y;
		offset = gameObject.transform.position.z;
	}
}
