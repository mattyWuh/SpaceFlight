using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelRender : MonoBehaviour
{
    [SerializeField]
    MeshFilter meshFilter;
    Mesh mesh;

    List<Vector2> uvs;
    List<Vector3> vertices;
    List<int> triangles;

    public float scale = 1.0f;

    float adjScale;

    void Awake() {
        adjScale = scale * 0.5f;
    }

    public void Render(int[, ,] data) {
        adjScale = scale * 0.5f;
        mesh = meshFilter.mesh;

        VoxelData voxelData = new VoxelData(data);
        GenerateVoxelMesh(voxelData);
        UpdateMesh();
    }

    void GenerateVoxelMesh(VoxelData data) {
        uvs = new List<Vector2>();
        vertices = new List<Vector3>();
        triangles = new List<int>();
        Vector3 offsetFromCenter = new Vector3(-data.Width*0.5f, -data.Height*0.5f, -data.Depth*0.5f);

        for (int z = 0; z < data.Depth; z++)
        {
            for (int y = 0; y < data.Height; y++) {
                
                for (int x = 0; x < data.Width; x++) {
                    if (data.GetCell(x,y,z) == 0)
                        continue;
                    
                    Vector3 pos = (new Vector3(x, y, z) * scale) + offsetFromCenter;
                    MakeCube(adjScale, pos, x, y, z, data);
                }
            }
        }
    }

    void MakeCube(float cubeScale, Vector3 cubePos, int x, int y, int z, VoxelData data)
    {

        for (int i = 0; i < 6; i++)
        {
            if (data.GetNeighbor(x, y, z, (Direction)i) == 0)
                MakeFace((Direction)i, cubeScale, cubePos);
        }        
    }

    void MakeFace(Direction dir, float faceScale, Vector3 facePos)
    {
        vertices.AddRange(CubeMeshData.faceVertices(dir, faceScale, facePos));
        int vCount = vertices.Count;

        triangles.Add(vCount-4);
        triangles.Add(vCount-3);
        triangles.Add(vCount-2);
        triangles.Add(vCount-4);
        triangles.Add(vCount-2);
        triangles.Add(vCount-1);
    }

    void UpdateMesh()
    {
        mesh.Clear();

        Vector3[] verticesArray = vertices.ToArray();
        Vector2[] uvs = new Vector2[verticesArray.Length];

        for (int i = 0; i < uvs.Length; i++) {
            uvs[i] = new Vector2(verticesArray[i].x, verticesArray[i].z);
            // if (verticesArray[i].x == 0)
            //     uvs[i] = new Vector2(verticesArray[i].y, verticesArray[i].z);
            // else if (verticesArray[i].y == 0) 
            //     uvs[i] = new Vector2(verticesArray[i].x, verticesArray[i].z);
            // else if (verticesArray[i].z == 0)
            //     uvs[i] = new Vector2(verticesArray[i].x, verticesArray[i].y);
        }

        mesh.vertices = verticesArray;
        mesh.uv = uvs;
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }
}
