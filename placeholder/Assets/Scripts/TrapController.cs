using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
  private bool triggered;
  private bool finished;
  private float aux_position;
  // Start is called before the first frame update
  void Start()
  {
    triggered = false;
    finished = false;
    aux_position = transform.position.y;
  }

  // Update is called once per frame
  void Update()
  {
    if (triggered && !finished)
    {
      transform.position += new Vector3(0.0f, 3.0f, 0.0f);

      if(transform.position.y > aux_position)
      {
        transform.position = new Vector3(transform.position.x, aux_position, 0.0f);
        finished = true;
      }
    }
  }

  void OnTriggerEnter(Collider other) 
  {
    if (!triggered) triggered = true;
  }
}
