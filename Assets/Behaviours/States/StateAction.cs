using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class StateAction
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private Transition[] _transitions;

    public bool Activate(MonoBehaviour[] states, int from, string name)
    {
        return _name == name && _transitions.FirstOrDefault(t => t.Activate(states, from)) != null;
    }
}