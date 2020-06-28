using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUtil
{


    public class Util : MonoBehaviour
    {
        // Generate random normalized direction
        public static Vector3 GetRandomDir()
        {
            return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        }
    }




}




