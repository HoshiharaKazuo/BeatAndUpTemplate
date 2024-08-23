using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifebarController : MonoBehaviour
{
    [SerializeField]
    private PlayerLife playerLife;
    [SerializeField]
    private Slider lifeBar;


    private void Start()
    {
        ConfigLifeBar();
    }
    private void Update()
    {
        UpdateLifeSlider();
    }

    private void UpdateLifeSlider()
    {
        lifeBar.value = playerLife.GetCurrentLife();
    }

    private void ConfigLifeBar()
    {
        lifeBar.maxValue = playerLife.GetMaxLife();
    }

}
