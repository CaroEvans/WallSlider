using UnityEngine;
using UnityEngine.SceneManagement;
using Views;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private TransitionScreen _screen;

    private bool _fired = false;

    public void Play ()
    {
        if (_fired) return;
        _fired = true;  
        _screen.Reverse(LoadGame);
    }

    private void LoadGame ()
    {
        SceneManager.LoadScene("Game");
    }
}
