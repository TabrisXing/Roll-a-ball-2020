using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_5pts : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    { 
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
