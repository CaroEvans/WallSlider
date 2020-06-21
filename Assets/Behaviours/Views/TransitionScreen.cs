using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    [RequireComponent(typeof(Image))]
    public class TransitionScreen : MonoBehaviour
    {
        [SerializeField]
        private Image _screen;
        [SerializeField]
        private float _transitionSpeed = 2f;

        public void Start()
        {
            StartCoroutine(TweenScreen(1f, 0f));
        }

        public void Reverse (Action callback = null)
        {
            _screen.fillOrigin = 1;
            StartCoroutine(TweenScreen(0f, 1f, callback));
        }

        public void Reset()
        {
            _screen = GetComponent<Image>();
        }

        private IEnumerator TweenScreen(float start, float end, Action callback = null)
        {
            float timer = 0f;
            while(timer <= 1f)
            {
                _screen.fillAmount = Mathf.Lerp(start, end, timer);
                yield return null;
                timer += Time.deltaTime * _transitionSpeed;
            }
            callback?.Invoke();
        }
    }
}
