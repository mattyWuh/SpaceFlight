using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    [SerializeField]
    public float spawnThreshold = 0.5f;


    [SerializeField]
    GameObject roomPrefab;

    [SerializeField]
    private Vector3 roomCenter;


    private float adjSpawnThreshold;
    private Room room;
    
    void Awake()
    {
        room = SpawnRoom();
        adjSpawnThreshold = (spawnThreshold - 0.5f) * room.Depth;
    }

    void Update()
    {
        float roomDistance = target.transform.position.z - room.transform.position.z;
        if (roomDistance > adjSpawnThreshold)
        {
            room = SpawnRoom();
            roomCenter += Vector3.forward * room.Depth;
        }
            
    }

    Room SpawnRoom() {
        GameObject roomObject = Instantiate(roomPrefab, roomCenter, Quaternion.identity) as GameObject;
        return roomObject.GetComponent<Room>();
    }

}