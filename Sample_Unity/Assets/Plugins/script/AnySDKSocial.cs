using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace anysdk {
	public enum SocialRetCode
	{
		// code for leaderboard feature
		kScoreSubmitSucceed =1,/**< enum value is callback of succeeding in submiting. */
		kScoreSubmitfail,/**< enum value is callback of failing to submit . */
		
		// code for achievement feature
		kAchUnlockSucceed,/**< enum value is callback of succeeding in unlocking. */
		kAchUnlockFail,/**< enum value is callback of failing to  unlock. */
		
		kSocialSignInSucceed,/**< enum value is callback of succeeding to login. */
		kSocialSignInFail,/**< enum value is callback of failing to  login. */
		
		kSocialSignOutSucceed,/**< enum value is callback of succeeding to login. */
		kSocialSignOutFail,/**< enum value is callback of failing to  login. */
		
		
	} ;
	public class AnySDKSocial
	{
		private static AnySDKSocial _instance;
		
		public static AnySDKSocial getInstance() {
			if( null == _instance ) {
				_instance = new AnySDKSocial();
			}
			return _instance;
		}

		/**
     	@brief user signIn
    	 */

		public  void signIn()
		{
			AnySDKSocial_nativeSignIn ();
		}

		/**
     	@brief user signOut
    	 */

		public  void signOut()
		{
			AnySDKSocial_nativeSignOut ();
		}

		/**
    	 @brief submit the score
    	 @param leaderboardID
     	 @param the score
     	*/

		public  void submitScore(string leadboardID, long score)
		{
			AnySDKSocial_nativeSubmitScore (leadboardID, score);
		}

		/**
     	 @brief show the id of Leaderboard page
     	 @param leaderboardID
     	 */

		public  void showLeaderboard(string leadboardID)
		{
			AnySDKSocial_nativeShowLeaderboard (leadboardID);
		}

		
		/**
    	 @brief methods of achievement feature
   		  @param the info of achievement
    	 */

		public  void unlockAchievement (Dictionary<string,string> achInfo)
		{
			string info = AnySDKUtil.dictionaryToString (achInfo);
			AnySDKSocial_nativeUnlockAchievement (info);
		}

		/**
    	 @brief show the page of achievements
     	*/

		public  void showAchievements ()
		{
			AnySDKSocial_nativeShowAchievements ();
		}

		/**
		 * set debugmode for plugin
		 * 
		 */

		public  void setDebugMode(bool bDebug)
		{
			AnySDKSocial_nativeSetDebugMode (bDebug);
		}
		/**
    	 @brief set pListener The callback object for social result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
			AnySDKUtil.registerActionCallback (AnySDKType.Social, gameObject, functionName);
		}

		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/

		public  string getPluginVersion()
		{
			StringBuilder version = new StringBuilder();
			AnySDKSocial_nativeGetPluginVersion (version);
			return version.ToString();
		}
		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/

		public  string getSDKVersion()
		{
			StringBuilder version = new StringBuilder();
			AnySDKSocial_nativeGetSDKVersion (version);
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
			AnySDKSocial_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
			if (param == null) 
			{
				AnySDKSocial_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				AnySDKSocial_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return AnySDKSocial_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return AnySDKSocial_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKSocial_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return AnySDKSocial_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return AnySDKSocial_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKSocial_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return AnySDKSocial_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return AnySDKSocial_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKSocial_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
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
			AnySDKSocial_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
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
				AnySDKSocial_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				AnySDKSocial_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
		}
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void AnySDKSocial_RegisterExternalCallDelegate(IntPtr functionPointer);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeSignIn();
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeSignOut();
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeShowLeaderboard(string leadboardID);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKSocial_nativeSubmitScore(string leadboardID, long score);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKSocial_nativeUnlockAchievement(string info);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKSocial_nativeShowAchievements();
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeSetDebugMode(bool bDebug);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeGetPluginVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeGetSDKVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeCallFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern int AnySDKSocial_nativeCallIntFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern float AnySDKSocial_nativeCallFloatFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKSocial_nativeCallBoolFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeCallStringFuncWithParam(string functionName, AnySDKParam[] param,int count,StringBuilder value);
	}
	
}


