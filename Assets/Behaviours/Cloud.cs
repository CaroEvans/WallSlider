using System.Collections;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private Vector2 _spawnMinCorner, _spawnMaxCorner;
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private float _xMax = 15f, _speedMin = 1f, _speedMax = 10f, _scaleMax = 5f, _scaleMin = 3f, _alphaMax = 0.9f, _alphaMin = 0.2f;

    public void Start()
    {
        BeginDrifting();
    }

    private void BeginDrifting ()
    {
        float distance = Random.Range(0, 1f);
        transform.localScale = Vector3.one * Mathf.Lerp(_scaleMin, _scaleMax, distance);
        _renderer.color = Color.Lerp(new Color(1, 1, 1, _alphaMin), new Color(1, 1, 1, _alphaMax), distance);
        StartCoroutine(DriftLeftToRight(Mathf.Lerp(_speedMin, _speedMax, distance)));
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
