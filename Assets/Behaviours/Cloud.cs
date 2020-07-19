using System.Collections;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rectTransform;
    [SerializeField]
    private Vector2 _spawnMinCorner, _spawnMaxCorner;
    [SerializeField]
    private float _xMax = 15f, _speedMin = 1f, _speedMax = 10f;

    public void Start()
    {
        BeginDrifting();
    }

    private void BeginDrifting ()
    {
        StartCoroutine(DriftLeftToRight(Random.Range(_speedMin, _speedMax)));
    }

    private IEnumerator DriftLeftToRight (float speed)
    {
        while(_rectTransform.anchoredPosition.x < _xMax)
        {
            _rectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;
            yield return null;
        }

        var x = Random.Range(_spawnMinCorner.x, _spawnMaxCorner.x);
        var y = Random.Range(_spawnMinCorner.y, _spawnMaxCorner.y);
        _rectTransform.anchoredPosition = new Vector2(x, y);

        BeginDrifting();
    }
}
