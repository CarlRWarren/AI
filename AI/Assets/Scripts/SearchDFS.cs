using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SearchDFS
{ 
  public static void Build(Node source, Node destination, out List<Node> path)
    {
        Stack<Node> nodes = new Stack<Node>();

        source.visited = true;
        nodes.Push(source);
        while(nodes.Peek() != destination && nodes.Count>0)
        {
            Node node = nodes.Peek();
            bool empty = true;
            foreach(Node.Edge edge in node.edges)
            {
                Node childNode = edge.nodeB;
                if(!childNode.visited)
                {
                    childNode.visited = true;
                    nodes.Push(childNode);
                    empty = false;
                    break;
                }                
            }
            if (empty)
            {
                nodes.Pop();
            }
        }
        path = new List<Node>(nodes.ToArray());
        path.Reverse();
    }
}
