using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    private HealthManager healthM_;
    private PlayerShooting player_shoot_;

    // Start is called before the first frame update
    void Start()
    {
        healthM_ = GetComponent<HealthManager>();
        player_shoot_ = GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Movile platform floor
    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("movile_platform") && Physics.CheckBox(transform.position + new Vector3(0 , -1.0f , 0), new Vector3(0.499f , 0.1f, 0.499f), transform.rotation)){
            transform.parent = other.transform;
        }

        if (other.gameObject.CompareTag("Shield_PickUP")){
            Destroy(other.gameObject);
            healthM_.shielded_counter = 10;
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

    
}
