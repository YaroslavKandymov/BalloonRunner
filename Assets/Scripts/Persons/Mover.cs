using BalloonPopRun.Other;
using UnityEngine;

namespace BalloonPopRun.Persons
{
    [RequireComponent(typeof(Rigidbody))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private SurfaceSlider _surfaceSlider;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _surfaceSlider = new SurfaceSlider();
        }

        public void Move(Vector3 direction)
        {
            Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);

            var nextPosition = _rigidbody.position + offset;

            _rigidbody.MovePosition(nextPosition);
        }
    }
}
