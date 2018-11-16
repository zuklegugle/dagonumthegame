using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachines;

namespace StateMachines
{
  public class State
  {
    public string Name { get; private set; }
    public bool Started { get; private set; }

    bool debug = true;

    public State(string name)
    {
      Name = name;
    }

    public virtual void OnInit()
    {
      Debug.Log("DEFAULT INIT CODE");
      //this code happens once after switching states
    }

    public virtual void OnRun()
    {
      Debug.Log("DEFAULT RUN CODE");
      //this code happens every frame state is active
    }

    public virtual void OnExit()
    {
      Debug.Log("DEFAULT EXIT CODE");
      //this code runs just before state switch, use to clean up vars and other garbage
    }

    public void Process()
    {
      if (!Started)
      {
        OnInit();
        Started = true;
      }
      OnRun();
    }
  }

  public class StateConnection
  {
    public State Source { get; private set; } // source node of the connection
    public State Target { get; private set; } // target node of the connection
    public bool Mode { get; private set; } // one-way or two-way

    public StateConnection(State src, State tg, bool mode)
    {
      Source = src;
      Target = tg;
      Mode = mode;
    }

    public void Log()
    {
      if (Mode)
      {
        Debug.Log("[Connection] " + Source.Name + " <===|===> " + Target.Name);
      }
      else
      {
        Debug.Log("[Connection] " + Source.Name + " ===> " + Target.Name);
      }
    }
  }


}
