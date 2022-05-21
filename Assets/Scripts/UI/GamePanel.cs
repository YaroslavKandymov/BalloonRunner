using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace BalloonPopRun.UI
{
    public class GamePanel : Panel
    {
        [SerializeField] private Button _leftArrow;
        [SerializeField] private Button _rightArrow;

        public event Action LeftArrowClicked;
        public event Action RightArrowClicked;

        private Image _leftArrowImage;
        private Image _rightArrowImage;

        private void OnEnable()
        {
            _leftArrow.onClick.AddListener(OnLeftArrowClicked);
            _rightArrow.onClick.AddListener(OnRightArrowClicked);
        }

        private void OnDisable()
        {
            _leftArrow.onClick.RemoveListener(OnLeftArrowClicked);
            _rightArrow.onClick.RemoveListener(OnRightArrowClicked);
        }

        private void Start()
        {
            _leftArrowImage = _leftArrow.GetComponent<Image>();
            _rightArrowImage = _rightArrow.GetComponent<Image>();

            TurnOffButtons();
        }

        public void TurnOnButtons()
        {
            _rightArrowImage.DOFade(1, 0);
            _leftArrowImage.DOFade(1, 0);

            _leftArrow.interactable = true;
            _rightArrow.interactable = true;
        }

        public void TurnOffButtons()
        {
            _rightArrowImage.DOFade(0, 0);
            _leftArrowImage.DOFade(0, 0);

            _leftArrow.interactable = false;
            _rightArrow.interactable = false;
        }

        private void OnLeftArrowClicked()
        {
            LeftArrowClicked?.Invoke();
        }

        private void OnRightArrowClicked()
        {
            RightArrowClicked?.Invoke();
        }
    }
}
