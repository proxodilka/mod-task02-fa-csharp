using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace fans
{
  public class State
  {
    public string Name;
    public StateDictionary Transitions = new StateDictionary();
    public bool IsAcceptState = false;
    public bool IsValid = true;

    public static State BuildInvalidState(string name = "__invalid__")
    {
      return new State()
      {
        Name = name,
        Transitions = new StateDictionary(),
        IsAcceptState = false,
        IsValid = false
      };
    }
  }

  public class StatesPull
  {
    public Dictionary<string, State> statesPull;
    State initialState;

    public State InitialState { get { return initialState; } }
    public StatesPull(IDictionary<string, List<string>> states, ICollection<string> acceptStateLabels, string initialStateName)
    {
      InitializePull(states.Keys.ToArray(), acceptStateLabels);
      foreach (var state in statesPull.Values)
      {
        if (state.Name == initialStateName)
        {
          initialState = state;
        }
        SetStateTransitions(state, states[state.Name]);
      }
    }

    private void InitializePull(IEnumerable<string> names, ICollection<string> acceptStateLabels)
    {
      statesPull = new Dictionary<string, State>();
      foreach (var name in names)
      {
        statesPull[name] = new State()
        {
          Name = name,
          IsAcceptState = acceptStateLabels.Contains(name)
        };
      }
    }

    private void SetStateTransitions(State state, IList<string> transitions)
    {
      if (transitions.Count() % 2 != 0)
      {
        throw new ArgumentException("Incorrect format of transitions: not all chars have pairs.");
      }
      for (int i=0; i<transitions.Count(); i+=2)
      {
        char symbol = transitions[i][0];
        string nextState = transitions[i + 1];
        state.Transitions[symbol] = statesPull[nextState];
      }
    }
  }
}
