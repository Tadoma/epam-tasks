using System;
using System.Collections;
using System.Collections.Generic;

namespace task11
{
    public sealed class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node _root;
        private readonly IComparer<T> _comparer;

        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer)
        {
            if (ReferenceEquals(null, collection))
                throw new ArgumentNullException("null exception");
            if (ReferenceEquals(null, comparer))
            {
                _comparer = Comparer<T>.Default;

            }
            else
            {
                _comparer = comparer;
            }
            foreach (var element in collection)
            {
                Add(element);
            }
        }

        public BinarySearchTree(IEnumerable<T> collection) : this(collection, null)
        {
        }

        public BinarySearchTree() { }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var value in collection)
            {
                Add(value);
            }
        }

        public void Add(T element)
        {
            if (ReferenceEquals(null, element))
                throw new ArgumentNullException();
            if (ReferenceEquals(null, _root))
            {
                _root = new Node(element);
                return;
            }
            Node currentRoot = _root;
            Node dadyRoot = null;

            while (!ReferenceEquals(null, currentRoot))
            {
                if (_comparer.Compare(currentRoot.Value, element) == 0)
                    return;
                dadyRoot = currentRoot;
                if (_comparer.Compare(currentRoot.Value, element) < 0)
                    currentRoot = currentRoot.Right;
                else
                    currentRoot = currentRoot.Left;
            }

            if (_comparer.Compare(dadyRoot.Value, element) > 0)
                dadyRoot.Left = new Node(element);
            else
                dadyRoot.Right = new Node(element);

        }

        public void Clear() { _root = null; }

        public IEnumerable<T> PreOrder() { return PreOrder(_root); }
        public IEnumerable<T> PostOrder() { return PostOrder(_root); }
        public IEnumerable<T> InOrder() { return InOrder(_root); }
        private class Node
        {
            private T _value;
            public T Value
            {
                get { return _value; }
            }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(T value)
            {
                _value = value;
            }
        }

        private IEnumerable<T> PostOrder(Node node)
        {
            if (node == null)
                yield break;

            foreach (var e in PostOrder(node.Left))
                yield return e;

            foreach (var e in PostOrder(node.Right))
                yield return e;

            yield return node.Value;
        }


        private IEnumerable<T> PreOrder(Node node)
        {
            if (node == null)
                yield break;

            yield return node.Value;

            foreach (var e in PreOrder(node.Left))
                yield return e;

            foreach (var e in PreOrder(node.Right))
                yield return e;
        }

        private IEnumerable<T> InOrder(Node node)
        {
            if (node == null)
                yield break;

            foreach (var n in InOrder(node.Left))
                yield return n;

            yield return node.Value;
            foreach (var n in InOrder(node.Right))
                yield return n;
        }
    }


    public class Test : IEquatable<Test>, IComparable<Test>, IComparer<Test>
    {
        private string _Student;
        private string _Nametest;
        private string _Date;
        private int _Oc;

        public string Student
        {
            get { return _Student; }
            private set
            {
                if (ReferenceEquals(value, null))
                    throw new ArgumentNullException();
                _Student = value;
            }
        }

        public string Nametest
        {
            get { return _Nametest; }
            private set
            {
                if (ReferenceEquals(value, null))
                    throw new ArgumentNullException();
                _Nametest = value;
            }
        }

        public int oc
        {
            get { return _Oc; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException();
                _Oc = value;
            }
        }

        public string GetDate1()
        {
            return _Date;
        }

        public void SetDate1(string value)
        {
            _Date = value;
        }

        public string Date
        {
            get { return GetDate1(); }
            private set { SetDate1(value); }
        }

        public Test(string student, string Nametest, int oc, string date)
        {
            _Student = student;
            _Nametest = Nametest;
            _Oc = oc;
            _Date = date;
        }

        public bool Equals(Test other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqulsPropertys(ref other);
        }

        private bool EqulsPropertys(ref Test other)
        {
            if (other.Student != Student)
                return false;
            if (other.Nametest == Nametest)
                return false;
            if (other.oc == oc)
                return false;
            if (other.Date == Date)
                return false;
            return true;
        }

        public int CompareTo(Test other)
        {
            if (ReferenceEquals(null, other))
                throw new ArgumentNullException();
            if (other.oc < oc) return 1;
            if (other.oc > oc) return -1;
            return 0;
        }

        public int Compare(Test x, Test y)
        {
            if (ReferenceEquals(null, x) || ReferenceEquals(null, y))
                throw new ArgumentNullException();
            return x.CompareTo(y);
        }

        public override string ToString()
        {
            string result = "Тест: " + Nametest + " | Дата: " + Date + " | Студент: " + Student + " | Результат: " + oc;
            return result;
        }
    }

    public class CompareByStudent : IComparer<Test>
    {
        public int Compare(Test left, Test right)
        {
            if (ReferenceEquals(null, left) || ReferenceEquals(null, right))
                throw new ArgumentNullException();
            if (string.Compare(left.Student, right.Student) == 1)
                return 1;
            if (string.Compare(left.Student, right.Student) == 0)
                return 0;
            return -1;
        }
    }
}
