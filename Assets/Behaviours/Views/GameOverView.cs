using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Views;

public class GameOverView : MonoBehaviour
{
    [SerializeField]
    private Distance _distance;
    [SerializeField]
    private Animator _animator, _scoreAnimator, _textAnimator;
    [SerializeField]
    private ScoreLabel _label;
    [SerializeField]
    private TransitionScreen _screen;
    [SerializeField]
    private AnimationCurve _fillCurve;
    [SerializeField]
    private float _fillSpeed = 1f;
    [SerializeField]
    HighScore _highScore;
    [SerializeField]
    private AudioSource _highScoreSource;
    [SerializeField]
    private Text _postGameText;

    public void Render()
    {
        StartCoroutine(RenderAfterDelay());
        StartCoroutine(WaitForRestart());
    }

    private IEnumerator RenderAfterDelay ()
    {
        yield return new WaitForSeconds(0.6f);
        _animator.SetBool("Visible", true);
        StartCoroutine(FillScore(_distance.Current()));
    }

    private IEnumerator FillScore(int score)
    {
        yield return new WaitForSeconds(2f);
        _scoreAnimator.SetBool("Filling", true);
        float current = 0;
        float stepSize = score / 2f;
        int highScore = _highScore.OldScore;
        bool triggeredHighScore = false;
        while(current < score)
        {
            current = Mathf.MoveTowards(current, score, stepSize * _fillCurve.Evaluate(current / score) * _fillSpeed * Time.deltaTime);
            _label.Render(Mathf.FloorToInt(current));
            if(current > highScore && !triggeredHighScore)
            {
                triggeredHighScore = true;
                _scoreAnimator.SetTrigger("HighScore");
                _highScoreSource.Play();
                SetPostGameText("WONDERFUL");
            }
            yield return null;
        }
        _scoreAnimator.SetBool("Filling", false);

        if (!triggeredHighScore)
            SetPostGameText("GAME OVER");
    }

    private void SetPostGameText(string message)
    {
        _postGameText.text = message;
        _textAnimator.SetTrigger("Bounce");
    }

    private IEnumerator WaitForRestart ()
    {
        yield return new WaitForSeconds(1.5f);
        yield return new WaitUntil(() => Input.anyKeyDown);
        _screen.Reverse(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
}
