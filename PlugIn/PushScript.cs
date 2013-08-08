using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.pushNotification;
using System;
using System.Runtime.InteropServices;

public class PushScript : MonoBehaviour 
{
	const string api_key = "3c1d8c1d23e1dde0d820b06e33e6260e3b9ac0438d522a4ac9d524fc12cb8559";//"App42_App_Key";
	const string secret_key = "254964c8a7fcc95cee0362adc2e0e06e0a64ec53c7a9e5279c11b3c4303edf73";//"App42_Secret_Key";
	
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void registerForRemoteNotifications();
	
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void setListenerGameObject(string listenerName);
	
	// Use this for initialization
	void Start ()
	{
		Debug.Log("Start called");
	    setListenerGameObject(this.gameObject.name);// sets the name of the game object as a listener to which this script is assigned.
	}
	
	//Sent when the application successfully registered with Apple Push Notification Service (APNS).
	void onDidRegisterForRemoteNotificationsWithDeviceToken(string deviceToken)
	{
		if (deviceToken != null && deviceToken.Length!=0) 
		{
			registerDeviceTokenToApp42PushNotificationService(deviceToken,"User Name");
		}
		SendPushToUser("Suman","Hello, Unity!!");
	}
	
	//Sent when the application failed to be registered with Apple Push Notification Service (APNS).
	void onDidFailToRegisterForRemoteNotificationsWithError(string error)
	{
		Debug.Log(error);
	}
	
	//Sent when the application Receives a push notification
	void onPushNotificationsReceived(string pushMessageString)
	{
		Console.WriteLine("onPushNotificationsReceived");
		//dump you code here
		Debug.Log(pushMessageString);
	}
	
	//Registers a user with the given device token to APP42 push notification service
	void registerDeviceTokenToApp42PushNotificationService(string devToken,string userName)
	{
		ServiceAPI serviceAPI = new ServiceAPI(api_key,secret_key);	
	    PushNotificationService pushService = serviceAPI.BuildPushNotificationService();
		pushService.StoreDeviceToken(userName,devToken,"iOS");
	}
	
	//Sends push to a given user
	void SendPushToUser(string userName,string message)
	{
		ServiceAPI serviceAPI = new ServiceAPI(api_key,secret_key);	
	    PushNotificationService pushService = serviceAPI.BuildPushNotificationService();
		pushService.SendPushMessageToUser(userName,message);
	}
	
}
