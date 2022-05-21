using System;
using BalloonPopRun.Persons;
using UnityEngine;

namespace BalloonPopRun.Other
{
    public class CheckPoint : MonoBehaviour
    {
        public event Action<Person> Reached;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Person person))
            {
                person.StopMove();
                Reached?.Invoke(person);
            }
        }
    }
}
