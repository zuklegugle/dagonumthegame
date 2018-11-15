using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlCharacter : MonoBehaviour
{

  Animator characterAnimator;
  Rigidbody body;
  float moveHorizontal;
  float moveVertical;

  // Start is called before the first frame update
  void Start()
  {
    characterAnimator = this.GetComponent<Animator>();
    body = this.GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey("left"))
    {
      characterAnimator.SetInteger("State", 1);
    }
    if (Input.GetKey("right"))
    {
      characterAnimator.SetInteger("State", 1);
    }

    if (!Input.GetKey("left") &&
        !Input.GetKey("up") &&
        !Input.GetKey("right") &&
        !Input.GetKey("down")
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
      body.velocity = Vector3.zero;
      body.angularVelocity = Vector3.zero;
    }

    //Use the two store floats to create a new Vector2 variable movement.
    Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

    //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
    body.AddForce(movement * 10);
    if (Input.GetKeyDown("left ctrl"))
    {
      characterAnimator.SetTrigger("Attack1");
      body.AddForce(new Vector3(1, 0, 0) * 20, ForceMode.Impulse);
    }
  }
}
