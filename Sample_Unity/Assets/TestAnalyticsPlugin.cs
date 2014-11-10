using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace anysdk {
	public class TestAnalyticsPlugin : MonoBehaviour {
	
		
		private GUIStyle fontStyle;
		
		void Awake()
		{
			fontStyle = new GUIStyle();
			fontStyle.alignment = TextAnchor.MiddleCenter;
	        fontStyle.fontSize = 40;   
		}
		
		void OnDestroy() {
			
		}
		
		void OnGUI()
		{	
			
			if(GUI.Button(new Rect(100,100,Screen.width - 200,80),"startSession" ))
			{
				AnySDKAnalytics.setDebugMode(true);
				startSession();
			}
			
			if(GUI.Button(new Rect(100,200,Screen.width - 200,80),"stopSession" ))
			{
				stopSession();
			}
			
			if(GUI.Button(new Rect(100,300,Screen.width - 200,80),"setSessionContinueMillis" ))
			{
				setSessionContinueMillis( );
			}
			
			if(GUI.Button(new Rect(100,400,Screen.width - 200,80),"logError" ))
			{
				AnySDKAnalytics.logError( "100", "test test test" );
			}
			
			if(GUI.Button(new Rect(100,500,Screen.width - 200,80),"logEvent" ))
			{
				logEvent();
			}
			
			if(GUI.Button(new Rect(100,600,Screen.width - 200,80),"logTimedEventBegin" ))
			{
				logTimedEventBegin();
			}
			
			if(GUI.Button(new Rect(100,700,Screen.width - 200,80),"logTimedEventEnd" ))
			{
				logTimedEventEnd();
			}
			
			if(GUI.Button(new Rect(100,800,Screen.width - 200,80),"setCaptureUncaughtException" ))
			{
				setCaptureUncaughtException( );
			}
		}
		
			// Update is called once per frame
		void Update() {
			if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Home))  
		    {  
		        Application.Quit();  
		    } 
		}
		
		/**
		 * 用于跟踪用户使用中的打开应用和页面跳转的数据
		 */
		void startSession() {
			AnySDKAnalytics.startSession();
		}
		
		/**
		 * 用于跟踪用户离开页面和退出应用的数据
		 */
		void stopSession() {
			AnySDKAnalytics.stopSession();
		}
		
		/**
		 * 实现在应用程序中埋点来统计用户的点击行为
		 */
		void logEvent() {
			Dictionary<string,string> dic = new Dictionary<string,string>();
			dic["100"] = "Page1 open";
			dic["角色名称"]="yonghu";
			dic["登陆时间"]="2014";
			AnySDKAnalytics.logEvent( "10", dic );
		}
		
		/**
		 * 当用户两次使用之间过长时，将被认为是两个的独立的session(启动)
		 */
		void setSessionContinueMillis() {
			AnySDKAnalytics.setSessionContinueMillis( 2000L );
		}
		
		/**
		 * 收集应用错误日志
		 */
		void setCaptureUncaughtException() {
			AnySDKAnalytics.setCaptureUncaughtException( true );
		}
		
		/**
		 * 记录事件的开始时间
		 */
		void logTimedEventBegin() {
			AnySDKAnalytics.logTimedEventBegin( "10" );
		}
		
		/**
		 * 记录事件的结束时间
		 */
		void logTimedEventEnd() {
			setAccount ();
			//AnySDKAnalytics.logTimedEventEnd( "10" );
		}
		
		void setAccount()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Account_Id"] = "123";
			paramMap["Account_Name"] = "test";
			paramMap["Account_Type"] = Convert.ToString((int)AnySDKAnalyticsEnum.AccountType.ANONYMOUS);
			paramMap["Account_Level"] = "1";
			paramMap["Account_Age"] = "1";
			paramMap["Account_Operate"] = Convert.ToString((int)AnySDKAnalyticsEnum.AccountOperate.LOGIN);
			paramMap["Account_Gender"] = Convert.ToString((int)AnySDKAnalyticsEnum.AccountGender.MALE);
			paramMap["Server_Id"] = "1";
			AnySDKAnalytics.callFunction ("setAccount", paramMap);

		}
		
		void onChargeRequest()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Order_Id"] = "123456";
			paramMap["Product_Name"] = "test";
			paramMap["Currency_Amount"] = Convert.ToString(2.0);
			paramMap["Currency_Type"] = "1";
			paramMap["Payment_Type"] = "1";
			paramMap["Virtual_Currency_Amount"] = Convert.ToString(100);

			AnySDKAnalytics.callFunction ("onChargeRequest", paramMap);

		}

		void onChargeOnlySuccess()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Order_Id"] = "123456";
			paramMap["Product_Name"] = "test";
			paramMap["Currency_Amount"] = Convert.ToString(2.0);
			paramMap["Currency_Type"] = "1";
			paramMap["Payment_Type"] = "1";
			paramMap["Virtual_Currency_Amount"] = Convert.ToString(100);
			
			AnySDKAnalytics.callFunction ("onChargeOnlySuccess", paramMap);

		}
		void onChargeSuccess()
		{
			ArrayList list = new ArrayList();
			list.Add( "123456" );
			
			AnySDKAnalytics.callFunction ("onChargeSuccess", list);

		}
		
		void onChargeFail()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Order_Id"] = "123456";
			paramMap["Fail_Reason"] = "test";
			
			AnySDKAnalytics.callFunction ("onChargeFail", paramMap);

		}
		void onPurchase()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Item_Id"] = "123456";
			paramMap["Item_Type"] = "test";
			paramMap["Item_Count"] = Convert.ToString(2);
			paramMap["Vitural_Currency"] = "1";
			paramMap["Currency_Type"] = AnySDK.getChannelId();
			
			AnySDKAnalytics.callFunction ("onPurchase", paramMap);

		}
		void onUse()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Item_Id"] = "123456";
			paramMap["Item_Type"] = "test";
			paramMap["Item_Count"] = Convert.ToString(2);
			paramMap["Use_Reason"] = "1";
			
			AnySDKAnalytics.callFunction ("onUse", paramMap);


		}
		void onReward()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Item_Id"] = "123456";
			paramMap["Item_Type"] = "test";
			paramMap["Item_Count"] = Convert.ToString(2);
			paramMap["Use_Reason"] = "1";
			
			AnySDKAnalytics.callFunction ("onReward", paramMap);

		}
		void startLevel()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Level_Id"] = "123456";
			paramMap["Seq_Num"] = "1";
			AnySDKAnalytics.callFunction ("startLevel", paramMap);

		}
		
		void finishLevel()
		{
			ArrayList list = new ArrayList();
			list.Add( "123456" );

			
			AnySDKAnalytics.callFunction ("finishLevel", list);



		}
		void failLevel()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Level_Id"] = "123456";
			paramMap["Fail_Reason"] = "test";
			
			AnySDKAnalytics.callFunction ("failLevel", paramMap);


		}
		void startTask()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Task_Id"] = "123456";
			paramMap["Task_Type"] = Convert.ToString((int)AnySDKAnalyticsEnum.TaskType.GUIDE_LINE);
			
			AnySDKAnalytics.callFunction ("startTask", paramMap);

		}
		void finishTask()
		{
			ArrayList list = new ArrayList();
			list.Add( "123456" );
			
			AnySDKAnalytics.callFunction ("finishTask", list);

		}
		void failTask()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Task_Id"] = "123456";
			paramMap["Fail_Reason"] = "test";
			
			AnySDKAnalytics.callFunction ("failTask", paramMap);

			
		}
	}
}
