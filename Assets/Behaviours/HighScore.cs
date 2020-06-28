
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

    public int OldScore { get; private set; }

    public void Awake()
    {
        if (_clearOnAwake)
            PlayerPrefs.DeleteAll();
        OldScore = BestDistance();
        _label.Render(BestDistance());
    }

    public void Check(int distance)
    {
        if(BestDistance() < distance)
        {
            PlayerPrefs.SetInt(_key, distance);
        }
    }

    public int BestDistance ()
    {
        return PlayerPrefs.GetInt(_key, 0);
    }
}
