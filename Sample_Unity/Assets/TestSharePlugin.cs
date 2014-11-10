using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace anysdk {
	public class TestSharePlugin : MonoBehaviour {
	
		
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
			
			//share
			if(GUI.Button(new Rect(100,100,Screen.width - 200,80),"share" ))
			{
				Application.LoadLevel("anySDK");
				//share();
			}
			
		}
		
			// Update is called once per frame
		void Update() {
			if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Home))  
		    {  
		        Application.Quit();  
		    } 
		}
	
		/**
		 * 分享
		 */
		void share() {
			Dictionary<string,string> info = new Dictionary<string, string>();
			info["title"] = "AnySDK是一个神奇的SDK";
			info["titleUrl"] = "http://www.anysdk.cn";
			info["site"] = "AnySDK";
			info["siteUrl"] = "http://www.anysdk.cn";
			info["text"] = "一次集成，多渠道发布";
        	info["comment"] = "无";
			AnySDKShare.share( info ); 	
		}
	}
}
