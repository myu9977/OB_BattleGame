using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float speed;
    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾�� �浹���� ��
        if (other.CompareTag("Player"))
        {
            StopMovement();
        }
    }

    void StopMovement()
    {
        isMoving = false;
    }
}
