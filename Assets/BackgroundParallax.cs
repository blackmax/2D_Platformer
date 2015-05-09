using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {
	public Transform[] backgrounds; //backgrounds for changes with paralax
	private float[] parallaxScales; //coff to paralax
	public float smoothing = 1f; //coff of blur
	private Transform cam;
	private Vector3 previousCamPos;

	float parallax;
	float backgroundTargetPosX;
	float backgroundTargetPosY;
	Vector3 backgroundTargetPos;

	//вызывается прежде чем вызовется Start() ахуенно для настройки
	void  Awake(){
		cam = Camera.main.transform;
	}
	
	// Use this for initialization
	void Start () {
		previousCamPos = cam.position;
		parallaxScales = new float[backgrounds.Length];
		
		for (int i = 0; i<backgrounds.Length; i++){
			parallaxScales[(backgrounds.Length-1)-i] = backgrounds[i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i<backgrounds.Length; i++){
			parallax = (previousCamPos.x - cam.position.x)*parallaxScales[i];
			backgroundTargetPosX = backgrounds[i].position.x+parallax;
			backgroundTargetPosY = backgrounds[i].position.y+(previousCamPos.y - cam.position.y)*(parallaxScales[(backgrounds.Length-1)-i]);//parallax*0.5f;
			backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgroundTargetPosY, backgrounds[i].position.z);
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing + Time.deltaTime);
		};
		previousCamPos = cam.position;
	}
}
