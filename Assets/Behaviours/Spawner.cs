using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private float _frequency = 1.0f;

    IEnumerator Start()
    {
        var delay = new WaitForSeconds(_frequency);
        while(true)
        {
            yield return delay;
            Instantiate(_prefab, _player.position + Vector3.down * 5f + Vector3.left * 3f, transform.rotation);
        }
    }
}
