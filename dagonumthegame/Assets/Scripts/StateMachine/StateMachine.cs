using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachines
{
  public class StateMachine
  {
    public State DefaultState { get; set; } //default state
    public State CurrentState { get; private set; } // currently active state
    public List<StateConnection> Connections { get; private set; } // list of all connections

    public StateMachine()
    {
      Connections = new List<StateConnection>();
    }

    public void Process()
    {
      if (CurrentState != null)
      {
        CurrentState.Process();
      }
      else
      {
        if (DefaultState != null)
        {
          CurrentState = DefaultState;
        }
        else
        {
          Debug.LogWarning("State Machine has no default state and cannot run");
        }
      }

    }


    public bool CreateConnection(State src, State tg, bool mode)
    {
      if (!ConnectionExists(src, tg))
      {
        Connections.Add(new StateConnection(src, tg, mode));
        Debug.Log("Connection established between " + src.Name + "and" + tg.Name);
        return true;
      }
      Debug.Log("Connection failed, already connected");
      return false;
    }

    public bool ConnectionExists(State s1, State s2)
    {
      foreach (StateConnection connection in Connections)
      {
        if (connection.Source == s1 && connection.Target == s2 ||
           (connection.Source == s2 && connection.Target == s1))
        {
          return true;
        }
      }
      return false;
    }

    public void LogConnections()
    {
      foreach (StateConnection connection in Connections)
      {
        connection.Log();
      }
    }
  }
}

