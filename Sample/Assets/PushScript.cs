using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.pushNotification;
using System;
using System.Runtime.InteropServices;

public class PushScript : MonoBehaviour 
{
	const string api_key = "00997a26e28f8e9e3ee0aebc9dbcda1b6c36537bb2f21989a8923f406daf97ae";
	const string secret_key = "706d9f53f67a18fcb427266231d998c43abe453cffa4a70091038bb861587639";
	PushResponse callBack = new PushResponse();
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void registerForRemoteNotifications();

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void setListenerGameObject(string listenerName);
	
	// Use this for initialization
	void Start ()
	{
		App42Log.SetDebug(true);
		Debug.Log("Start called -----"+this.gameObject.name);
	    setListenerGameObject(this.gameObject.name);// sets the name of the game object as a listener to which this script is assigned.
	}
	

	//Sent when the application successfully registered with Apple Push Notification Service (APNS).
	void onDidRegisterForRemoteNotificationsWithDeviceToken(string deviceToken)
	{
		Debug.Log("deviceToken"+deviceToken);
		if (deviceToken != null && deviceToken.Length!=0) 
		{
			registerDeviceTokenToApp42PushNotificationService(deviceToken,"NewUser123");
		}
		SendPushToUser("NewUser123","Hello, Unity!!");
	}
	
	//Sent when the application failed to be registered with Apple Push Notification Service (APNS).
	void onDidFailToRegisterForRemoteNotificcallBackationsWithError(string error)
	{
		Debug.Log(error);
		SendPushToUser("NewUser123","Hello, Unity!!");
	}
	
	//Sent when the application Receives a push notification
	void onPushNotificationsReceived(string pushMessageString)
	{
		Console.WriteLine("onPushNotificationsReceived....Called");
		//dump you code here
		Debug.Log(pushMessageString);
	}
	
	//Registers a user with the given device token to APP42 push notification service
	void registerDeviceTokenToApp42PushNotificationService(string devToken,string userName)
	{
		Debug.Log("registerDeviceTokenToApp42PushNotificationService   Called");
		ServiceAPI serviceAPI = new ServiceAPI(api_key,secret_key);	
	    PushNotificationService pushService = serviceAPI.BuildPushNotificationService();
		pushService.StoreDeviceToken(userName,devToken,"iOS",callBack);
		//pushService.StoreDeviceToken(userName,devToken,com.shephertz.app42.paas.sdk.csharp.pushNotification.DeviceType.iOS);
	}
	
	//Sends push to a given user
	void SendPushToUser(string userName,string message)
	{
		Debug.Log("SendPushToUser Called");
		ServiceAPI serviceAPI = new ServiceAPI(api_key,secret_key);	
	    PushNotificationService pushService = serviceAPI.BuildPushNotificationService();
		pushService.SendPushMessageToUser(userName,message,callBack);
	}

	void onDidRegisterUserNotificationSettings(string setting)
	{
		Debug.Log("setting"+setting);
	}

}
