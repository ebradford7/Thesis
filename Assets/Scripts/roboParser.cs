using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace robo
{
    public class roboParser : MonoBehaviour
    {
        GameObject objToSpawn;
        // Start is called before the first frame update
        void Start()
        {
            //spawn object
            objToSpawn = new GameObject("Cool GameObject made from Code");
            //Add Components
            objToSpawn.AddComponent<Rigidbody>();
            objToSpawn.AddComponent<MeshFilter>();
            objToSpawn.AddComponent<BoxCollider>();
            objToSpawn.AddComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}