using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
namespace anysdk {
public class TestAdsPlugin : MonoBehaviour
{
		private AnySDKAds _instance;
		void Awake()
		{
		}
		void Start()
		{
			_instance = AnySDKAds.getInstance ();
			_instance.setListener (this,"AdsExternalCall");
		}
		void AdsExternalCall(string msg)
		{
			Debug.Log("AdsExternalCall("+ msg+")");
			Dictionary<string,string> dic = AnySDKUtil.stringToDictionary (msg);
			int code = Convert.ToInt32(dic["code"]);
			string result = dic["msg"];
			switch(code)
			{
			case (int)AdsResultCode.kAdsReceived://广告接受成功回调
				break;
			case (int)AdsResultCode.kAdsShown://广告展示回调		
				break;
			case (int)AdsResultCode.kAdsDismissed://广告消失回调
				
				break;
			case (int)AdsResultCode.kPointsSpendSucceed://积分设置成功回调
				
				break;
			case (int)AdsResultCode.kPointsSpendFailed://积分设置失败回调
				
				break;
			case (int)AdsResultCode.kNetworkError://网络错误回调
				
				break;
			case (int)AdsResultCode.kUnknownError://未知错误回调
				
				break;
			case (int)AdsResultCode.kOfferWallOnPointsChanged://积分改变回调
				
				break;
			default:
				break;
			}
		}
		void OnDestroy() {
			
		}
		
		void OnGUI()
		{	
			GUI.color = Color.white;
			
			GUI.skin.button.fontSize = 30;
			if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"showAds" ))
			{
				showAds();
			}
			
			if(GUI.Button(new Rect(5, 80, Screen.width - 10, 70),"hideAds" ))
			{
				hideAds();
			}
			
			if(GUI.Button(new Rect(5, 155, Screen.width - 10, 70),"preloadAds" ))
			{
				
				preloadAds();
			}

			if(GUI.Button(new Rect(5, 230, Screen.width - 10, 70),"return" ))
			{
				Destroy (GetComponent ("TestAdsPlugin" ));
				this.gameObject.AddComponent<Test>();
			}

		}
		/**
		 * show Ads
		 */
		void showAds() {
			if (_instance.isAdTypeSupported (AdsType.AD_TYPE_BANNER)) {
				_instance.showAds(AdsType.AD_TYPE_BANNER);
				//_instance.showAds(AdsType.AD_TYPE_BANNER,1);
				//_instance.showAds(AdsType.AD_TYPE_BANNER,2);
			}
		}

		/**
		 * hide Ads
		 */
		void hideAds() {
			if (_instance.isAdTypeSupported (AdsType.AD_TYPE_BANNER)) {
				_instance.hideAds(AdsType.AD_TYPE_BANNER);
				//_instance.hideAds(AdsType.AD_TYPE_BANNER,1);
				//_instance.hideAds(AdsType.AD_TYPE_BANNER,2);
			}
		}

		/**
		 * preload Ads
		 */
		void preloadAds() {
			if (_instance.isAdTypeSupported (AdsType.AD_TYPE_BANNER)) {
				_instance.preloadAds(AdsType.AD_TYPE_BANNER);
				//_instance.preloadAds(AdsType.AD_TYPE_BANNER,1);
				//_instance.preloadAds(AdsType.AD_TYPE_BANNER,2);
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
}
}

