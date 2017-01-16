using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace anysdk {
	public class TestRECPlugin : MonoBehaviour {

		private AnySDKREC _instance;

		void Awake()
		{

		}
		void Start()
		{
			_instance = AnySDKREC.getInstance ();
			_instance .setListener (this,"RECExternalCall");
		}
		void RECExternalCall(string msg)
		{
			Debug.Log("RECExternalCall("+ msg+")");
			Dictionary<string,string> dic = AnySDKUtil.stringToDictionary (msg);
			int code = Convert.ToInt32(dic["code"]);
			string result = dic["msg"];
			switch(code)
			{
			case (int)RECResultCode.kRECInitSuccess://初始化成功
				Debug.Log("kRECInitSuccess\n");
				break;
			case (int)RECResultCode.kRECInitFail://初始化失败
				Debug.Log("kRECInitFail\n");
				break;
			case (int)RECResultCode.kRECStartRecording://开始录制
				Debug.Log("kRECStartRecording \n");
				break;
			case (int)RECResultCode.kRECStopRecording://结束录制
				Debug.Log("kRECStopRecording \n");
				break;
			case (int)RECResultCode.kRECPauseRecording://暂停录制
				Debug.Log("kRECPauseRecording \n");
				break;
			case (int)RECResultCode.kRECResumeRecording://恢复录制
				Debug.Log("kRECResumeRecording \n");
				break;
			case (int)RECResultCode.kRECEnterSDKPage://进入SDK页面
				Debug.Log("kRECEnterSDKPage \n");
				break;
			case (int)RECResultCode.kRECQuitSDKPage://退出SDK页面
				Debug.Log("kRECQuitSDKPage \n");
				break;
			case (int)RECResultCode.kRECShareSuccess://视频分享成功
				Debug.Log("kRECShareSuccess \n");
				break;
			case (int)RECResultCode.kRECShareFail://视频分享失败
				Debug.Log("kRECShareFail \n");
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
			if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"startRecording" ))
			{
				string flag = isAvailable()?"is":"is not";
				Debug.Log("The device"+ flag + "supported.");
				startRecording();
			}
			
			if(GUI.Button(new Rect(5, 80, Screen.width - 10, 70),"stopRecording" ))
			{
				stopRecording();
			}
			
			if(GUI.Button(new Rect(5, 155, Screen.width - 10, 70),"share" ))
			{
				
				share();
			}
			
			if(GUI.Button(new Rect(5, 230, Screen.width - 10, 70),"pauseRecording" ))
			{
				string flag = isRecording()?"is":"is not";
				Debug.Log("The video"+ flag + "being recorded.");
				pauseRecording();
			}
			
			
			if(GUI.Button(new Rect(5, 305, Screen.width - 10, 70),"resumeRecording" ))
			{
				resumeRecording();
			}
			
			
			if(GUI.Button(new Rect(5, 380, Screen.width - 10, 70),"showToolBar" ))
			{
				
				showToolBar();
			}

			if(GUI.Button(new Rect(5, 455, Screen.width - 10, 70),"hideToolBar" ))
			{
				hideToolBar();
			}

			if(GUI.Button(new Rect(5, 525, Screen.width - 10, 70),"showVideoCenter" ))
			{
				showVideoCenter();
			}

			if(GUI.Button(new Rect(5, 595, Screen.width - 10, 70),"enterPlatform" ))
			{
				enterPlatform();
			}

			if(GUI.Button(new Rect(5, 665, Screen.width - 10, 70),"setMetaData" ))
			{
				setMetaData();
			}

			if(GUI.Button(new Rect(5, 735, Screen.width - 10, 70),"return" ))
			{
				Destroy (GetComponent ("TestRECPlugin" ));
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
	

		void startRecording() {
			_instance.startRecording();
		}

		void stopRecording() {
			_instance.stopRecording();
		}

		void share() {
			Dictionary<string,string> info = new Dictionary<string, string>();
			info["Video_Title"] = "AnySDK";
			info["Video_Desc"] = "AnySDK是一个神奇的SDK";
			AnySDKREC.getInstance().share(info);
		}

		void pauseRecording() {
			if( _instance.isFunctionSupported( "pauseRecording" ) ) {
				_instance.callFuncWithParam( "pauseRecording" );
			}	
		}

		void resumeRecording() {
			if( _instance.isFunctionSupported( "resumeRecording" ) ) {
				_instance.callFuncWithParam( "resumeRecording" );
			}
		}

		bool isAvailable() {
			if( _instance.isFunctionSupported( "isAvailable" ) ) {
				return _instance.callBoolFuncWithParam( "isAvailable" );
			}
			return false;
		}

		void showToolBar() {
			if( _instance.isFunctionSupported( "showToolBar" ) ) {
				_instance.callFuncWithParam( "showToolBar" );
			}
		}

		void hideToolBar() {
			if( _instance.isFunctionSupported( "hideToolBar" ) ) {
				_instance.callFuncWithParam( "hideToolBar" );
			}
		}

		bool isRecording() {
			if( _instance.isFunctionSupported( "isRecording" ) ) {
				return _instance.callBoolFuncWithParam( "isRecording" );
			}
			return false;
		}

		void showVideoCenter() {
			if( _instance.isFunctionSupported( "showVideoCenter" ) ) {
				_instance.callFuncWithParam( "showVideoCenter" );
			}
		}

		void enterPlatform() {
			if( _instance.isFunctionSupported( "enterPlatform" ) ) {
				_instance.callFuncWithParam( "enterPlatform" );
			}
		}

		void setMetaData() {
			if( _instance.isFunctionSupported( "setMetaData" ) ) {
				Dictionary<string, string> data = new Dictionary<string, string>();
				data["ext"] = "anysdk";
				AnySDKParam param = new AnySDKParam(data);
				_instance.callFuncWithParam( "setMetaData",param );
			}
		}


	}
}
