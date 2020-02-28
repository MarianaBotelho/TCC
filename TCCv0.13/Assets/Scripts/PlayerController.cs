using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{
	public float speed;
	public Joystick joystick;
	
	private Rigidbody2D rb;
	private Vector2 moveVelocity;
	
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
		
        Vector2 moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
		
		moveVelocity = moveInput.normalized * speed;
    }
	
	void FixedUpdate(){
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
	}
}
