using BalloonPopRun.Other;
using DG.Tweening;
using UnityEngine;

namespace BalloonPopRun.Persons
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private float _duration;
        [SerializeField] private int _jumpCount;

        private bool _inAir;

        private void OnValidate()
        {
            if (_jumpCount <= 0)
                _jumpCount = 1;

            if (_force < 0)
                _force = 0;
            
            if (_duration < 0)
                _duration = 0;
        }

        public void Jump(Vector3 direction)
        {
            if (_inAir == false)
            {
                _inAir = true;
                transform.DOJump(direction, _force, _jumpCount, _duration).SetEase(Ease.Linear);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Floor floor))
            {
                _inAir = false;
            }
        }
    }
}
