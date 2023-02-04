using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
  public int n_lifes;
  public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
      isDead = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecieveDamage(int damage)
    {
      n_lifes -= damage;
      if (n_lifes <= 0)
      {
        Destroy(gameObject);
      }
    }

    public bool bIsDead()
    {
      return isDead;
    }
}
