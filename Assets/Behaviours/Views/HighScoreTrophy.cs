using UnityEngine;
using Views;

public class HighScoreTrophy : MonoBehaviour
{
    [SerializeField]
    private string _key;
    [SerializeField]
    private ScoreLabel _scoreLabel;

    public void Awake()
    {
        var bestScore = PlayerPrefs.GetInt(_key, 0);
        if (bestScore <= 0)
            Destroy(gameObject);
        _scoreLabel.Render(bestScore);
    }
}
