using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Config
    [SerializeField] float moveSpeed = 1f;

    // Cached component references
    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (IsFacingRight())
            myRigidBody.velocity = Vector2.right * moveSpeed;
        else
            myRigidBody.velocity = Vector2.left  * moveSpeed;
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0f;
    }

    private void OnTriggerExit2D()
    {
        FlipDirection();
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     Player player = other.gameObject.GetComponent<Player>();
    //     if (player)
    //         player.HitByEnemy();
    // }

    private void FlipDirection()
    {
        transform.localScale = new Vector2(-Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
