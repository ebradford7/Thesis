using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboParser
{
    public class DOF : MonoBehaviour
    {
        public float x;
        public float y;
        public float z;
        public float roll;
        public float pitch;
        public float yaw;



        public DOF(float x, float y, float z, float roll, float pitch, float yaw)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.roll = roll;
            this.pitch = pitch;
            this.yaw = yaw;

        }

    }


}
