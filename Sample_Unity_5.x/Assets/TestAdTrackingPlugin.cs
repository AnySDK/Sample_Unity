using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace anysdk {
	public class TestAdTrackingPlugin : MonoBehaviour {

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
			if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"onRegister" ))
			{
				onRegister();
			}
			
			if(GUI.Button(new Rect(5, 80, Screen.width - 10, 70),"onLogin" ))
			{
				onLogin();
			}
			
			if(GUI.Button(new Rect(5, 155, Screen.width - 10, 70),"onPay" ))
			{
				onPay();
				
			}
			
			if(GUI.Button(new Rect(5, 230, Screen.width - 10, 70),"trackEvent" ))
			{
			
				trackEvent();
			}
			
			
			if(GUI.Button(new Rect(5, 305, Screen.width - 10, 70),"onCreateRole" ))
			{
				
				onCreateRole();
			}
			
			
			if(GUI.Button(new Rect(5, 380, Screen.width - 10, 70),"onLevelUp" ))
			{
				onLevelUp();
			}
			
			
			if(GUI.Button(new Rect(5, 455, Screen.width - 10, 70),"onStartToPay" ))
			{
				onStartToPay();
			}

			if(GUI.Button(new Rect(5, 525, Screen.width - 10, 70),"return" ))
			{
				Destroy (GetComponent ("TestAdTrackingPlugin"));
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
		 * Call this method if you want to track register event as happening during a section.
		 */
		void onRegister() {
			AnySDKAdTracking.getInstance().onRegister("user_unity");
		}
		
		/**
		 * Call this method if you want to track login event as happening during a section.
		 */
		void onLogin() {
			Dictionary<string,string> dic = new Dictionary<string,string>();
			dic["User_Id"] = "123456";
			dic["Role_Id"] = "test";
			dic["Role_Name"] = "test";
			dic["Level"] = "10";
			AnySDKAdTracking.getInstance().onLogin(dic);
		}

		/**
		 * Call this method if you want to track pay event as happening during a section.
		 */
		void onPay() {
			Dictionary<string,string> dic = new Dictionary<string,string>();
			dic["User_Id"] = "123456";
			dic["Order_Id"] = System.DateTime.Now.ToString();
			dic["Currency_Amount"] = "5";
			dic["Currency_Type"] = "CNY";
			dic["Payment_Type"] = "test";
			dic["Payment_Time"] = System.DateTime.Now.ToString();
			AnySDKAdTracking.getInstance().onPay(dic);
		}
		
		/**
		 *Call this method if you want to track custom events as happening during a section.
		 */
		void trackEvent() {
			AnySDKAdTracking.getInstance().trackEvent("event_1");
			AnySDKAdTracking.getInstance().trackEvent("event_2");
			AnySDKAdTracking.getInstance().trackEvent("onCustEvent2");
			AnySDKAdTracking.getInstance().trackEvent("onCustEvent1");
		}
		
		/**
		 * Call this method if you want to trackthe event of creating role as happening during a section.
		 */
		void onCreateRole() {
			if (!AnySDKAdTracking.getInstance ().isFunctionSupported ("onStartToPay"))
				return;
			Dictionary<string,string> dic = new Dictionary<string,string>();
			dic["User_Id"] = "123456";
			dic["Role_Id"] = "test";
			dic["Role_Name"] = "test";
			dic["Level"] = "10";
			AnySDKAdTracking.getInstance ().trackEvent ("onCreateRole", dic);
			AnySDKAdTracking.getInstance ().callFuncWithParam ("onCreateRole", new AnySDKParam (dic));

		}
		
		/**
		 * Call this method if you want to track the event of starting to pay s as happening during a section.
		 */
		void onStartToPay() {
			if (!AnySDKAdTracking.getInstance ().isFunctionSupported ("onStartToPay"))
				return;
			Dictionary<string,string> dic = new Dictionary<string,string>();
			dic["User_Id"] = "123456";
			dic["Order_Id"] = System.DateTime.Now.ToString();
			dic["Currency_Amount"] = "5";
			dic["Currency_Type"] = "CNY";
			dic["Payment_Type"] = "test";
			dic["Payment_Time"] = System.DateTime.Now.ToString();
			AnySDKAdTracking.getInstance ().trackEvent ("onStartToPay", dic);
			AnySDKAdTracking.getInstance ().callFuncWithParam ("onStartToPay", new AnySDKParam (dic));

		}
		
		/**
		 * Call this method if you want to track the event of leveling up as happening during a section.
		 */
		void onLevelUp() {
			if (!AnySDKAdTracking.getInstance ().isFunctionSupported ("onLevelUp"))
				return;
			Dictionary<string,string> dic = new Dictionary<string,string>();
			dic["User_Id"] = "123456";
			dic["Role_Id"] = "test";
			dic["Role_Name"] = "test";
			dic["Level"] = "10";
			AnySDKAdTracking.getInstance ().trackEvent ("onLevelUp", dic);
			AnySDKAdTracking.getInstance ().callFuncWithParam ("onLevelUp", new AnySDKParam (dic));

		}

	}
}
