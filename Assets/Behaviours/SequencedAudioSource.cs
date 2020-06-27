using System.Collections;
using UnityEngine;

public class SequencedAudioSource : MonoBehaviour
{
    [SerializeField]
    private AudioSource _introSource, _bodySource;
    [SerializeField, Range(0, 1f)]
    private float _delay;

    public void Play ()
    {
        StartCoroutine(PlaySequence());
    }

    private IEnumerator PlaySequence ()
    {
        yield return new WaitForSeconds(_delay);
        _introSource.Play();
        _bodySource.PlayDelayed(_introSource.clip.samples / (float)_introSource.clip.frequency);
    }
}
