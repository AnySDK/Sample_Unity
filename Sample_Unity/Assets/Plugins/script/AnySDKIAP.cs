using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace anysdk {

	/**
	 * 支付插件
	 */
	public class AnySDKIAP : AnySDKProtocol
	{
		private static AnySDKIAP _instance;
#if UNITY_ANDROID		
		private AndroidJavaClass mAndroidJavaClass;
#endif		
		void Awake()
		{
			GameObject.DontDestroyOnLoad(gameObject);
			registerPluginXActionCallback( this );
		}
		
		void onDestory() {
			unRegisterPluginXActionCallback( this );
		}
		
		private static AnySDKIAP instance() {
			if( null == _instance ) {
				_instance = new AnySDKIAP();
			}
			return _instance;
		}
		
		/**
		 * 支付成功
		 */
		public void onPaySuccess( string msg ) {
			//Todo
		}
	
		/**
		 * 支付失败
		 */
		public void onPayFailed( string msg ) {
			//Todo
		}
		
		/**
		 * 支付取消
		 */
		public void onPayCancel( string msg ) {
			//Todo
		}
		
		/**
		 * 网络错误
		 */
		public void onPayNetworkError( string msg ) {
			//Todo
		}
		
		/**
		 * 支付未完成
		 */
		public void onPayProductionInforIncomplete( string msg ) {
			//Todo
		}
		
		/**
		 * 支付初始化成功
		 */
		public void onPayInitSuccess( string msg ) {
			//Todo
		}
		
		/**
		 * 支付初始化失败
		 */
		public void onPayPayInitFail( string msg ) {
			//Todo
		}

		/**
		 * 支付进行中
		 */
		public void onPayNowPaying( string msg ) {
			//Todo
		}
		
		/**
		 * 未确定的请求会派发到这个接口
		 * @param result
		 */
		public void onPayActionResult( string msg ) {
			//Todo
		}
#if UNITY_ANDROID			
		protected override  AndroidJavaClass getAndroidJavaClass() {
			checkAndCreatePluginXIAPAndroidClass();
			return mAndroidJavaClass;
		}
#endif
		
		/**
		 * 获取订单ID
		 */
		public static String getOrderId() {
			return instance()._getOrderId();
		}
		
		/**
		 * 购买道具
		 */
		public static void payForProduct( Dictionary<string,string> productInfos ) {
			instance()._payForProduct( productInfos );
		}

		/**
		 * 重置支付状态
		 */
		public static void resetPayStatus() {
			instance()._resetPayStatus();
		}
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
		 * 调用渠道sdk中的函数
		 * @param functionName 函数名称
		 */
		public static void callFunction( string functionName ) {
			instance()._callFunction( functionName );
		}
		
		/**
		 * 调用渠道sdk中的函数
		 * @param functionName
		 * @param paramList
		 */
		public static void callFunction( string functionName, ArrayList paramList ) {
			instance()._callFunction( functionName, paramList );
		}
#if UNITY_ANDROID			
		private void checkAndCreatePluginXIAPAndroidClass() {
			if( null == mAndroidJavaClass ) {
				mAndroidJavaClass = new AndroidJavaClass( "com.anysdk.framework.unity.PluginXIAP" );
			}
		}
#endif
		
		
		private string _getOrderId() {
#if UNITY_ANDROID	
			checkAndCreatePluginXIAPAndroidClass();
			return mAndroidJavaClass.CallStatic<string>( "getOrderId", new object[]{}); 
#else
			return "";
#endif
		}
		
		private void _payForProduct( Dictionary<string,string> productInfos ) {
#if UNITY_ANDROID	
			checkAndCreatePluginXIAPAndroidClass();
			AndroidJavaObject jProductInfos = AnySDKUtil.dictionary2JavaMap( productInfos );
			mAndroidJavaClass.CallStatic( "payForProduct", new object[]{jProductInfos}); 
#endif
		}

		private  void _resetPayStatus() {
#if UNITY_ANDROID	
			checkAndCreatePluginXIAPAndroidClass();
			mAndroidJavaClass.CallStatic( "resetPayStatus", new object[]{}); 
#endif
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
	}
}

