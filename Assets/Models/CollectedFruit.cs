using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class CollectedFruit
{
    public class CollectedEvent : UnityEvent<int> { }

    [SerializeField]
    private string _prefsKey;
    [SerializeField]
    private CollectedEvent _onChanged, _onFull;
    [SerializeField]
    private int _max;
}
