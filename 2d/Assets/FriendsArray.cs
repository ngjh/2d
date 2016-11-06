using UnityEngine;
using System.Collections;
//used for parsing to json from json to the following data
[System.Serializable]
public class FriendsArray{

	public FriendsData[] Friends;
}
[System.Serializable]
public class FriendsData{
	public string MatricFriender;
	public string MatricFriendee;
}
