using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
  public float death_timer_;
  private float timer_;

    // Start is called before the first frame update
    void Start()
    {
      timer_ = 0;
    }

    // Update is called once per frame
    void Update()
    {
      if(timer_ > death_timer_)
      {
        Destroy(gameObject);
      }

      timer_ += Time.deltaTime;
    }
}
