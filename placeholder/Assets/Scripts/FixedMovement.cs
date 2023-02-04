using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovement : MonoBehaviour
{
  public float max_;
  public float min_;
  public float speed_;
  public float parent_speed_;
  public Vector3 dir_;

  // Start is called before the first frame update
  void Start()
  {
    if (transform.parent != null && transform.parent.GetComponent<FixedMovement>() != null)
    {
      FixedMovement mov_;
      mov_ = transform.parent.GetComponent<FixedMovement>();
      parent_speed_ = mov_.speed_;
    }
    else
    {
      parent_speed_ = 0;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (dir_.x != 0)
    {
      if (transform.localPosition.x < min_)
      {
        dir_ = new Vector3(-dir_.x, 0, 0);
        transform.localPosition = new Vector3(min_, transform.localPosition.y, 0);
      }

      if (transform.localPosition.x > max_)
      {
        dir_ = new Vector3(-dir_.x, 0, 0);
        transform.localPosition = new Vector3(max_, transform.localPosition.y, 0);
      }
    }
    else
    {
      if (transform.position.y < min_)
      {
        dir_ = new Vector3(0, -dir_.y, 0);
        transform.position = new Vector3(transform.position.x, min_, 0);
      }

      if (transform.position.y > max_)
      {
        dir_ = new Vector3(0, -dir_.y, 0);
        transform.position = new Vector3(transform.position.x, max_, 0);
      }
    }

    transform.position += dir_ * (speed_ + parent_speed_) * Time.deltaTime;
  }
}
