using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventList : MonoBehaviour {

    public static List<EventController.Event> WorkEventList = new List<EventController.Event>();
    public static List<EventController.Event> FriendEventList = new List<EventController.Event>();
    public static List<EventController.Event> ParentEventList = new List<EventController.Event>();

    // First number is the energy gained. Second number is the money earned.
    // Example: If an event gives the player -10 Energy, +50 Money,
    //          it should look like this ("eventname", -10, 50)

    public static void InitialiseWorkEventList() {
        WorkEventList.Clear();

        WorkEventList.Add(new EventController.Event("You have a new report to finish by 9am. Work overtime to finish it?", -3, 5));
        WorkEventList.Add(new EventController.Event("Your coworker is on leave. Cover duties for him?", -5, 8));
        WorkEventList.Add(new EventController.Event("Take on a new joint venture for your company?", -10, 15));
        WorkEventList.Add(new EventController.Event("Engage another client?", -5, 10));
        WorkEventList.Add(new EventController.Event("Attend a networking event after work?", -3, 4));
        WorkEventList.Add(new EventController.Event("Take some time to polish your business presentation slides?", -4, 7));
        WorkEventList.Add(new EventController.Event("Practice your pitch for tomorrow's board meeting again?", -3, 7));
        WorkEventList.Add(new EventController.Event("Fix your coworker's mistakes in the project report?", -2, 3));
        WorkEventList.Add(new EventController.Event("Propose and execute new initiatives to foster work cohesion?", -5, 12));
        WorkEventList.Add(new EventController.Event("Go for an overseas business trip?", -15, 30));
        WorkEventList.Add(new EventController.Event("Go to your boss's house for Chinese New Year?", -2, 4));
        WorkEventList.Add(new EventController.Event("Attend company certified training course?", -5, 8));
        WorkEventList.Add(new EventController.Event("Attend optional lunch meeting for managers and executives?", -1, 5));
        WorkEventList.Add(new EventController.Event("Help boss with some extra admin work?", -5, 7));
        WorkEventList.Add(new EventController.Event("Attend Networking 101 course?", -2, 4));
        WorkEventList.Add(new EventController.Event("Lead bonding initative in your department?", -6, 11));
        WorkEventList.Add(new EventController.Event("Rush report for a demanding client?", -7, 20));
        WorkEventList.Add(new EventController.Event("Meet new coworker for lunch?", -2, 3));
        WorkEventList.Add(new EventController.Event("Make sure reports are in order for an upcoming audit?", -10, 22));
        WorkEventList.Add(new EventController.Event("Attend government's new SkillsFuture programme?", -1, 10));
    }


    public static void InitialiseFriendEventList() {
        FriendEventList.Clear();

        FriendEventList.Add(new EventController.Event("It's your friend's birthday! She's hosting a party. Attend?", 0, -3));
        FriendEventList.Add(new EventController.Event("Your friends want to go for supper. Accept?", 0, -5));
        FriendEventList.Add(new EventController.Event("It's Ladies Night. Your friends want to go out for drinks! Party?", 0, -10));
        FriendEventList.Add(new EventController.Event("Your friends want to watch a movie. Go with them?", 0, -2));
        FriendEventList.Add(new EventController.Event("Your friends want to sing karaoke. Join them?", 0, -3));
        FriendEventList.Add(new EventController.Event("Your friend is finally getting married. Accept their wedding invitation?", -5, 0));
        FriendEventList.Add(new EventController.Event("Your friend needs to borrow some money from you. Help them?", 0, -15));
        FriendEventList.Add(new EventController.Event("Your friends want to travel to Taiwan for a week. Take leave?", 0, -20));
        FriendEventList.Add(new EventController.Event("Your friend just broke up and needs comfort. Spend some time with them?", -3, -3));
        FriendEventList.Add(new EventController.Event("Attend new exercise fad class with your friend?", 5, -5));
        FriendEventList.Add(new EventController.Event("Call a cab for a friend?", 0, -4));
        FriendEventList.Add(new EventController.Event("Join the new book club with friends?", -3, 0));
        FriendEventList.Add(new EventController.Event("Go for your secondary school gathering dinner?", 0, -2));
        FriendEventList.Add(new EventController.Event("Your friend just moved to a new place! Buy them a housewarming gift?", 0, -7));
        FriendEventList.Add(new EventController.Event("Your friend needs help proposing to his partner. Help him?", -5, -5));
        FriendEventList.Add(new EventController.Event("Support your friend's new cafe?", 0, -10));
        FriendEventList.Add(new EventController.Event("Staycation with friends?", 0, -80));
        FriendEventList.Add(new EventController.Event("Your friend's mom needs an emergency surgery. Lend her some money?", 0, -20));
        FriendEventList.Add(new EventController.Event("Your friend is performing tonight! Support and attend his gig?", 0, -7));
        FriendEventList.Add(new EventController.Event("Catch up and buy a meal for a friend you met overseas that is coming to visit?", 0, -5));
    }

    public static void InitialiseParentEventList() {
        ParentEventList.Clear();

        ParentEventList.Add(new EventController.Event("Have dinner with your parents?", -3, 0));
        ParentEventList.Add(new EventController.Event("Help mom with the cooking?", -2, 0));
        ParentEventList.Add(new EventController.Event("Watch soccer with dad?", -2, 0));
        ParentEventList.Add(new EventController.Event("Install new shower head for mom?", -5, 0));
        ParentEventList.Add(new EventController.Event("Watch Wheel of Fortune with parents?", -1, 0));
        ParentEventList.Add(new EventController.Event("Attend a wedding with your parents?", -2, 0));
        ParentEventList.Add(new EventController.Event("Help your parents move some furniture?", -4, 0));
        ParentEventList.Add(new EventController.Event("Teach mom how to use Facebook?", -10, 0));
        ParentEventList.Add(new EventController.Event("Celebrate your parent's wedding anniversary?", -2, -10));
        ParentEventList.Add(new EventController.Event("Help your parents clean the house?", -5, 0));
        ParentEventList.Add(new EventController.Event("Have brunch with your parents?", -3, 0));
        ParentEventList.Add(new EventController.Event("Help dad 'find' the Wifi?", -8, 0));
        ParentEventList.Add(new EventController.Event("JB road trip with parents?", -2, -5));
        ParentEventList.Add(new EventController.Event("Visit Gardens by the Bay with parents?", -3, 0));
        ParentEventList.Add(new EventController.Event("Attend your cousin's housewarming party with your parents?", -2, 0));
        ParentEventList.Add(new EventController.Event("Spend some time chilling at Sentosa with your parents?", -1, 0));
        ParentEventList.Add(new EventController.Event("Bake a birthday cake for dad?", -3, 0));
        ParentEventList.Add(new EventController.Event("Go gift shopping with your parnets?", -2, -5));
        ParentEventList.Add(new EventController.Event("Make mom a special birthday gift?", -6, 0));
        ParentEventList.Add(new EventController.Event("Help parents do the groceries?", -2, -5));
    }
}
