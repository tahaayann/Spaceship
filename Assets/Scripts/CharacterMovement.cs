using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CharacterController : MonoBehaviour
{
    public float defaultMoveSpeed = 5f;
    public float moveSpeed = 5f;
    public float dashSpeed = 10.0f;

    public float dashDuration = 2f;
    public float dashTimeRemaining;

    public float _dashCooldown = 2f;
    public float _dashCooldownRemaining = 0;

    public bool isDashing = false;

    public Rigidbody2D rb;
    public PlayerHealth playerHealth;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.JoystickButton1)) && !isDashing && _dashCooldownRemaining <= 0 && movement != Vector2.zero)
        {
            isDashing = true;
            dashTimeRemaining = dashDuration;
            _dashCooldownRemaining = _dashCooldown;
            rb.velocity = movement.normalized;
            FindObjectOfType<AudioManager>().Play("DashEffect");
            playerHealth.DashImmunity();
            

        }
        if (_dashCooldownRemaining > 0)
        {
            _dashCooldownRemaining -= Time.deltaTime;
        }


    }
    private void FixedUpdate()
    {
        if (isDashing)
        {

            rb.velocity = dashSpeed * movement.normalized;
            dashTimeRemaining -= Time.deltaTime;
            if (dashTimeRemaining <= 0)
            {
                isDashing = false;
                rb.velocity = Vector2.zero;

            }

        }
        else
        {
            rb.velocity = moveSpeed * movement.normalized;

        }


    }
    public void ResetSpeed()
    {
        moveSpeed = defaultMoveSpeed;

    }

}
