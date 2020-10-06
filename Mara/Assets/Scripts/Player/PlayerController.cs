using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update

    public float speed = 20.0f;
    public static bool facingRight = true;
    private Rigidbody2D rb;
    private Animator playerAnimator;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float moveX = Input.GetAxis("Horizontal");

        if (moveX == 0) playerAnimator.Play("Stay");
        else Walk(moveX, facingRight);

        if (moveX < 0 && facingRight || moveX > 0 && !facingRight) Flip();
    }

    void Flip() {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }

    void Walk(float move, bool isRight) {
        if (isRight) rb.transform.Translate(move * speed * Time.deltaTime, 0, 0);
        else rb.transform.Translate(-move * speed * Time.deltaTime, 0, 0);

        playerAnimator.StopPlayback();
        playerAnimator.Play("Walk");
    }
}
