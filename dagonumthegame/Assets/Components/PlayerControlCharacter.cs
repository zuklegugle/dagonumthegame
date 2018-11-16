using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlCharacter : MonoBehaviour
{

  Animator characterAnimator;
  Rigidbody2D body;
  float moveHorizontal;
  float moveVertical;
  PlayerInput PlayerInput;

  // Start is called before the first frame update
  void Start()
  {
    characterAnimator = this.GetComponent<Animator>();
    body = this.GetComponent<Rigidbody2D>();
    PlayerInput = this.GetComponent<PlayerInput>();
  }

  // Update is called once per frame
  void Update()
  {
    if (PlayerInput.MoveLeft)
    {
      characterAnimator.SetInteger("State", 1);
    }
    if (PlayerInput.MoveRight)
    {
      characterAnimator.SetInteger("State", 1);
    }

    if (!PlayerInput.MoveLeft &&
        !PlayerInput.MoveRight
        )
    {
      characterAnimator.SetInteger("State", 0);
    }

    //Store the current horizontal input in the float moveHorizontal.
    moveHorizontal = Input.GetAxisRaw("Horizontal");

    //Store the current vertical input in the float moveVertical.
    moveVertical = Input.GetAxisRaw("Vertical");
  }

  void FixedUpdate()
  {

    if (moveHorizontal > 0)
    {
      moveHorizontal = 5;
    }
    if (moveHorizontal < 0)
    {
      moveHorizontal = -5;
    }
    if (moveVertical > 0)
    {
      moveVertical = 5;
    }
    if (moveVertical < 0)
    {
      moveVertical = -5;
    }
    if (moveHorizontal == 0 && moveVertical == 0)
    {
      body.velocity = Vector2.zero;
      body.angularVelocity = 0;
    }

    //Use the two store floats to create a new Vector2 variable movement.
    Vector2 movement = new Vector2(moveHorizontal, moveVertical);

    //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
    body.AddForce(movement * 10);
    if (Input.GetKeyDown("left ctrl"))
    {
      characterAnimator.SetTrigger("Attack1");
      body.AddForce(new Vector2(1, 0) * 20, ForceMode2D.Impulse);
    }
  }
}
