using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
  public Image[] lifes = new Image[3];
  public Image shield;
  public Text ammo;
  public GameObject exit_button;
  public GameObject return_button;
  public GameObject resume_button;
  public GameObject background;

    public void ChangeLifes(int n_lifes)
    {
      for(int i = 0; i < n_lifes; i++)
      {
        lifes[i].gameObject.SetActive(true);
      }

      for(int i = n_lifes; i < 3; i++)
      {
        lifes[i].gameObject.SetActive(false);
      }
    }

    public void SetShield(bool activated){
      if(activated){
        shield.gameObject.SetActive(true);
      }else{
        shield.gameObject.SetActive(false);
      }
    }

    public void ChangeAmmo(int nBullets)
    {
      ammo.text = nBullets.ToString();
    }

    public void ActivatePauseMenu(bool option){
      resume_button.SetActive(option);
      return_button.SetActive(option);
      exit_button.SetActive(option);
      background.SetActive(option);
    }
}
