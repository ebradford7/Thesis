using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoboParser
{
    public class Joint : MonoBehaviour
    {
        public int id;
        public List<int> parents;
        public List<String> servoParameters;
        public DOF degreesOfFreedom;
        public Link link;

        public Joint() { }

        public Joint(int id, List<int> parents, List<String> servoParameters, DOF degreesOfFreedom, Link link)
        {
            this.id = id;
            this.parents = parents;
            this.servoParameters = servoParameters;
            this.degreesOfFreedom = degreesOfFreedom;
            this.link = link;
        }
    }
}