using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoivement : MonoBehaviour
{
  public Rigidbody rb;
  public GameObject camera;
  Vector3 direction;
  protected bool movement;
  public float velocity;
  public float jump_high;
  bool already_jump;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      already_jump = false;
    }

    // Update is called once per frame
    void Update()
    {

      direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
      direction.Normalize();

      if(Input.GetAxis("Horizontal") > 0 && rb.velocity.x < 0){
        rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
      }

      if(Input.GetAxis("Horizontal") < 0 && rb.velocity.x > 0){
        rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
      }

      if(Input.GetAxis("Horizontal") > 0){
        direction = new Vector3(1, 0, 0);
      }

      if(Input.GetAxis("Horizontal") < 0){
        direction = new Vector3(-1, 0, 0);
      }

      if(Input.GetAxis("Horizontal") != 0){
        rb.AddForce(direction * velocity * Time.deltaTime, ForceMode.VelocityChange);
      }else{
        rb.velocity = new Vector3(rb.velocity.x*0.9f, rb.velocity.y, 0);
      }

      if(Input.GetButtonDown("Jump") && Physics.CheckBox(transform.position + new Vector3(0 , -1.0f , 0), new Vector3(0.499f , 0.1f, 0.499f), transform.rotation) && !already_jump){
        rb.AddForce(transform.up * Mathf.Sqrt (Physics.gravity.y * -2.0f * jump_high), ForceMode.VelocityChange);
        already_jump = true;
      }

      if(Physics.CheckBox(transform.position + new Vector3(0 , -1.0f , 0), new Vector3(0.499f , 0.1f, 0.499f), transform.rotation) && rb.velocity.y<0){
        already_jump = false;
      }

    }
}
