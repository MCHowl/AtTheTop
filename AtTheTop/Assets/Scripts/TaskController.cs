using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour {

    public GameObject TaskUi;
    public TMPro.TextMeshProUGUI TaskUiText;
    public GameObject OvertimeUi;
    public string[] PossibleTasks;

    public static int WorkDone { get; set; }

    int taskQuantity = 5;
    string[] currentTasks;

    int[] currentTasksEnergy;
    int baseTaskEnergy = 30;
    int totalTaskEnergy;

    void Start () {
        TaskUi.SetActive(false);
        OvertimeUi.SetActive(false);

        currentTasks = new string[taskQuantity];
        currentTasksEnergy = new int[taskQuantity];

        totalTaskEnergy = GetNewTasks();

        WorkDone = 0;
	}
	
	void Update () {
		if (GameController.InOffice) {
            if (!TaskUi.activeSelf) {
                TaskUi.SetActive(true);
            }

            TaskUiText.text = "";
            int remainingEnergy = WorkDone;

            for (int i = 0; i < taskQuantity; i++) {

                TaskUiText.text += currentTasks[i] + ": ";

                if (remainingEnergy < currentTasksEnergy[i]) {
                    TaskUiText.text += remainingEnergy;
                } else {
                    TaskUiText.text += currentTasksEnergy[i];
                }

                TaskUiText.text += "/" + currentTasksEnergy[i] + "\n";

                remainingEnergy = Mathf.Max(0, remainingEnergy - currentTasksEnergy[i]);
            }

            if (WorkDone >= totalTaskEnergy) {
                GameController.Paused = true;
                TaskUiText.text = "You've completed your work for the day. But there's always money waiting to be earned. Work overtime?";
                OvertimeUi.SetActive(true);
            }

        } else {
            TaskUi.SetActive(false);
        }
	}

    int GetNewTasks() {
        int energyTotal = 0;

        for (int i = 0; i < taskQuantity; i++) {
            currentTasks[i] = PossibleTasks[Random.Range(0, PossibleTasks.Length)];
            currentTasksEnergy[i] = baseTaskEnergy + Random.Range(-GameData.CurrentDay * 2, GameData.CurrentDay * 5);
            energyTotal += currentTasksEnergy[i];
        }

        return energyTotal;
    }

    public void Overtime() {
        OvertimeUi.SetActive(false);
        GameController.Paused = false;
        WorkDone = 0;
        totalTaskEnergy = GetNewTasks();
    }

    public void GoHome() {
        OvertimeUi.SetActive(false);
        GameController.Paused = false;
        GameController.InOffice = false;
    }
}
