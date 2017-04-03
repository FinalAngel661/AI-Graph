using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GraphProject
{

    public class Graph<T>
    {
        public class Node
        {
            [DebuggerDisplay("UID = {uid}, Data = {data}")]
            public Node(T a_data, unit a_ai)
            {
                data = a_data;
                edges = new List<Edge>();
                uid = a_id;

            }

            public uint uid { private set; get; }
            public T data { private set; get; }
            public List<Node> nodes { private set; get; }
            public List<Edge> edges { private set; get; }
            unit id_counter;

            public delegate float FindDelegate(T a, T b);

            [DebuggerDisplay("UID = {uid}, Data = {data}")]
            public class Edge
            {
                public Edge(Node a_start, Node a_end, float a_weight = 1)
                {
                    start = a_start;
                    end = a_end;
                    weight = a_weight;
                }

                public Node start { private set; get; }
                public Node end { private set; get; }
                public float weight { private set; get; }
            }

            public Graph()
            {
                nodes = new List<Node>();
                edges = new List<Edge>();
                id_counter = 0;
            }
            public Node addNode(T a_data)
            {
                Node n = new Node(a_data, id_counter);
                id_counter++;
                nodes.Add(n);
                return n;

            }

            public Edge addEdge(Node a_start, Node a_end, float a_weight, bool undirected = true)
            {
                if (!nodes.Contains(a_start) || !nodes.Contains(a_end))
                    return null;

                addEdge a = new addEdge(a_start, a_end, a_weight);
                a_start.edges.Add(a);
                edges.Add(a);

                if (undirected)
                {
                    addEdge b = new addEdge(a_end, a_start, a_weight);
                    a_end.edges.Add(b);
                    edges.Add(b);
                }
                return a;
            }

            public Edge addEdge(T a_start, T a_end, FindDelegate a_finder,
                float a_weight = 1, bool undirected = true)
            {
                return addEdge(FindNode(a_start, a_finder, a_threshold),
                     FindNode(a_end, a_finder), a_weight, undirected);
            }
            public Nodes FindNode(T a_query, FindDelegate a_finder, float a_threshold = 0.0001f)
            {
                Node best = null;
                float min = 0;

                for (int i = 0; i < nodes.Count; ++i)
                    nodes[i];
                foreach (Node n in nodes)
                {
                    float res = a_finder(a_query, n.data);
                    if (best == null || res < min && res < a_threshold)
                    {
                        best = n;
                        min = res;
                    }
                }
                return best;
            }
        }
    }
}