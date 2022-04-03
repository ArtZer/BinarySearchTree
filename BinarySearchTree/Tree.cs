using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Tree<T>
        where T : IComparable
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }
        public void Add(T data)
        {            
            if(Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Root.Add(data);
            Count++;
        }

        //Префиксный обход дерева
        public List<T> PreOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return Preorder(Root);
        }
        private List<T> Preorder(Node<T> node)
        {
            var list = new List<T>();
            if(node != null)
            {
                list.Add(node.Data);

                if(node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }
                if(node.Right != null)
                {
                    list.AddRange(Preorder(node.Right));
                }
            }
            return list;
        }
        //Постфикстный обход дерева
        public List<T> PostOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return PostOrder(Root);
        }

        private List<T> PostOrder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(PostOrder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(PostOrder(node.Right));
                }

                list.Add(node.Data);
            }
            return list;
        }

        //Инфикстный обход
        public List<T> InOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return InOrder(Root);
        }

        private List<T> InOrder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(InOrder(node.Left));
                }

                list.Add(node.Data);

                if (node.Right != null)
                {
                    list.AddRange(InOrder(node.Right));
                }               
            }
            return list;
        }

        //Поиск
        public Node<T> Search(T searchData)
        {
            Node<T> node = Root;
            do
            {
                if (node.Data.CompareTo(searchData) == -1)
                {
                    node = node.Right;
                    continue;
                }                    

                if (node.Data.CompareTo(searchData) == 1)
                {
                    node = node.Left;
                    continue;
                }                    
                else
                    return node;
            } while (node != null);
                        
            return null; 
        }

        //Поиск родителя
        public Node<T> SearchParent(T searchData)
        {
            Node<T> node = Root;
            do
            {
                if(node.Left is not null && node.Left.Data.CompareTo(searchData) == 0)
                    return node;

                if (node.Right is not null && node.Right.Data.CompareTo(searchData) == 0)
                    return node;

                if (node.Data.CompareTo(searchData) == -1)
                {
                    node = node.Right;
                    continue;
                }

                if (node.Data.CompareTo(searchData) == 1)
                {
                    node = node.Left;
                    continue;
                }
            } while (node != null);

            return null;
        }

        public void Delete(T data)
        {
            Node<T> node = Search(data);
            Node<T> nodeParent = SearchParent(data);

            if (node.Left == null && node.Right != null)
            {
                if(nodeParent.Left is not null && nodeParent.Left == node)
                {
                    nodeParent.Left = node.Right;
                    return;
                }
                if(nodeParent.Right is not null && nodeParent.Right == node)
                {
                    nodeParent.Right = node.Right;
                    return;
                }
                    
            }

            if (node.Left != null && node.Right == null)
            {
                if (nodeParent.Left is not null && nodeParent.Left == node)
                {
                    nodeParent.Left = node.Left;
                    return;
                }
                if (nodeParent.Right is not null &&  nodeParent.Right == node)
                {
                    nodeParent.Right = node.Left;
                    return;
                }
            }


            //Удалить связь родителя

            if (nodeParent.Left != null && nodeParent.Left.CompareTo(data) == 0)
                nodeParent.Left = null;
            if (nodeParent.Right != null && nodeParent.Right.CompareTo(data) == 0)
                nodeParent.Right = null;
        }

        private void Del(Node<T> node)
        {
            

        }
    }
}
