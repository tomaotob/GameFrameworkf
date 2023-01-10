﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace GameFramework
{
    /// <summary>
    /// 游戏框架链表类。
    /// </summary>
    /// <typeparam name="T">指定链表的元素类型。</typeparam>
    public class GameFrameworkLinkedList<T> : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable
    {
        private readonly LinkedList<T> m_LinkedList;
        private readonly Queue<LinkedListNode<T>> m_CachedNode;

        /// <summary>
        /// 初始化游戏框架链表类的新实例。
        /// </summary>
        public GameFrameworkLinkedList()
        {
            m_LinkedList = new LinkedList<T>();
            m_CachedNode = new Queue<LinkedListNode<T>>();
        }

        /// <summary>
        /// 获取链表中实际包含的节点数。
        /// </summary>
        public int Count
        {
            get
            {
                return m_LinkedList.Count;
            }
        }

        /// <summary>
        /// 获取链表的第一个节点。
        /// </summary>
        public LinkedListNode<T> First
        {
            get
            {
                return m_LinkedList.First;
            }
        }

        /// <summary>
        /// 获取链表的最后一个节点。
        /// </summary>
        public LinkedListNode<T> Last
        {
            get
            {
                return m_LinkedList.Last;
            }
        }

        /// <summary>
        /// 获取一个值，该值指示 ICollection`1 是否为只读。
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<T>)m_LinkedList).IsReadOnly;
            }
        }

        /// <summary>
        /// 获取可用于同步对 ICollection 的访问的对象。
        /// </summary>
        public object SyncRoot
        {
            get
            {
                return ((ICollection)m_LinkedList).SyncRoot;
            }
        }

        /// <summary>
        /// 获取一个值，该值指示是否同步对 ICollection 的访问（线程安全）。
        /// </summary>
        public bool IsSynchronized
        {
            get
            {
                return ((ICollection)m_LinkedList).IsSynchronized;
            }
        }

        /// <summary>
        /// 将值添加到 ICollection`1 的结尾处。
        /// </summary>
        /// <param name="value">要添加的值。</param>
        public void Add(T value)
        {
            AddLast(value);
        }

        /// <summary>
        /// 在链表中指定的现有节点后添加包含指定值的新节点。
        /// </summary>
        /// <param name="node">指定的现有节点。</param>
        /// <param name="value">指定值。</param>
        /// <returns>包含指定值的新节点。</returns>
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = AcquireNode(value);
            m_LinkedList.AddAfter(node, newNode);
            return newNode;
        }

        /// <summary>
        /// 在链表中指定的现有节点后添加指定的新节点。
        /// </summary>
        /// <param name="node">指定的现有节点。</param>
        /// <param name="newNode">指定的新节点。</param>
        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            m_LinkedList.AddAfter(node, newNode);
        }

        /// <summary>
        /// 在链表中指定的现有节点前添加包含指定值的新节点。
        /// </summary>
        /// <param name="node">指定的现有节点。</param>
        /// <param name="value">指定值。</param>
        /// <returns>包含指定值的新节点。</returns>
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = AcquireNode(value);
            m_LinkedList.AddBefore(node, newNode);
            return newNode;
        }

        /// <summary>
        /// 在链表中指定的现有节点前添加指定的新节点。
        /// </summary>
        /// <param name="node">指定的现有节点。</param>
        /// <param name="newNode">指定的新节点。</param>
        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            m_LinkedList.AddBefore(node, newNode);
        }

        /// <summary>
        /// 在链表的开头处添加包含指定值的新节点。
        /// </summary>
        /// <param name="value">指定值。</param>
        /// <returns>包含指定值的新节点。</returns>
        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> node = AcquireNode(value);
            m_LinkedList.AddFirst(node);
            return node;
        }

        /// <summary>
        /// 在链表的开头处添加指定的新节点。
        /// </summary>
        /// <param name="node">指定的新节点。</param>
        public void AddFirst(LinkedListNode<T> node)
        {
            m_LinkedList.AddFirst(node);
        }

        /// <summary>
        /// 在链表的结尾处添加包含指定值的新节点。
        /// </summary>
        /// <param name="value">指定值。</param>
        /// <returns>包含指定值的新节点。</returns>
        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> node = AcquireNode(value);
            m_LinkedList.AddLast(node);
            return node;
        }

        /// <summary>
        /// 在链表的结尾处添加指定的新节点。
        /// </summary>
        /// <param name="node">指定的新节点。</param>
        public void AddLast(LinkedListNode<T> node)
        {
            m_LinkedList.AddLast(node);
        }

        /// <summary>
        /// 从链表中移除所有节点。
        /// </summary>
        public void Clear()
        {
            LinkedListNode<T> current = m_LinkedList.First;
            while (current != null)
            {
                ReleaseNode(current);
                current = current.Next;
            }

            m_LinkedList.Clear();
        }

        /// <summary>
        /// 确定某值是否在链表中。
        /// </summary>
        /// <param name="value">指定值。</param>
        /// <returns>某值是否在链表中。</returns>
        public bool Contains(T value)
        {
            return m_LinkedList.Contains(value);
        }

        /// <summary>
        /// 从目标数组的指定索引处开始将整个链表复制到兼容的一维数组。
        /// </summary>
        /// <param name="array">一维数组，它是从链表复制的元素的目标。数组必须具有从零开始的索引。</param>
        /// <param name="index">array 中从零开始的索引，从此处开始复制。</param>
        public void CopyTo(T[] array, int index)
        {
            m_LinkedList.CopyTo(array, index);
        }

        /// <summary>
        /// 从特定的 ICollection 索引开始，将数组的元素复制到一个数组中。
        /// </summary>
        /// <param name="array">一维数组，它是从 ICollection 复制的元素的目标。数组必须具有从零开始的索引。</param>
        /// <param name="index">array 中从零开始的索引，从此处开始复制。</param>
        public void CopyTo(Array array, int index)
        {
            ((ICollection)m_LinkedList).CopyTo(array, index);
        }

        /// <summary>
        /// 查找包含指定值的第一个节点。
        /// </summary>
        /// <param name="value">要查找的指定值。</param>
        /// <returns>包含指定值的第一个节点。</returns>
        public LinkedListNode<T> Find(T value)
        {
            return m_LinkedList.Find(value);
        }

        /// <summary>
        /// 查找包含指定值的最后一个节点。
        /// </summary>
        /// <param name="value">要查找的指定值。</param>
        /// <returns>包含指定值的最后一个节点。</returns>
        public LinkedListNode<T> FindLast(T value)
        {
            return m_LinkedList.FindLast(value);
        }

        /// <summary>
        /// 清除链表结点缓存。
        /// </summary>
        public void Free()
        {
            m_CachedNode.Clear();
        }

        /// <summary>
        /// 返回循环访问集合的枚举数。
        /// </summary>
        /// <returns>循环访问集合的枚举数。</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return ((ICollection<T>)m_LinkedList).GetEnumerator();
        }

        /// <summary>
        /// 从链表中移除指定值的第一个匹配项。
        /// </summary>
        /// <param name="value">指定值。</param>
        /// <returns>是否移除成功。</returns>
        public bool Remove(T value)
        {
            LinkedListNode<T> node = m_LinkedList.Find(value);
            if (node != null)
            {
                m_LinkedList.Remove(node);
                ReleaseNode(node);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 从链表中移除指定的节点。
        /// </summary>
        /// <param name="node">指定的节点。</param>
        public void Remove(LinkedListNode<T> node)
        {
            m_LinkedList.Remove(node);
            ReleaseNode(node);
        }

        /// <summary>
        /// 移除位于链表开头处的节点。
        /// </summary>
        public void RemoveFirst()
        {
            LinkedListNode<T> first = m_LinkedList.First;
            if (first == null)
            {
                throw new GameFrameworkException("First is invalid.");
            }

            m_LinkedList.RemoveFirst();
            ReleaseNode(first);
        }

        /// <summary>
        /// 移除位于链表结尾处的节点。
        /// </summary>
        public void RemoveLast()
        {
            LinkedListNode<T> last = m_LinkedList.Last;
            if (last == null)
            {
                throw new GameFrameworkException("Last is invalid.");
            }

            m_LinkedList.RemoveLast();
            ReleaseNode(last);
        }

        private LinkedListNode<T> AcquireNode(T value)
        {
            LinkedListNode<T> node = null;
            if (m_CachedNode.Count > 0)
            {
                node = m_CachedNode.Dequeue();
                node.Value = value;
            }
            else
            {
                node = new LinkedListNode<T>(value);
            }

            return node;
        }

        private void ReleaseNode(LinkedListNode<T> node)
        {
            node.Value = default(T);
            m_CachedNode.Enqueue(node);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<T>)m_LinkedList).GetEnumerator();
        }
    }
}
