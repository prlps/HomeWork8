using System;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Golf
{
    public class StoneCollosionLog : MonoBehaviour
    {
        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.collider.CompareTag("Ground"))
        //    {
        //        Debug.Log($"{name} Ground");
        //    }
        //    else if (collision.collider.CompareTag("Stick"))
        //    {
        //        Debug.Log($"{name} Stick");
        //    }
        //    else
        //    {
        //        Debug.Log($"{name} collission with {collision.collider.name}");
        //    }
        //}

        public event Action<StoneCollosionLog> Hit;
        public event Action<StoneCollosionLog> Missed;

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
    }
}
