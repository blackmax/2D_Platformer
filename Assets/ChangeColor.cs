using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour {

	public void Colorize () {
		GetComponent<Image>().color = Color.green;
	}
	public void unColorize () {
		GetComponent<Image>().color = Color.white;
	}
}
