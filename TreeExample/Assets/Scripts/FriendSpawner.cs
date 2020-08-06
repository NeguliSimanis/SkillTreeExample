using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject friend;

    float minSpawnDelay = 1.5f;
    float maxSpawnDelay = 2.5f;
    float nextSpawnTime = 1f;

    private void Update()
    {
        if (!GameManager.instance.gameStarted)
            return;

        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
            SpawnFriend();
        }
    }

    private void SpawnFriend()
    {
        GameObject newFriend = friend;
        Instantiate(newFriend, gameObject.transform);
        newFriend.transform.position = Vector3.zero;
    }
}
