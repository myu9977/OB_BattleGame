using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackInterval = 1.0f;
    public float attackRadius = 5.0f;
    public int attackDamage = 100;
    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            PlayerAttack();
            nextAttackTime = Time.time + attackInterval;
        }
    }

    void PlayerAttack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        foreach (var hitCollider in hitColliders)
        {
            MonsterHealth monsterHealth = hitCollider.GetComponent<MonsterHealth>();
            if (monsterHealth != null)
            {
                Debug.Log($"플레이어가 {hitCollider.name} 공격");
                monsterHealth.TakeDamage(attackDamage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();
        if (monsterHealth != null)
        {
            Debug.Log($"플레이어 범위 안으로 {other.name} 들어옴");
            //monsterHealth.TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
