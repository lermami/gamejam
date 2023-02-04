using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

  public string text;
  public bool need_input;

  // Start is called before the first frame update
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Return) && need_input)
    {
      SceneManager.LoadScene(text);
    }

  }

  void OnCollisionEnter(Collision other){
    if (other.gameObject.CompareTag("Player")){
      SceneManager.LoadScene(text);
    }
  }
}
