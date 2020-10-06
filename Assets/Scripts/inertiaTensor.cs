using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RoboParser
{
    public class InertiaTensor : MonoBehaviour
    {
        // Start is called before the first frame update
        public float lxx;
        public float lyy;
        public float lzz;
        public float lxy;
        public float lyz;
        public float lzx;


        public InertiaTensor(float lxx, float lyy, float lzz, float lxy, float lyz, float lzx)
        {
            this.lxx = lxx;
            this.lyy = lyy;
            this.lzz = lzz;
            this.lxy = lxy;
            this.lyz = lyz;
            this.lzx = lzx;
        }
    }
}