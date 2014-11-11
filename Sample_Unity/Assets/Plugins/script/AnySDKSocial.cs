using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace anysdk {
	/**
	 * 社交插件
	 */
	public class AnySDKSocial : AnySDKProtocol
	{
		private static AnySDKSocial _instance;
#if UNITY_ANDROID		
		private AndroidJavaClass mAndroidJavaClass;
#endif
		
		private static AnySDKSocial instance() {
			if( null == _instance ) {
				_instance = new AnySDKSocial();
			}
			return _instance;
		}
		
		void Awake()
		{
			GameObject.DontDestroyOnLoad(gameObject);
			AnySDKSocial.registerPluginXActionCallback( this );
		}
		
		void onDestory() {
			AnySDKSocial.unRegisterPluginXActionCallback( this );
		}
		
		/**
		 * 提交成功
		 */
		public void onScoreSubmitSuccess( string msg ) {
			//Todo
		}
		
		/**
		 * 提交失败
		 */
		public void onScoreSubmitFailed( string msg ) {
			//Todo
		}
		
		/**
		 * 成就点开启成功
		 */
		public void onAchUnlockSuccess( string msg ) {
			//Todo
		}
		
		/**
		 * 成就点开启失败
		 */
		public void onAchUnlockFailed( string msg ) {
			//Todo
		}
		
		/**
		 * 未确定的通知会派发到这个接口
		 * @param result
		 */
		public void onSocialActionResult( string msg ) {
			//Todo
		}
#if UNITY_ANDROID			
		protected override  AndroidJavaClass getAndroidJavaClass() {
			checkAndCreatePluginXSocialAndroidClass();
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
		 * 提交分数
		 */ 
		public static void submitScore( string leadboardId, long score ) {
			instance()._submitScore( leadboardId, score );
		}
		
		/**
		 * 显示积分牌
		 * @param leadboardId
		 */ 
		public static void showLeaderboard( string leadboardId ) {
			instance()._showLeaderboard( leadboardId );
		}
		
		/**
		 * 显示积分牌
		 */ 
		public static void showAchievements() {
			instance()._showAchievements();
		}
		
		/**
		 * 显示积分牌
		 * @param achInfo
		 */ 
		public static void unlockAchievement(  Dictionary<string, string> achInfo ) {
			instance()._unlockAchievement( achInfo );
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
		
		private void _submitScore( string leadboardId, long score ) {
#if UNITY_ANDROID	
			checkAndCreatePluginXSocialAndroidClass();
			mAndroidJavaClass.CallStatic( "submitScore", new object[]{leadboardId,score}); 
#endif
		}
		
		private void _showLeaderboard( string leadboardId ) {
#if UNITY_ANDROID
			checkAndCreatePluginXSocialAndroidClass();
			mAndroidJavaClass.CallStatic( "showLeaderboard", new object[]{leadboardId}); 
#endif
		}
		
		private void _showAchievements() {
#if UNITY_ANDROID
			checkAndCreatePluginXSocialAndroidClass();
			mAndroidJavaClass.CallStatic( "showAchievements", new object[]{}); 
#endif
		}
		
		private void _unlockAchievement( Dictionary<string, string> achInfo ) {
#if UNITY_ANDROID
			checkAndCreatePluginXSocialAndroidClass();
			AndroidJavaObject jcObject = AnySDKUtil.dictionary2JavaMap( achInfo );
			mAndroidJavaClass.CallStatic( "unlockAchievement", new object[]{jcObject}); 
#endif
		}
		
		private void checkAndCreatePluginXSocialAndroidClass() {
#if UNITY_ANDROID
			if( null == mAndroidJavaClass ) {
				mAndroidJavaClass = new AndroidJavaClass( "com.anysdk.framework.unity.PluginXSocial" );
			}
#endif
		}	
	}
}

