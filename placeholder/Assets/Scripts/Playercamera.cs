using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercamera : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3(transform.position.x, gameObject.transform.parent.position.y/2, transform.position.z);
    }
}
