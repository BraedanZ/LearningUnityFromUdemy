using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public GameObject losePanel;

    public Text healthDisplay;

    public float speed;
    public int health;
    private float input;

    Rigidbody2D rigidBody;
    Animator animator;

    public float startDashTime;
    private float dashTime;
    public float extraSpeed;
    private bool isDashing;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        healthDisplay.text = health.ToString();
    }

    // Update is called once per frame
    void Update() {
        if (input != 0) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }

        if (input < 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (input > 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false) {
            speed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
        }
        if (dashTime <= 0 && isDashing == true) {
            isDashing = false;
            speed -= extraSpeed;
        } else {
            dashTime -= Time.deltaTime;
        }
    }

    void FixedUpdate() {
        input = Input.GetAxisRaw("Horizontal");

        rigidBody.velocity = new Vector2(input * speed, rigidBody.velocity.y);
    }
    
    public void TakeDamage(int damageAmount) {
        health -= damageAmount;
        healthDisplay.text = health.ToString();

        if (health <= 0) {
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
