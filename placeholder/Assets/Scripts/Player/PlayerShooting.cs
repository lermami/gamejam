using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
  public float cadence;
  protected float fire_time;
  public GameObject bulletPrefab_;
  public int nBullets;

    // Update is called once per frame
    void Update()
    {
      if(Input.GetButton("Fire1") && fire_time < 0 && nBullets > 0){
          Instantiate(bulletPrefab_, new Vector3(transform.position.x, transform.position.y, 0.0f), Quaternion.identity);
          fire_time = cadence;
          nBullets--;
      }

      if(fire_time >=  0){
        fire_time -= Time.deltaTime;
      }
    }
}
