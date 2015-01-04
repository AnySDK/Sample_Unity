using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using System.Text;

namespace anysdk
{

	public class AnySDK
	{
		private static AnySDK _instance;
		
		public static AnySDK getInstance() {
			if( null == _instance ) {
				_instance = new AnySDK();
			}
			return _instance;
		}

		/**
   		 @breif the init of AgentManager
   		 @param the appKey of anysdk
    	 @param the appSecret of anysdk
   		 @param the privateKey of anysdk
    	 @param the url of oauthLoginServer
   		 @warning Must invoke this interface before loadALLPlugin
  		*/

		public  void init(string appKey, string appSecret, string privateKey, string authLoginServer)
		{
			AnySDK_nativeInitPluginSystem (appKey, appSecret, privateKey, authLoginServer);
		}

		/**
    	 @brief Get channel ID
     	@return  return value is channel ID.
     	*/

		public  void loadALLPlugin()
		{
			AnySDK_nativeLoadPlugins ();
		}

		/**
    	 @brief Get custom param
     	@return  return value is custom param for channel.
    	 */

		public  string getCustomParam()
		{
			StringBuilder customParam = new StringBuilder();
			AnySDK_nativeGetCustomParam (customParam);
			return customParam.ToString();
		}

		public  string getChannelId()
		{
			StringBuilder channelId = new StringBuilder();
			AnySDK_nativeGetChannelId (channelId);
			return channelId.ToString();
		}

		/**
     		@brief release the anysdk
     	*/

		public  void release()
		{
			AnySDK_nativeRelease ();
		}

		/**
		 * 
		* @Title: isUserPluginExist 
		* @Description: is UserPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isUserPluginExist()
		{
			return AnySDK_nativeIsUserPluginExist ();
		}

		/**
		 * 
		* @Title: isIAPPluginExist 
		* @Description: is IAPPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isIAPPluginExist()
		{
			return AnySDK_nativeIsIAPPluginExist ();
		}

		/**
		 * 
		* @Title: isAdsPluginExist 
		* @Description: is AdsPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isAdsPluginExist()
		{
			return AnySDK_nativeIsAdsPluginExist ();
		}

		/**
		 * 
		* @Title: isAnalyticsPluginExist 
		* @Description: is AnalyticsPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isAnalyticsPluginExist()
		{
			return AnySDK_nativeIsAnalyticsPluginExist ();
		}

		/**
		 * 
		* @Title: isPushPluginExist 
		* @Description: is PushPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isPushPluginExist()
		{
			return AnySDK_nativeIsPushPluginExist ();
		}

		/**
		 * 
		* @Title: isSharePluginExist 
		* @Description: is SharePlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isSharePluginExist()
		{
			return AnySDK_nativeIsSharePluginExist ();
		}

		/**
		 * 
		* @Title: isSocialPluginExist 
		* @Description: is SocialPlugin Exist 
		* @param @return   true or false     
		* @return boolean   
	 	*/

		public bool isSocialPluginExist()
		{
			return AnySDK_nativeIsSocialPluginExist ();
		}

		/**
	 	* 
		* @Title: setIsAnaylticsEnabled 
		* @Description: choose to open or close
		* @param @param enabled    true or false  
		* @return void   
	 	*/

		public void setIsAnaylticsEnabled(bool enabled)
		{
			AnySDK_nativeSetIsAnaylticsEnabled (enabled);
		}

		/**
		 * 
		* @Title: isAnaylticsEnabled 
		* @Description: the status of Anayltics
		* @param @return    true or false    
		* @return boolean   
		 */

		public bool isAnaylticsEnabled()
		{
			return AnySDK_nativeIsAnaylticsEnabled ();
		}

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDK_nativeInitPluginSystem(string appKey, string appSecret, string privateKey, string authLoginServer);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDK_nativeLoadPlugins();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDK_nativeGetChannelId(StringBuilder channelId);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDK_nativeGetCustomParam(StringBuilder customParam);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDK_nativeRelease();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDK_nativeIsUserPluginExist();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDK_nativeIsIAPPluginExist();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDK_nativeIsAdsPluginExist();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDK_nativeIsAnalyticsPluginExist();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDK_nativeIsSharePluginExist();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDK_nativeIsSocialPluginExist();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDK_nativeIsPushPluginExist();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDK_nativeSetIsAnaylticsEnabled(bool enabled);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDK_nativeIsAnaylticsEnabled();

	}
}

