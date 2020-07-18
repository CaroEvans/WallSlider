using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("Game");
    }
}