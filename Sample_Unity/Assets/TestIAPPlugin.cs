using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using anysdk;

namespace anysdk {
	public class TestIAPPlugin : MonoBehaviour {
	
		
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
			
			//Login
			if(GUI.Button(new Rect(100,100,Screen.width - 200,80),"getOrderId" ))
			{
				getOrderId();
			}
			
			//Logout
			if(GUI.Button(new Rect(100,200,Screen.width - 200,80),"payForProduct" ))
			{
				payForProduct();
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
		 * 获取订单号
		 */
		void getOrderId() {
			string orderId = AnySDKIAP.getOrderId();
			AnySDK.log( "AnySDK@ getOrder id " + orderId ); 
		}
		
		/**
		 * 支付
		 */
		void payForProduct() {
			Dictionary<string, string> products = new Dictionary<string, string>();
			products["Product_Price"] = "1";
			products["Product_Id"] = "jinbi";
			products["Product_Name"] = "gold";
			products["Server_Id"] = "13";
			products["Product_Count"] = "1";
			products["Role_Id"] = "1";
			products["Role_Name"] = "1";
			AnySDKIAP.payForProduct( products );
		}
		
	}
}
