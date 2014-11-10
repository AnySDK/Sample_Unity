using UnityEngine;
using System.Collections;
namespace anysdk {
public class TestAdsPlugin : MonoBehaviour
{

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
			
			if(GUI.Button(new Rect(100,100,Screen.width - 200,80),"showAds" ))
			{
				showAds();
			}
			
			if(GUI.Button(new Rect(100,200,Screen.width - 200,80),"hideAds" ))
			{
				hideAds();
			}

		}
		/**
		 * show Ads
		 */
		void showAds() {
			if( AnySDKAds.isAdTypeSupported( AnySDKAdsTypeEnum.AD_TYPE_BANNER ) ) {
				AnySDKAds.showAds(AnySDKAdsTypeEnum.AD_TYPE_BANNER,1);
				AnySDKAds.showAds(AnySDKAdsTypeEnum.AD_TYPE_BANNER,2);
			}
		}

		/**
		 * hide Ads
		 */
		void hideAds() {
			if( AnySDKAds.isAdTypeSupported(AnySDKAdsTypeEnum.AD_TYPE_BANNER ) ) {
				AnySDKAds.hideAds(AnySDKAdsTypeEnum.AD_TYPE_BANNER,1);

			}
		}
		
		// Update is called once per frame
		void Update() {
			if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Home))  
			{  
				Application.Quit();  
			} 
		}
}
}

