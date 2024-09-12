using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float wallLeft;
    private float wallRight;
    private float walkingDirection;
    private Vector2 walkAmount;
    public float walkSpeed = 5f;
    public HealthController healthController;

    private void Start()
    {
        wallLeft = transform.position.x - 3f;
        wallRight = transform.position.x + 3f;
        walkingDirection = transform.localScale.x;
    }
    private void Update()
    {
        Vector3 scale = transform.localScale;
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= wallRight)
        {
            walkingDirection = -1.0f;
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
        {
            walkingDirection = 1.0f;
            scale.x = 1f * Mathf.Abs(scale.x);

        }
        transform.Translate(walkAmount);
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            healthController.Reducehealth();
        }

    }

}
