using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using Newtonsoft.Json;

public class RobotDisplay : MonoBehaviour

{
    public RobotInfo robotInfo;

    public Text idText;
    public Text massText;
    public MeshRenderer currentColor;

    public int serverID;
    public int serverMass;

    // Start is called before the first frame update
    void Start()
    {
        DisplayStats();
        robotInfo.PrintMessage();
        WebSocket ws = new WebSocket("ws://127.0.0.1:4649/Laputa");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            print("Laputa says: " + e.Data);
            RoboParser.Joint j = JsonConvert.DeserializeObject<RoboParser.Joint>(e.Data);
            Debug.Log(j.id);
            serverID = j.id;
            serverMass = j.link.mass;
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
        DisplayStats();
        //robotInfo.PrintMessage();
    }

    void DisplayStats()
    {
        idText.text = "ID: " + serverID;
        massText.text = "Mass: " + serverMass;
        currentColor.material = robotInfo.color;
    }
}
