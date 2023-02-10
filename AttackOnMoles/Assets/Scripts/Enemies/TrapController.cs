using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
  private bool triggered;
  private bool finished;
  private float aux_position;

  private Vector3 check_box_pos;
  private Vector3 check_box_size;
  // Start is called before the first frame update
  void Start()
  {
    triggered = false;
    finished = false;
    aux_position = transform.position.y + 1.0f;

    check_box_size = new Vector3(0.5f, 0.5f, 1.0f);
  }

  // Update is called once per frame
  void Update()
  {
    if (triggered && !finished)
    {
      transform.position += new Vector3(0.0f, 1.0f, 0.0f);

      if(transform.position.y > aux_position)
      {
        transform.position = new Vector3(transform.position.x, aux_position, 0.0f );
        finished = true;
      }
    }
  }

  void FixedUpdate()
  {
    if(!finished && Physics.CheckBox(new Vector3(transform.position.x, transform.position.y + 1.1f, 0.0f), check_box_size, transform.rotation))
    {
      triggered = true;
    }
  }

}
