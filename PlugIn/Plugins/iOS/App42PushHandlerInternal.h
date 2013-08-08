//
//  App42PushHandlerInternal.h
//  PushSDK
//
//  Created by Rajeev Ranjan on 06/08/13.
//  Copyright (c) 2013 ShepHertz Technologies Pvt Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>

#import <UIKit/UIKit.h>

@interface UIApplication(SupressWarnings)
- (void)application:(UIApplication *)application app42didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)devToken;
- (void)application:(UIApplication *)application app42didFailToRegisterForRemoteNotificationsWithError:(NSError *)err;
- (void)application:(UIApplication *)application app42didReceiveRemoteNotification:(NSDictionary *)userInfo;

- (BOOL)application:(UIApplication *)application app42didFinishLaunchingWithOptions:(NSDictionary *)launchOptions;
@end
