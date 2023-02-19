using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject cursor;
    private Vector3 _startPos;
    public float scaleValue = 5;
    private void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        RayPlayerOnCursor();
            
    }
    void RayPlayerOnCursor()
    {
        Vector2 dir =  cursor.transform.position - player.transform.position ;
        Ray ray = new Ray(player.transform.position, dir);
        float distance = Vector2.Distance(cursor.transform.position, player.transform.position) / scaleValue;
        Vector2 pointCenter = ray.GetPoint(distance);
        transform.position = new Vector3(pointCenter.x, pointCenter.y, _startPos.z);

    }
}
