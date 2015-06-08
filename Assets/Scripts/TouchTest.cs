using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchTest : MonoBehaviour {
	public Camera cam;
	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;
	private RaycastHit hit;

	void Update () {

		if (Input.touchCount > 0) {
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();
		}

		foreach (Touch touch in Input.touches) {

			Ray ray = cam.ScreenPointToRay(touch.position);


			if (Physics.Raycast(ray, out hit, touchInputMask)) {
				GameObject recipient = hit.transform.gameObject;
				touchList.Add(recipient);

				if (touch.phase == TouchPhase.Began) {
					recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (touch.phase == TouchPhase.Ended) {
					recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
					recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (touch.phase == TouchPhase.Canceled) {
					recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}




	}
}
