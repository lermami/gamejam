using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public AudioSource mole0;
  public AudioSource mole1;
  public AudioSource mole2;
  public AudioSource mole3;
  public AudioSource mole4;
  public AudioSource mole5;

    // Update is called once per frame
    public void Sound(int sound)
    {
      switch(sound){
        case 0:
          mole0.Play();
        break;

        case 1:
          mole1.Play();
        break;

        case 2:
          mole2.Play();
        break;

        case 3:
          mole3.Play();
        break;

        case 4:
          mole4.Play();
        break;

        case 5:
          mole5.Play();
        break;
      }
    }
}
