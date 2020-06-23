using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Views
{
    public class HighScoreLabel : MonoBehaviour
    {
        [SerializeField]
        private ScoreLabel _label;
        [SerializeField]
        private Rigidbody[] _elementsToExplode;
        [SerializeField]
        private Collider _collider;
        [SerializeField]
        private Vector2 _force;
        [SerializeField]
        private float _fadeDuration;
        [SerializeField]
        private CanvasGroup _group;
        [SerializeField]
        private UnityEvent _onReached;

        public void Render(int distance)
        {
            gameObject.SetActive(distance > 0);
            transform.position = Vector3.down * distance;
            _label.Render(distance);
        }

        public void OnTriggerEnter(Collider other)
        {
            StartCoroutine(ReachedAnimation());
            _onReached.Invoke();
        }

        private IEnumerator Fade(float start, float end)
        {
            float groupAlpha = 0f;
            while (groupAlpha <= 1f)
            {
                _group.alpha = Mathf.Lerp(start, end, groupAlpha);
                groupAlpha = groupAlpha + Time.deltaTime / _fadeDuration;
                yield return null;
            }
        }

        private IEnumerator ReachedAnimation ()
        {
            _collider.enabled = false;
            foreach (var rb in _elementsToExplode) {
                rb.useGravity = true;
                rb.AddForce(Force(), ForceMode.Impulse);
                rb.AddTorque(Vector3.one * 150f);
            }
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(Fade(1f, 0f));
            foreach (var rb in _elementsToExplode)
            {
                rb.useGravity = false;
            }
        }

        private Vector2 Force ()
        {
            return new Vector2(Random.Range(-1f, 1f) * _force.x, Random.Range(0.6f, 1f) * _force.y);
        }
    }
}

