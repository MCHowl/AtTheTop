using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float moveDistance = 10;

    [SerializeField]
    float walkTime = 0.25f;
    float nextWalkTime = 0;

    Animator animator;
    Rigidbody rb;
    GameController gameController;

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent <GameController>();
        Debug.Assert(gameController != null);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !gameController.Paused) {
            if (Time.time >= nextWalkTime) {
                nextWalkTime = Time.time + walkTime;
                StartCoroutine(WalkAnimation(0.25f));
            }
        }
    }

    IEnumerator WalkAnimation(float walkTime) {
        animator.SetBool("isPlayerWalking", true);

        Vector3 end = transform.position + transform.right * moveDistance;
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb.position, end, Time.deltaTime / walkTime);
            rb.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }

        animator.SetBool("isPlayerWalking", false);
        yield return null;
    }
}
