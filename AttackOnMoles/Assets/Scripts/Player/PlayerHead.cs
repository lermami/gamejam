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
  protected float weapon_side;
  public SpriteRenderer sprite_;


    // Update is called once per frame
    void Update()
    {
      if(Time.timeScale == 1.0f){

         if(Input.mousePosition.x < Screen.width/2){
           if (!sprite_.flipY) sprite_.flipY = true;
           weapon_side = -weapon_distance;
         }else{
           if (sprite_.flipY) sprite_.flipY = false;
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

      }

    }
}
