using System.Collections;
using UnityEngine;

public class Debris : MonoBehaviour
{
    [SerializeField]
    public Mesh mesh;

    [SerializeField]
    public Material material;

    [SerializeField]
    public int spawnNumber;

    [SerializeField]
    public float spawnWidth;

    [SerializeField]
    public float spawnDepth;

    [SerializeField]
    public float spawnHeight;
    
    void Start()
    {
        Construct();
    }

    public void Construct()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            SpawnDebris();
        }
    }

    void SpawnDebris()
    {
        string name = "Debris Object";

        // Vector3 position = this.transform.position;
        Vector3 scale = Vector3.one;
        Quaternion rotation = Quaternion.Euler(0, 0, 0);

        Vector3 position = new Vector3(
            Random.Range(-spawnWidth * 0.5f, spawnWidth * 0.5f),
            Random.Range(-spawnHeight * 0.5f, spawnHeight * 0.5f),
            Random.Range(-spawnDepth * 0.5f, spawnDepth * 0.5f)
        );

        ProceduralObject newObject = new GameObject(name).AddComponent<ProceduralObject>();
        newObject.Construct(this.transform, mesh, material, scale, position, rotation);
    }
    
}