using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
  public int n_lifes;
  public bool isDead;
  public float inmune_timer_;


  private PlayerMovement playerMov_;
  private HudManager hudC_;
    // Start is called before the first frame update
    void Start()
    {
      isDead = false;
      inmune_timer_ = 0;

      if(GetComponent<PlayerMovement>() != null)
      {
        playerMov_ = GetComponent<PlayerMovement>();
      }

      if(gameObject.tag == "Player")
      {
        hudC_ = GameObject.Find("HudManager").GetComponent<HudManager>();
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
        if(hudC_ != null)
        {
          hudC_.ChangeLifes(n_lifes);
        }
      }
      if (n_lifes <= 0)
      {
        if(gameObject.CompareTag("Enemy")){
          GameObject player = GameObject.Find("Player");
          int random_number = Random.Range(0,6);
          player.GetComponent<SoundManager>().Sound(random_number);
        }
        Destroy(gameObject);
        if(gameObject.CompareTag("Player")){
          SceneManager.LoadScene("GameOver");
        }
      }
      if(gameObject.CompareTag("Player")){
        inmune_timer_ = 0.5f;
      }

    }

    public bool bIsDead()
    {
      return isDead;
    }
}
