using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    [RequireComponent(typeof(Text))]
    public class FruitLabel : MonoBehaviour
    {
        [SerializeField]
        private Text _label;
        [SerializeField]
        private Image _fillImage;

        public void Render(int count, int max)
        {
            _fillImage.fillAmount = count / (float)max;
            _label.text = count.ToString();
        }

        public void ForActive ()
        {
            _label.enabled = true;
        }

        public void ForInactive ()
        {
            _label.enabled = false;
        }

        public void Reset()
        {
            _label = GetComponent<Text>();
        }
    }
}

