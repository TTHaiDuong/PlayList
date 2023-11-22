using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playlist
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PlaylistForm()); 
        }
    }

    #region Danh sách liên kết đôi
    public class Node
    {
        public Node Next, Previous;
        public object Value;
        public Node(object Value) { this.Value = Value; }
        public Node() { this.Next = null; this.Previous = null; this.Value = null; }
    }
    public class DoublyLinkedList : IEnumerable
    {
        public Node Head, Tail; // Đầu và đuôi của List
        public int Count { get; private set; }
        public DoublyLinkedList(object Value) { Add(Value); }
        public DoublyLinkedList() { this.Head = null; this.Tail = null; this.Count = 0; }

        #region Các hàm chuyển đổi kiểu dữ liệu
        // Chuyển đổi Doubly Linked List qua Array
        public Array ToArray()
        {
            return this.ToList().ToArray();
        }

        // Chuyển đổi Doubly Linked List qua List
        public List<object> ToList()
        {
            List<object> List = new List<object>();

            Node LinkedListElement = Head;
            for (int i = 0; i < Count; i++)
            {
                List.Add(LinkedListElement.Value);
                LinkedListElement = LinkedListElement.Next;
            }
            return List;
        }

        // Chuyển đổi Doubly Linked List qua string[]
        public string[] ToArray_String()
        {
            return this.ToList().Select(obj => obj.ToString()).ToArray();
        }

        // Cho phép khởi tạo một Doubly Linked List mới từ một Array
        public static DoublyLinkedList FromArray(object Values)
        {
            DoublyLinkedList NewList = new DoublyLinkedList();

            if (!(Values is Array)) throw new Exception("Kiểu dữ liệu truyền vào không phải kiểu Array!");

            foreach (object Value in (dynamic)Values)
                NewList.Add(Value);

            return NewList;
        }
        #endregion

        // Cho phép Doubly Linked List sử dụng vòng lặp foreach, Enumeration
        public IEnumerator GetEnumerator()
        {
            Node Current = Head;
            while (Current != null)
            {
                yield return Current;
                Current = Current.Next;
            }
        }

        #region Các hàm tiện ích trong class
        // Truy cập phần tử thông qua chỉ số
        private Node Find(int index)
        {
            Node FindNode = Head;
            if (FindNode != null)
                for (int i = 0; i < index; i++)
                    FindNode = FindNode.Next;
            return FindNode;
        }

        // Kiểm tra tính hợp lệ của chỉ số
        private void ValidIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Chỉ số không hợp lệ!");
        }
        #endregion

        #region Các hàm truy cập
        // Tìm vị trí của Node
        public int FindIndex(Node FindNode)
        {
            for (int i = 0; i < Count; i++)
                if (FindNode == this.Find(i))
                    return i;

            return -1;
        }
        
        // Lấy một Node từ chỉ số
        public Node GetNode(int index)
        {
            Node FindNode = Find(index);
            return FindNode;
        }

        // Truy cập phần tử thông qua chỉ số
        public object GetValue(int index)
        {
            ValidIndex(index);

            Node FindNode = Find(index);
            return FindNode.Value;
        }

        // Cho phép truy cập, gán giá trị thông qua chỉ số với cặp dấu '[]'
        public object this[int index]
        {
            get { return GetValue(index); }
            set { SetValue(index, value); }
        }
        #endregion

        #region Các hàm thay đổi cấu trúc List
        // Đặt giá trị phần tử
        public void SetValue(int index, object NewValue)
        {
            ValidIndex(index);

            Node FindNode = Find(index);
            FindNode.Value = NewValue;
        }

        // Hoán đổi giá trị 2 Node
        public void Inverted(int index1, int index2)
        {
            object Node1 = Find(index1).Value;
            object Node2 = Find(index2).Value;

            object Swap = Node1;
            Node1 = Node2;
            Node2 = Swap;

            this.SetValue(index1, Node1);
            this.SetValue(index2, Node2);
        }

        // Thêm một phần tử vào cuối List
        public void Add(object Value)
        {
            Node NewNode = new Node(Value);
            if (Tail == null) { Head = NewNode; Tail = NewNode; }
            else
            {
                Tail.Next = NewNode;
                NewNode.Previous = Tail;
                Tail = NewNode;
            }
            Count++;
        }

        // Thêm một dãy các phần tử vào cuối List
        public void AddRange(object Values)
        {
            for (int i = 0; i < ((dynamic)Values).Length; i++)
                this.Add(((dynamic)Values)[i]);
        }

        // Chèn một phần tử mới vào List
        public void Insert(int index, object Value)
        {
            Node NewNode = new Node(Value);

            if (index == 0)
            {
                if (Head == null) { Head = NewNode; Tail = NewNode; }
                else
                {
                    NewNode.Next = Head;
                    Head.Previous = NewNode;
                    Head = NewNode;
                }
            }
            else if (index == Count)
            {
                Tail.Next = NewNode;
                NewNode.Previous = Tail;
                Tail = NewNode;
            }
            else
            {
                Node FindNode = Find(index - 1);

                Node TheRest = FindNode.Next;
                TheRest.Previous = NewNode;
                FindNode.Next = NewNode;
                NewNode.Previous = FindNode;
                NewNode.Next = TheRest;
            }
            Count++;
        }

        // Chèn một dãy các phần tử mới vào List
        public void InsertRange(int index, object Value)
        {
            if (Value is Array)
                for (int i = 0; i < ((dynamic)Value).Length; i++)
                    this.Insert(index + i, ((dynamic)Value)[i]);
            else
                this.Insert(index, Value);
        }

        // Xoá một phần tử thông qua chỉ số
        public void Remove(int index)
        {
            ValidIndex(index);

            if (index == 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Head = Head.Next;
                    Head.Previous = null;
                }
            }
            else if (index == Count - 1)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                Node FindNode = Find(index - 1);
                Node TheRest = FindNode.Next.Next;
                FindNode.Next = TheRest;
            }
            Count--;
        }

        // Xoá một dãy các phần tử
        public void RemoveRange(int index, int length)
        {
            ValidIndex(index); ValidIndex(index + length);

            for (int i = index; i < index + length; i++)
                this.Remove(i);
        }
    }
    #endregion
    #endregion
}
