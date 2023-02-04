using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
  public float roll_speed;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, transform.rotation.y+roll_speed*Time.deltaTime, 0);
    }
}
