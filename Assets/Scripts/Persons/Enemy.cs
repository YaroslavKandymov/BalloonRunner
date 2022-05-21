using System;
using System.Collections;
using UnityEngine;

namespace BalloonPopRun.Persons
{
    public class Enemy : Person
    {
        [SerializeField] private float _jumpingPause;

        private WaitForSeconds _seconds;
        private Coroutine _coroutine;

        public event Action AllBalloonsTaken;

        private void OnEnable()
        {
            BalloonCollector.AllBalloonsTaken += OnAllBalloonsTaken;
        }

        private void OnDisable()
        {
            BalloonCollector.AllBalloonsTaken -= OnAllBalloonsTaken;
        }

        private void Start()
        {
            _seconds = new WaitForSeconds(_jumpingPause);
        }

        public void StopJump()
        {
            if(_coroutine == null)
                return;

            StopCoroutine(_coroutine);
        }

        public void StartJump()
        {
            _coroutine = StartCoroutine(StartJumpCoroutine());
        }

        private void OnAllBalloonsTaken()
        {
            StopLookAtBalloon();
            AllBalloonsTaken?.Invoke();
        }

        private IEnumerator StartJumpCoroutine()
        {
            while (true)
            {
                Jump();

                yield return _seconds;
            }
        }
    }
}
