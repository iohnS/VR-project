using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))] // Requires MeshFilter and MeshRenderer components to be attached to the same GameObject
public class TunnelMeshGenerator : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject ship;

    private readonly int smoothness = 10; // Number of segments in the tunnel
    Vector3[] pathPoints;
    Vector3[] normals;
    Vector3[] tangents;

    void Start()
    {
        pathCreator.transform.position = Vector3.zero;
        transform.position = Vector3.zero;

        pathPoints = pathCreator.path.localPoints;
        normals = pathCreator.path.localNormals;
        tangents = pathCreator.path.localTangents;

        for (int i = 0; i < pathPoints.Length; i++)
        {
            CreateCylinder(pathPoints[i], tangents[i], normals[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CreateCylinder(Vector3 point, Vector3 direction, Vector3 normal){
        GameObject cylinder = new GameObject("Cylinder");
        cylinder.transform.position = point;
        Quaternion rotation = Quaternion.LookRotation(direction, normal);
        cylinder.transform.rotation = rotation;

        MeshFilter meshFilter = cylinder.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = cylinder.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();

        float radius = 1f;
        float height = 0.2f;

        Vector3[] vertices = new Vector3[smoothness * 2];      // Vertices for the top and bottom circles
        
        int[] triangles = new int[smoothness * 6]; // Triangles for the side faces
        
        Vector3[] normals = new Vector3[smoothness * 2]; // Normals

        // Generate vertices and triangles for the top and bottom circles
        for (int i = 0; i < smoothness; i++)
        {
            float angle = (Mathf.PI * 2f / smoothness) * i;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            vertices[i] = new Vector3(x, y, height / 2f) + point;
            vertices[i + smoothness] = new Vector3(x, y, -height / 2f) + point;

            // Set normals
            normals[i] = Vector3.up;
            normals[i + smoothness] = Vector3.down;
        }

        // Generate triangles for the side faces
        for (int i = 0; i < smoothness; i++)
        {
            int ti = i * 6;
            int vi = i;

            triangles[ti] = vi;
            triangles[ti + 1] = vi + smoothness;
            triangles[ti + 2] = (vi + 1) % smoothness;

            triangles[ti + 3] = vi + smoothness;
            triangles[ti + 4] = (vi + 1) % smoothness + smoothness;
            triangles[ti + 5] = (vi + 1) % smoothness;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;

        meshFilter.mesh = mesh;
    }
}
