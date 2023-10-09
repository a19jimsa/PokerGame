using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Navigation;

namespace GameCardLib
{
    public class ListManager<T>
    {
        List<T> m_list;

        public int Count { get { return m_list.Count; } }
        public List<T> List { get { return m_list; } }

        public ListManager()
        {
            m_list = new List<T>();
        }
        public void Add(T type)
        {
            m_list.Add(type);
        }

        public void RemoveAt(int index)
        {
            m_list.RemoveAt(index);
        }
        public void Clear()
        {
            m_list.Clear();
        }

        public void RemoveLast()
        {
            m_list.RemoveAt(m_list.Count-1);
        }

        public T GetAt(int index)
        {
            return m_list[index];
        }
    }
}