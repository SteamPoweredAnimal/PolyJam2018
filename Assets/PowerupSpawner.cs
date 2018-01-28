using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour {

    public GameObject[] powerups;
    public GameObject[] powerupSlots;

	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnPawerUp");
	}

    IEnumerator SpawnPawerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);

            int slotIndex = Random.Range(0, powerupSlots.Length);
            int powerUpIndex = Random.Range(0, powerups.Length);
            Debug.Log("Power up index : " + powerUpIndex);

            if (powerupSlots[slotIndex].transform.childCount == 0)
            {
                GameObject powerupGO = Instantiate(powerups[powerUpIndex]);
                powerupGO.transform.parent = powerupSlots[slotIndex].transform;
                powerupGO.transform.localPosition = Vector3.zero;
            }
        }

    }

    public void SpawnShield (Vector3 position)
    {
        GameObject powerupGO = Instantiate(powerups[0]);
        powerupGO.transform.position = position + new Vector3 (0f, 0f, -0.01f);
    }
	
}
