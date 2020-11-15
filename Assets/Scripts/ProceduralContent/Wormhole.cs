using System.Collections;
using UnityEngine;

public class Wormhole : MonoBehaviour {

    [SerializeField]
    ScenesData.Scene warpTo;

    [SerializeField]
    int depth = 5;

    [SerializeField]
    int height = 5;
    [SerializeField]
    int width = 5;


    [SerializeField]
    int coreRadius = 3;

    [Range(0,100)]
    int orbitalFillPercentage = 10;


    [SerializeField]
    VoxelRender voxelRender;

    [SerializeField]
    ScenesData sceneDatabase;

    
    System.Random rng;

    void Start() {
        string seed = Time.time.ToString();
        rng = new System.Random(seed.GetHashCode());

        Construct();
    }


    void Construct() {
        Vector3 center = new Vector3(width/2.0f, height/2.0f, depth/2.0f);
        int [, ,] volume = new int[width, height, depth];
        
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++){
                for (int z = 0; z < depth; z++) {
                    Vector3 pos = new Vector3(x, y, z) - center;

                    bool isCore = (pos.magnitude < coreRadius);

                    volume[x,y,z] = (isCore) ? 1 : 
                        (rng.Next(0,100) < orbitalFillPercentage) ? 1 : 0;
                }
            }
        }

        voxelRender.Render(volume);
        MeshCollider meshc = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        meshc.enabled = true;
        meshc.convex = true;
    }

    void OnCollisionEnter(Collision other) {
        // Debug.Log("Collision with wormhole detected.");
        sceneDatabase.LoadScene(warpTo);
    }
}