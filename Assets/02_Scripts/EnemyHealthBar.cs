using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
        healthSlider.maxValue = enemyController.maxHealth;
        healthSlider.value = enemyController.maxHealth;
    }

    private void Update()
    {
        healthSlider.value = enemyController.currentHealth;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        healthSlider.transform.position = screenPosition;
    }
}
