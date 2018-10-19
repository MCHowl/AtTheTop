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

    public static void InitialiseWorkEventList() {
        WorkEventList.Clear();

        WorkEventList.Add(new EventController.Event("You have a new report to finish by 9am. Work overtime to finish it?", EventController.Event.EventType.work, -3, 5));
        WorkEventList.Add(new EventController.Event("Your coworker is on leave. Cover duties for him?", EventController.Event.EventType.work, -5, 8));
        WorkEventList.Add(new EventController.Event("Take on a new joint venture for your company?", EventController.Event.EventType.work, -10, 15));
        WorkEventList.Add(new EventController.Event("Engage another client?", EventController.Event.EventType.work, -5, 10));
        WorkEventList.Add(new EventController.Event("Attend a networking event after work?", EventController.Event.EventType.work, -3, 4));
        WorkEventList.Add(new EventController.Event("Take some time to polish your business presentation slides?", EventController.Event.EventType.work, -4, 7));
        WorkEventList.Add(new EventController.Event("Practice your pitch for tomorrow's board meeting again?", EventController.Event.EventType.work, -3, 7));
        WorkEventList.Add(new EventController.Event("Fix your coworker's mistakes in the project report?", EventController.Event.EventType.work, -2, 3));
        WorkEventList.Add(new EventController.Event("Propose and execute new initiatives to foster work cohesion?", EventController.Event.EventType.work, -5, 12));
        WorkEventList.Add(new EventController.Event("Go for an overseas business trip?", EventController.Event.EventType.work, -15, 30));
        WorkEventList.Add(new EventController.Event("Go to your boss's house for Chinese New Year?", EventController.Event.EventType.work, -2, 4));
        WorkEventList.Add(new EventController.Event("Attend company certified training course?", EventController.Event.EventType.work, -5, 8));
        WorkEventList.Add(new EventController.Event("Attend optional lunch meeting for managers and executives?", EventController.Event.EventType.work, -1, 5));
        WorkEventList.Add(new EventController.Event("Help boss with some extra admin work?", EventController.Event.EventType.work, -5, 7));
        WorkEventList.Add(new EventController.Event("Attend Networking 101 course?", EventController.Event.EventType.work, -2, 4));
        WorkEventList.Add(new EventController.Event("Lead bonding initative in your department?", EventController.Event.EventType.work, -6, 11));
        WorkEventList.Add(new EventController.Event("Rush report for a demanding client?", EventController.Event.EventType.work, -7, 20));
        WorkEventList.Add(new EventController.Event("Meet new coworker for lunch?", EventController.Event.EventType.work, -2, 3));
        WorkEventList.Add(new EventController.Event("Make sure reports are in order for an upcoming audit?", EventController.Event.EventType.work, -10, 22));
        WorkEventList.Add(new EventController.Event("Attend government's new SkillsFuture programme?", EventController.Event.EventType.work, -1, 10));
    }


    public static void InitialiseFriendEventList() {
        FriendEventList.Clear();

        FriendEventList.Add(new EventController.Event("It's your friend's birthday! She's hosting a party. Attend?", EventController.Event.EventType.friend, 0, -3));
        FriendEventList.Add(new EventController.Event("Your friends want to go for supper. Accept?", EventController.Event.EventType.friend, 0, -5));
        FriendEventList.Add(new EventController.Event("It's Ladies Night. Your friends want to go out for drinks! Party?", EventController.Event.EventType.friend, 0, -10));
        FriendEventList.Add(new EventController.Event("Your friends want to watch a movie. Go with them?", EventController.Event.EventType.friend, 0, -2));
        FriendEventList.Add(new EventController.Event("Your friends want to sing karaoke. Join them?", EventController.Event.EventType.friend, 0, -3));
        FriendEventList.Add(new EventController.Event("Your friend is finally getting married. Accept their wedding invitation?", EventController.Event.EventType.friend, -5, 0));
        FriendEventList.Add(new EventController.Event("Your friend needs to borrow some money from you. Help them?", EventController.Event.EventType.friend, 0, -15));
        FriendEventList.Add(new EventController.Event("Your friends want to travel to Taiwan for a week. Take leave?", EventController.Event.EventType.friend, 0, -20));
        FriendEventList.Add(new EventController.Event("Your friend just broke up and needs comfort. Spend some time with them?", EventController.Event.EventType.friend, -3, -3));
        FriendEventList.Add(new EventController.Event("Attend new exercise fad class with your friend?", EventController.Event.EventType.friend, 5, -5));
        FriendEventList.Add(new EventController.Event("Call a cab for a friend?", EventController.Event.EventType.friend, 0, -4));
        FriendEventList.Add(new EventController.Event("Join the new book club with friends?", EventController.Event.EventType.friend, -3, 0));
        FriendEventList.Add(new EventController.Event("Go for your secondary school gathering dinner?", EventController.Event.EventType.friend, 0, -2));
        FriendEventList.Add(new EventController.Event("Your friend just moved to a new place! Buy them a housewarming gift?", EventController.Event.EventType.friend, 0, -7));
        FriendEventList.Add(new EventController.Event("Your friend needs help proposing to his partner. Help him?", EventController.Event.EventType.friend, -5, -5));
        FriendEventList.Add(new EventController.Event("Support your friend's new cafe?", EventController.Event.EventType.friend, 0, -10));
        FriendEventList.Add(new EventController.Event("Staycation with friends?", EventController.Event.EventType.friend, 0, -80));
        FriendEventList.Add(new EventController.Event("Your friend's mom needs an emergency surgery. Lend her some money?", EventController.Event.EventType.friend, 0, -20));
        FriendEventList.Add(new EventController.Event("Your friend is performing tonight! Support and attend his gig?", EventController.Event.EventType.friend, 0, -7));
        FriendEventList.Add(new EventController.Event("Catch up and buy a meal for a friend you met overseas that is coming to visit?", EventController.Event.EventType.friend, 0, -5));
    }

    public static void InitialiseParentEventList() {
        ParentEventList.Clear();

        ParentEventList.Add(new EventController.Event("Have dinner with your parents?", EventController.Event.EventType.parent, -3, 0));
        ParentEventList.Add(new EventController.Event("Help mom with the cooking?", EventController.Event.EventType.parent, -2, 0));
        ParentEventList.Add(new EventController.Event("Watch soccer with dad?", EventController.Event.EventType.parent, -2, 0));
        ParentEventList.Add(new EventController.Event("Install new shower head for mom?", EventController.Event.EventType.parent, -5, 0));
        ParentEventList.Add(new EventController.Event("Watch Wheel of Fortune with parents?", EventController.Event.EventType.parent, -1, 0));
        ParentEventList.Add(new EventController.Event("Attend a wedding with your parents?", EventController.Event.EventType.parent, -2, 0));
        ParentEventList.Add(new EventController.Event("Help your parents move some furniture?", EventController.Event.EventType.parent, -4, 0));
        ParentEventList.Add(new EventController.Event("Teach mom how to use Facebook?", EventController.Event.EventType.parent, -10, 0));
        ParentEventList.Add(new EventController.Event("Celebrate your parent's wedding anniversary?", EventController.Event.EventType.parent, -2, -10));
        ParentEventList.Add(new EventController.Event("Help your parents clean the house?", EventController.Event.EventType.parent, -5, 0));
        ParentEventList.Add(new EventController.Event("Have brunch with your parents?", EventController.Event.EventType.parent, -3, 0));
        ParentEventList.Add(new EventController.Event("Help dad 'find' the Wifi?", EventController.Event.EventType.parent, -8, 0));
        ParentEventList.Add(new EventController.Event("JB road trip with parents?", EventController.Event.EventType.parent, -2, -5));
        ParentEventList.Add(new EventController.Event("Visit Gardens by the Bay with parents?", EventController.Event.EventType.parent, -3, 0));
        ParentEventList.Add(new EventController.Event("Attend your cousin's housewarming party with your parents?", EventController.Event.EventType.parent, -2, 0));
        ParentEventList.Add(new EventController.Event("Spend some time chilling at Sentosa with your parents?", EventController.Event.EventType.parent, -1, 0));
        ParentEventList.Add(new EventController.Event("Bake a birthday cake for dad?", EventController.Event.EventType.parent, -3, 0));
        ParentEventList.Add(new EventController.Event("Go gift shopping with your parnets?", EventController.Event.EventType.parent, -2, -5));
        ParentEventList.Add(new EventController.Event("Make mom a special birthday gift?", EventController.Event.EventType.parent, -6, 0));
        ParentEventList.Add(new EventController.Event("Help parents do the groceries?", EventController.Event.EventType.parent, -2, -5));
    }
}
