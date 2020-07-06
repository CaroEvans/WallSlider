using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class TitleLetter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Text _letterLabel;
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _forceStrength = 1f, _colorSpeed = 2f;
    [SerializeField]
    private Color[] _colors;

    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();
        _rigidbody.AddForceAtPosition(Random.insideUnitCircle * _forceStrength, transform.position + Random.insideUnitSphere, ForceMode.Impulse);
        StartCoroutine(ChangeColor(_letterLabel.color, _colors[Random.Range(0, _colors.Length)]));
    }

    public void Reset()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _letterLabel = GetComponentInChildren<Text>();
    }

    private IEnumerator ChangeColor(Color initialColor, Color nextColor)
    {
        float timer = 0;
        while (timer < 1f)
        {
            timer += Time.deltaTime * _colorSpeed;
            _letterLabel.color = Color.Lerp(initialColor, Color.white, timer);
            yield return null;
        }
        while(timer > 0)
        {
            timer -= Time.deltaTime * _colorSpeed;
            _letterLabel.color = Color.Lerp(nextColor, Color.white, timer);
            yield return null;
        }
    }

}
