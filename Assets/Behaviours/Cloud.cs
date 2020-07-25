using System.Collections;
using UnityEngine;
using Gangplank.Ranges;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private Vector2 _spawnMinCorner, _spawnMaxCorner;
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private float _xMax = 15f;
    [SerializeField]
    private FloatRange _speed;
    [SerializeField]
    private Vector3Range _scale;
    [SerializeField]
    private ColorRange _color;

    public void Start()
    {
        BeginDrifting();
    }

    private void BeginDrifting ()
    {
        float distance = Random.Range(0, 1f);
        transform.localScale = _scale.Interpolate(distance);
        _renderer.color = _color.Interpolate(distance);
        StartCoroutine(DriftLeftToRight(_speed.Interpolate(distance)));
    }

    private IEnumerator DriftLeftToRight (float speed)
    {
        while(transform.position.x < _xMax)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            yield return null;
        }

        var x = Random.Range(_spawnMinCorner.x, _spawnMaxCorner.x);
        var y = Random.Range(_spawnMinCorner.y, _spawnMaxCorner.y);
        transform.position = new Vector3(x, y, transform.position.z);
        BeginDrifting();
    }
}