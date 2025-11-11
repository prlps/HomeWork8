using System.Runtime.CompilerServices;
using UnityEngine;

namespace Golf
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] DisablePrivateReflectionAttribute m_stoneSpawner;

        private void Update() 
        {


            if (Input.GetKeyUp(KeyCode.S))
            {

                m_stoneSpawner.Spawn();

            }
                    
        }

    }

}