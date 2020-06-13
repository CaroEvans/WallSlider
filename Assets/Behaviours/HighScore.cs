
using UnityEngine;
using Views;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    private string _key;
    [SerializeField]
    private HighScoreLabel _label;
    [SerializeField]
    private bool _clearOnAwake;

    public void Awake()
    {
        if (_clearOnAwake)
            PlayerPrefs.DeleteAll();
        _label.Render(BestDistance());
    }

    public void Check(int distance)
    {
        if(BestDistance() < distance)
        {
            PlayerPrefs.SetInt(_key, distance);
        }
    }

    private int BestDistance ()
    {
        return PlayerPrefs.GetInt(_key, 0);
    }
}
