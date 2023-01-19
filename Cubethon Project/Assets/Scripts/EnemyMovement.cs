using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool move = true;
    public float speed = 2.0f;

    void Update()
    {
        if (move)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= 4.0f)
        {
            move = false;
        }

        if (transform.position.x <= -4)
        {
            move = true;
        }
    }
}
