using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
  private Transform tr_;
  public Vector3 dir_;
  public float speed_;

  // Start is called before the first frame update
    void Start()
    {
      tr_ = GetComponent<Transform>();
    }

  // Update is called once per frame
    void Update()
    {
      tr_.position += dir_ * speed_ * Time.deltaTime;
    }
}
