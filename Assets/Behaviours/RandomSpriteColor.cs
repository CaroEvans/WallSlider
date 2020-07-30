using UnityEngine;
using Gangplank.Ranges;

public class RandomSpriteColor : MonoBehaviour
{
    [SerializeField]
    private ColorRange _colorRange;
    [SerializeField]
    private SpriteRenderer _renderer;

    public void Roll ()
    {
        _renderer.color = _colorRange.Random();
    }
}
