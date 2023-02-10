using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
  private Transform tr_;
  public Transform player_tr_;
  public float shoot_cd_;
  public GameObject bulletPrefab_;

  private float timer_;
    // Start is called before the first frame update
    void Start()
    {
      tr_ = GetComponent<Transform>();
      timer_ = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
      if (Vector3.Distance(tr_.position, player_tr_.position) < 15.0f)
      {
        if(timer_ > shoot_cd_)
        {
          timer_ = 0;
          Instantiate(bulletPrefab_, new Vector3(tr_.position.x - 1.0f, tr_.position.y, 0.0f), Quaternion.identity);
        }

        timer_ += Time.deltaTime;
      }
    }
}
