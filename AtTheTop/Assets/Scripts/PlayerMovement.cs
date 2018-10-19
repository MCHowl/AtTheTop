using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float moveDistance = 10;

    [SerializeField]
    float walkTime = 0.25f;

    [SerializeField]
    float[] Upgrade2Effect, Upgrade3Effect, Upgrade4Effect, Upgrade5Effect;

    [SerializeField]
    RuntimeAnimatorController[] animatorControllers;

    float nextWalkTime = 0;
    float nextAutoWalkTime = 0;

    Animator animator;
    Rigidbody rb;

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        switch(PlayerPrefs.GetInt("character")) {
            case (1):
                animator.runtimeAnimatorController = animatorControllers[0] as RuntimeAnimatorController;
                break;
            case (2):
                animator.runtimeAnimatorController = animatorControllers[1] as RuntimeAnimatorController;
                break;
            default:
                break;
        }
    }

    void Update() {
        if (!GameController.Paused) {
            // Manual Clicks
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.CompareTag("Player") && Time.time >= nextWalkTime) {
                        PlayerAction();
                        nextWalkTime = Time.time + walkTime;
                    }
                }
            }

            //Auto Clicks
            if (Time.time >= nextAutoWalkTime && GameData.Upgrade1Level != 0) {
                PlayerAction();

                switch (GameData.Upgrade1Level) {
                    case (1):
                        nextAutoWalkTime = Time.time + 1f;
                        break;
                    case (2):
                        nextAutoWalkTime = Time.time + 0.5f;
                        break;
                    case (3):
                        nextAutoWalkTime = Time.time + 0.25f;
                        break;
                    default:
                        Debug.LogWarning("Upgrade level too high");
                        break;
                }
            }
        } else {
            //StopCoroutine("WalkAnimation");
            animator.SetBool("isPlayerWalking", false);
        }
    }

    private void PlayerAction() {
        GameData.CurrentEnergy = Mathf.Max(0, GameData.CurrentEnergy - 1 / (Upgrade4Effect[GameData.Upgrade4Level] + Upgrade5Effect[GameData.Upgrade5Level]));

        if (GameController.InOffice) {
            GameData.CurrentMoney += 1 * (1 + Upgrade2Effect[GameData.Upgrade2Level] + Upgrade3Effect[GameData.Upgrade3Level]);
            TaskController.WorkDone += 1;
            //StopCoroutine("WalkAnimation");
            animator.SetBool("isPlayerWalking", false);
        } else {
            //StopCoroutine("WalkAnimation");
            StartCoroutine(WalkAnimation(0.25f));
        }
    }

    IEnumerator WalkAnimation(float walkTime) {
        animator.SetBool("isPlayerWalking", true);

        Vector3 end = transform.position + transform.right * moveDistance;
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon) {
            Vector3 newPosition = Vector3.MoveTowards(rb.position, end, Time.deltaTime / walkTime);
            rb.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }

        animator.SetBool("isPlayerWalking", false);
        yield return null;
    }
}
