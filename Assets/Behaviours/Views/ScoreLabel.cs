using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ScoreLabel : MonoBehaviour
    {
        [SerializeField]
        private Text _label;
        [SerializeField]
        private string _format;

        public void Render(int distance)
        {
            _label.text = string.Format(_format, distance);
        }
    }
}