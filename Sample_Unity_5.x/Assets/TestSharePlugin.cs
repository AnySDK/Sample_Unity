using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace anysdk {
	public class TestSharePlugin : MonoBehaviour {

		private AnySDKShare _instance;
		void Awake()
		{

		}
		void Start()
		{
			_instance = AnySDKShare.getInstance ();
			_instance.setListener (this,"ShareExternalCall");
		}
		void ShareExternalCall(string msg)
		{
			Debug.Log("ShareExternalCall("+ msg+")");
			Dictionary<string,string> dic = AnySDKUtil.stringToDictionary (msg);
			int code = Convert.ToInt32(dic["code"]);
			string result = dic["msg"];
			switch(code)
			{
			case (int)ShareResultCode.kShareSuccess://分享成功回调
				break;
			case (int)ShareResultCode.kShareFail://分享失败回调
				break;
			case (int)ShareResultCode.kShareCancel://分享取消回调
				break;
			case (int)ShareResultCode.kShareNetworkError://分享网络出错回调
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
			if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"Share" ))
			{
				share();
			}
			if(GUI.Button(new Rect(5, 80, Screen.width - 10, 70),"return" ))
			{
				Destroy (GetComponent ("TestSharePlugin" ));
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
	
		/**
		 * 分享
		 */
		void share() {
			Dictionary<string,string> info = new Dictionary<string, string>();
			info["title"] = "AnySDK是一个神奇的SDK";
			info["titleUrl"] = "http://www.AnySDK.cn";
			info["site"] = "AnySDK";
			info["siteUrl"] = "http://www.AnySDK.cn";
			info["text"] = "一次集成，多渠道发布";
        	info["comment"] = "无";
			_instance.share (info);	
		}
	}
}
