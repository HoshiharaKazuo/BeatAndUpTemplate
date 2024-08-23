using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject [] powerUps;

    [SerializeField]
    private GameObject powerUpSpawnPoint;

    public void SpawnPowerUp()
    {
        GameObject selectedPowerup = SortPowerUp();
        Instantiate(selectedPowerup, powerUpSpawnPoint.transform.position, Quaternion.identity);
    }

    private GameObject SortPowerUp() {

        GameObject selectedPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        return selectedPowerUp;
    }
}
