using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyUtil
{


    public class Util : MonoBehaviour
    {
        // Generate random normalized direction
        public static Vector3 GetRandomDir()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }


        public static Vector3 GetRandomSingleDir()
        {
            int randNum = Random.Range(0, 2);
            float dir = Random.Range(-1f, 1f);
            return (randNum == 0) ? new Vector3(dir, 0, 0) : new Vector3(0, dir, 0);

        }

        public static Vector3 GetRandomXDir()
        {
            return Vector3.right * Random.Range(-1f, 1f);
        }
    }




}




