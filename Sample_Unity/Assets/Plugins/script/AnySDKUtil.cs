using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class AnySDKUtil : MonoBehaviour {
#if UNITY_ANDROID
	public static AndroidJavaObject dictionary2JavaMap( Dictionary<string,string> maps  ) {	
		
		AndroidJavaObject jcMap = new AndroidJavaObject( "java.util.HashMap" );
		
		IntPtr putMethodPtr = AndroidJNI.GetMethodID( jcMap.GetRawClass(), "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;" ) ;
		
		foreach (KeyValuePair<string, string> kv in maps){
			AndroidJavaObject[] localParams = new AndroidJavaObject[2];
			localParams[0] = new AndroidJavaObject( "java.lang.String", (string)kv.Key );
			localParams[1] = new AndroidJavaObject( "java.lang.String", (string)kv.Value );
			AndroidJNI.CallObjectMethod( jcMap.GetRawObject(), putMethodPtr, AndroidJNIHelper.CreateJNIArgArray( localParams ) );
		}
		return jcMap;			
	}

	public static AndroidJavaObject arrayList2JavaArrayList( ArrayList list  ) {	
		
		AndroidJavaObject jcList = new AndroidJavaObject( "java.util.ArrayList" );
		
		IntPtr addMethodPtr = AndroidJNI.GetMethodID( jcList.GetRawClass(), "add", "(Ljava/lang/Object;)Z" ) ;
		
		for( int i = 0; i < list.Count; i++ ) {
			object item = list[i];
			AndroidJavaObject[] localParams = new AndroidJavaObject[1];
			localParams[0] = new AndroidJavaObject( "java.lang.String", (string)item );
			AndroidJNI.CallBooleanMethod( jcList.GetRawObject(), addMethodPtr, AndroidJNIHelper.CreateJNIArgArray( localParams ) );
		}
		return jcList;			
	}
#endif
}
