using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void ChangeToScene (int sceneToChangeTo){
		SceneManager.LoadScene (sceneToChangeTo);
	}
}
