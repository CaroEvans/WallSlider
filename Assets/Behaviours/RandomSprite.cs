using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomSprite : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private Sprite[] _sprites;

    public void Roll ()
    {
        _renderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
    }
}
