using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    private HealthManager healthM_;
    public PlayerShooting player_shoot_;

    // Start is called before the first frame update
    void Start()
    {
        healthM_ = GetComponent<HealthManager>();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Shield_PickUP")){
            Destroy(other.gameObject);
            healthM_.shielded_counter = 10;
        }

        if (other.gameObject.CompareTag("Ammo_PickUP"))
        {
            Destroy(other.gameObject);
            player_shoot_.AddAmmo(20);
        }

        if (other.gameObject.CompareTag("Health_PickUP"))
        {
            Destroy(other.gameObject);
            if(gameObject.GetComponent<HealthManager>().n_lifes < 3){
                gameObject.GetComponent<HealthManager>().RecieveDamage(-1);
            }
        }
    }

    //Movile platform floor
    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("movile_platform") && Physics.CheckBox(transform.position + new Vector3(0 , -1.0f , 0), new Vector3(0.499f , 0.1f, 0.499f), transform.rotation)){
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("movile_platform")){
            transform.parent = null;
        }
    }

    
}
