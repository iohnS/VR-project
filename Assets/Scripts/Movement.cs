using PathCreation;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Tunnel tunnel;
    void Start()
    {
        if (tunnel == null)
        {
            tunnel = transform.AddComponent<Tunnel>();
        }
    }

    void Update()
    {
        transform.position = tunnel.currentPosition;
        transform.rotation = tunnel.currentRotation;
    }
}
