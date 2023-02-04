using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

  public string text;

  // Start is called before the first frame update
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Return))
    {
      SceneManager.LoadScene(text);
    }

  }
}
