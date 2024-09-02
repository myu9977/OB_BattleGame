using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrowPrefab; // 화살 Prefab
    public Transform firePoint; // 화살이 발사될 위치
    public float fireForce = 20f; // 화살의 발사 속도
    public float attackInterval = 1.0f; // 1초마다 발사
    public float attackRadius = 5.0f; // 공격 범위
    public int damageAmount = 10; // 데미지

    private void Start()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            FireArrow();

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy"))
                {
                    EnemyHealth enemyHealth = hitCollider.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damageAmount);
                    }
                }
            }


            yield return new WaitForSeconds(attackInterval);
        }
    }

    private void FireArrow()
    {
        // 화살 생성
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
        }
    }
}
