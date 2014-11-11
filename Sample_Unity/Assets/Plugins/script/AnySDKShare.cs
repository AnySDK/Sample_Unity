using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace anysdk {
	/**
	 * 分享插件
	 */
	public class AnySDKShare : AnySDKProtocol
	{
		private static AnySDKShare _instance;
#if UNITY_ANDROID			
		private AndroidJavaClass mAndroidJavaClass;
#endif		
		private static AnySDKShare instance() {
			if( null == _instance ) {
				_instance = new AnySDKShare();
			}
			return _instance;
		}	
		
		void Awake()
		{
			GameObject.DontDestroyOnLoad(gameObject);
			AnySDKShare.registerPluginXActionCallback( this );
		}
		
		void onDestory() {
			AnySDKShare.unRegisterPluginXActionCallback( this );
		}
		
		/**
		 * 分享成功
		 */
		public void onShareSuccess( string msg ) {
			//Todo
		}
	
		/**
		 * 分享失败
		 */
		public void onShareFailed( string msg ) {
			//Todo
		}
		
		/**
		 * 分享被取消
		 */
		public void onShareCancel( string msg ) {
			//Todo
		}
		
		/**
		 * 网络错误
		 */
		public void onShareNetworkError( string msg ) {
			//Todo
		}
		
		/**
		 * 未确定的请求会派发到这个接口
		 * @param result
		 */
		public void onShareActionResult( string msg ) {
			//Todo
		}
#if UNITY_ANDROID		
		protected override  AndroidJavaClass getAndroidJavaClass() {
			checkAndCreatePluginXShareAndroidClass();
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
		 * 分享
		 * @param infos 
		 */
		public static void share( Dictionary<string, string> infos ) {
			instance()._share( infos );
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
		
		
		private void checkAndCreatePluginXShareAndroidClass() {
#if UNITY_ANDROID
			if( null == mAndroidJavaClass ) {
				mAndroidJavaClass = new AndroidJavaClass( "com.anysdk.framework.unity.PluginXShare" );
			}
#endif
		}
		
		private void _share( Dictionary<string, string> infos ) {
#if UNITY_ANDROID
			checkAndCreatePluginXShareAndroidClass();
			AndroidJavaObject jcObject = AnySDKUtil.dictionary2JavaMap( infos );
			mAndroidJavaClass.CallStatic( "share", new object[]{jcObject}); 
#endif
		}
	}
}
