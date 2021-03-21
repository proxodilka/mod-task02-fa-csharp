using System;
using System.Collections.Generic;
using System.Text;

namespace fans
{ 
  public class FA
  {
    protected State currentState;
    public FA(State currentState = null)
    {
      if (currentState is null)
      {
        currentState = State.BuildInvalidState();
      }
      this.currentState = currentState;
    }

    public bool? Run(IEnumerable<char> s)
    {
      foreach (char c in s)
      {
        currentState = currentState.Transitions[c];
        if (!currentState.IsValid)
        {
          return null;
        }
      }
      return currentState.IsAcceptState;
    }
  }

  public class FA1 : FA
  {
     Dictionary<string, List<string>> transitionMatrix = new Dictionary<string, List<string>>
    {
      ["Initial"]       = new List<string>() { "0", "Wait-for-one", "1", "Wait-for-zero"},
      ["Wait-for-one"]  = new List<string>() { "0", "Death",        "1", "Accept"},
      ["Accept"]        = new List<string>() { "0", "Death",        "1", "Accept"},
      ["Wait-for-zero"] = new List<string>() { "0", "Accept",       "1", "Wait-for-zero"},
      ["Death"]         = new List<string>() { "0", "Death",        "1", "Death"},
    };
    HashSet<string> acceptStateLabels = new HashSet<string>() { "Accept" };
    public FA1()
    {
      var statesPull = new StatesPull(transitionMatrix, acceptStateLabels, "Initial");
      currentState = statesPull.InitialState;
    }
  }

  public class FA2 : FA
  {
    Dictionary<string, List<string>> transitionMatrix = new Dictionary<string, List<string>>
    {
      ["1_1"] = new List<string>() { "0", "0_1", "1", "1_0" },
      ["0_1"] = new List<string>() { "0", "1_1", "1", "0_0" },
      ["1_0"] = new List<string>() { "0", "0_0", "1", "1_1" },
      ["0_0"] = new List<string>() { "0", "1_0", "1", "0_1" },
    };
    HashSet<string> acceptStateLabels = new HashSet<string>() { "1_1" };
    public FA2()
    {
      var statesPull = new StatesPull(transitionMatrix, acceptStateLabels, "1_1");
      currentState = statesPull.InitialState;
    }
  }
}
