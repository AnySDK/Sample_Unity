using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace anysdk {
	public enum RECResultCode
	{
		kRECInitSuccess = 0,/**< enum value is callback of succeeding in initing sdk . */
		kRECInitFail,/**< enum  value is callback of failing to init sdk. */
		kRECStartRecording,/**< enum  value is callback of starting to record. */
		kRECStopRecording,/**< enum  value is callback of stoping to record. */
		kRECPauseRecording,/**< enum  value is callback of pausing to record. */
		kRECResumeRecording,/**< enum  value is callback of resuming to record. */
		kRECEnterSDKPage,/**< enum  value is callback of failing to init sdk. */
		kRECQuitSDKPage,/**< enum  value is callback of entering SDK`s page. */
		kRECShareSuccess,/**< enum  value is callback of  quiting SDK`s page. */
		kRECShareFail,/**< enum  value is callback of failing to share. */
		kRECExtension = 90000 /**< enum value is  extension code . */
	};
	public class AnySDKREC
	{

		private static AnySDKREC _instance;
		
		public static AnySDKREC getInstance() {
			if( null == _instance ) {
				_instance = new AnySDKREC();
			}
			return _instance;
		}

		/**
     	@brief Start to record
    	 */
		
		public  void startRecording()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKREC_nativeStartRecording ();
#else
			Debug.Log("This platform does not support!");
#endif
		}
		
		/**
     	@brief Stop a session.
    	 @warning This interface only worked on android
    	 */
		
		public  void stopRecording()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKREC_nativeStopRecording ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	@brief share video
   		@param info The info of share, contains key:
   		 @warning Look at the manual of plugins.

    	*/
		
		public  void share(Dictionary<string,string> shareInfo)
		{
			
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string info = AnySDKUtil.dictionaryToString (shareInfo);
			Debug.Log("share   " + info);
			AnySDKREC_nativeShare (info );
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief Check function the plugin support or not
     	*/
		
		public  bool  isFunctionSupported (string functionName)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return AnySDKREC_nativeIsFunctionSupported (functionName);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
		 * set debugmode for plugin
		 * 
		 */
		[Obsolete("This interface is obsolete!",false)]
		public  void setDebugMode(bool bDebug)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKREC_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief set pListener The callback object for share result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
#if !UNITY_EDITOR && UNITY_ANDROID
			AnySDKUtil.registerActionCallback (AnySDKType.REC, gameObject, functionName);
#elif !UNITY_EDITOR && UNITY_IOS
			string gameObjectName = gameObject.gameObject.name;
			AnySDKREC_nativeSetListener(gameObjectName,functionName);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/
		public  string getPluginVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKREC_nativeGetPluginVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		
		/**
		 * Get SDK version
		 * 
		 * @return string
	 	*/
		public  string getSDKVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKREC_nativeGetSDKVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return void
    	 */
		
		public  void callFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			AnySDKREC_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null) 
			{
				AnySDKREC_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				AnySDKREC_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return int
    	 */
		public  int callIntFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKREC_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam param 
    	 *@return int
    	 */
		public  int  callIntFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			if (param == null)
			{
				return AnySDKREC_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKREC_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKREC_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return AnySDKREC_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKREC_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKREC_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam param 
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return AnySDKREC_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKREC_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKREC_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			if (param == null)
			{
				AnySDKREC_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				AnySDKREC_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void AnySDKREC_RegisterExternalCallDelegate(IntPtr functionPointer);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKREC_nativeStartRecording();
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKREC_nativeStopRecording();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKREC_nativeShare(string info);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKREC_nativeSetListener(string gameName, string functionName);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKREC_nativeIsFunctionSupported(string functionName);
	
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKREC_nativeSetDebugMode(bool bDebug);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKREC_nativeGetPluginVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKREC_nativeGetSDKVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKREC_nativeCallFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern int AnySDKREC_nativeCallIntFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern float AnySDKREC_nativeCallFloatFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKREC_nativeCallBoolFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKREC_nativeCallStringFuncWithParam(string functionName, AnySDKParam[] param,int count,StringBuilder value);
	}
	
}


