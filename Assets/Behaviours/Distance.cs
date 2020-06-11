using System;
using UnityEngine;
using UnityEngine.Events;

public class Distance : MonoBehaviour
{
    [Serializable]
    private class DistanceEvent : UnityEvent<int> { }

    [SerializeField]
    private DistanceEvent _onUpdated = new DistanceEvent();
    [SerializeField]
    private float _distanceScale = 0.3f;

    private int _previousDistance = -1;

    public void Update()
    {
        int currentDistance = Mathf.FloorToInt(-transform.position.y * _distanceScale);
        if (currentDistance > _previousDistance)
        {
            _previousDistance = currentDistance;
            _onUpdated.Invoke(currentDistance);
        }
    }
}