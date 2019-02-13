using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SearchBFS
{ 
  public static void Build(Node source, Node destination, out List<Node> path)
    {
        Queue<Node> nodes = new Queue<Node>();

        source.visited = true;
        nodes.Enqueue(source);

        bool found = false;
        while(!found && nodes.Count>0)
        {
            Node node = nodes.Dequeue();
            foreach(Node.Edge edge in node.edges)
            {
                Node childNode = edge.nodeB;
                if(!childNode.visited)
                {
                    childNode.parentNode = node;
                    childNode.visited = true;
                    nodes.Enqueue(childNode);
                }
                if(childNode == destination)
                {
                    found = true;
                    break;
                }
            }
        }
        path = new List<Node>();
        if(found)
        {
            Node node = destination;
            while(node)
            {
                path.Add(node);
                node = node.parentNode;               
            }
        path.Reverse();
        }
    }
}
