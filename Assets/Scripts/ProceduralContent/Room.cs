using System.Collections;
using UnityEngine;

public class Room : MonoBehaviour {

    [SerializeField]
    float depth;

    [SerializeField]
    float height;

    [SerializeField]
    float width;


    [SerializeField]
    Mesh mesh;

    [SerializeField]
    Material material;


    [SerializeField]
    VoxelRender voxelRender;


    public float Depth {
        get { return depth; }
    }

    public float Height {
        get { return height; }
    }

    public float Width {
        get { return width; }
    }

    void Start() {
        Construct();
    }

    void SpawnDebris() {
        string name = "Debris";
        Debris debris = new GameObject(name).AddComponent<Debris>();
        debris.mesh = mesh;
        debris.material = material;
        debris.spawnNumber = 20;
        debris.spawnDepth = depth;
        debris.spawnHeight = height;
        debris.spawnWidth = width;
        debris.transform.parent = this.transform;
        debris.transform.localPosition = Vector3.zero;

        debris.Construct();
    }

    void SpawnSurface(){
        int[, ,] surface = new int[(int)width, (int)height, (int)depth];

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < depth; z++) {
                    bool isFloor = (y == 0);
                    bool isWall = (x == 0 || x == width - 1);
                    bool fill = (isFloor || isWall);
                    
                    surface[x,y,z] = (fill) ? 1 : 0;
                }
            }
        }

        voxelRender.Render(surface);
    }

    public virtual void Construct() {
        SpawnDebris();

        SpawnSurface();
    }

    public virtual void Construct(Vector3 _position)
    {
        this.transform.position = _position;

        Construct();
    }

    public virtual void Construct(
        Vector3 _position, float _depth, float _height, float _width, Mesh _mesh, Material _material
    ){
        depth = _depth;
        height = _height;
        width = _width;
        mesh = _mesh;
        material = _material;

        Construct(_position);
    }
}