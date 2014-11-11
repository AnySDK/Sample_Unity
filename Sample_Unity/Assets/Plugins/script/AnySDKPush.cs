using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace anysdk {
	/**
	 * 用户系统插件
	 * 提供登录、调用渠道SDK内部函数等功能
	 */
	public class AnySDKPush : AnySDKProtocol {
			
		private static AnySDKPush _instance;
#if UNITY_ANDROID		
		private AndroidJavaClass mAndroidJavaClass;
#endif		
		private static AnySDKPush instance() {
			if( null == _instance ) {
				_instance = new AnySDKPush();
			}
			return _instance;
		}
		
		void Awake()
		{
			GameObject.DontDestroyOnLoad(gameObject);
			AnySDKPush.registerPluginXActionCallback( this );

		}
		
		void onDestory() {
			AnySDKPush.unRegisterPluginXActionCallback( this );
		}
			
		/**
		 * the callback of receiving the message
		 * @param msg message
		 */
		public void onPushReceiveMessage( string msg ) {
			//Todo		
		}

		

		
		/**
		 * 未确定的通知会派发到这个接口
		 * @param result
		 */
		public void onPushActionResult( string result ) {
			//Todo			
		}
#if UNITY_ANDROID		
		protected override  AndroidJavaClass getAndroidJavaClass() {
			checkAndCreatePluginXPushAndroidClass();
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
	 	* 
		* @Title: startPush 
		* @Description: TODO start/register  Push services
		* @param      
		* @return void   
		* @throws
		 */
		public static void startPush(){
			instance()._startPush();
		}
			
		/**
     	* 
   		* @Title: closePush 
    	* @Description: TODO close Push services
   		* @param      
    	* @return void   
   	 	* @throws
     	*/
		public static void closePush() {
			instance()._closePush();
		}

		/**
     	* 
    	* @Title: setAlias 
    	* @Description: TODO set alias
    	* @param @param alias     
    	* @return void   
    	 @throws
     	*/
		public  static void setAlias(String alias){
			instance()._setAlias(alias);
		}

		
		/**
	     * 
	    * @Title: delAlias 
	    * @Description: TODO delete the alias
	    * @param @param alias     
	    * @return void   
	    * @throws
	     */
		public static void delAlias(String alias){
			instance()._delAlias(alias);
		}
	
		/**
	     * 
	    * @Title: setTag 
	    * @Description: TODO set tags
	    * @param @param tags     
	    * @return void   
	    * @throws
	     */
		public static void setTags(ArrayList tags){
			instance()._setTags(tags);
		}
		
		/**
	     * 
	    * @Title: delTag 
	    * @Description: TODO delete the tag
	    * @param  @param tags    
	    * @return void   
	    * @throws
	     */
		public static void delTags(ArrayList tags){
			instance()._delTags(tags);
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
		
		private void _startPush() {
#if UNITY_ANDROID
			checkAndCreatePluginXPushAndroidClass();
			mAndroidJavaClass.CallStatic( "startPush", new object[]{}); 
#endif
		}

		private void _closePush() {
#if UNITY_ANDROID
			checkAndCreatePluginXPushAndroidClass();
			mAndroidJavaClass.CallStatic( "closePush", new object[]{}); 
#endif
		}

		private void _setAlias(string alias) {
#if UNITY_ANDROID
			checkAndCreatePluginXPushAndroidClass();
			mAndroidJavaClass.CallStatic( "setAlias", new object[]{alias}); 
#endif
		}

		private void _delAlias(string alias) {
			#if UNITY_ANDROID
			checkAndCreatePluginXPushAndroidClass();
			mAndroidJavaClass.CallStatic( "delAlias", new object[]{alias}); 
			#endif
		}

		private void _setTags(ArrayList tags) {
#if UNITY_ANDROID	
			checkAndCreatePluginXPushAndroidClass();
			AndroidJavaObject jTags = AnySDKUtil.arrayList2JavaArrayList(tags);
			mAndroidJavaClass.CallStatic( "setTags", new object[]{jTags}); 
#endif
		}

		private void _delTags(ArrayList tags) {
#if UNITY_ANDROID	
			checkAndCreatePluginXPushAndroidClass();
			AndroidJavaObject jTags = AnySDKUtil.arrayList2JavaArrayList(tags);
			mAndroidJavaClass.CallStatic( "delTags", new object[]{jTags}); 
#endif
		}
		
		private void checkAndCreatePluginXPushAndroidClass() {
#if UNITY_ANDROID
			if( null == mAndroidJavaClass ) {
				mAndroidJavaClass = new AndroidJavaClass( "com.anysdk.framework.unity.PluginXPush" );
			}
#endif
		}
	}
}
