using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
  public int n_lifes;
  public bool isDead;
  public float inmune_timer_;

  private PlayerMovement playerMov_;
    // Start is called before the first frame update
    void Start()
    {
      isDead = false;
      inmune_timer_ = 0;

      if(GetComponent<PlayerMovement>() != null)
      {
        playerMov_ = GetComponent<PlayerMovement>();
      }
    }

    // Update is called once per frame
    void Update()
    {
      if(inmune_timer_ > 0)
      {
        inmune_timer_ -= Time.deltaTime;
      }
    }

    public void RecieveDamage(int damage)
    {
      if(inmune_timer_ <= 0)
      {
        n_lifes -= damage;
      }
      if (n_lifes <= 0)
      {
        Destroy(gameObject);
      }
      inmune_timer_ = 0.5f;

    }

    public bool bIsDead()
    {
      return isDead;
    }
}
