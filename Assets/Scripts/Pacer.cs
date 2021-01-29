﻿using UnityEngine;
{
    public float speed = 5.0f;
    private float zMax = 7.5f;
    private float zMin = -7.5f;
    private int direction = 1;


    void Update()
    {
        float zNew = transform.position.z + direction * speed * Time.deltaTime;
        if (zNew >= zMax)
        {
            zNew = zMax;
            direction *= -1;
        }
        else if (zNew <= zMin)
        {
            zNew = zMin;

        }
        transform.position = new Vector3(7.5f, 0.75f, zNew);

    }
}