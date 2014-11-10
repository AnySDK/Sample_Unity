using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace anysdk {
	public class TestSocialPlugin : MonoBehaviour
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
			
			//Login
			if(GUI.Button(new Rect(100,100,Screen.width - 200,80),"submitScore" ))
			{
				submitScore();
			}
			
			//Logout
			if(GUI.Button(new Rect(100,200,Screen.width - 200,80),"showLeaderboard" ))
			{
				showLeaderboard();
			}
			
			//Logout
			if(GUI.Button(new Rect(100,300,Screen.width - 200,80),"showAchievements" ))
			{
				showAchievements();
			}
			
			//ShowToolBar
			if(GUI.Button(new Rect(100,400,Screen.width - 200,80),"unlockAchievement" ))
			{
				unlockAchievement();
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
		 * 提交分数
		 */
		void submitScore() {
			AnySDKSocial.submitScore( "1", 100 );	
		}
		
		/**
		 * 显示排行榜
		 */
		void showLeaderboard() {
			AnySDKSocial.showLeaderboard( "1" );
		}
		
		/**
		 * 显示成就榜
		 */
		void showAchievements() {
			AnySDKSocial.showAchievements();	
		}
		
		/**
		 * 解锁成就榜
		 */
		void unlockAchievement() {
			Dictionary<string,string> info = new Dictionary<string, string>();
			info["xx1"] = "xx1";
			info["xx2"] = "xx2";
			AnySDKSocial.unlockAchievement( info ); 	
		}
	}
}

