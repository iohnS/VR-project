using UnityEngine;
using PathCreation;
using UnityEditor;
using System;
using System.Security.Cryptography;
using System.Threading;


public class PropsGenerator : MonoBehaviour{

    public GameObject ship;
    public float speed = 10f;
    private Vector2 target;
    private GameObject cell;
    
    private float startZ = 20f;
    private float width = 10f;
    private System.Random random = new System.Random(); 
    private GameObject[] cells; 

    void Start(){
        target = ship.transform.position;
        ship.transform.position = new Vector3(0, 0, 0);
    }

    // Creates a random cell from a given width.
    void CreateCell(float w, float distance) {
        cell = GameObject.CreatePrimitive(PrimitiveType.Cube);
        int rnd = random.Next();
        cell.transform.position = new Vector3((float)Math.Sin(rnd) * w, (float)Math.Cos(rnd) * w, distance); 
        cell.AddComponent<Rigidbody>();
        cell.GetComponent<Rigidbody>().useGravity = false;
        cell.GetComponent<Rigidbody>().velocity = cell.transform.forward * -1 * speed;
        Destroy(cell, distance/speed + 1f);
    }


    void Update(){
        for(int i = 0; i < 10; i++){
            Thread.Sleep(500);
            CreateCell(width, startZ);
        }
    }
}