using BalloonPopRun.Other;
using UnityEngine;

namespace BalloonPopRun.Balloon
{
    public class Balloon : MonoBehaviour
    {
        [SerializeField] private Directions _direction;

        public Directions Direction => _direction;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BalloonCollector balloonCollector))
            {
                balloonCollector.TakeBalloon();
                gameObject.SetActive(false);
            }
        }
    }
}
