using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    public float dashSpeed;
    Vector2 dire;
    Vector2 move;

    PlayerStamina PS;

    public static bool canMove = true;
    void Start ()
    {
      rb = GetComponent<Rigidbody2D>();
      PS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStamina>();
	}
	
	void Update ()
    {
        dire = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        move = dire.normalized * speed;


    }
    private void FixedUpdate()
    {
        if (canMove == true)
        {
            if ((dire.x > 0 || dire.x < 0) && Input.GetMouseButtonDown(1) && PS.currentStamina >= 12f)
            {
                rb.MovePosition(rb.position + move * Time.fixedDeltaTime * dashSpeed);
                PS.StaminaDecrease();
            }

            else if ((dire.y > 0 || dire.y < 0) && Input.GetMouseButtonDown(1) && PS.currentStamina >= 12f)
            {
                rb.MovePosition(rb.position + move * Time.fixedDeltaTime * dashSpeed);
                PS.StaminaDecrease();
            }
            else
            {
                rb.MovePosition(rb.position + move * Time.fixedDeltaTime);

                if (PS.currentStamina <= 100)
                {
                    PS.StaminaIncrease();
                }
            }
        }
        
    }

    
}
