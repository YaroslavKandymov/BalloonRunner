using System;
using BalloonPopRun.Other;
using BalloonPopRun.UI;
using UnityEngine;

namespace BalloonPopRun.Persons
{
    public class Player : Person
    {
        [SerializeField] private GamePanel _gamePanel;

        public event Action AllBalloonsTaken;

        private void OnEnable()
        {
            _gamePanel.LeftArrowClicked += OnLeftArrowClicked;
            _gamePanel.RightArrowClicked += OnRightArrowClicked;
            BalloonCollector.AllBalloonsTaken += OnAllBalloonsTaken;
        }

        private void OnDisable()
        {
            _gamePanel.LeftArrowClicked -= OnLeftArrowClicked;
            _gamePanel.RightArrowClicked -= OnRightArrowClicked;
            BalloonCollector.AllBalloonsTaken -= OnAllBalloonsTaken;
        }

        private void OnRightArrowClicked()
        {
            if (BalloonCollector.CurrentBalloon.Direction == Directions.Right)
            {
                Jump();
            }
        }

        private void OnLeftArrowClicked()
        {
            if (BalloonCollector.CurrentBalloon.Direction == Directions.Left)
            {
                Jump();
            }
        }

        private void OnAllBalloonsTaken()
        {
            StopLookAtBalloon();
            AllBalloonsTaken?.Invoke();
        }
    }
}
