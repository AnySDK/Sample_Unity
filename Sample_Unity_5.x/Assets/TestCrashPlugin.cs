using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace anysdk {
	public class TestCrashPlugin : MonoBehaviour {

		private AnySDKCrash _instance;
		void Awake()
		{
		}
		void Start()
		{
			_instance = AnySDKCrash.getInstance ();
		}
		void OnDestroy() {
			
		}
		
		void OnGUI()
		{	
			GUI.color = Color.white;
			
			GUI.skin.button.fontSize = 30;
			if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"setUserIdentifier" ))
			{
				setUserIdentifier("AnySDK");
			}
			
			if(GUI.Button(new Rect(5, 80, Screen.width - 10, 70),"reportException" ))
			{
				reportException("error","test");
			}
			
			if(GUI.Button(new Rect(5, 155, Screen.width - 10, 70),"leaveBreadcrumb" ))
			{
				
				leaveBreadcrumb("AnySDK");
			}

			if(GUI.Button(new Rect(5, 225, Screen.width - 10, 70),"return" ))
			{
				Destroy (GetComponent ("TestCrashPlugin" ));
				this.gameObject.AddComponent<Test>();
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
	

		void setUserIdentifier(string identifier) {
			_instance.setUserIdentifier(identifier);
		}

		void reportException(string message, string exception) {
			_instance.reportException(message,exception);
		}

		void leaveBreadcrumb(string bread) {
			_instance.leaveBreadcrumb(bread);
		}


	}
}
