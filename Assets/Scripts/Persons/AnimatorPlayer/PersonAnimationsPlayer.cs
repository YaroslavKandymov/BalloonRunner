using BalloonPopRun.Other;
using UnityEngine;

namespace BalloonPopRun.Persons.AnimatorPlayer
{
    public class PersonAnimationsPlayer
    {
        private readonly Animator _animator;

        public PersonAnimationsPlayer(Animator animator)
        {
            _animator = animator;
        }

        public void PlayJumpAnimation()
        {
            _animator.Play(AnimatorController.State.Jump);
        }

        public void PlayRunAnimation()
        {
            _animator.Play(AnimatorController.State.Run);
        }

        public void PlayIdleAnimation()
        {
            _animator.Play(AnimatorController.State.Idle);
        }

        public void Dance()
        {
            _animator.Play(AnimatorController.State.Dancing);
        }
    }
}
