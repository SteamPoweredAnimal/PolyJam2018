using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
	public float totalTime = 0.0f;
	private float timer = 0.0f;
	public bool fade = false;
	public RawImage image;
	
	private void Update()
	{
		if (fade)
		{
			if (!image.gameObject.activeInHierarchy)
			{
				image.gameObject.SetActive(true);
			}
			
			timer += Time.deltaTime;
			
			image.material.SetFloat("_Cutoff", timer / totalTime);
			
			if (timer >= totalTime)
			{
				SceneManager.LoadScene("FinalArena");
			}
		}
	}

	public void OpenFightScene()
	{
		fade = true;
	}
}
