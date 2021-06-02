using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode
{
    #region public
    public List<MapNode> MN_neighbours = new List<MapNode>();
    public Vector2 V2_position;
    public float f_radius;
    #endregion

    public MapNode(float _posX, float _posY, float _radius)
    {
        V2_position.x = _posX;
        V2_position.y = _posY;
        f_radius = _radius;
    }

    public MapNode(Vector2 _pos)
    {
        V2_position = _pos;
    }
}