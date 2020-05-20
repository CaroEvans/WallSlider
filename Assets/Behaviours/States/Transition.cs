using System;
using UnityEngine;

[Serializable]
public class Transition
{
    [SerializeField]
    private int _from, _to;

    public bool Activate(MonoBehaviour[] states, int from)
    {
        var eligible = from == _from;
        if (eligible)
        {
            states[from].enabled = false;
            states[_to].enabled = true;
        }
        return eligible;
    }
}