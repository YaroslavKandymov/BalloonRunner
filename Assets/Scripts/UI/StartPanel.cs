using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace BalloonPopRun.UI
{
    public class StartPanel : Panel
    {
        [SerializeField] private float _targetScale;
        [SerializeField] private float _duration;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Ease _ease;

        public event Action Clicked;

        private void Start()
        {
            PlayTextAnimation();

            StartCoroutine(TapCoroutine());
        }

        private IEnumerator TapCoroutine()
        {
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Clicked?.Invoke();
                    yield break;
                }

                yield return null;
            }
        }

        private void PlayTextAnimation()
        {
            _text.transform.DOScale(transform.localScale * _targetScale, _duration).SetLoops(-1, LoopType.Yoyo).SetEase(_ease);
        }
    }
}
