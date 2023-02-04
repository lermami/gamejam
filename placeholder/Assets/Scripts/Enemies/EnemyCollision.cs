using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
  private Rigidbody rb_;
    // Start is called before the first frame update
    void Start()
    {
      rb_ = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      //Fallin Deth
      if(transform.position.y < -30 ){
        Destroy(gameObject);
      }
    }

    void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.tag == "Player")
      {
        PlayerMovement playerMov_ = other.gameObject.GetComponent<PlayerMovement>();

        if (!playerMov_.IsInmune())
        {
          playerMov_.FlyAway(transform.position);
          other.gameObject.GetComponent<HealthManager>().RecieveDamage(1);
        }
        else
        {
          rb_.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX |
                            RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

          rb_.useGravity = true;
          FlyAway(other.transform.position);
          transform.position = new Vector3(transform.position.x, transform.position.y, -1.5f);
          Destroy(gameObject.GetComponent<FixedMovement>());
          Destroy(gameObject.GetComponent<BoxCollider>());
        }
      }
    }

    void FlyAway(Vector3 other_pos)
    {
      Vector3 force_dir = transform.position - other_pos;
      force_dir = force_dir.normalized;
      force_dir = new Vector3(force_dir.x / 8.0f, 0.8f, force_dir.z);

      rb_.AddForce(force_dir * 10.0f, ForceMode.VelocityChange);
    }
}
