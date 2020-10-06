using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using RoboParser;

public class connector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WebSocket ws = new WebSocket("ws://127.0.0.1:4649/Laputa");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            print("Laputa says: " + e.Data);
            RoboParser.Joint j = JsonConvert.DeserializeObject<RoboParser.Joint>(e.Data);
            Debug.Log(j.id);
            Debug.Log(j.parents);
            Debug.Log(j.servoParameters);
            Debug.Log(j.degreesOfFreedom);
            Debug.Log(j.link.inertiaTensor.lxy);
        };
        ws.Send("BALUS");
 


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
