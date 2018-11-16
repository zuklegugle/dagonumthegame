using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  public bool MoveLeft { get; private set; }
  public bool MoveRight { get; private set; }

  // Start is called before the first frame update
  void Start()
  {
    MoveLeft = false;
    MoveRight = false;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey("left"))
    {
      MoveLeft = true;
    }
    else
    {
      MoveLeft = false;
    }

    if (Input.GetKey("right"))
    {
      MoveRight = true;
    }
    else
    {
      MoveRight = false;
    }
  }
}
