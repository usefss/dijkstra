﻿using System.Collections.Generic;
using System;
using System.Collections;

namespace Dijkstra
{
    public class Vertex
    {
        public bool State { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }

        public string Tail = "";

        public List<Vertex> Adjacents = new List<Vertex>();
        public List<int> AdjacentsValues = new List<int>();
        public static List<Vertex> All = new List<Vertex>();

        public Vertex(string text, int value = 10000)
        {
            State = true;
            Value = value;
            All.Add(this);
            Name = text;
        }
        public void AddAdjacent(Vertex adj , int val)
        {
            Adjacents.Add(adj);
            AdjacentsValues.Add(val);
        }
    }

    public class Test
    {
        public void Dijkstra2(Vertex start,Vertex final)
        {
            start.State = false;

            if (start.Tail == "")
                start.Tail += start.Name;

            for (int i = 0 ; i < start.Adjacents.Count; i++)   //  updating values of all the adjacent vertexes 
            {
                if(start.Value + start.AdjacentsValues[i] < start.Adjacents[i].Value)  //  check to see if the value of the specific adjacent vertex can be updated
                {
                    start.Adjacents[i].Value = start.Value + start.AdjacentsValues[i];
                    start.Adjacents[i].Tail = start.Tail + start.Adjacents[i].Name;
                }
            }

            int min = 10000;

            for(int j = 0; j < Vertex.All.Count ; j++)
            {
                if(Vertex.All[j].State && Vertex.All[j].Value != 10000)   //  checking all the valid vertexes
                {
                    if(Vertex.All[j].Value <= min)  // selecting the vertex of the minimum value
                    {
                        min = Vertex.All[j].Value;   //  minimization
                    }
                }
            }
            
            Vertex next = Vertex.All.Find(n => n.Value == min && n.State);
 
            if(start.Name != final.Name)
                Dijkstra2(next, final);
            else
                Console.WriteLine(start.Tail);
        }
    }

    public class Program
    {
        public static void Main()
        {
            Vertex a = new Vertex("a" ,0);
            Vertex b = new Vertex("b");
            Vertex c = new Vertex("c");
            Vertex d = new Vertex("d");
            Vertex e = new Vertex("e");
            Vertex f = new Vertex("f");

            a.AddAdjacent(b, 10);
            a.AddAdjacent(e, 2);
            e.AddAdjacent(f, 4);
            b.AddAdjacent(d, 3);
            b.AddAdjacent(c, 3);
            d.AddAdjacent(f, 0);
            c.AddAdjacent(f, 5);

            Test test = new Test();
            test.Dijkstra2(a, f);

            Console.ReadKey();
        }
    }
}
