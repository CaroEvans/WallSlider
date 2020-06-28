using UnityEngine;

public class TextureDrift : MonoBehaviour
{
    [SerializeField]
    private Material _material;
    [SerializeField]
    private Vector2 _driftDirection;
    [SerializeField]
    private float _driftSpeed;

    private const string TEX_OFFSET_NAME = "_MainTex";

    void Update()
    {
        _material.SetTextureOffset(TEX_OFFSET_NAME, new Vector2(Mathf.Sin(Time.time), 1f * Time.time) * _driftSpeed);
    }
}
