using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

  public void StartGameHandle1()
  {

      SceneManager.LoadScene("StageOne");
  }

  public void StartGameHandle2()
  {

      SceneManager.LoadScene("Controls");
  }

  public void ReturnMainMenu(){
    SceneManager.LoadScene("Start");
  }

  public void Resume(){
    Time.timeScale = 1.0f;
  }

  public void Exit(){
    Application.Quit();
  }

}
