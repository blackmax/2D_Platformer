using UnityEngine;
using System.Collections;

public class TouchInp : MonoBehaviour {
	public LayerMask touchInputMask;
	void Update () {
		for (var i = 0; i < Input.touchCount; ++i) {

			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero, 10000, touchInputMask);

			if (hit) {
				GameObject recipient = hit.transform.gameObject;

				if (Input.GetTouch(i).phase == TouchPhase.Began) {
					recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetTouch(i).phase == TouchPhase.Ended) {
					recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetTouch(i).phase == TouchPhase.Stationary || Input.GetTouch(i).phase == TouchPhase.Moved) {
					recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetTouch(i).phase == TouchPhase.Canceled) {
					recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}

	}
}
