using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoftStopAudioSource : MonoBehaviour
{
    [SerializeField, Range(0.2f, 5f)]
    private float _fadeDuration = 1f;
    [SerializeField]
    private AudioSource _source;

    public void Stop ()
    {
        StartCoroutine(SoftStop());
    }

    private IEnumerator SoftStop ()
    {
        float t = 0;
        while(t < 1f)
        {
            t += Time.deltaTime / _fadeDuration;
            _source.volume = 1 - t;
            yield return null;
        }
        _source.Stop();
    }
}
