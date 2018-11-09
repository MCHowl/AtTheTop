using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventList : MonoBehaviour {

    public static List<EventController.Event> WorkEventList = new List<EventController.Event>();
    public static List<EventController.Event> FriendEventList = new List<EventController.Event>();
    public static List<EventController.Event> ParentEventList = new List<EventController.Event>();

    // First number is the energy gained. Second number is the money earned.
    // Example: If an event gives the player -10 Energy, +50 Money,
    //          it should look like this ("eventname", long thing saying work/parent/friend,-10, 50)

	public static void InitialiseEventLists() {
		InitialiseFriendEventList();
		InitialiseParentEventList();
		InitialiseWorkEventList();
	}

    static void InitialiseWorkEventList() {
        WorkEventList.Clear();

        WorkEventList.Add(new EventController.Event("You have a new report to finish by 9am. Work overtime to finish it?", EventController.Event.EventType.work, -5, 20));
        WorkEventList.Add(new EventController.Event("Engage another client?", EventController.Event.EventType.work, -5, 20));
        WorkEventList.Add(new EventController.Event("Take some time to polish your business presentation slides?", EventController.Event.EventType.work, -5, 20));
        WorkEventList.Add(new EventController.Event("Practice your pitch for tomorrow's board meeting again?", EventController.Event.EventType.work, -5, 20));
        WorkEventList.Add(new EventController.Event("Fix your coworker's mistakes in the project report?", EventController.Event.EventType.work, -5, 20));
        WorkEventList.Add(new EventController.Event("Go to your boss's house for Chinese New Year?", EventController.Event.EventType.work, -5, 20));
        WorkEventList.Add(new EventController.Event("Attend optional lunch meeting for managers and executives?", EventController.Event.EventType.work, -5, 20));
        WorkEventList.Add(new EventController.Event("Attend government's new SkillsFuture programme?", EventController.Event.EventType.work, -5, 20));
        WorkEventList.Add(new EventController.Event("Help boss with some extra admin work?", EventController.Event.EventType.work, -5, 20));
        WorkEventList.Add(new EventController.Event("Meet new coworker for lunch?", EventController.Event.EventType.work, -5, 20));
        WorkEventList.Add(new EventController.Event("Your coworker is on leave. Cover duties for him?", EventController.Event.EventType.work, -10, 40));
        WorkEventList.Add(new EventController.Event("Take on a new joint venture for your company?", EventController.Event.EventType.work, -10, 40));
        WorkEventList.Add(new EventController.Event("Propose and execute new initiatives to foster work cohesion?", EventController.Event.EventType.work, -10, 40));
        WorkEventList.Add(new EventController.Event("Attend Networking 101 course?", EventController.Event.EventType.work, -10, 40));
        WorkEventList.Add(new EventController.Event("Make sure reports are in order for an upcoming audit?", EventController.Event.EventType.work, -10, 40));
        WorkEventList.Add(new EventController.Event("Rush report for a demanding client?", EventController.Event.EventType.work, -15, 60));
        WorkEventList.Add(new EventController.Event("Attend a networking event after work?", EventController.Event.EventType.work, -15, 60));
        WorkEventList.Add(new EventController.Event("Go for an overseas business trip?", EventController.Event.EventType.work, -20, 80));
        WorkEventList.Add(new EventController.Event("Attend company certified training course?", EventController.Event.EventType.work, -20, 80));
        WorkEventList.Add(new EventController.Event("Lead bonding initative in your department?", EventController.Event.EventType.work, -25, 100));
    }


    static void InitialiseFriendEventList() {
        FriendEventList.Clear();

        FriendEventList.Add(new EventController.Event("Friend: Eh, I need to borrow some money, could you spot me $20?", EventController.Event.EventType.friend, 0, -20));
        FriendEventList.Add(new EventController.Event("Friend: Could you help me book a Grab?", EventController.Event.EventType.friend, 0, -20));
        FriendEventList.Add(new EventController.Event("Friend: Yo, are you going for the secondary school class gathering?", EventController.Event.EventType.friend, -0, -40));
        FriendEventList.Add(new EventController.Event("Friend: I don't know how to propose to my girlfriend leh, can you give me some advice?", EventController.Event.EventType.friend, -0, -40));
        FriendEventList.Add(new EventController.Event("Friend: My mum needs an emergency surgery but I need the money by tonight, do you think you can help me?", EventController.Event.EventType.friend, -0, -100));
        FriendEventList.Add(new EventController.Event("Friend: Supper?", EventController.Event.EventType.friend, -5, -20));
        FriendEventList.Add(new EventController.Event("Friend: We're going to watch Crazy Rich Asians! Want to come?", EventController.Event.EventType.friend, -5, -20));
        FriendEventList.Add(new EventController.Event("Friend: Wanna go for the food festival with me?", EventController.Event.EventType.friend, -5, -20));
        FriendEventList.Add(new EventController.Event("Friend: You free to go and sing karaoke this weekend?", EventController.Event.EventType.friend, -5, -20));
        FriendEventList.Add(new EventController.Event("Friend: I'm graduating! Can you make it down for the ceremony?", EventController.Event.EventType.friend, -5, -60));
        FriendEventList.Add(new EventController.Event("Friend: Wanna hit the gym together?", EventController.Event.EventType.friend, -10, -40));
        FriendEventList.Add(new EventController.Event("Friend: I'm turning 22 this Wednesday, can you make it for my party?", EventController.Event.EventType.friend, -10, -40));
        FriendEventList.Add(new EventController.Event("Friend: I just broke up...I need some comforting.", EventController.Event.EventType.friend, -10, -40));
        FriendEventList.Add(new EventController.Event("Friend: Sup! My gig's at Clarke Quay tonight. Are you coming?", EventController.Event.EventType.friend, -10, -40));
        FriendEventList.Add(new EventController.Event("Friend: I just moved into my new flat! Can you make it for my housewarming?", EventController.Event.EventType.friend, -10, -60));
        FriendEventList.Add(new EventController.Event("Friend: Hey! I'm landing in Singapore today, wanna catch a meal together?", EventController.Event.EventType.friend, -15, -60));
        FriendEventList.Add(new EventController.Event("Friend: It's TGIW! Wanna go club with us?", EventController.Event.EventType.friend, -15, -60));
        FriendEventList.Add(new EventController.Event("Friend: We're planning a getaway to Taiwan for a week! Can take leave anot?", EventController.Event.EventType.friend, -10, -100));
        FriendEventList.Add(new EventController.Event("Friend: I'm getting hitched! Can you make it for my wedding?", EventController.Event.EventType.friend, -15, -100));
        FriendEventList.Add(new EventController.Event("Friend: Free to go on a staycation?", EventController.Event.EventType.friend, -15, -100));
    }

    static void InitialiseParentEventList() {
        ParentEventList.Clear();

        ParentEventList.Add(new EventController.Event("Mum: Come and watch Wheel of Fortune with us! Very exciting!", EventController.Event.EventType.parent, -5, 0));
        ParentEventList.Add(new EventController.Event("Dad: Wanna watch the soccer game with me?", EventController.Event.EventType.parent, -5, 0));
        ParentEventList.Add(new EventController.Event("Parents: Do you have time to grab brunch with us?", EventController.Event.EventType.parent, -5, 0));
        ParentEventList.Add(new EventController.Event("Parents: We're going to visit your grandparents today. Do you want to come?", EventController.Event.EventType.parent, -10, 0));
        ParentEventList.Add(new EventController.Event("Mum: Can you help me cook tonight?", EventController.Event.EventType.parent, -10, 0));
        ParentEventList.Add(new EventController.Event("Mum: Aiya, I don't know how to use Facebook. Got time to teach me?", EventController.Event.EventType.parent, -10, 0));
        ParentEventList.Add(new EventController.Event("Dad: Help! Our wifi is gone! Help me find it!", EventController.Event.EventType.parent, -10, 0));
        ParentEventList.Add(new EventController.Event("Parents: We bought a new couch, could you help us move it?", EventController.Event.EventType.parent, -15, 0));
        ParentEventList.Add(new EventController.Event("Dad: Help me wash the car later?", EventController.Event.EventType.parent, -20, 0));
        ParentEventList.Add(new EventController.Event("Parents: Are you able to have dinner with us tonight?", EventController.Event.EventType.parent, -5, -20));
        ParentEventList.Add(new EventController.Event("Mum: Can you help me buy and change the shower head? It's broken.", EventController.Event.EventType.parent, -10, -20));
        ParentEventList.Add(new EventController.Event("Parents: Your auntie is getting married. Do you want to attend her wedding with us?", EventController.Event.EventType.parent, -10, -20));
        ParentEventList.Add(new EventController.Event("Parents: Need your help to buy and carry groceries. Are you available?", EventController.Event.EventType.parent, -10, -30));
        ParentEventList.Add(new EventController.Event("Mum: Your dad's birthday is coming soon! Want to bake something for him?", EventController.Event.EventType.parent, -15, -10));
        ParentEventList.Add(new EventController.Event("Parents: We want to go visit Gardens by the Bay, do you want to come?", EventController.Event.EventType.parent, -15, -40));
        ParentEventList.Add(new EventController.Event("Parents: We're celebrating our 30th wedding anniversary! Will you be celebrating with us again?", EventController.Event.EventType.parent, -15, -60));
        ParentEventList.Add(new EventController.Event("Parents: We're going out shopping! Wanna come?", EventController.Event.EventType.parent, -15, -60));
        ParentEventList.Add(new EventController.Event("Dad: Your mum's birthday is coming soon! Do you want to make something for her?", EventController.Event.EventType.parent, -20, -10));
        ParentEventList.Add(new EventController.Event("Parents: We're going for a family day at Sentosa! Are you free?", EventController.Event.EventType.parent, -20, -15));
        ParentEventList.Add(new EventController.Event("Parents: We're planning a trip to Johor Bahru this weekend. Can you join us?", EventController.Event.EventType.parent, -20, -60));
    }
}
