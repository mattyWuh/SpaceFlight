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
    private Vector3 roomCenter;

    [SerializeField]
    private float roomDepth;
    
    [SerializeField]
    private float roomHeight;

    [SerializeField]
    private float roomWidth;

    [SerializeField]
    private Mesh roomMesh;

    [SerializeField]
    private Material roomMaterial;


    private float adjSpawnThreshold;
    private Room room;
    
    void Awake()
    {
        adjSpawnThreshold = (spawnThreshold - 0.5f) * roomDepth;
        roomCenter = new Vector3(0, roomHeight * 0.5f, roomDepth * 0.5f + target.position.z);
        room = SpawnRoom(roomCenter);
    }

    void Update()
    {
        float roomDistance = target.transform.position.z - room.transform.position.z;
        if (roomDistance > adjSpawnThreshold)
        {
            room = SpawnRoom(roomCenter);
            roomCenter += Vector3.forward * roomDepth;
        }
            
    }

    Room SpawnRoom(Vector3 position)
    {
        string name = "Room";
        Room room = new GameObject(name).AddComponent<Room>();
        room.Construct(position, roomDepth, roomHeight, roomWidth, roomMesh, roomMaterial);
        return room;
    }

}