using System.Collections;
using BalloonPopRun.Balloon;
using BalloonPopRun.Persons.AnimatorPlayer;
using UnityEngine;

namespace BalloonPopRun.Persons
{
    public abstract class Person : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private BalloonCollector _balloonCollector;
        [SerializeField] private Mover _mover;
        [SerializeField] private Jumper _jumper;
        [SerializeField] private Rigidbody _rigidbody;

        private PersonAnimationsPlayer _animationsPlayer;
        private Coroutine _moveCoroutine;
        private Coroutine _lookAtBalloonCoroutine;

        protected PersonAnimationsPlayer AnimationsPlayer => _animationsPlayer;
        protected BalloonCollector BalloonCollector => _balloonCollector;

        private void Awake()
        {
            _animationsPlayer = new PersonAnimationsPlayer(_animator);
        }

        public void StartJumping()
        {
            _lookAtBalloonCoroutine = StartCoroutine(LooAtBalloonCoroutine());
        }

        public void RunForward()
        {
            _moveCoroutine = StartCoroutine(MoveCoroutine(Vector3.left));
            AnimationsPlayer.PlayRunAnimation();
        }

        public void Run(Transform target)
        {
            var direction = (target.position - transform.position).normalized;

            _moveCoroutine = StartCoroutine(MoveCoroutine(direction));
            AnimationsPlayer.PlayRunAnimation();
        }

        public void Jump()
        {
           
            _jumper.Jump( _balloonCollector.CurrentBalloon.transform.position);
            AnimationsPlayer.PlayJumpAnimation();
        }

        public void StopMove()
        {
            AnimationsPlayer.PlayIdleAnimation();

            if (_moveCoroutine == null)
                return;

            StopCoroutine(_moveCoroutine);
        }

        public void LookAtTarget(Transform target)
        {
            StartCoroutine(LooAtTargetCoroutine(target));
        }

        public void Dance()
        {
            AnimationsPlayer.Dance();
        }

        public void StopLookAtBalloon()
        {
            StopCoroutine(_lookAtBalloonCoroutine);
        }

        public void MakeKinematic()
        {
            _rigidbody.isKinematic = true;
        }

        private IEnumerator MoveCoroutine(Vector3 direction)
        {
            while (true)
            {
                _mover.Move(direction);

                yield return null;
            }
        }

        private IEnumerator LooAtBalloonCoroutine()
        {
            while (true)
            {
                var balloon = new Vector3(_balloonCollector.CurrentBalloon.transform.position.x, transform.position.y , _balloonCollector.CurrentBalloon.transform.position.z);

                transform.LookAt(balloon);

                yield return null;
            }
        }

        private IEnumerator LooAtTargetCoroutine(Transform target)
        {
            while (true)
            {
                var targetTransform = new Vector3(target.position.x, transform.position.y, target.position.z);
                transform.LookAt(target);

                yield return null;
            }
        }
    }
}
