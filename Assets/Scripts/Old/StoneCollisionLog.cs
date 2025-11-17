using System;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Golf
{
    public class StoneCollosionLog : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                Debug.Log($"{name} Ground");
            }
            else if (collision.collider.CompareTag("Stick"))
            {
                Debug.Log($"{name} Stick");
            }
            else
            {
                Debug.Log($"{name} collission with {collision.collider.name}");
            }
        }
    }
}
