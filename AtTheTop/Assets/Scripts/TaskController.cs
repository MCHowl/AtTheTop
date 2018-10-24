using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour {

    public GameObject TaskUi;
    public TMPro.TextMeshProUGUI TaskUiText;
    public string[] PossibleTasks;

    public static int WorkDone { get; set; }

    string currentTask;
    int taskEnergy = 100;

    void Start () {
        TaskUi.SetActive(false);
        currentTask = GetNewTask();

        WorkDone = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.InOffice) {
            if (!TaskUi.activeSelf) {
                TaskUi.SetActive(true);
            }
            
            if (WorkDone >= taskEnergy) {
                WorkDone = 0;
                currentTask = GetNewTask();
            }
            
            TaskUiText.text = currentTask + ": " + WorkDone + "/" + taskEnergy;
        } else {
            TaskUi.SetActive(false);
        }
	}

    string GetNewTask() {
        return PossibleTasks[Random.Range(0, PossibleTasks.Length)];
    }
}
