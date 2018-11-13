using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float moveDistance = 10;

    [SerializeField]
    float walkDelay = 0.25f;

    [SerializeField]
    float[] Upgrade2Effect, Upgrade3Effect, Upgrade4Effect, Upgrade5Effect;

    [SerializeField]
    RuntimeAnimatorController[] animatorControllers;

    [SerializeField]
    AudioSource WalkSound, WorkSound;

    float nextWalkTime = 0;
    float nextAutoWalkTime = 0;

	public float nonWorkReduction = 0.75f;

    Animator animator;
    Rigidbody2D rb2d;

    private void Start() {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        switch (PlayerPrefs.GetInt("character")) {
            case (1):
                animator.runtimeAnimatorController = animatorControllers[0] as RuntimeAnimatorController;
                break;
            case (2):
                animator.runtimeAnimatorController = animatorControllers[1] as RuntimeAnimatorController;
                break;
            default:
                break;
        }

		InitialiseWorkSound();
	}

    void Update() {
        if (!GameController.Paused) {
            // Manual Clicks
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit == true) {
                    if (hit.collider.CompareTag("Player") && Time.time >= nextWalkTime) {
                        PlayerAction();
                        nextWalkTime = Time.time + walkDelay;

                        if (nextAutoWalkTime - nextWalkTime <= walkDelay) {
                            nextAutoWalkTime = nextWalkTime;
                        }
                    }
                }
            }

            //Auto Clicks
            if (Time.time >= nextAutoWalkTime && GameData.Upgrade1Level != 0) {
                PlayerAction();

                switch (GameData.Upgrade1Level) {
                    case (1):
                        nextAutoWalkTime = Time.time + 1f;
                        nextWalkTime = Time.time + walkDelay;
                        break;
                    case (2):
                        nextAutoWalkTime = Time.time + 0.5f;
                        nextWalkTime = Time.time + walkDelay;
                        break;
                    case (3):
                        nextAutoWalkTime = Time.time + 0.25f;
                        nextWalkTime = Time.time + walkDelay;
                        break;
                    default:
                        Debug.LogWarning("Upgrade level too high");
                        break;
                }
            }
        } else {
            StopCoroutine("WalkAnimation");
            animator.SetBool("isPlayerWalking", false);
        }
    }

    private void PlayerAction() {
        if (GameController.InOffice) {
			GameData.CurrentEnergy = Mathf.Max(0, GameData.CurrentEnergy - 1f / (Upgrade4Effect[GameData.Upgrade4Level] + Upgrade5Effect[GameData.Upgrade5Level]));
			GameData.CurrentMoney += 1 * (1 + Upgrade2Effect[GameData.Upgrade2Level] + Upgrade3Effect[GameData.Upgrade3Level]);
            TaskController.WorkDone += 1;

			StartCoroutine(PlayWorkSound());

            if (!animator.GetBool("isPlayerWorking")) {
                animator.SetBool("isPlayerWorking", true);
            }
            
            StopCoroutine("WalkAnimation");
            animator.SetBool("isPlayerWalking", false);
        } else {
			GameData.CurrentEnergy = (Mathf.Max(0, GameData.CurrentEnergy - (1f / (Upgrade4Effect[GameData.Upgrade4Level] + Upgrade5Effect[GameData.Upgrade5Level])) * nonWorkReduction));

            if (animator.GetBool("isPlayerWorking")) {
                animator.SetBool("isPlayerWorking", false);
            }

            WalkSound.Play();
            StopCoroutine("WalkAnimation");
            StartCoroutine(WalkAnimation(0.15f));
        }
    }

    IEnumerator WalkAnimation(float walkTime) {
        animator.SetBool("isPlayerWalking", true);

        Vector3 end = transform.position + transform.right * moveDistance;
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon) {
            Vector3 newPosition = Vector3.MoveTowards(rb2d.position, end, Time.deltaTime / walkTime * moveDistance);
            rb2d.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }

        animator.SetBool("isPlayerWalking", false);
        yield return null;
    }

	void InitialiseWorkSound() {
		WorkSound.mute = true;
		WorkSound.Play();
		WorkSound.Pause();
		WorkSound.mute = false;
	}

	private IEnumerator PlayWorkSound() {
		WorkSound.UnPause();
		yield return new WaitForSeconds(0.15f);
		WorkSound.Pause();
	}
}
