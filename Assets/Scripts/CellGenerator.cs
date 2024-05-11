using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CellGenerator : MonoBehaviour
{    
    public float speed = 10f;
    public float width = 2f;
    public float cellDistance = 20f;
    public float cellInterval = 0.5f;
    public GameObject ship;

    private float timer = 0.0f;

    void Start()
    {
        ship.transform.position = new Vector3(0, 0, 0);   
    }

    void CreateCell(){
        var cell = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Cell>();
        cell.transform.parent = transform;
        cell.ship = ship;
        cell.speed = speed;
        cell.width = width;
        cell.distance = cellDistance;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= cellInterval){
            timer = 0.0f;
            CreateCell();
        }
    }

}
