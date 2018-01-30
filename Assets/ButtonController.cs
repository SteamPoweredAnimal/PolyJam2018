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
	public int direction = 1;
	public bool stay = false;
	
	private void Update()
	{
		if (fade)
		{
			if (!image.gameObject.activeInHierarchy)
			{
				image.gameObject.SetActive(true);
			}
			
			timer += Time.deltaTime;
			
			if(direction == 1) image.material.SetFloat("_Cutoff", timer / totalTime);
			else image.material.SetFloat("_Cutoff", 1.0f - timer / totalTime);
			
			if (timer >= totalTime)
			{
				if (!stay)
				{
					if (direction == 1) SceneManager.LoadScene("FinalArena");
					else gameObject.SetActive(false);
				}
			}
		}
	}

	public void OpenFightScene()
	{
		fade = true;
	}
}
