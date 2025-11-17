using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField][Min(0)] private float m_power = 250f;
        [SerializeField] private Transform m_point;
        [SerializeField] private float m_minAngleZ = -30f;
        [SerializeField] private float m_maxAngleZ = 30f;
        [SerializeField][Min(0)] private float m_speed = 90f;

        private Vector3 m_lastPointPosition;
        private Vector3 m_direction;

        private void Awake()
        {
            if (m_point != null)
                m_lastPointPosition = m_point.position;
        }

        private void FixedUpdate()
        {
            var angles = transform.localEulerAngles;
            float currentZ = angles.z;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                angles.z = Rotate(currentZ, m_minAngleZ);
            }
            else
            {
                angles.z = Rotate(currentZ, m_maxAngleZ);
            }

            transform.localEulerAngles = angles;

            if (m_point != null)
            {
                m_direction = (m_point.position - m_lastPointPosition).normalized;
                m_lastPointPosition = m_point.position;
            }
        }

        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, m_speed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Stone>(out var stone))
            {
                var rb = stone.GetComponent<Rigidbody>();
                if (rb != null && !rb.isKinematic)
                {
                    rb.AddForce(m_power * m_direction, ForceMode.Force);
                }
            }
        }
    }
}
