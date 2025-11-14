using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField][Min(0)] private float m_power = 250;
        [SerializeField] private Transform m_point;
        [SerializeField] private float m_minAngleZ = -30;
        [SerializeField] private float m_maxAngleZ = 30;
        [SerializeField][Min(0)] private float m_speed;

        private Vector3 m_lastPointPosition;
        private Vector3 m_direction;
        private void FixedUpdate()
        {
            var angles = transform.localEulerAngles;
            float currentZ = angles.z;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                angles.z = Roate(currentZ, m_minAngleZ);
            }
            else
            {
                angles.z = Roate(currentZ, m_maxAngleZ);
            }

            transform.localEulerAngles = angles;

            var direction = m_point.position - m_lastPointPosition;
            m_lastPointPosition = m_point.position;
        }

        private float Roate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, m_speed * Time.fixedDeltaTime);
        }



    }
}
