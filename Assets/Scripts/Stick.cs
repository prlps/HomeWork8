using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {

        [SerializeField] private float m_minAngleZ = -30;
        [SerializeField] private float m_maxAngleZ = 30;
        [SerializeField] [Min(0)] private float m_speed;
        private void FixedUpdate()
        {
            var angles = transform.localEulerAngles;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                angles.z = Roate(angles.z, m_minAngleZ);
            }

            else
            {
                angles.z = Roate(angles.z, m_maxAngleZ);

            }
        }

        private float Roate (float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angles.z, m_minAngleZ, m_speed * Time.deltaTime);
        }

    }
}
