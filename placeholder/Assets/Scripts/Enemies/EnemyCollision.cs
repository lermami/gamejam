using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.tag == "Player")
      {
        other.gameObject.GetComponent<PlayerMovement>().FlyAway(transform.position);
        other.gameObject.GetComponent<HealthManager>().RecieveDamage(1);
      }
    }
}
