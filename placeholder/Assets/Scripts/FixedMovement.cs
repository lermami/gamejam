using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovement : MonoBehaviour
{
  private Transform tr_;
  public float speed_;
    // Start is called before the first frame update
    void Start()
    {
        tr_ = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
