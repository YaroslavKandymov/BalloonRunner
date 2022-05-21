using BalloonPopRun.Persons;
using UnityEngine;
using UnityEngine.UI;

namespace BalloonPopRun.UI
{
    public class LevelProgressBar : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Image _playerPointer;
        [SerializeField] private Image _enemyPointer;
        [SerializeField] private Slider _playerSlider;
        [SerializeField] private Slider _enemySlider;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private Transform _finish;

        private float _playerPointStartPosition;
        private float _fullDistance;

        private void Start()
        {
            _playerPointStartPosition = _playerPointer.transform.localPosition.x;
            _fullDistance = GetDistance(_player.transform, _finish.transform);
        }

        private void Update()
        {
            _playerSlider.value = 1 - (GetDistance(_player.transform, _finish.transform) / _fullDistance);
            _enemySlider.value = 1 - (GetDistance(_enemy.transform, _finish.transform) / _fullDistance);
        }

        private float GetDistance(Transform firstPoint, Transform secondPoint)
        {
            return (secondPoint.position - firstPoint.position).sqrMagnitude;
        }
    }
}
