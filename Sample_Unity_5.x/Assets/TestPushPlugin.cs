using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace anysdk {
	public class TestPushPlugin : MonoBehaviour {

		private AnySDKPush _instance;
		void Awake()
		{
		}
		void Start()
		{
			_instance = AnySDKPush.getInstance ();
			_instance .setListener (this,"PushExternalCall");
		}
		void PushExternalCall(string msg)
		{
			Debug.Log("PushExternalCall("+ msg+")");
			Dictionary<string,string> dic = AnySDKUtil.stringToDictionary (msg);
			int code = Convert.ToInt32(dic["code"]);
			string result = dic["msg"];
			switch(code)
			{
			case (int)PushActionResultCode.kPushReceiveMessage://Push接受到消息回调
				break;
			default:
				break;
			}
		}
		void OnDestroy() {
			
		}
		
		void OnGUI()
		{	
			GUI.color = Color.white;
			
			GUI.skin.button.fontSize = 30;
			if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"startPush" ))
			{
				startPush();
			}
			
			if(GUI.Button(new Rect(5, 80, Screen.width - 10, 70),"closePush" ))
			{
				closePush();
			}
			
			if(GUI.Button(new Rect(5, 155, Screen.width - 10, 70),"setAlias" ))
			{
				
				setAlias("AnySDK");
			}
			
			if(GUI.Button(new Rect(5, 230, Screen.width - 10, 70),"delAlias" ))
			{
				
				delAlias("AnySDK");
			}
			
			
			if(GUI.Button(new Rect(5, 305, Screen.width - 10, 70),"setTags" ))
			{
				List<string> tags = new List<string>();
				tags.Add("easy");
				tags.Add("fast");
				setTags(tags);
				
			}
			
			
			if(GUI.Button(new Rect(5, 380, Screen.width - 10, 70),"delTags" ))
			{
				
				List<string> tags = new List<string>();
				tags.Add("easy");
				tags.Add("fast");
				delTags(tags);
			}

			if(GUI.Button(new Rect(5, 455, Screen.width - 10, 70),"return" ))
			{
				Destroy (GetComponent ("TestPushPlugin" ));
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
	

		void startPush() {
			AnySDKPush.getInstance().startPush();
		}

		void closePush() {
			AnySDKPush.getInstance().closePush();
		}

		void setAlias(string alias) {
			AnySDKPush.getInstance().setAlias(alias);
		}

		void delAlias(string alias) {
			AnySDKPush.getInstance().delAlias(alias);
		}

		void setTags(List<string> tags) {
			AnySDKPush.getInstance().setTags(tags);
		}

		void delTags(List<string> tags) {
			AnySDKPush.getInstance().delTags(tags);
		}

	}
}
