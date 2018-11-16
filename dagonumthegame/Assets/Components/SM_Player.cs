using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachines;

public class SM_Player : MonoBehaviour
{
  StateMachine sm;

  // Start is called before the first frame update
  void Start()
  {
    List<State> States = new List<State>();
    States.Add(new State("Idle"));
    States.Add(new State("Running"));
    States.Add(new State("Attack1"));
    States.Add(new State("Crouching"));

    sm = new StateMachine();

    sm.CreateConnection(States[0], States[1], true);
    sm.CreateConnection(States[0], States[3], true);

    sm.LogConnections();

    sm.DefaultState = States[0];

  }

  // Update is called once per frame
  void Update()
  {
    sm.Process();
  }
}
