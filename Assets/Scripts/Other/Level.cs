using BalloonPopRun.Persons;
using BalloonPopRun.UI;
using UnityEngine;

namespace BalloonPopRun.Other
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private StartPanel _startPanel;
        [SerializeField] private GamePanel _gamePanel;
        [SerializeField] private WinPanel _winPanel;
        [SerializeField] private LosePanel _losePanel;
        [SerializeField] private Player _player;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private CheckPoint _jumpStartPoint;
        [SerializeField] private CheckPoint _finishPoint;

        private void OnEnable()
        {
            _startPanel.Clicked += OnClicked;
            _jumpStartPoint.Reached += OnJumpStartPointReached;
            _finishPoint.Reached += OnFinishPointReached;
            _player.AllBalloonsTaken += OnPlayerAllBalloonsTaken;
            _enemy.AllBalloonsTaken += OnEnemyAllBalloonsTaken;
        }

        private void OnDisable()
        {
            _startPanel.Clicked -= OnClicked;
            _jumpStartPoint.Reached -= OnJumpStartPointReached;
            _finishPoint.Reached -= OnFinishPointReached;
            _player.AllBalloonsTaken -= OnPlayerAllBalloonsTaken;
            _enemy.AllBalloonsTaken -= OnEnemyAllBalloonsTaken;
        }

        private void Start()
        {
            _startPanel.Open();
            _gamePanel.Close();
            _winPanel.Close();
            _losePanel.Close();
        }

        private void OnClicked()
        {
            _startPanel.Close();
            _gamePanel.Open();

            _player.RunForward();
            _enemy.RunForward();
        }

        private void OnJumpStartPointReached(Person person)
        {
            if (person is Player)
            {
                _gamePanel.TurnOnButtons();
                _player.StartJumping();
            }
            else if (person is Enemy)
            {
                _enemy.StartJumping();
                _enemy.StartJump();
            }
        }

        private void OnPlayerAllBalloonsTaken()
        {
            _gamePanel.TurnOffButtons();
            _player.LookAtTarget(_finishPoint.transform);
            _player.Run(_finishPoint.transform);
        }

        private void OnEnemyAllBalloonsTaken()
        {
            _enemy.LookAtTarget(_finishPoint.transform);
            _enemy.Run(_finishPoint.transform);
        }

        private void OnFinishPointReached(Person person)
        {
            _gamePanel.Close();

            if (person is Player)
            {
                _player.StopMove();
                _winPanel.Open();
                _enemy.StopMove();
                _enemy.StopJump();
                _player.MakeKinematic();
            }
            else
            {
                _losePanel.Open();
                _player.StopMove();
                _enemy.StopMove();
                _enemy.MakeKinematic();
            }

            person.Dance();
        }
    }
}
