using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
  public Image[] lifes = new Image[3];
  public Text ammo;

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

    public void ChangeAmmo(int nBullets)
    {
      ammo.text = nBullets.ToString();
    }

}
