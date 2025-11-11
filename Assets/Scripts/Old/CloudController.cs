using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private Transform[] m_people;
    [SerializeField] private float m_speed = 2f;

    private int m_index = -1;
    private Vector3 m_target;
    private bool m_isMoving;

    public void MoveNext()
    {
        m_index = (m_index + 1) % m_people.Length;

        m_target = m_people[m_index].position;
        m_target.y = transform.position.y;

        m_isMoving = true;
    }

    private void Update()
    {
        if (!m_isMoving)
            return;

        transform.position = Vector3.Lerp(transform.position, m_target, m_speed * Time.deltaTime);

        if (Vector3.SqrMagnitude(transform.position - m_target) < 0.01f)
            m_isMoving = false;
    }
}
