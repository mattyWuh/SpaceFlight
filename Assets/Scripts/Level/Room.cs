using System.Collections;
using UnityEngine;

public class Room : MonoBehaviour
{
    float depth;
    float height;
    float width;

    Mesh mesh;
    Material material;

    public virtual void Construct(Vector3 _position)
    {
        string name = "Debris";
        this.transform.position = _position;

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