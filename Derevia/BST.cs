﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derevia
{
    class BST
    {

        public Node4 root;
        public BST()
        {
            root = null;
        }
        public void Insert4(string i)
        {
            Node4 newNode4 = new Node4();
            newNode4.Data = i;
            if (root == null)
                root = newNode4;
            else
            {
                Node4 current = root;
                Node4 parent;
                while (true)
                {
                    parent = current;
                    if (String.Compare(i, current.Data) < 0)
                    {
                        current = current.LeftChild;
                        if (current == null)
                        {
                            parent.LeftChild = newNode4;
                            break;
                        }
                    }

                    else
                    {
                        current = current.RightChild;
                        if (current == null)
                        {
                            parent.RightChild = newNode4;
                            break;
                        }
                    }
                }
            }
        }

        public int Delete4(string i)
        {
            Node4 current = root;
            Node4 parent;
            parent = current;
            while (current.Data != i)
            {
                if (String.Compare(i, current.Data) < 0) { parent = current; current = current.LeftChild; }
                else { parent = current; current = current.RightChild; }
                if (current == null) break;
            }
            if (current == null) { return 0; }
            else
            {

                if ((current.LeftChild == null) && (current.RightChild == null))
                {
                    if (current == root) { current = null; }
                    else
                    {
                        if (i == parent.LeftChild.Data) { parent.LeftChild = null; }
                        else { parent.RightChild = null; }
                    }
                }
                else
                {
                    if ((current.LeftChild == null) || (current.RightChild == null))
                    {
                        if (current.LeftChild == null)
                        {
                            if (current == root) { root = current.RightChild; } else { parent.RightChild = current.RightChild; }
                        }
                        else { if (current == root) { root = current.LeftChild; } else parent.LeftChild = current.LeftChild; }
                    }
                    else
                    {
                        if ((current.LeftChild != null) || (current.RightChild != null))
                        {
                            string temp = minValue(current.RightChild);
                            Delete4(temp);
                            current.Data = temp;
                        }
                    }
                }
                return 1;
            }
        }

        private string minValue(Node4 begining)
        {
            string minv = begining.Data;
            while (begining.LeftChild != null)
            {
                minv = begining.LeftChild.Data;
                begining = begining.LeftChild;
            }
            return minv;
        }

        public int Search4(string i)
        {
            if (root == null) { return 0; }
            Node4 current = root;
            Node4 newcurrent = null;
            bool found = false;
            while (current != null)
            {
                Repetition(i, current, out newcurrent, out found); current = newcurrent;
            }
            if (found == true) { return 1; } else { return 0; }

        }

        private void Repetition(string i, Node4 current, out Node4 newcurrent, out bool found)
        {
            found = false;
            newcurrent = null;
            if (current == null) { found = false; return; }
            if (i == current.Data) { found = true; return; }
            else
            {
                if (String.Compare(i, current.Data) < 0) { current = current.LeftChild; }
                else
                {
                    if (String.Compare(i, current.Data) > 0)
                    {
                        current = current.RightChild;
                    }
                }
            }
            newcurrent = current;
        }
    
}

    public class Node4
    {
        public string Data;
        public Node4 LeftChild;
        public Node4 RightChild;

    }

}