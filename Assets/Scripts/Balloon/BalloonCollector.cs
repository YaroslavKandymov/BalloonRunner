using System;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonPopRun.Balloon
{
    public class BalloonCollector : MonoBehaviour
    {
        [SerializeField] private Balloon[] _balloons;

        private readonly Queue<Balloon> _balloonsQueue = new Queue<Balloon>();

        public Balloon CurrentBalloon { get; private set; }

        public event Action AllBalloonsTaken;

        private void Start()
        {
            foreach (var balloon in _balloons)
            {
                _balloonsQueue.Enqueue(balloon);
            }

            CurrentBalloon = _balloonsQueue.Dequeue();
        }

        public void TakeBalloon()
        {
            if (_balloonsQueue.Count > 0)
            {
                CurrentBalloon = _balloonsQueue.Dequeue();
            }
            else 
            {
                AllBalloonsTaken?.Invoke();
            }
        }
    }
}
