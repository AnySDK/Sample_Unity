using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using System;
namespace anysdk {
	public class TestUserPlugin : MonoBehaviour {

		private AnySDKUser _instance;
		void Awake()
		{

		}

		void Start()
		{

			_instance = AnySDKUser.getInstance ();
			_instance.setListener (this,"UserExternalCall");
		}

		void UserExternalCall(string msg)
		{
			Debug.Log("UserExternalCall("+ msg+")");
			Dictionary<string,string> dic = AnySDKUtil.stringToDictionary (msg);
			int code = Convert.ToInt32(dic["code"]);
			string result = dic["msg"];
			switch(code)
			{
			case (int)UserActionResultCode.kInitSuccess://初始化SDK成功回调
				break;
			case (int)UserActionResultCode.kInitFail://初始化SDK失败回调
				break;
			case (int)UserActionResultCode.kLoginSuccess://登陆成功回调
				break;
			case (int)UserActionResultCode.kLoginNetworkError://登陆失败回调
			case (int)UserActionResultCode.kLoginCancel://登陆取消回调
			case (int)UserActionResultCode.kLoginFail://登陆失败回调
				break;
			case (int)UserActionResultCode.kLogoutSuccess://登出成功回调
				break;
			case (int)UserActionResultCode.kLogoutFail://登出失败回调
				break;
			case (int)UserActionResultCode.kPlatformEnter://平台中心进入回调
				break;
			case (int)UserActionResultCode.kPlatformBack://平台中心退出回调
				break;
			case (int)UserActionResultCode.kPausePage://暂停界面回调
				break;
			case (int)UserActionResultCode.kExitPage://退出游戏回调
				break;
			case (int)UserActionResultCode.kAntiAddictionQuery://防沉迷查询回调
				break;
			case (int)UserActionResultCode.kRealNameRegister://实名注册回调
				break;
			case (int)UserActionResultCode.kAccountSwitchSuccess://切换账号成功回调
				break;
			case (int)UserActionResultCode.kAccountSwitchFail://切换账号成功回调
				break;
			case (int)UserActionResultCode.kOpenShop://应用汇  悬浮窗点击粮饷按钮回调
				break;
			default:
				break;
			}
		}
		
		void OnDestroy() {
			
		}
		
		void OnGUI()
		{	GUI.color = Color.white;

			GUI.skin.button.fontSize = 30;
			if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"Login" ))
			{

				login();
			}

			if (GUI.Button (new Rect (5, 80 , Screen.width - 10, 70), "logout")) 
			{
				logout ();
			}

			if (GUI.Button (new Rect (5, 155, Screen.width - 10, 70), "enterPlatform")) 
			{
				enterPlatform ();

			}


			if (GUI.Button (new Rect (5, 230, Screen.width - 10, 70), "showToolBar"))
			{
				showToolBar (ToolBarPlace.kToolBarBottomLeft);
			}

			if (GUI.Button (new Rect (5, 305, Screen.width - 10, 70), "hideToolBar")) 
			{
				hideToolBar ();
			}

			if (GUI.Button (new Rect (5, 380, Screen.width - 10, 70), "accountSwitch")) 
			{
				accountSwitch ();
			}

			if (GUI.Button (new Rect (5, 455, Screen.width - 10, 70), "antiAddictionQuery")) 
			{
				antiAddictionQuery ();
			}

			if (GUI.Button (new Rect (5, 530, Screen.width - 10, 70), "realNameRegister")) 
			{
				realNameRegister ();
			}



			if (GUI.Button (new Rect (5, 605, Screen.width - 10, 70), "submitLoginAnySDKRole"))
			{
				submitLoginAnySDKRole ();
			}

			if(GUI.Button(new Rect(5, 680, Screen.width - 10, 70),"return" ))
			{
				Destroy (GetComponent ("TestUserPlugin" ));
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
		 * 登录
		 */
		void login() {
			_instance.login();
		}
		
		/**
		 * 注销
		 */
		void logout() {
			if( _instance.isFunctionSupported( "logout" ) ) {
				_instance.callFuncWithParam( "logout" );
			}
		}
		
		/**
		 * 进入平台
		 */
		void enterPlatform() {
			if( _instance.isFunctionSupported( "enterPlatform" ) ) {
				_instance.callFuncWithParam( "enterPlatform" );
			}
		}
		
		/**
		 * 显示Toolbar
		 */
		void showToolBar(ToolBarPlace align ) {
			if( _instance.isFunctionSupported( "showToolBar" ) ) {
				AnySDKParam param = new AnySDKParam((int)align);
				_instance.callFuncWithParam( "showToolBar", param );
			}
		}
		
		/**
		 * 隐藏Toolbar
		 */
		void hideToolBar() {
			if( _instance.isFunctionSupported( "hideToolBar" ) ) {
				_instance.callFuncWithParam( "hideToolBar" );
			}
		}
		
		/**
		 * 切换账号
		 */
		void accountSwitch() {
			if( _instance.isFunctionSupported( "accountSwitch" ) ) {
				_instance.callFuncWithParam( "accountSwitch" );
			}
		}
		
		/**
		 * 防沉迷查询
		 */
		void antiAddictionQuery() {
			if( _instance.isFunctionSupported( "antiAddictionQuery" ) ) {
				_instance.callFuncWithParam( "antiAddictionQuery" );
			}	
		}
		
		/**
		 * 实名注册
		 */
		void realNameRegister() {
			if( _instance.isFunctionSupported( "realNameRegister" ) ) {
				_instance.callFuncWithParam( "realNameRegister" );
			}	
		}
	
		/**
		 * 把游戏数据传递到SDK服务端
		 */
		void submitLoginAnySDKRole() {
			if( _instance.isFunctionSupported( "submitLoginGameRole" ) ) {
				Dictionary<string, string> userInfo = new Dictionary<string, string>();
				userInfo["roleId"] = "123456";
				userInfo["roleName"] = "test";
				userInfo["roleLevel"] = "10";
				userInfo["zoneId"] = "123";
				userInfo["zoneName"] = "test";
                userInfo["dataType"] = "1";
                userInfo["ext"] = "login";
				AnySDKParam param = new AnySDKParam(userInfo);
				_instance.callFuncWithParam( "submitLoginGameRole", param );
			}	
		}
	}
}
