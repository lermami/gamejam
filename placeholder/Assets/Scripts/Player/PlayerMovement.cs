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
  protected float shielded_counter;
  public PlayerShooting player_shoot_;
  protected float long_jump;
  public float long_jump_max;
  public float long_jump_min;
  protected bool ground_;
  protected bool walking_;
  public AudioSource footsteps_;
  public AudioSource land_sound_;


    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      already_jump = false;
      shielded_counter = 0;
      long_jump = long_jump_max;
    }

    // Update is called once per frame
    void Update()
    {

      //Movement
      if(Input.GetAxis("Horizontal") > 0){
        direction = new Vector3(1, 0, 0);
      }

      if(Input.GetAxis("Horizontal") < 0){
        direction = new Vector3(-1, 0, 0);
      }

    //Jump
      ground_ = (Physics.CheckBox(transform.position + new Vector3(0, -1.0f, 0),
      new Vector3(0.499f, 0.1f, 0.499f), transform.rotation));

      if(Input.GetButtonDown("Jump") && ((Physics.CheckBox(transform.position + new Vector3(0 , -1.0f , 0), new Vector3(0.499f , 0.1f, 0.499f), transform.rotation)) || jump_time < ghost_jump_time)  && !already_jump){
        rb.AddForce(transform.up * Mathf.Sqrt (Physics.gravity.y * -2.0f * jump_high), ForceMode.VelocityChange);
        already_jump = true;
      }

      if(Input.GetButton("Jump") && already_jump){
        if(long_jump > long_jump_min && long_jump < long_jump_max){
          rb.AddForce(transform.up * Mathf.Sqrt (Physics.gravity.y * -2.0f * jump_high/1000), ForceMode.VelocityChange);
        }
        long_jump += Time.deltaTime;
      }


      if(Physics.CheckBox(transform.position + new Vector3(0 , -1.0f , 0), new Vector3(0.499f , 0.1f, 0.499f), transform.rotation) && rb.velocity.y<0 && already_jump){
        land_sound_.Play();
        already_jump = false;
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

      //Inmunity
      if(shielded_counter > 0){
        shielded_counter -= Time.deltaTime;
      }

      //Fallin Deth
      if(transform.position.y < -15 ){
        SceneManager.LoadScene("GameOver");
      }

      //Footsteps audio
      if((rb.velocity.x > 0.1f || rb.velocity.x < -0.1f) && ground_)
      {
        if (!walking_)
        {
          footsteps_.Play();
        }
        walking_ = true;
        }
      else
      {
        footsteps_.Stop();
        walking_ = false;
      }
  }

    //Movile platform floor
    void OnCollisionEnter(Collision other){
      if (other.gameObject.CompareTag("movile_platform") && Physics.CheckBox(transform.position + new Vector3(0 , -1.0f , 0), new Vector3(0.499f , 0.1f, 0.499f), transform.rotation)){
         transform.parent = other.transform;
      }

      if (other.gameObject.CompareTag("Shield_PickUP")){
         Destroy(other.gameObject);
         shielded_counter = 10;
      }

      if (other.gameObject.CompareTag("Ammo_PickUP"))
      {
        player_shoot_.AddAmmo(20);
        Destroy(other.gameObject);
      }

      if (other.gameObject.CompareTag("Health_PickUP"))
      {
        Destroy(other.gameObject);
        if(gameObject.GetComponent<HealthManager>().n_lifes < 3){
          gameObject.GetComponent<HealthManager>().RecieveDamage(-1);
        }
      }
  }

    void OnCollisionExit(Collision other)
    {
      if (other.gameObject.CompareTag("movile_platform")){
         transform.parent = null;
      }
    }

    public bool IsInmune(){
      if(shielded_counter > 0){
        return true;
      }else{
        return false;
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
}
