using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;
namespace anysdk {
	public enum AnySDKType
	{
		Ads = 1,
		Analytics = 2,
		IAP = 3,
		Share = 4,
		User = 5,
		Social = 6,
		Push = 7,
	} ;
	public class AnySDKUtil 
	{
	#if UNITY_ANDROID
		public const string ANYSDK_PLATFORM = "anysdk";
	#else
		public const string ANYSDK_PLATFORM= "__Internal";
	#endif

		public static string dictionaryToString( Dictionary<string,string> maps  ) 
		{
			StringBuilder param = new StringBuilder();
			if ( null != maps ) {  
				foreach (KeyValuePair<string, string> kv in maps){
					if ( param.Length == 0)  
					{  
						param.AppendFormat("{0}={1}",kv.Key,kv.Value);
					}  
					else  
					{  
						param.AppendFormat("&{0}={1}",kv.Key,kv.Value); 
					} 
				} 
			}  
			byte[] tempStr = Encoding.UTF8.GetBytes (param.ToString ());
			string msgBody = Encoding.Default.GetString(tempStr);
			return msgBody;			
		}

		public static Dictionary<string,string> stringToDictionary( string message ) 
		{
			Dictionary<string,string> param = new Dictionary<string,string>();
			if ( null != message) {  
				string[] tokens = message.Split(new Char[] { ',' });
				foreach (string kv in tokens)
				{

					string[] temp = kv.Split(new Char[] { '=' });

					param.Add(temp[0],temp[1]);
				} 
			}  
			
			return param;			
		}

		public static string ListToString( List<string> list  ) 
		{
			StringBuilder param = new StringBuilder();
			if ( null != list ) {  
				foreach (string kv in list){
					if ( param.Length == 0)  
					{  
						param.AppendFormat("{0}",kv);
					}  
					else  
					{  
						param.AppendFormat(",{0}",kv); 
					} 
				} 
			}  
			byte[] tempStr = Encoding.UTF8.GetBytes (param.ToString ());
			string msgBody = Encoding.Default.GetString(tempStr);
			return msgBody;			
		}
		public static List<string>   StringToList( string value  ) 
		{
			string[] temp = value.Split(',');
			List<string> param = new  List<string>();
			if ( null != temp ) {  
				foreach (string kv in temp){
					param.Add(kv); 
				} 
			}  
			
			return param;			
		}

		#if UNITY_ANDROID		
		private static AndroidJavaClass mAndroidJavaClass;
		#endif

		public static void registerActionCallback(AnySDKType type,MonoBehaviour gameObject,string functionName)
		{
	#if UNITY_ANDROID		
			if (mAndroidJavaClass == null) 
			{
				mAndroidJavaClass = new AndroidJavaClass( "com.anysdk.framework.unity.MessageHandle" );
			}
			string gameObjectName = gameObject.gameObject.name;
			mAndroidJavaClass.CallStatic( "registerActionResultCallback", new object[]{(int)type,gameObjectName,functionName});
	#endif

		}




	}
}
