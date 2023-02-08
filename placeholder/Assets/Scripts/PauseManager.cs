using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
  public HudManager menu;
  protected bool pause;

    // Start is called before the first frame update
    void Start()
    {
      pause = false;
      menu.ActivatePauseMenu(pause);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause")){
          if(pause){
            Time.timeScale = 1.0f;
            pause = false;
            menu.ActivatePauseMenu(pause);
          }else{
            Time.timeScale = 0.0f;
            pause = true;
            menu.ActivatePauseMenu(pause);
          }

        }

        if(Time.timeScale == 1.0f && pause){
            pause = false;
            menu.ActivatePauseMenu(pause);
        }
    }
}
