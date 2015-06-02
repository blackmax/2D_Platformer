using UnityEngine;
using System.Collections;

public class CameraPixelPerfect : MonoBehaviour {
	public bool ipad = false;
	public float textureSize = 100f;

	float unitsPerPixel;

	Camera cam;

	void Start () {
		cam = GetComponent<Camera>();
		unitsPerPixel = 1f / textureSize;
		cam.orthographicSize = (Screen.height / 2f) * unitsPerPixel;
	}
	void Update () {
		if (ipad) {
			unitsPerPixel = 1f / textureSize;
			cam.orthographicSize = (Screen.height) * unitsPerPixel;
		}
		else {
			unitsPerPixel = 1f / textureSize;
			cam.orthographicSize = (Screen.height / 2f) * unitsPerPixel;
		}
	}
}