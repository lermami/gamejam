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
      if(other.gameObject.GetComponent<HealthManager>().IsInmune()){
        Destroy(gameObject);
      }else{
        other.gameObject.GetComponent<HealthManager>().RecieveDamage(1);
        Destroy(gameObject);
      }
    }
}
