using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour {

    public GameObject TaskUi;
    public TMPro.TextMeshProUGUI TaskUiText;
    public string[] PossibleTasks;

    public static int WorkDone { get; set; }

    int taskQuantity = 5;
    string[] currentTasks;

    int[] currentTasksEnergy;
    int baseTaskEnergy = 20;
    int totalTaskEnergy;

    void Start () {
        TaskUi.SetActive(false);

        currentTasks = new string[taskQuantity];
        currentTasksEnergy = new int[taskQuantity];

        totalTaskEnergy = GetNewTasks();

        WorkDone = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.InOffice) {
            if (!TaskUi.activeSelf) {
                TaskUi.SetActive(true);
            }

            if (WorkDone >= totalTaskEnergy) {
                WorkDone = 0;
                totalTaskEnergy = GetNewTasks();
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

        } else {
            TaskUi.SetActive(false);
        }
	}

    int GetNewTasks() {
        int energyTotal = 0;

        for (int i = 0; i < taskQuantity; i++) {
            currentTasks[i] = PossibleTasks[Random.Range(0, PossibleTasks.Length)];
            currentTasksEnergy[i] = baseTaskEnergy + Random.Range(-GameData.CurrentDay * 5, GameData.CurrentDay * 5);
            energyTotal += currentTasksEnergy[i];
        }

        return energyTotal;
    }
}
