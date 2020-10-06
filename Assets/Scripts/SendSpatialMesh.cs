using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using Parabox;
using WebSocketSharp;

//[RequireComponent(typeof(MeshFilter))]
public class SendSpatialMesh : MonoBehaviour

{
    private MLInput.Controller _controller;
    public GameObject objMeshToExport;


    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        _controller = MLInput.GetController(MLInput.Hand.Left);
        objMeshToExport = GameObject.Find("MeshingNodes");
    }

    // Update is called once per frame
    void Update()
    {
        CheckTrigger();
    }

    void OnDestroy()
    {
        MLInput.Stop();
    }

    void CheckTrigger()
    {
        if (_controller.TriggerValue > 0.2f)
        {
            using (var ws = new WebSocket("ws://127.0.0.1:4649/Laputa"))
            {
                Debug.Log("Trigger Pressed");
                //string path = Path.Combine(Application.persistentDataPath, "data");
                //path = Path.Combine(path, "roomModel" + ".stl");
                string path = "C:/Users/Brian/Desktop/newRoomModel.stl";
                GameObject[] gameObjArray = new GameObject[1];

                gameObjArray[0] = objMeshToExport;

                ws.Connect();
                Parabox.Stl.Exporter.Export(path, gameObjArray, Parabox.Stl.FileType.Binary);
                byte[] bytes = File.ReadAllBytes(path);
                //Console.WriteLine("bytes", bytes);
                ws.Send(bytes);
            }


            //string path = Path.Combine(Application.persistentDataPath, "data");
            //path = Path.Combine(path, "roomModel" + ".stl");

            //Debug.Log(objMeshToExport.transform.childCount);

            //int i = 0;
            //CombineInstance[] combine = new CombineInstance[objMeshToExport.transform.childCount];
            //foreach (Transform child in objMeshToExport.transform)
            //{
            //    GameObject meshObj = child.gameObject;
            //    Debug.Log(meshObj);
            //    Debug.Log(meshObj.GetComponent<Mesh>());
            //    combine[i].mesh = meshObj.GetComponent<Mesh>();
            //    i++;
            //}
            //transform.GetComponent<MeshFilter>().mesh = new Mesh();
            ////Debug.Log(combine);
            ////Debug.Log(combine.Length);
            //transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
            //Debug.Log(transform.GetComponent<MeshFilter>().mesh);

            //Create Directory if it does not exist
            //if (!Directory.Exists(Path.GetDirectoryName(path)))
            //{
            //    Directory.CreateDirectory(Path.GetDirectoryName(path));
            //}

            //Parabox.Stl.Exporter.WriteFile(path, transform.GetComponent<MeshFilter>().mesh, Parabox.Stl.FileType.Binary);

            //byte[] bytes = System.IO.File.ReadAllBytes(path);
            //Console.WriteLine("bytes", bytes);
            //ws.Send(bytes);

        }

        if (_controller.IsBumperDown)
        {
            Debug.Log("Bumper Pressed");
        }
    }
}
