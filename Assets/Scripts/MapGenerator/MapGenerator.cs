using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MapGenerator : MonoBehaviour
{
    #region serialised
    [Header("Node generation")]
    [SerializeField] private float f_minCircleSize = 0.5f;
    [SerializeField] private float f_maxCircleSize = 2.5f;
    [SerializeField] private float f_maxNeighbourDistance = 1.0f;
    [SerializeField] private float f_spawnRate = 0.01f;
    [SerializeField, Tooltip("A circular map will have paths spread out from/towards the center")] private bool b_circularMap = false;
    [SerializeField] private Transform T_spawnLocation;
    [SerializeField] private Transform T_mapCenter;
    [Header("Pathing")]
    [SerializeField] private int i_verticalSteps = 2;
    [SerializeField] private int i_horizontalSteps = 3;
    #endregion

    #region private
    private bool b_spawning = false;
    private List<Rigidbody2D> R2D_bodies = new List<Rigidbody2D>();
    private List<MapNode> MN_nodes = new List<MapNode>();
    private List<MapNode> MN_finalNodes = new List<MapNode>();
    private Vector2 V2_center;
    #endregion

    private enum e_orientation
    {
        none,
        left,
        right,
        clockwise,
        counterclockwise
    }

    private void Start()
    {
        Assert.IsNotNull(T_spawnLocation, "No spawn location set for map generator!");
        Assert.IsNotNull(T_mapCenter, "No map center set for map generator!");

        V2_center = new Vector2(T_mapCenter.position.x, T_mapCenter.position.y);

        StartCoroutine(SpawnCircles());
    }

    #region generation

    /// <summary>
    /// Sets b_spawning to false if all bodies' velocity reaches 0
    /// </summary>
    private void CheckForStop()
    {
        foreach(var circle in R2D_bodies)
        {
            if (circle.velocity.magnitude > 0.05f)
                return;
        }

        b_spawning = false;
    }

    private void SpawnCircle(float size)
    {
        Vector2 offset = Random.insideUnitCircle;

        GameObject go = new GameObject("circle " + R2D_bodies.Count);
        go.transform.position = T_spawnLocation.position + new Vector3(offset.x, offset.y, 0.0f);
        go.transform.parent = T_spawnLocation;

        CircleCollider2D cc = go.AddComponent<CircleCollider2D>();
        Rigidbody2D r2 = go.AddComponent<Rigidbody2D>();

        cc.radius = size;
        R2D_bodies.Add(r2);
    }

    private IEnumerator SpawnCircles()
    {
        b_spawning = true;

        while(b_spawning)
        {
            if(R2D_bodies.Count > 0)
                CheckForStop();

            SpawnCircle(Random.Range(f_minCircleSize, f_maxCircleSize));

            yield return new WaitForSeconds(f_spawnRate);
        }

        Invoke("MarkNodes", 2f);
    }

    #endregion
    #region pathing

    private void MarkNodes()
    {
        // Add all nodes
        foreach(var body in R2D_bodies)
        {
            // Add new node
            MN_nodes.Add(new MapNode(body.transform.position.x, body.transform.position.y, body.GetComponent<CircleCollider2D>().radius));
        }

        // Setup neighbours
        for(int i = 0; i < MN_nodes.Count; i++)
        {
            for(int j = i + 1; j < MN_nodes.Count; j++)
            {
                if(Vector2.Distance(MN_nodes[i].V2_position, MN_nodes[j].V2_position) <= MN_nodes[i].f_radius + MN_nodes[j].f_radius + 0.01f)
                {
                    MN_nodes[i].MN_neighbours.Add(MN_nodes[j]);
                    MN_nodes[j].MN_neighbours.Add(MN_nodes[i]);
                }
            }
        }

        Invoke("DoPathing", 2f);
    }

    private void DoPathing()
    {
        int currentIter = 0, maxIter = 1000;

        // Vertical steps
        for(int i = 0; i < i_verticalSteps; i++)
        {
            if(b_circularMap)
            {
                MapNode botNode = RandomBottomNode();

                while (MN_finalNodes.Contains(botNode) && currentIter++ < maxIter)
                    botNode = RandomBottomNode();

                VerticalStep(botNode);
            }
            else
            {
                MapNode topNode = RandomTopNode();

                while (MN_finalNodes.Contains(topNode) && currentIter++ < maxIter)
                    topNode = RandomTopNode();

                VerticalStep(topNode);
            }
        }

        currentIter = 0;

        // Horizontal steps
        for (int i = 0; i < i_horizontalSteps; i++)
        {
            MapNode sideNode = RandomSideNode();

            while (MN_finalNodes.Contains(sideNode) && currentIter++ < maxIter)
                sideNode = RandomSideNode();

            HorizontalStep(sideNode);
        }
    }

    private void VerticalStep(MapNode _from)
    {
        List<MapNode> path = new List<MapNode>();
        path.Add(_from);

        if(b_circularMap)
        {
            MapNode up = GetNeighbourUp(_from);

            while (up != null)
            {
                path.Add(up);

                up = GetNeighbourUp(up);
            }
        }
        else
        {
            MapNode down = GetNeighbourDown(_from);

            while(down != null)
            {
                path.Add(down);

                down = GetNeighbourDown(down);
            }
        }

        MN_finalNodes.AddRange(path);
    }

    private void HorizontalStep(MapNode _from)
    {
        List<MapNode> path = new List<MapNode>();
        path.Add(_from);

        MapNode next = GetNeightbourSideways(_from);

        while(next != null)
        {
            path.Add(next);

            next = GetNeightbourSideways(next);

            if (path.Contains(next)) break;
        }

        MN_finalNodes.AddRange(path);
    }

    private MapNode RandomTopNode()
    {
        List<MapNode> topNodes = new List<MapNode>();

        foreach(var node in MN_nodes)
        {
            // A top node is a node with no upper neighbours
            if (GetNeighbourUp(node) == null)
                topNodes.Add(node);
        }

        if (topNodes.Count == 0) 
            return null;
        else 
            return topNodes[Random.Range(0, topNodes.Count)];
    }

    private MapNode RandomBottomNode()
    {
        List<MapNode> bottomNodes = new List<MapNode>();

        foreach (var node in MN_nodes)
        {
            // A bottom node is a node with no lower neighbours
            if (GetNeighbourDown(node) == null)
                bottomNodes.Add(node);
        }

        if (bottomNodes.Count == 0)
            return null;
        else
            return bottomNodes[Random.Range(0, bottomNodes.Count)];
    }

    private MapNode RandomSideNode()
    {
        List<MapNode> sideNodes = new List<MapNode>();

        foreach (var node in MN_nodes)
        {
            // A side node is a node with either upper or lower neighbours
            if (GetNeighbourUp(node) != null || GetNeighbourDown(node) != null)
                sideNodes.Add(node);
        }

        if (sideNodes.Count == 0)
            return null;
        else
            return sideNodes[Random.Range(0, sideNodes.Count)];
    }

    private MapNode GetNeighbourDown(MapNode _of)
    {
        HashSet<MapNode> checkedNodes = new HashSet<MapNode>();

        while(checkedNodes.Count < _of.MN_neighbours.Count)
        {
            MapNode newNode = _of.MN_neighbours[Random.Range(0, _of.MN_neighbours.Count)];

            // Find a random node
            while(checkedNodes.Contains(newNode))
            {
                newNode = _of.MN_neighbours[Random.Range(0, _of.MN_neighbours.Count)];
            }

            checkedNodes.Add(newNode);

            if(b_circularMap)
            {
                if (Vector2.Distance(newNode.V2_position, V2_center) > Vector2.Distance(_of.V2_position, V2_center) && Mathf.Abs(Vector2.Distance(newNode.V2_position, V2_center) - Vector2.Distance(_of.V2_position, V2_center)) > f_minCircleSize)
                    return newNode;
            }
            else // Rectangular map
            {
                if(newNode.V2_position.y < _of.V2_position.y)
                {
                    return newNode;
                }
            }
        }

        return null;
    }

    private MapNode GetNeighbourUp(MapNode _of)
    {
        HashSet<MapNode> checkedNodes = new HashSet<MapNode>();

        while (checkedNodes.Count < _of.MN_neighbours.Count)
        {
            MapNode newNode = _of.MN_neighbours[Random.Range(0, _of.MN_neighbours.Count)];

            // Find a random node
            while (checkedNodes.Contains(newNode))
            {
                newNode = _of.MN_neighbours[Random.Range(0, _of.MN_neighbours.Count)];
            }

            checkedNodes.Add(newNode);

            if (b_circularMap)
            {
                if (Vector2.Distance(newNode.V2_position, V2_center) < Vector2.Distance(_of.V2_position, V2_center) && Mathf.Abs(Vector2.Distance(newNode.V2_position, V2_center) - Vector2.Distance(_of.V2_position, V2_center)) > f_minCircleSize)
                    return newNode;
            }
            else // Rectangular map
            {
                if (newNode.V2_position.y > _of.V2_position.y)
                {
                    return newNode;
                }
            }
        }

        return null;
    }

    private MapNode GetNeightbourSideways(MapNode _of)
    {
        HashSet<MapNode> checkedNodes = new HashSet<MapNode>();
        e_orientation orientation = e_orientation.none;

        if(b_circularMap)
        {
            orientation = Random.Range(0, 100) % 2 + e_orientation.clockwise;
        }
        else
        {
            orientation = _of.V2_position.x - T_mapCenter.position.x < 0 ? e_orientation.right : e_orientation.left;
        }

        while (checkedNodes.Count < _of.MN_neighbours.Count)
        {
            MapNode newNode = _of.MN_neighbours[Random.Range(0, _of.MN_neighbours.Count)];

            // Find a random neighbour
            while (checkedNodes.Contains(newNode))
            {
                newNode = _of.MN_neighbours[Random.Range(0, _of.MN_neighbours.Count)];
            }

            checkedNodes.Add(newNode);

            if (b_circularMap)
            {
                if (Vector2.Distance(newNode.V2_position, _of.V2_position) < f_maxCircleSize && Mathf.Abs(Vector2.Distance(newNode.V2_position, V2_center) - Vector2.Distance(_of.V2_position, V2_center)) < f_maxCircleSize)
                    return newNode;
            }
            else // Rectangular map
            {
                switch (orientation)
                {
                    case e_orientation.left:
                        {
                            if (newNode.V2_position.x < _of.V2_position.x && Mathf.Abs(newNode.V2_position.x - _of.V2_position.x) > f_minCircleSize && Mathf.Abs(newNode.V2_position.y - _of.V2_position.y) < f_maxCircleSize)
                            {
                                return newNode;
                            }

                            break; 
                        }
                    case e_orientation.right:
                        {
                            if (newNode.V2_position.x > _of.V2_position.x && Mathf.Abs(newNode.V2_position.x - _of.V2_position.x) > f_minCircleSize && Mathf.Abs(newNode.V2_position.y - _of.V2_position.y) < f_maxCircleSize)
                            {
                                return newNode;
                            }

                            break; 
                        }
                    default:
                        break;
                }
            }
        }

        return null;
    }

    #endregion
    private void OnDrawGizmos()
    {
        if(MN_nodes.Count > 0 && MN_finalNodes.Count == 0)
        {
            foreach(var node in MN_nodes)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(new Vector3(node.V2_position.x, node.V2_position.y, 0.0f), 0.2f);

                foreach(var _node in node.MN_neighbours)
                {
                    Gizmos.DrawLine(new Vector3(node.V2_position.x, node.V2_position.y, 0.0f), new Vector3(_node.V2_position.x, _node.V2_position.y, 0.0f));
                }
            }
        }
        else if(MN_finalNodes.Count > 0)
        {
            foreach (var node in MN_finalNodes)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(new Vector3(node.V2_position.x, node.V2_position.y, 0.0f), 0.2f);

                foreach (var _node in node.MN_neighbours)
                {
                    if(MN_finalNodes.Contains(_node))
                        Gizmos.DrawLine(new Vector3(node.V2_position.x, node.V2_position.y, 0.0f), new Vector3(_node.V2_position.x, _node.V2_position.y, 0.0f));
                }
            }
        }
    }
}
