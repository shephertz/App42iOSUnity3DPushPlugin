using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp.pushNotification;
using com.shephertz.app42.paas.sdk.csharp;
using System;
public class PushResponse :  App42CallBack {

		public void OnSuccess(object response)
        {
			if(response is PushNotification){
				PushNotification pushNotification = (PushNotification)response;
				Debug.Log ("UserName : " + pushNotification.GetUserName());	
				Debug.Log ("Expiery : " + pushNotification.GetExpiry());
				Debug.Log ("DeviceToken : " + pushNotification.GetDeviceToken());	
				Debug.Log ("pushNotification : " + pushNotification.GetMessage());	
				Debug.Log ("pushNotification : " + pushNotification.GetStrResponse());	
				Debug.Log ("pushNotification : " + pushNotification.GetTotalRecords());	
				Debug.Log ("pushNotification : " + pushNotification.GetType());	
//				for(int i = 0 ; i < pushNotification.GetChannelList)
//				Debug.Log ("pushNotification : " + pushNotification.GetChannelList()[0].GetName());	
//				Debug.Log ("pushNotification : " + pushNotification.GetChannelList()[0].GetName());	
//				Debug.Log ("pushNotification : " + pushNotification.GetChannelList()[0].GetType());	
			}
		}

        public void OnException(Exception e)
        {
			Debug.Log ("Exception--------- : " + e);
		}
}
