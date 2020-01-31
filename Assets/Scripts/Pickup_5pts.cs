using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_5pts : MonoBehaviour
{
    private Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);
    // Update is called once per frame

        void Update()
    { 
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        transform.RotateAround(target, Vector3.up, 30 * Time.deltaTime);
    }

}
