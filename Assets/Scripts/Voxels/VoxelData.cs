using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelData {
    int[, ,] data;
    
    public VoxelData(int[, ,] _data) {
        data = _data;
    }

    public int Depth {
        get { return data.GetLength(2); }
    }

    public int Height {
        get { return data.GetLength(1); }
    }

    public int Width {
        get { return data.GetLength(0); }
    }

    public int GetCell(int x, int y, int z){
        return data[x,y,z];
    }

    public int GetNeighbor(int x, int y, int z, Direction dir){
        DataCoordinate offsetToCheck = offsets[(int)dir];
        DataCoordinate neighborCoord = new DataCoordinate(x, y, z) + offsetToCheck;

        bool neighborNonexistent = (
            neighborCoord.x < 0 || 
            neighborCoord.x >= Width || 
            neighborCoord.y < 0 ||
            neighborCoord.y >= Height || 
            neighborCoord.z < 0 || 
            neighborCoord.z >= Depth
        );
        if (neighborNonexistent)
            return 0;
        
        return GetCell(neighborCoord.x, neighborCoord.y, neighborCoord.z);
    }

    struct DataCoordinate{
        public int x;
        public int y;
        public int z;

        public DataCoordinate(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public static DataCoordinate operator +(DataCoordinate a, DataCoordinate b)
            => new DataCoordinate(a.x+b.x, a.y+b.y, a.z+b.z);
        
        public static DataCoordinate operator -(DataCoordinate a, DataCoordinate b)
            => new DataCoordinate(a.x-b.x, a.y-b.y, a.z-b.z);
    }

    DataCoordinate[] offsets = {
        new DataCoordinate(0, 0, 1),
        new DataCoordinate(1, 0, 0),
        new DataCoordinate(0, 0, -1),
        new DataCoordinate(-1, 0, 0),
        new DataCoordinate(0, 1, 0),
        new DataCoordinate(0, -1, 0)
    };
}

public enum Direction {
    Forward,
    Right,
    Back,
    Left,
    Up,
    Down
}
