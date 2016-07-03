using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {

  public float timeWait = 1f;

	// Use this for initialization
	void Start () {
    StartCoroutine(ChangeScene());
	}
	
	IEnumerator ChangeScene()
  {
    yield return new WaitForSeconds(timeWait);
    UnityEngine.SceneManagement.SceneManager.LoadScene("Vote Card");
  }
}
