using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace anysdk {
	public enum AdsResultCode
	{
		kAdsReceived = 0,           /**< enum the callback: the ad is received is at center. */
		
		kAdsShown,                  /**< enum the callback: the advertisement dismissed. */
		kAdsDismissed,             /**< enum the callback: the advertisement dismissed. */
		
		kPointsSpendSucceed,       /**< enum the callback: the points spend succeed. */
		kPointsSpendFailed,        /**< enum the callback: the points spend failed. */
		
		
		
		kNetworkError,              /**< enum the callback of Network error at center. */
		kUnknownError,              /**< enum the callback of Unknown error. */
		kOfferWallOnPointsChanged,   /**< enum the callback of Changing the point of offerwall. */
	} ;
	/** @brief AdsPos enum, with inline docs */
	public enum AdsPos
	{
		kPosCenter = 0,/**< enum the toolbar is at center. */
		kPosTop,/**< enum the toolbar is at top. */
		kPosTopLeft,/**< enum the toolbar is at topleft. */
		kPosTopRight,/**< enum the toolbar is at topright. */
		kPosBottom,/**< enum the toolbar is at bottom. */
		kPosBottomLeft,/**< enum the toolbar is at bottomleft. */
		kPosBottomRight,/**< enum the toolbar is at bottomright. */
	};
	/** @brief AdsType enum, with inline docs */
	public enum AdsType
	{
		AD_TYPE_BANNER = 0,/**< enum value is banner ads . */
		AD_TYPE_FULLSCREEN,/**< enum value is fullscreen ads . */
		AD_TYPE_MOREAPP,/**< enum value is moreapp ads . */
		AD_TYPE_OFFERWALL,/**< enum value is offerwall ads . */
	} ;

	public class AnySDKAds
	{
		
		private static AnySDKAds _instance;
		
		public static AnySDKAds getInstance() {
			if( null == _instance ) {
				_instance = new AnySDKAds();
			}
			return _instance;
		}

		
		/**
		 * 
		* @Title: showAds 
		* @Description: show ad with the type and idx
		* @param @param adsType  the type of ad
		* @param @param idx     
		* @return void   
	 	*/

		public  void showAds(AdsType adsType, int idx = 1)
		{
			AnySDKAds_nativeShowAds (adsType,idx);
		}

		/**
	 	* 
		* @Title: hideAds 
		* @Description: hide ad with the type and idx
		* @param @param adsType  the type of ad
		* @param @param idx     
		* @return void   
		 */

		public  void hideAds(AdsType adsType, int idx = 1)
		{
			AnySDKAds_nativeHideAds (adsType,idx);
		}

		/**
-		 * 
-		* @Title: preloadAds 
-		* @Description: preload ad with the type and idx
-		* @param @param adsType  the type of ad
-		* @param @param idx     
-		* @return void   
-		 */
			

		public void  preloadAds(AdsType adsType, int idx = 1)
		{
			AnySDKAds_nativePreloadAds (adsType,idx);
		}

		/**
		 * 
		* @Title: queryPoints 
		* @Description: query the ponits in the type of offerwall 
		* @param @return     
		* @return float   
		 */

		public  float queryPoints()
		{
			return AnySDKAds_nativeQueryPoints ();
		}

		/**
		 * 
		* @Title: spendPoints 
		* @Description: spend the ponits in the type of offerwall 
		* @param @param points     
		* @return void   
		 */
		public  void spendPoints (int points)
		{
			AnySDKAds_nativeSpendPoints (points);
		}

		/**
		 * 
		* @Title: isAdTypeSupported 
		* @Description: does the plugin support the type of ad
		* @param @param adsType
		* @param @return     
		* @return boolean   
	 	*/
		public bool isAdTypeSupported(AdsType adType)
		{
			return AnySDKAds_nativeIsAdTypeSupported (adType);
			
		}

		/**
		 * set debugmode for plugin
		 * 
		 */
		public  void setDebugMode(bool bDebug)
		{
			AnySDKAds_nativeSetDebugMode (bDebug);
		}

		/**
    	 @brief set pListener The callback object for ads result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
			AnySDKUtil.registerActionCallback (AnySDKType.Ads, gameObject, functionName);
		}

		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/

		public  string getPluginVersion()
		{
			StringBuilder version = new StringBuilder();
			AnySDKAds_nativeGetPluginVersion (version);
			return version.ToString();
		}

		/**
		 * Get Sdk version
		 * 
		 * @return string
		 */

		public  string getSDKVersion()
		{
			StringBuilder version = new StringBuilder();
			AnySDKAds_nativeGetSDKVersion (version);
			return version.ToString();
		}
		
		/**
    	 *@brief methods for reflections
    	 *@param function name
    	 *@param AnySDKParam* param
     	*@return void
    	 */

		public  void callFuncWithParam(string functionName, AnySDKParam param)
		{
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			AnySDKAds_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
		}

		/**
    	 *@brief methods for reflections
    	 *@param function name
    	 *@param List<AnySDKParam> params
    	 *@return void
    	 */

		public  void callFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			if (param == null) 
			{
				AnySDKAds_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				AnySDKAds_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
			}
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
    	 *@param AnySDKParam param
    	 *@return int
    	 */

		public  int callIntFuncWithParam(string functionName, AnySDKParam param)
		{
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKAds_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
		}
		
		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return int
    	 */

		public  int  callIntFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			if (param == null)
			{
				return AnySDKAds_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKAds_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
			}
		}
		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return float
    	 */

		public  float callFloatFuncWithParam(string functionName, AnySDKParam param)
		{
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKAds_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
		}
		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return float
    	 */

		public  float callFloatFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			if (param == null)
			{
				return AnySDKAds_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKAds_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
			}
		}
		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return bool
    	 */

		public  bool callBoolFuncWithParam(string functionName, AnySDKParam param)
		{
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKAds_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
		}
		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return bool
    	 */

		public  bool callBoolFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			if (param == null)
			{
				return AnySDKAds_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKAds_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
			}
		}
		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return string
    	 */

		public  string callStringFuncWithParam(string functionName, AnySDKParam param)
		{
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			AnySDKAds_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
			return value.ToString ();
		}
		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return string
    	 */

		public  string callStringFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			StringBuilder value = new StringBuilder();
			if (param == null)
			{
				AnySDKAds_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				AnySDKAds_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
		}
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void AnySDKAds_RegisterExternalCallDelegate(IntPtr functionPointer);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAds_nativeShowAds(AdsType adsType, int idx = 1);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAds_nativeHideAds(AdsType adsType, int idx = 1);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAds_nativePreloadAds(AdsType adsType, int idx = 1);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern float AnySDKAds_nativeQueryPoints();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAds_nativeSpendPoints(int points);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKAds_nativeIsAdTypeSupported(AdsType adsType);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAds_nativeSetDebugMode(bool bDebug);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAds_nativeGetPluginVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAds_nativeGetSDKVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAds_nativeCallFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern int AnySDKAds_nativeCallIntFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern float AnySDKAds_nativeCallFloatFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKAds_nativeCallBoolFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAds_nativeCallStringFuncWithParam(string functionName, AnySDKParam[] param,int count,StringBuilder value);
	}
	
}


