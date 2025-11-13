using UnityEngine;

namespace Golf
{
    public class StoneCollisionLog : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                Debug.Log($"{name} столкнулся с землей!");
            }
            else if (collision.collider.CompareTag("Stick"))
            {
                Debug.Log($"{name} столкнулся с клюшкой!");
            }
            else
            {
                Debug.Log($"{name} столкнулся с {collision.collider.name}");
            }
        }
    }
}
