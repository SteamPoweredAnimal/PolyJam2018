using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	public void OpenFightScene()
	{
		SceneManager.LoadScene("FinalArena");
	}
}
