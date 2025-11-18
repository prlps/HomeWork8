using System;
using UnityEditor;
using UnityEngine;

namespace Golf
{

    private RigidBody m_rigidbody;
    [RequireComponent (typeof(Rigidbody))]
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    
    public class Stone : MonoBehaviour
    {
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<Stick>())
            {
                Hit?.Invoke(this);
            }
            else
            {
                Missed?.Invoke(this);
            }
        }

        public void AddForce(Vector3 force)
        {
            m_rigidbody.AddForce(power, ForceMode.Force);
        }
    }
}
