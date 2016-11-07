using UnityEngine;
using System.Collections;

public class GridScalingController : MonoBehaviour {

	public float textureToMeshX;
	public float textureToMeshZ;

	private float planeSizeX = 10;
	private float planeSizeZ = 10;

	private Material gridMaterial;

	// Use this for initialization
	void Start () {
		gridMaterial = gameObject.GetComponent<Renderer> ().material;
		resetScaling ();
	}

	private void resetScaling() {
		float newScaleX = (planeSizeX * gameObject.transform.lossyScale.x) / textureToMeshX;
		float newScaleZ = (planeSizeZ * gameObject.transform.lossyScale.z) / textureToMeshZ;

		gridMaterial.mainTextureScale = new Vector2 (newScaleX, newScaleZ);

		float newOffsetX = - (((gameObject.transform.lossyScale.x * planeSizeX / 2) + gameObject.transform.position.x) % textureToMeshX);
		float newOffsetZ = - (((gameObject.transform.lossyScale.z * planeSizeZ / 2) + gameObject.transform.position.z) % textureToMeshZ);

		gridMaterial.mainTextureOffset = new Vector2 (newOffsetX, newOffsetZ);
	}

	[ContextMenu("Reset Scaling")]
	private void contextResetScaling() {
		gridMaterial = gameObject.GetComponent<Renderer> ().sharedMaterial;
		resetScaling ();
	}
}
