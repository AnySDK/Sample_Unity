using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using anysdk;
public class Test : MonoBehaviour {
	
	void Start ()
	{
		Init.getInstance();
		Debug.Log ("getCustomParam" + AnySDK.getInstance ().getCustomParam ());
		Debug.Log ("getChannelId" + AnySDK.getInstance ().getChannelId ());
		
	}

	void OnGUI()
	{	
		GUI.color = Color.white;

		GUI.skin.button.fontSize = 30;
		if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"User System" ))
		{
			this.gameObject.AddComponent<TestUserPlugin>();
			Destroy (GetComponent ("Test" ));
		}

		if(GUI.Button(new Rect(5, 80, Screen.width - 10, 70),"IAP System" ))
		{

			this.gameObject.AddComponent<TestIAPPlugin>();
			Destroy (GetComponent ("Test" ));
		}
		
		if(GUI.Button(new Rect(5, 155, Screen.width - 10, 70),"Share System" ))
		{
			this.gameObject.AddComponent<TestSharePlugin>();
			Destroy (GetComponent ("Test" ));
		}
		
		if(GUI.Button(new Rect(5, 230, Screen.width - 10, 70),"Ads System" ))
		{
			this.gameObject.AddComponent<TestAdsPlugin>();
			Destroy (GetComponent ("Test" ));
		}
		
		
		if(GUI.Button(new Rect(5, 305, Screen.width - 10, 70),"Social System" ))
		{
			this.gameObject.AddComponent<TestSocialPlugin>();
			Destroy (GetComponent ("Test" ));
		}
		
		
		if(GUI.Button(new Rect(5, 380, Screen.width - 10, 70),"Push System" ))
		{
			this.gameObject.AddComponent<TestPushPlugin>();
			Destroy (GetComponent ("Test" ));
		}
		
		
		if(GUI.Button(new Rect(5, 455, Screen.width - 10, 70),"Analytics System" ))
		{
			this.gameObject.AddComponent<TestAnalyticsPlugin>();
			Destroy (GetComponent ("Test" ));
		}

		if(GUI.Button(new Rect(5, 525, Screen.width - 10, 70),"Crash System" ))
		{
			this.gameObject.AddComponent<TestCrashPlugin>();
			Destroy (GetComponent ("Test" ));
		}

		if(GUI.Button(new Rect(5, 595, Screen.width - 10, 70),"REC System" ))
		{
			this.gameObject.AddComponent<TestRECPlugin>();
			Destroy (GetComponent ("Test" ));
		}

		if(GUI.Button(new Rect(5, 665, Screen.width - 10, 70),"AdTracking System" ))
		{
			this.gameObject.AddComponent<TestAdTrackingPlugin>();
			Destroy (GetComponent ("Test" ));
		}
		
		
	}
	
	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Home))  
		{  
			Application.Quit(); 
			AnySDK.getInstance ().release ();
		} 
	}


}
