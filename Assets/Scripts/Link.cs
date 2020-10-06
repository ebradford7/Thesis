using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboParser
{
    public class Link : MonoBehaviour
    {
        public int mass;
        public List<float> extents;
        public InertiaTensor inertiaTensor;

        public Link(int mass, List<float> extents, InertiaTensor inertiaTensor)
        {
            this.mass = mass;
            this.extents = extents;
            this.inertiaTensor = inertiaTensor;
        }
    }
}