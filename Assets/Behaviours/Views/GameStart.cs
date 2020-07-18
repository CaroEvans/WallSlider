using UnityEngine;
using UnityEngine.SceneManagement;
using Views;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    private TransitionScreen _screen;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _screen.Reverse(LoadGame);
    }

    private void LoadGame ()
    {
        SceneManager.LoadScene("Game");
    }
}