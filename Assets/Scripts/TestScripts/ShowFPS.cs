using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour {
	
	public  float updateInterval = 0.5F;
	
	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval
	
	// Use this for initialization
	void Start () {
		timeleft = updateInterval;  
		Application.targetFrameRate = 60;
	}

	void Awake () {
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		
		// Interval ended - update GUI text and start new interval
		if( timeleft <= 0.0 )
		{
			// display two fractional digits (f2 format)
			float fps = accum/frames;
			string format = System.String.Format("{0:F2} FPS",fps);
			GetComponent<Text>().text = format;
			
			if(fps < 30)
				GetComponent<Text>().color = Color.yellow;
			else 
				if(fps < 10)
					GetComponent<Text>().color = Color.red;
			else
				GetComponent<Text>().color = Color.green;
			//	DebugConsole.Log(format,level);
			timeleft = updateInterval;
			accum = 0.0F;
			frames = 0;
		}
		
	}
}

//test comment