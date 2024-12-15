using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public class Node<T>//רשימה מקושרת
    {
        private T value;
        private Node<T> next;
        public Node(T x)
        {
            value = x;
            next = null;
        }
        public Node(T x, Node<T> next)
        {
            value = x;
            this.next = next;
        }
        //returns the value of the current node:
        public T GetValue() { return value; }

        //sets the value of the current node:
        public void SetValue(T x) { value = x; }

        //returns the value of the next node.
        public Node<T> GetNext() { return next; }

        //sets the value of the next node from the one it is on:
        public void SetNext(Node<T> x) { next = x; }

        //checks if there is a next node from the one it is on:
        public bool HasNext() { return next != null; }

        //shows all the nodes
        public override string ToString() { return value.ToString(); }
    }
}
