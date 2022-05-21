using BalloonPopRun.Extensions;
using UnityEngine;

namespace BalloonPopRun.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Panel : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Open()
        {
            _canvasGroup.Open();
        }

        public void Close()
        {
            _canvasGroup.Close();
        }
    }
}
