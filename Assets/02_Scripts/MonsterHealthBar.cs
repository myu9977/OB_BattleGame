using UnityEngine;
using UnityEngine.UI;

public class MonsterHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    private MonsterHealth monsterHealth;

    void Start()
    {
        monsterHealth = GetComponent<MonsterHealth>();
        healthSlider.maxValue = monsterHealth.health;
        healthSlider.value = monsterHealth.health;
    }

    void Update()
    {
        if (monsterHealth != null)
        {
            healthSlider.value = monsterHealth.health;
        }
    }
}
