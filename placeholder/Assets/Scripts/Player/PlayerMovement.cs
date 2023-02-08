using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public Rigidbody rb;
  protected Vector3 direction;
  protected bool movement;
  public float acceleration;
  public float jump_high;
  public float max_velocity;
  protected bool already_jump;
  public float ghost_jump_time;
  protected float jump_time;
  protected float long_jump;
  public float long_jump_max;
  public float long_jump_min;
  protected float jump_offset;

  protected bool ground_;
  protected bool walking_;

  public SpriteRenderer Sprite;
  private Animator animator_;
  private bool flipped;

  public AudioManager audioM_;


  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
    animator_ = GetComponent<Animator>();
    already_jump = false;
    long_jump = 0;
    jump_offset = -1.0f;

    animator_.SetBool("fly", false);
    animator_.SetBool("land", false);
  }

  // Update is called once per frame
  void Update()
  {
    //Movement
    if(Input.GetAxis("Horizontal") > 0)
    {
      direction = new Vector3(1, 0, 0);
      
      if (!already_jump)
        animator_.SetBool("run", true);

      if (Sprite.flipX)
        Sprite.flipX = false;
    }
    else if (Input.GetAxis("Horizontal") < 0)
    {
      direction = new Vector3(-1, 0, 0);

      if (!already_jump)
        animator_.SetBool("run", true);

      if (!Sprite.flipX)
        Sprite.flipX = true;
    }
    else
    {
      animator_.SetBool("run", false);
    }

    //Jump
    if (Input.GetButtonDown("Jump") && ((Physics.CheckBox(transform.position + new Vector3(0 , -1.8f , 0), new Vector3(0.499f , 0.05f, 0.499f), transform.rotation)) || jump_time < ghost_jump_time)  && !already_jump && jump_offset < 0){
      rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
      rb.AddForce(transform.up * Mathf.Sqrt (Physics.gravity.y * -2.0f * jump_high), ForceMode.VelocityChange);
      already_jump = true;
      animator_.SetBool("fly", true);
      animator_.SetBool("run", false);
      jump_offset = 0.4f;
    }

    if(jump_offset >= 0){
      jump_offset -= Time.deltaTime;
    }

    if(already_jump && long_jump <= long_jump_max){
      long_jump += Time.deltaTime;
    }

    if(Input.GetButton("Jump") && already_jump){
      if(long_jump > long_jump_min && long_jump < long_jump_max){
        rb.AddForce(transform.up * Mathf.Sqrt (Physics.gravity.y * -2.0f * jump_high/30000), ForceMode.VelocityChange);
      }
    }

    if(Physics.CheckBox(transform.position + new Vector3(0 , -1.8f , 0), new Vector3(0.499f , 0.1f, 0.499f), transform.rotation) && rb.velocity.y<0 && already_jump){
      audioM_.land_sound_.Play();
      already_jump = false;
      animator_.SetBool("fly", false);
      animator_.SetBool("land", false);
      long_jump = 0;
    }

    //Break
    if(Input.GetAxis("Horizontal") != 0){
      rb.AddForce(direction * acceleration * Time.deltaTime, ForceMode.VelocityChange);
    }else{
      rb.velocity = new Vector3(rb.velocity.x*0.9f, rb.velocity.y, 0);
    }

    //AirBreak
    if(Input.GetAxis("Horizontal") > 0 && rb.velocity.x < (-acceleration/2)){
      rb.velocity = new Vector3((-acceleration/3), rb.velocity.y, rb.velocity.z);
    }

    if(Input.GetAxis("Horizontal") < 0 && rb.velocity.x > (acceleration/2)){
      rb.velocity = new Vector3((acceleration/3), rb.velocity.y, rb.velocity.z);
    }

    //Speed Limiter
    if(rb.velocity.x > max_velocity){
      rb.velocity = new Vector3(max_velocity, rb.velocity.y, rb.velocity.z);
    }

    if(rb.velocity.x < -max_velocity){
      rb.velocity = new Vector3(-max_velocity, rb.velocity.y, rb.velocity.z);
    }

    //Ghost Time Timer
    if(!Physics.CheckBox(transform.position + new Vector3(0 , -1.0f , 0), new Vector3(0.499f , 0.1f, 0.499f), transform.rotation) && !already_jump){
      jump_time += Time.deltaTime;
    }else{
      jump_time = 0;
    }

    //Falling Death
    if(transform.position.y < -15 ){
      SceneManager.LoadScene("GameOver");
    }

    //Walking
    if((rb.velocity.x > 0.1f || rb.velocity.x < -0.1f) && !already_jump){
      walking_ = true;
    }else{
      walking_ = false;
    }

  }

  public void FlyAway(Vector3 other_pos)
  {
    Vector3 force_dir = transform.position - other_pos;
    force_dir = force_dir.normalized;

    if(force_dir.x == 1.0f || force_dir.x == -1.0f)
    {
      rb.AddForce(force_dir * 20.0f, ForceMode.VelocityChange);
    }
    else
    {
      rb.AddForce(force_dir * 10.0f, ForceMode.VelocityChange);
    }
  }

  public bool isWalking(){
    return walking_;
  }

  public void setWalking(bool walking){
    walking_ = walking;
  }
}
