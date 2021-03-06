﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendZone : MonoBehaviour
{
    [SerializeField]
    bool isInnerFriendZone;

    FriendController friendController;
    PlayerController playerController;

    private void Start()
    {
        friendController = transform.parent.gameObject.GetComponent<FriendController>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.instance.gameStarted)
            return;
        if (collision.gameObject.tag == "Player")
        {
            playerController.inFriendZone = true;
            if (!isInnerFriendZone)
            {
                friendController.ActivateFriendZone(true);
            }
            else
                friendController.HurtPlayer();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.inFriendZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerController.inFriendZone = false;
        if (!GameManager.instance.gameStarted)
            return;
        if (collision.gameObject.tag == "Player" && !isInnerFriendZone)
        {
            friendController.ActivateFriendZone(false);
        }
    }
}