using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrowPrefab; // ȭ�� Prefab
    public Transform firePoint; // ȭ���� �߻�� ��ġ
    public float fireForce = 20f; // ȭ���� �߻� �ӵ�
    public float attackInterval = 1.0f; // 1�ʸ��� �߻�
    public float attackRadius = 5.0f; // ���� ����
    public int damageAmount = 10; // ������

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
        // ȭ�� ����
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
        }
    }
}
