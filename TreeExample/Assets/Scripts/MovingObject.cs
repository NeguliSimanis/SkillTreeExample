using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        //if (GameManager.instance.gameStarted)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
