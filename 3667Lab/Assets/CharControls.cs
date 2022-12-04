using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControls : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] int speed = 15;
    [SerializeField] bool isFaceRight = true;
    [SerializeField] bool jumpPressed = false;
	[SerializeField] float jumpForce = 500.0f;
	[SerializeField] bool isGrounded = true;

    [SerializeField] Vector2 projectileSize = new Vector2(0.3f, 0.3f);

    // Start is called before the first frame update
    void Start()
    {
        if (rigid ==null){
            rigid = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump")){
            jumpPressed = true;
        }
        if (Input.GetButtonDown("Fire1")){
            shootPin();
        }
    }

    //called multiple times per frame (Use for physics)
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement*speed, rigid.velocity.y);
        if ((movement < 0 && isFaceRight) || (movement > 0 && !isFaceRight)){
            Flip();
        }
        if (jumpPressed && isGrounded){
            Jump();
        }
    }

    void Flip()
    {
        transform.Rotate(0,180,0);
        isFaceRight = !isFaceRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
		rigid.AddForce(new Vector2(0, jumpForce));
		jumpPressed = false;
		isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground"){
			isGrounded = true;
        }
	}

    void shootPin()
    {
        GameObject reservePin = transform.Find("Pin").gameObject;
        GameObject shotPin = Instantiate(reservePin);
        shotPin.transform.position = reservePin.transform.position;
        shotPin.transform.localScale = projectileSize;
        if (!isFaceRight){
            shotPin.transform.Rotate(0,180,0);
        }
        shotPin.GetComponent<SpriteRenderer>().enabled = true;
        shotPin.GetComponent<PinScript>().enabled = true;
        shotPin.GetComponent<BoxCollider2D>().enabled = true;
    }
}
