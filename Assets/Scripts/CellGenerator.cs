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
    public GameObject cellPrefab;
    public GameObject redBloodCellPrefab;
    public GameObject whiteBloodCellPrefab;
    public float whiteCellRatio = 0.5f;
    private System.Random random = new System.Random();

    private float timer = 0.0f;

    void Start()
    {
        ship.transform.position = new Vector3(0, 0, 0);   
    }

    void CreateCell(){
        Cell cell;
        if(random.NextDouble() < whiteCellRatio){
            cell = Instantiate(whiteBloodCellPrefab).AddComponent<Cell>();
        } else {
            cell = Instantiate(redBloodCellPrefab).AddComponent<Cell>();
        }
        
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
