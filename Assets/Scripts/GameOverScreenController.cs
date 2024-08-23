using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenController : MonoBehaviour
{
    [SerializeField]
    private PlayerLife playerLife;
    
    [SerializeField]
    private GameObject gameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GetRestartInput();

        if (!playerLife.GetAliveStatus())
        {
            gameOverScreen.SetActive(true);
        }
    }

    private void GetRestartInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1.0f;
    }
}
