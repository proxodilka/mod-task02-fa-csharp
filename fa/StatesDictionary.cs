using System;
using System.Collections.Generic;
using System.Text;

namespace fans
{
  public class StateDictionary
  {
    private Dictionary<char, State> _dictionary;
    public StateDictionary(Dictionary<char, State> states)
    {
      _dictionary = new Dictionary<char, State>(states);
    }

    public StateDictionary()
    {
      _dictionary = new Dictionary<char, State>();
    }

    public State this[char key]
    {
      get
      {
        if (_dictionary.ContainsKey(key))
        {
          return _dictionary[key];
        }
        else
        {
          return State.BuildInvalidState();
        }
      }
      set
      {
        _dictionary[key] = value;
      }
    }
  }
}
