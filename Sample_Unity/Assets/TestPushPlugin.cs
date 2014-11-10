using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace anysdk {
	public class TestPushPlugin : MonoBehaviour {
	
		
		private GUIStyle fontStyle;
		
		void Awake()
		{
			fontStyle = new GUIStyle();
			fontStyle.alignment = TextAnchor.MiddleCenter;
	        fontStyle.fontSize = 40;   
		}
		
		void OnDestroy() {
			
		}
		
		void OnGUI()
		{	
			
			//startPush
			if(GUI.Button(new Rect(100,100,Screen.width - 200,80),"startPush" ))
			{
			
				startPush();
				Debug.Log(AnySDKPush.getPluginName());
				Debug.Log(AnySDKPush.getPluginVersion());
				Debug.Log(AnySDKPush.getSDKVersion());
				AnySDKPush.setDebugMode(true);
			}
			
			//closePush
			if(GUI.Button(new Rect(100,200,Screen.width - 200,80),"closePush" ))
			{
				closePush();
				Debug.Log(AnySDKIAP.getPluginName());
				Debug.Log(AnySDKIAP.getPluginVersion());
				Debug.Log(AnySDKIAP.getSDKVersion());
				AnySDKIAP.setDebugMode(true);
			}
			
			//setAlias
			if(GUI.Button(new Rect(100,300,Screen.width - 200,80),"setAlias" ))
			{
				setAlias("AnySDK");
			}
			
			//delAlias
			if(GUI.Button(new Rect(100,400,Screen.width - 200,80),"delAlias" ))
			{
				delAlias("AnySDK");
			}
			
			//setTags
			if(GUI.Button(new Rect(100,500,Screen.width - 200,80),"setTags" ))
			{
				ArrayList tags = new ArrayList();
				tags.Add("easy");
				tags.Add("fast");
				setTags(tags);
			}
			
			//delTag
			if(GUI.Button(new Rect(100,600,Screen.width - 200,80),"delTag" ))
			{
				ArrayList tags = new ArrayList();
				tags.Add("easy");
				tags.Add("fast");
				delTags(tags);
			}

		}
		
			// Update is called once per frame
		void Update() {
			if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Home))  
		    {  
		        Application.Quit();  
		    } 
		}
	

		void startPush() {
			AnySDKPush.startPush();
		}

		void closePush() {
			AnySDKPush.closePush();
		}

		void setAlias(string alias) {
			AnySDKPush.setAlias(alias);
		}

		void delAlias(string alias) {
			AnySDKPush.delAlias(alias);
		}

		void setTags(ArrayList tags) {
			AnySDKPush.setTags(tags);
		}

		void delTags(ArrayList tags) {
			AnySDKPush.delTags(tags);
		}

	}
}
