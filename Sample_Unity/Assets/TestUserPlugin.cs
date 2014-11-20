using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace anysdk {
	public class TestUserPlugin : MonoBehaviour {
	
		
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
			//Login
			if(GUI.Button(new Rect(100,10,Screen.width - 200,80),"login" ))
			{
				login();
			}
			
			//Logout
			if(GUI.Button(new Rect(100,110,Screen.width - 200,80),"logout" ))
			{
				logout();
			}
			
			//Logout
			if(GUI.Button(new Rect(100,210,Screen.width - 200,80),"enterPlatform" ))
			{
				enterPlatform();
			}
			
			//ShowToolBar
			if(GUI.Button(new Rect(100,310,Screen.width - 200,80),"showToolBar" ))
			{
				showToolBar(AnySDKToolBarPlaceEnum.kToolBarTopBottomLeft);
			}
			
			//HideToolBar
			if(GUI.Button(new Rect(100,410,Screen.width - 200,80),"hideToolBar" ))
			{
				hideToolBar();
			}
			
			//AccountSwitch
			if(GUI.Button(new Rect(100,510,Screen.width - 200,80),"accountSwitch" ))
			{
				accountSwitch();
			}
			
			//RealNameRegister
			if(GUI.Button(new Rect(100,610,Screen.width - 200,80),"realNameRegister" ))
			{
				realNameRegister();
			}

			//RealNameRegister
			if(GUI.Button(new Rect(100,710,Screen.width - 200,80),"submitLoginGameRole" ))
			{
				submitLoginGameRole();
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
		 * 登录
		 */
		void login() {
			AnySDKUser.login("1");
		}
		
		/**
		 * 注销
		 */
		void logout() {
			if( AnySDKUser.isFunctionSupported( "logout" ) ) {
				AnySDKUser.callFunction( "logout" );
			}
		}
		
		/**
		 * 进入平台
		 */
		void enterPlatform() {
			if( AnySDKUser.isFunctionSupported( "enterPlatform" ) ) {
				AnySDKUser.callFunction( "enterPlatform" );
			}
		}
		
		/**
		 * 显示Toolbar
		 */
		void showToolBar( AnySDKToolBarPlaceEnum align ) {
			if( AnySDKUser.isFunctionSupported( "showToolBar" ) ) {
				ArrayList list = new ArrayList();
				list.Add( (int)align );
				AnySDKUser.callFunction( "showToolBar", list );
			}
		}
		
		/**
		 * 隐藏Toolbar
		 */
		void hideToolBar() {
			if( AnySDKUser.isFunctionSupported( "hideToolBar" ) ) {
				AnySDKUser.callFunction( "hideToolBar" );
			}
		}
		
		/**
		 * 切换账号
		 */
		void accountSwitch() {
			if( AnySDKUser.isFunctionSupported( "accountSwitch" ) ) {
				AnySDKUser.callFunction( "accountSwitch" );
			}
		}
		
		/**
		 * 游戏退出界面
		 * 游戏退出时调用该函数
		 */
		void exit() {
			if( AnySDKUser.isFunctionSupported( "exit" ) ) {
				AnySDKUser.callFunction( "exit" );
			}
		}
		
		/**
		 * 暂停界面
		 * 游戏暂停时调用该函数。
		 */
		void pause() {
			if( AnySDKUser.isFunctionSupported( "pause" ) ) {
				AnySDKUser.callFunction( "pause" );
			}	
		}
		
		/**
		 * 释放资源
		 */
		void destory() {
			if( AnySDKUser.isFunctionSupported( "destroy" ) ) {
				AnySDKUser.callFunction( "destroy" );
			}	
		}
		
		/**
		 * 防沉迷查询
		 */
		void antiAddictionQuery() {
			if( AnySDKUser.isFunctionSupported( "antiAddictionQuery" ) ) {
				AnySDKUser.callFunction( "antiAddictionQuery" );
			}	
		}
		
		/**
		 * 实名注册
		 */
		void realNameRegister() {
			if( AnySDKUser.isFunctionSupported( "realNameRegister" ) ) {
				AnySDKUser.callFunction( "realNameRegister" );
			}	
		}
	
		/**
		 * 把游戏数据传递到SDK服务端
		 */
		void submitLoginGameRole() {
			if( AnySDKUser.isFunctionSupported( "submitLoginGameRole" ) ) {
				Dictionary<string, string> userInfo = new Dictionary<string, string>();
				userInfo["roleId"] = "123456";
				userInfo["roleName"] = "test";
				userInfo["roleLevel"] = "10";
				userInfo["zoneId"] = "123";
				userInfo["zoneName"] = "test";
                userInfo["dataType"] = "1";
                userInfo["ext"] = "login";
				AnySDKUser.callFunction( "submitLoginGameRole", userInfo );
			}	
		}
	}
}
