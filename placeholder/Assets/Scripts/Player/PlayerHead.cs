using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using ;

public class PlayerHead : MonoBehaviour
{

  protected Vector3 object_pos;
  protected Vector3 mouse_pos;
  protected float angle;
  public float weapon_distance;
  public GameObject bulletPrefab_;
  protected float weapon_side;
  public float cadence;
  protected float fire_time;


    // Update is called once per frame
    void Update()
    {

       if(Input.mousePosition.x < Screen.width/2){
         weapon_side = -weapon_distance;
       }else{
         weapon_side = weapon_distance;
       }

        transform.position = new Vector3(gameObject.transform.parent.position.x+weapon_side, transform.position.y, transform.position.z);


      mouse_pos = Input.mousePosition;
      mouse_pos = new Vector3(mouse_pos.x, mouse_pos.y, -1000);
      object_pos = Camera.main.WorldToScreenPoint(transform.position);
      mouse_pos.x = mouse_pos.x - object_pos.x;
      mouse_pos.y = mouse_pos.y - object_pos.y;
      angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


      if(Input.GetButton("Fire1") && fire_time <0){
          Instantiate(bulletPrefab_, new Vector3(transform.position.x+weapon_side, transform.position.y, 0.0f), Quaternion.identity);
          fire_time = cadence;
      }

      if(fire_time >=  0){
        fire_time -= Time.deltaTime;
      }


    }
}
