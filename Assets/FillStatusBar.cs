using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public Enemy enemy;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
       slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
       float fillValue = enemy.health / enemy.maxHealth;
       slider.value = fillValue;
    }
}
