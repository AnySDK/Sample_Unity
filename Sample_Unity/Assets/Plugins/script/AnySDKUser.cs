using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace anysdk {
	/**
	 * 用户系统插件
	 * 提供登录、调用渠道SDK内部函数等功能
	 */
	public class AnySDKUser : AnySDKProtocol {
			
		private static AnySDKUser _instance;
#if UNITY_ANDROID		
		private AndroidJavaClass mAndroidJavaClass;
#endif		
		private static AnySDKUser instance() {
			if( null == _instance ) {
				_instance = new AnySDKUser();
			}
			return _instance;
		}
		
		void Awake()
		{
			GameObject.DontDestroyOnLoad(gameObject);
			AnySDKUser.registerPluginXActionCallback( this );
		}
		
		void onDestory() {
			AnySDKUser.unRegisterPluginXActionCallback( this );
		}
			
		/**
		 * 初始化成功的回调
		 * @param msg 消息内容
		 */
		public void onUserPluginXInitSuccess( string msg ) {
			//Todo		
		}
		
		/**
		 * 初始化失败
		 * @param msg 消息内容
		 */
		public void onUserPluginXInitFailed( string msg ) {
			//Todo
		}
		
		/**
		 * 登录成功的回调
		 * @param msg 消息内容
		 */
		public void onUserLoginSuccess( string msg ) {
			//Todo
			Debug.Log (getUserID ());
		}
		
		/**
		 * 无法访问网络的回调
		 * @param msg 消息内容
		 */
		public void onUserLoginNetworkError( string msg ) {
			//Todo
		}
		
		/**
		 * 登录失败，无需再次登录等回调
		 * @param msg 消息内容
		 */
		public void onUserLoginNoNeed( string msg ) {
			//Todo
		}
		
		/**
		 * 登录失败的回调
		 * @param msg 消息内容
		 */
		public void onUserLoginFailed( string msg ) {
			//Todo
		}
		
		/**
		 * 用户取消登录的回调
		 * @param msg 消息内容
		 */
		public void onUserLoginCancel( string msg ) {
			//Todo
		}
		
		/**
		 * 用户注销成功的回调
		 * @param msg 消息内容
		 */
		public void onUserLogoutSuccess( string msg ) {
			//Todo
		}
		
		/**
		 * 用户注销失败的回调
		 */
		public void onUserLogoutFailed( string msg ) {
			//Todo
		}
		
		/**
		 * 用户进入平台的回调
		 * @param msg 消息内容
		 */
		public void onUserPlatformEnter( string msg ) {
			//Todo
		}
		
		/**
		 * 用户从平台返回的回调
		 * @param msg 消息内容
		 */
		public void onUserPlatformBack( string msg ) {
			//Todo
		}
		
		/**
		 * 暂停页面的回调
		 */
		public void onUserPausePage( string msg ) {
			//Todo	
		}
		
		/**
		 * 页面退出的回调
		 * @param msg 消息内容
		 */
		public void onUserExitPage( string msg ) {
			//Todo				
		}
		
		/**
		 * xxx
		 * @param msg 消息内容
		 */
		public void onUserAntiAddictionQuery( string msg ) {
			//Todo					
		}
		
		/**
		 * 实名注册的回调
		 * @param msg 消息内容
		 */
		public void onUserRealnameRegister( string msg ) {
			//Todo		
		}
		
		/**
		 * 账号切换成功的回调
		 * @param msg 消息内容
		 */
		public void onUserAccountSwitchSuccess( string msg ) {
			//Todo		
		}
		
		/**
		 * 账号切换失败的回调
		 * @param msg 消息内容
		 */
		public void onUserAccountSwitchFail( string msg ) {
			//Todo		
		}
		
		/**
		 * 未确定的通知会派发到这个接口
		 * @param result
		 */
		public void onUserActionResult( string result ) {
			//Todo			
		}
#if UNITY_ANDROID		
		protected override  AndroidJavaClass getAndroidJavaClass() {
			checkAndCreatePluginXUserAndroidClass();
			return mAndroidJavaClass;
		}
#endif
		
		/**
		 * 获取插件名称
		 */
		public static string getPluginName() {
			return instance()._getPluginName();
		}
		
		/**
		 * 获取插件版本号
		 */
		public static string getPluginVersion() {
			return instance()._getPluginVersion();
		}
		
		/**
		 * 获取Sdk 版本号
		 */
		public static string getSDKVersion() {
			return instance()._getSDKVersion();
		}
		
		
		/**
		 * set debugmode for plugin
		 */
		public static void setDebugMode(bool bDebug) {
			instance()._setDebugMode(bDebug);
		}

		/**
		 * 登录
		 */
		public static void login() {
			instance()._login();
		}

		/**
		 * 登录
		 */
		public static void login(string serverID, string serverIP = "") {
			instance()._login(serverID,serverIP);
		}
	


		/**
		 * id
		 */
		public static string getUserID() {
			return instance()._getUserID();
		}
			
		/**
		 * 确定是否支持某功能
		 * @param functionName
		 * @return true 支持  false 不支持
		 */
		public static bool isFunctionSupported( string functionName ) {
			return instance()._isFunctionSupported( functionName );
		}
		
		/**
		 * 调用sdk中的函数
		 * @param functionName 函数名称
		 */
		public static void callFunction( string functionName ) {
			instance()._callFunction( functionName );
		}
		
		/**
		 * Call sdk function
		 * @param functionName
		 * @param paramList
		 */
		public static void callFunction( string functionName, ArrayList paramList ) {
			instance()._callFunction( functionName, paramList );
		}
		
		/**
		 * Call sdk function
		 * @param functionName
		 * @param datas
		 */
		public static void callFunction( string functionName, Dictionary<string, string> datas ) {
			instance()._callFunction( functionName, datas );
		}
		
		/**
		 * 注册Action回调接口
		 * 注：callback 必须实现PluginXActionCallback 接口
		 */
		static void registerPluginXActionCallback( MonoBehaviour callback ) {
			instance()._registerPluginXActionCallback( callback );
		}
		
		/**
		 * 去掉注册的action回调接口
		 */
		static void unRegisterPluginXActionCallback( MonoBehaviour callback ) {
			instance()._unRegisterPluginXActionCallback( callback );
		}
		
		private void _login(string serverID, string serverIP = "") {

#if UNITY_ANDROID
			checkAndCreatePluginXUserAndroidClass();
			mAndroidJavaClass.CallStatic( "login", new object[]{serverID,serverIP}); 
#endif
		}

		private void _login() {
#if UNITY_ANDROID
			checkAndCreatePluginXUserAndroidClass();
			mAndroidJavaClass.CallStatic( "login", new object[]{}); 
#endif
		}

		private string _getUserID() {
#if UNITY_ANDROID
			checkAndCreatePluginXUserAndroidClass();
			return mAndroidJavaClass.CallStatic<string>( "getUserID", new object[]{}); 
#else
			return "";
#endif
		}
		
		private void checkAndCreatePluginXUserAndroidClass() {
#if UNITY_ANDROID
			if( null == mAndroidJavaClass ) {
				mAndroidJavaClass = new AndroidJavaClass( "com.anysdk.framework.unity.PluginXUser" );
			}
#endif
		}
	}
}
