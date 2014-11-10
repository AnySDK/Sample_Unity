using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace anysdk {
	public abstract class AnySDKProtocol : MonoBehaviour
	{
#if UNITY_ANDROID	
		protected abstract AndroidJavaClass getAndroidJavaClass();
#endif
		
		/**
		 * 获取插件名称
		 */
		protected string _getPluginName() {
#if UNITY_ANDROID	
			AndroidJavaClass jcAndroidObject = getAndroidJavaClass();
			return jcAndroidObject.CallStatic<string>( "getPluginName", new object[]{});
#else
			return "";			
#endif
		}
		
		/**
		 * 获取插件版本号
		 */
		protected string _getPluginVersion() {
#if UNITY_ANDROID
			AndroidJavaClass jcAndroidObject = getAndroidJavaClass();
			return jcAndroidObject.CallStatic<string>( "getPluginVersion", new object[]{});
#else
			return "";			
#endif
		}
		
		/**
		 * 获取Sdk 版本号
		 */
		protected string _getSDKVersion() {
#if UNITY_ANDROID
			AndroidJavaClass jcAndroidObject = getAndroidJavaClass();
			return jcAndroidObject.CallStatic<string>( "getSDKVersion", new object[]{});
#else
			return "";			
#endif
		}

		/**
		 * set debugmode for plugin
		 */
		protected void _setDebugMode(bool bDebug) {
#if UNITY_ANDROID
			AndroidJavaClass jcAndroidObject = getAndroidJavaClass();
			jcAndroidObject.CallStatic("setDebugMode", new object[]{bDebug});		
#endif
		}

		protected bool _isFunctionSupported( string functionName ) {
#if UNITY_ANDROID
			AndroidJavaClass jcAndroidObject = getAndroidJavaClass();
			return jcAndroidObject.CallStatic<bool>( "isFunctionSupported", new object[]{functionName});
#else
			return false;
#endif
		}
		
		protected void _callFunction( string functionName ) {
#if UNITY_ANDROID
			AndroidJavaClass jcAndroidObject = getAndroidJavaClass();
			jcAndroidObject.CallStatic( "callFunction", new object[]{functionName});
#endif
		}
		
		protected void _callFunction( string functionName, ArrayList listParams ) {
#if UNITY_ANDROID
			AndroidJavaClass jcAndroidObject = getAndroidJavaClass();		
			AndroidJavaObject jcArrayList = new AndroidJavaObject( "java.util.ArrayList" );
		
			IntPtr addMethodPtr = AndroidJNI.GetMethodID( jcArrayList.GetRawClass(), "add", "(Ljava/lang/Object;)Z" ) ;
			
			for( int i = 0; i < listParams.Count; i++ ) {
				object item = listParams[i];
				AndroidJavaObject[] localParams = new AndroidJavaObject[1];
				Debug.Log("string");
				if( item is string ) {	
					Debug.Log("string");
					localParams[0] = new AndroidJavaObject( "java.lang.String", (string)item );	
				} else if( item is int ) {				
					localParams[0] = new AndroidJavaObject( "java.lang.Integer", (int)item );
				} else if( item is float ) {
					localParams[0] = new AndroidJavaObject( "java.lang.Float", (float)item );		
				} else if( item is bool ) {
					localParams[0] = new AndroidJavaObject( "java.lang.Boolean", (bool)item );	
				} else if( item is double ) {
					localParams[0] = new AndroidJavaObject( "java.lang.Float", (float)item );	
				}
				AndroidJNI.CallBooleanMethod( jcArrayList.GetRawObject(), addMethodPtr, AndroidJNIHelper.CreateJNIArgArray( localParams ) );
			}
	
			jcAndroidObject.CallStatic( "callFunction", new object[]{ functionName,jcArrayList});
#endif
		}
		
		protected void _callFunction( string functionName, Dictionary<string,string> maps ) {
#if UNITY_ANDROID
			AndroidJavaClass jcAndroidObject = getAndroidJavaClass();		
			AndroidJavaObject jcMap = new AndroidJavaObject( "java.util.HashMap" );
		
			IntPtr putMethodPtr = AndroidJNI.GetMethodID( jcMap.GetRawClass(), "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;" ) ;
			
			foreach (KeyValuePair<string, string> kv in maps){
				AndroidJavaObject[] localParams = new AndroidJavaObject[2];
				localParams[0] = new AndroidJavaObject( "java.lang.String", (string)kv.Key );
				localParams[1] = new AndroidJavaObject( "java.lang.String", (string)kv.Value );
				AndroidJNI.CallObjectMethod( jcMap.GetRawObject(), putMethodPtr, AndroidJNIHelper.CreateJNIArgArray( localParams ) );
			}
			jcAndroidObject.CallStatic( "callFunction", new object[]{ functionName,jcMap });
#endif
		}

		protected void _registerPluginXActionCallback( MonoBehaviour callback ) {
#if UNITY_ANDROID
			AndroidJavaClass jcAndroidObject = getAndroidJavaClass();
			string gameObjectName = callback.gameObject.name;
			jcAndroidObject.CallStatic( "registerActionResultCallback", new object[]{gameObjectName});
#endif
		}
		
		protected void _unRegisterPluginXActionCallback( MonoBehaviour callback ) {
#if UNITY_ANDROID
			AndroidJavaClass jcAndroidObject = getAndroidJavaClass();
			string gameObjectName = callback.gameObject.name + "|" + callback.name;
			jcAndroidObject.CallStatic( "unRegisterActionResultCallback", new object[]{gameObjectName});
#endif
		}
	}
}


