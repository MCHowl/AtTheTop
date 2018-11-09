using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventResponseList : MonoBehaviour {

	public static List<string> ParentAcceptResponse = new List<string>();
	public static List<string> ParentDeclineResponse = new List<string>();
	public static List<string> FriendAcceptResponse = new List<string>();
	public static List<string> FriendDeclineResponse = new List<string>();

	public static void InitialiseResponseLists() {
		InitialiseParentAcceptList();
		InitialiseParentDeclineList();
		InitialiseFriendAcceptList();
		InitialiseFriendDeclineList();
	}

	static void InitialiseParentAcceptList() {
		ParentAcceptResponse.Add("Thanks dear!");
		ParentAcceptResponse.Add("Great! Love you!");
		ParentAcceptResponse.Add("Thanks sweetie!");
	}

	static void InitialiseParentDeclineList() {
		ParentDeclineResponse.Add("Oh, okay dear...");
		ParentDeclineResponse.Add("Oh, okay, don't overwork yourself");
	}

	static void InitialiseFriendAcceptList() {
		FriendAcceptResponse.Add("Great, see ya");
		FriendAcceptResponse.Add("Nice, alright then");
	}

	static void InitialiseFriendDeclineList() {
		FriendDeclineResponse.Add("Aw man, alright then...");
		FriendDeclineResponse.Add("Shucks, okay.");
		FriendDeclineResponse.Add("It's fine...");
	}
}
