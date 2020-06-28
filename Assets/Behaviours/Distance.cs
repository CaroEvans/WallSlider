using System;
using UnityEngine;
using UnityEngine.Events;

public class Distance : MonoBehaviour
{
    [Serializable]
    private class DistanceEvent : UnityEvent<int> { }

    [SerializeField]
    private DistanceEvent _onUpdated = new DistanceEvent();

    private int _previousDistance = -1;

    public void Update()
    { 
        if (Current() > _previousDistance)
        {
            _previousDistance = Current();
            _onUpdated.Invoke(Current());
        }
    }

    public void CheckBest(HighScore highScore)
    {
        highScore.Check(Current());
    }

    public int Current()
    {
        return Mathf.FloorToInt(-transform.position.y);
    }
}