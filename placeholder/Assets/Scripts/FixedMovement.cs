using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovement : MonoBehaviour
{
  private Transform tr_;
  private Rigidbody rb_;
  private Vector3 dir_;

  public float speed_;
  public Transform startPos;
  public Transform finalPos;

    // Start is called before the first frame update
    void Start()
    {
        tr_ = GetComponent<Transform>();
        rb_ = GetComponent<Rigidbody>();

        dir_ = new Vector3(speed_, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(tr_.position.x < startPos.position.x)
        {
          dir_ = new Vector3(-dir_.x, dir_.y, dir_.z);
          tr_.position = new Vector3(startPos.position.x, tr_.position.y, tr_.position.z);
        }

        if (tr_.position.x > finalPos.position.x)
        {
          dir_ = new Vector3(-dir_.x, dir_.y, dir_.z);
          tr_.position = new Vector3(finalPos.position.x, tr_.position.y, tr_.position.z);
        }

        tr_.position += dir_ * Time.deltaTime;
    }

}
