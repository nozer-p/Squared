using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    private enum Side
    {
        Left = -1,
        Right = 1
    }

    private Vector2 start;
    private Vector2 finish;
    private Transform trans;

    private Camera cam;

    void Start()
    {
        start = Vector2.right;
        trans = transform;
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        float rotateZ = GetRotateZ();
        trans.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    private float GetRotateZ()
    {
        finish = (Vector2)(cam.ScreenToWorldPoint(Input.mousePosition) - trans.position);
        float scalarCom = start.x * finish.x + start.y * finish.y;
        float nudelesCom = start.magnitude * finish.magnitude;
        float division = scalarCom / nudelesCom;
        float angle = Mathf.Acos(division) * Mathf.Rad2Deg * (int)GetSide();
        return angle;
    }

    private Side GetSide()
    {
        Side side = Side.Right;
        if (finish.y <= start.y)
        {
            side = Side.Left;
        }
        return side;
    }
}