using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace anysdk {
	public class TestSocialPlugin : MonoBehaviour
	{	
		private AnySDKSocial _instance;
		void Awake()
		{

		}

		void Start()
		{
			_instance = AnySDKSocial.getInstance ();
			_instance.setListener (this,"SocialExternalCall");
		}
		void SocialExternalCall(string msg)
		{
			Debug.Log("SocialExternalCall("+ msg+")");
			Dictionary<string,string> dic = AnySDKUtil.stringToDictionary (msg);
			int code = Convert.ToInt32(dic["code"]);
			string result = dic["msg"];
			switch(code)
			{
			case (int)SocialRetCode.kScoreSubmitSucceed://提交分数成功回调
				
				break;
			case (int)SocialRetCode.kScoreSubmitfail://提交分数失败回调
				
				break;
			case (int)SocialRetCode.kAchUnlockSucceed://解锁成F就成功回调
				
				break;
			case (int)SocialRetCode.kAchUnlockFail://解锁成就失败回调
				
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
			if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"submitScore" ))
			{
				submitScore();
			}
			
			if(GUI.Button(new Rect(5, 80, Screen.width - 10, 70),"showLeaderboard" ))
			{
				showLeaderboard();
				
			}
			
			if(GUI.Button(new Rect(5, 155, Screen.width - 10, 70),"showAchievements" ))
			{
				
				showAchievements();
			}
			
			if(GUI.Button(new Rect(5, 230, Screen.width - 10, 70),"unlockAchievement" ))
			{
				
				unlockAchievement();
			}

			if(GUI.Button(new Rect(5, 305, Screen.width - 10, 70),"return" ))
			{
				Destroy (GetComponent ("TestSocialPlugin" ));
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
		 * 提交分数
		 */
		void submitScore() {
			AnySDKSocial.getInstance().submitScore( "1", 100 );	
		}
		
		/**
		 * 显示排行榜
		 */
		void showLeaderboard() {
			AnySDKSocial.getInstance().showLeaderboard( "1" );
		}
		
		/**
		 * 显示成就榜
		 */
		void showAchievements() {
			AnySDKSocial.getInstance().showAchievements();	
		}
		
		/**
		 * 解锁成就榜
		 */
		void unlockAchievement() {
			Dictionary<string,string> info = new Dictionary<string, string>();
			info["xx1"] = "xx1";
			info["xx2"] = "xx2";
			AnySDKSocial.getInstance().unlockAchievement( info ); 	
		}
	}
}

