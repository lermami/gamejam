using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float bullet_velocity;
    protected Vector3 mouse_pos;
    protected Vector3 object_pos;
    protected float angle;

    void Start()
    {
      rb = GetComponent<Rigidbody>();
      mouse_pos = Input.mousePosition;
      mouse_pos = new Vector3(mouse_pos.x, mouse_pos.y, -1000);
      object_pos = Camera.main.WorldToScreenPoint(transform.position);
      mouse_pos.x = mouse_pos.x - object_pos.x;
      mouse_pos.y = mouse_pos.y - object_pos.y;
      angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    // Update is called once per frame
    void Update()
    {
      rb.AddForce(transform.right * bullet_velocity, ForceMode.VelocityChange);
    }
}
