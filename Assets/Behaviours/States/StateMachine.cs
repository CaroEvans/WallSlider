using System;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField]
    private State[] _states;
    [SerializeField]
    private StateAction[] _actions;

    public void Awake()
    {
        if (_states.Count(s => s.enabled) > 1)
            throw new Exception("More than one state is enabled. Please disable all states except the initial.");
    }

    public void Change(string action)
    {
        var currentState = _states.First(state => state.enabled);
        var fromIndex = Array.IndexOf(_states, currentState);
        var activatedAction = _actions.FirstOrDefault(a => a.Activate(_states, fromIndex, action));
        if (activatedAction == null)
            throw new System.Exception($"Failed to change state via {action} from {currentState.GetType().Name}");
    }
}