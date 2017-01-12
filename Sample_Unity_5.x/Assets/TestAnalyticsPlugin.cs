using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace anysdk {
	public class TestAnalyticsPlugin : MonoBehaviour {

		void Awake()
		{
 
		}

		void Start()
		{

		}

		void OnDestroy() {
			
		}
		
		void OnGUI()
		{	
			GUI.color = Color.white;
			
			GUI.skin.button.fontSize = 30;
			if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"startSession" ))
			{
				AnySDKAnalytics.getInstance ().setDebugMode(true);
				startSession();
			}
			
			if(GUI.Button(new Rect(5, 80, Screen.width - 10, 70),"stopSession" ))
			{
				stopSession();
			}
			
			if(GUI.Button(new Rect(5, 155, Screen.width - 10, 70),"setSessionContinueMillis" ))
			{
				setSessionContinueMillis();
				
			}
			
			if(GUI.Button(new Rect(5, 230, Screen.width - 10, 70),"logError" ))
			{
			
				logError();
			}
			
			
			if(GUI.Button(new Rect(5, 305, Screen.width - 10, 70),"logEvent" ))
			{
				
				logEvent();
			}
			
			
			if(GUI.Button(new Rect(5, 380, Screen.width - 10, 70),"logTimedEventBegin" ))
			{
				
				logTimedEventBegin();
			}
			
			
			if(GUI.Button(new Rect(5, 455, Screen.width - 10, 70),"logTimedEventEnd" ))
			{
				logTimedEventEnd();
			}

			if(GUI.Button(new Rect(5, 530, Screen.width - 10, 70),"setCaptureUncaughtException" ))
			{
				setCaptureUncaughtException( );
			}

			if(GUI.Button(new Rect(5, 605, Screen.width - 10, 70),"return" ))
			{
				Destroy (GetComponent ("TestAnalyticsPlugin"));
				this.gameObject.AddComponent<Test>();
			}

		}
		
			// Update is called once per frame
		void Update() {
			if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Home))  
		    {  
		        Application.Quit();  
				AnySDK.getInstance ().release ();
		    } 
		}
		
		/**
		 * 用于跟踪用户使用中的打开应用和页面跳转的数据
		 */
		void startSession() {
			AnySDKAnalytics.getInstance ().startSession();
		}
		
		/**
		 * 用于跟踪用户离开页面和退出应用的数据
		 */
		void stopSession() {
			AnySDKAnalytics.getInstance ().stopSession();
		}

		/**
		 * 实现在应用程序中埋点来统计用户的错误信息
		 */
		void logError() {
			AnySDKAnalytics.getInstance ().logError( "100", "test test test" );
		}
		
		/**
		 * 实现在应用程序中埋点来统计用户的点击行为
		 */
		void logEvent() {
			Dictionary<string,string> dic = new Dictionary<string,string>();
			dic["100"] = "Page1 open";
			dic["角色名称"]="yonghu";
			dic["登陆时间"]="2014";
			AnySDKAnalytics.getInstance ().logEvent( "10", dic );
		}
		
		/**
		 * 当用户两次使用之间过长时，将被认为是两个的独立的session(启动)
		 */
		void setSessionContinueMillis() {
			AnySDKAnalytics.getInstance ().setSessionContinueMillis( 2000L );
		}
		
		/**
		 * 收集应用错误日志
		 */
		void setCaptureUncaughtException() {
			AnySDKAnalytics.getInstance ().setCaptureUncaughtException( true );
		}
		
		/**
		 * 记录事件的开始时间
		 */
		void logTimedEventBegin() {
			AnySDKAnalytics.getInstance ().logTimedEventBegin( "10" );
		}
		
		/**
		 * 记录事件的结束时间
		 */
		void logTimedEventEnd() {
			AnySDKAnalytics.getInstance ().logTimedEventEnd( "10" );
		}
		
		void setAccount()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Account_Id"] = "123";
			paramMap["Account_Name"] = "test";
			paramMap["Account_Type"] = Convert.ToString((int)AccountType.ANONYMOUS);
			paramMap["Account_Level"] = "1";
			paramMap["Account_Age"] = "1";
			paramMap["Account_Operate"] = Convert.ToString((int)AccountOperate.LOGIN);
			paramMap["Account_Gender"] = Convert.ToString((int)AccountGender.MALE);
			paramMap["Server_Id"] = "1";
			AnySDKParam param = new AnySDKParam (paramMap);
			AnySDKAnalytics.getInstance ().callFuncWithParam ("setAccount", param);

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
			AnySDKParam param = new AnySDKParam (paramMap);
			AnySDKAnalytics.getInstance ().callFuncWithParam ("onChargeRequest", param);

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
			AnySDKParam param = new AnySDKParam (paramMap);
			AnySDKAnalytics.getInstance ().callFuncWithParam ("onChargeOnlySuccess", param);

		}
		void onChargeSuccess()
		{
			AnySDKAnalytics.getInstance ().callFuncWithParam ("onChargeSuccess", new AnySDKParam("123456"));

		}
		
		void onChargeFail()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Order_Id"] = "123456";
			paramMap["Fail_Reason"] = "test";
			AnySDKParam param = new AnySDKParam (paramMap);
			AnySDKAnalytics.getInstance ().callFuncWithParam ("onChargeFail", param);

		}
		void onPurchase()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Item_Id"] = "123456";
			paramMap["Item_Type"] = "test";
			paramMap["Item_Count"] = Convert.ToString(2);
			paramMap["Virtual_Currency"] = "1";
			paramMap["Currency_Type"] = AnySDK.getInstance().getChannelId();
			AnySDKParam param = new AnySDKParam (paramMap);
			AnySDKAnalytics.getInstance ().callFuncWithParam ("onPurchase", param);

		}
		void onUse()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Item_Id"] = "123456";
			paramMap["Item_Type"] = "test";
			paramMap["Item_Count"] = Convert.ToString(2);
			paramMap["Use_Reason"] = "1";
			AnySDKParam param = new AnySDKParam (paramMap);
			AnySDKAnalytics.getInstance ().callFuncWithParam ("onUse", param);


		}
		void onReward()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Item_Id"] = "123456";
			paramMap["Item_Type"] = "test";
			paramMap["Item_Count"] = Convert.ToString(2);
			paramMap["Use_Reason"] = "1";
			AnySDKParam param = new AnySDKParam (paramMap);
			AnySDKAnalytics.getInstance ().callFuncWithParam ("onReward", param);

		}
		void startLevel()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Level_Id"] = "123456";
			paramMap["Seq_Num"] = "1";
			AnySDKParam param = new AnySDKParam (paramMap);
			AnySDKAnalytics.getInstance ().callFuncWithParam ("startLevel", param);

		}
		
		void finishLevel()
		{
			AnySDKAnalytics.getInstance ().callFuncWithParam ("finishLevel", new AnySDKParam("123456"));



		}
		void failLevel()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Level_Id"] = "123456";
			paramMap["Fail_Reason"] = "test";
			AnySDKParam param = new AnySDKParam (paramMap);
			AnySDKAnalytics.getInstance ().callFuncWithParam ("failLevel", param);


		}
		void startTask()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Task_Id"] = "123456";
			paramMap["Task_Type"] = Convert.ToString((int)TaskType.GUIDE_LINE);
			AnySDKParam param = new AnySDKParam (paramMap);
			AnySDKAnalytics.getInstance ().callFuncWithParam ("startTask", param);

		}
		void finishTask()
		{
			AnySDKAnalytics.getInstance ().callFuncWithParam ("finishTask", new AnySDKParam("123456"));

		}
		void failTask()
		{
			Dictionary<string,string> paramMap = new Dictionary<string,string>();
			paramMap["Task_Id"] = "123456";
			paramMap["Fail_Reason"] = "test";
			AnySDKParam param = new AnySDKParam (paramMap);
			
			AnySDKAnalytics.getInstance ().callFuncWithParam ("failTask", param);

			
		}
	}
}
