using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace anysdk {
	public enum ShareResultCode
	{
		kShareSuccess = 0,/**< enum value is callback of failing to sharing . */
		kShareFail,/**< enum value is callback of failing to share . */
		kShareCancel,/**< enum value is callback of canceling to share . */
		kShareNetworkError,/**< enum value is callback of network error . */
	};
	public class AnySDKShare
	{

		private static AnySDKShare _instance;
		
		public static AnySDKShare getInstance() {
			if( null == _instance ) {
				_instance = new AnySDKShare();
			}
			return _instance;
		}

		/**
    	@brief share information
   		@param info The info of share, contains key:
   		 @warning Look at the manual of plugins.

    	*/

		public  void share(Dictionary<string,string> shareInfo)
		{
			string info = AnySDKUtil.dictionaryToString (shareInfo);
			AnySDKShare_nativeShare (info );
		}

		/**
		 * set debugmode for plugin
		 * 
		 */

		public  void setDebugMode(bool bDebug)
		{
			AnySDKShare_nativeSetDebugMode (bDebug);
		}

		/**
    	 @brief set pListener The callback object for share result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
			AnySDKUtil.registerActionCallback (AnySDKType.Share, gameObject, functionName);
		}

		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/
		public  string getPluginVersion()
		{
			StringBuilder version = new StringBuilder();
			AnySDKShare_nativeGetPluginVersion (version);
			return version.ToString();
		}

		
		/**
		 * Get SDK version
		 * 
		 * @return string
	 	*/
		public  string getSDKVersion()
		{
			StringBuilder version = new StringBuilder();
			AnySDKShare_nativeGetSDKVersion (version);
			return version.ToString();
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return void
    	 */
		
		public  void callFuncWithParam(string functionName, AnySDKParam param)
		{
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			AnySDKShare_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			if (param == null) 
			{
				AnySDKShare_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				AnySDKShare_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return AnySDKShare_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam param 
    	 *@return int
    	 */
		public  int  callIntFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			if (param == null)
			{
				return AnySDKShare_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKShare_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return AnySDKShare_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			if (param == null)
			{
				return AnySDKShare_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKShare_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return AnySDKShare_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam param 
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			if (param == null)
			{
				return AnySDKShare_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKShare_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
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
			AnySDKShare_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
			return value.ToString ();
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			StringBuilder value = new StringBuilder();
			if (param == null)
			{
				AnySDKShare_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				AnySDKShare_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
		}
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void AnySDKShare_RegisterExternalCallDelegate(IntPtr functionPointer);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKShare_nativeShare(string info);
	
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKShare_nativeSetDebugMode(bool bDebug);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKShare_nativeGetPluginId(StringBuilder pluginID);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKShare_nativeGetPluginVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKShare_nativeGetSDKVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKShare_nativeCallFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern int AnySDKShare_nativeCallIntFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern float AnySDKShare_nativeCallFloatFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKShare_nativeCallBoolFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKShare_nativeCallStringFuncWithParam(string functionName, AnySDKParam[] param,int count,StringBuilder value);
	}
	
}


