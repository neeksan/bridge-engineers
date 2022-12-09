using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Point : MonoBehaviour
{
    public bool Runtime = true;
    public List<Bar> ConnectedBars;
    public Vector2 PointID;
    public Rigidbody2D rbd;

    void Start()
    {
        if (!Runtime)
        {
            rbd.bodyType = RigidbodyType2D.Static;
            PointID = transform.position;
            if (!GameManager.AllPoints.ContainsKey(PointID))
            {
                GameManager.AllPoints.Add(PointID, this);
            }
        }
    }

    void Update()
    {
        if (!Runtime)
        {
            if (transform.hasChanged)
            {
                transform.hasChanged = false;
                transform.position = Vector3Int.RoundToInt(transform.position);
            }
        }
    }
}
