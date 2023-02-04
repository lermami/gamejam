using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.GetComponent<PlayerMovement>().IsInmune()){
        Debug.Log("Protected");
        Destroy(gameObject);
      }else{
        Debug.Log("Hitted");
        other.gameObject.GetComponent<HealthManager>().RecieveDamage(1);
        Destroy(gameObject);
      }
    }
}
