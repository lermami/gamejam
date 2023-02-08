using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public AudioSource footsteps_;
  public AudioSource land_sound_;
  public PlayerMovement playerMov_;

  public bool walk_sound;

    void Start(){
        walk_sound = false; 
    }
   
    // Update is called once per frame
    void Update()
    {
      //Footsteps audio
      if(playerMov_.isWalking()) {
        if(!walk_sound)
            footsteps_.Play();
        walk_sound = true;
      } else {
        footsteps_.Stop();
        walk_sound = false;
      }
    }
}
