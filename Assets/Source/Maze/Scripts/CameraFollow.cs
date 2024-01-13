using UnityEngine;

namespace Source.Maze.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float lerpSpeed = 0.125f;
        public float moveSpeed = 25f;
        public float maxDistance = 2f;
        public Vector3 locationOffset;
        public Vector3 rotationOffset;

        private Rigidbody _rigidbody;
        private Vector3 _velocity;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + target.rotation * locationOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, lerpSpeed);

            if (Vector3.Distance(transform.position, target.position) >= maxDistance)
            {
                transform.position = desiredPosition;
            }
            else
            {
                _rigidbody.velocity = (smoothedPosition - transform.position) * moveSpeed;
            }

            Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
            Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, lerpSpeed);
            transform.rotation = smoothedrotation;
        }
    }
}