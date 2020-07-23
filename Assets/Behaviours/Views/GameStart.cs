using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    private TransitionScreen _screen;
    [SerializeField]
    private Transform _cameraTransform;
    [SerializeField]
    private float _cameraScrollSpeed = 1f, _loadDuration = 3f, _scrollAccelDuration = 3f;
    [SerializeField]
    private AnimationCurve _scrollCurve;
    [SerializeField]
    private Animator _titleAnimator, _frogAnimator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartScrolling();
    }

    private void StartScrolling ()
    {
        _frogAnimator.SetTrigger("Enter");
        _titleAnimator.SetBool("Visible", false);
        StartCoroutine(LoadGameAfterDelay());
        StartCoroutine(ScrollCamera(Time.time + _scrollAccelDuration));
    }

    private void LoadGame ()
    {
        SceneManager.LoadScene("Game");
    }

    private IEnumerator LoadGameAfterDelay ()
    {
        yield return new WaitForSeconds(_loadDuration);
        _screen.Reverse(LoadGame);
    }

    private IEnumerator ScrollCamera (float fullSpeedTime)
    {
        while (true)
        {
            _cameraTransform.position += Vector3.down * _cameraScrollSpeed * _scrollCurve.Evaluate(Time.time / fullSpeedTime) * Time.deltaTime;
            yield return null;
        }
    }
}