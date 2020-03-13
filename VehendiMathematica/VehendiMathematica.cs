using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VehendiMathematica
{
    public interface IVector : IEnumerable<float>
    {
        /// <summary>
        /// 次元数
        /// </summary>
        int Dimension { get; }
        float this[int index] { get; }
        List<float> ToList();
        float[] ToArray();
    }

    public class Vector2 : IVector
    {
        private float[] vector;

        public float this[int index]
        {
            get
            {
                return vector[index];
            }
        }

        public float X
        {
            get
            {
                return vector[0];
            }
            set
            {
                vector[0] = value;
            }
        }
        public float Y
        {
            get
            {
                return vector[1];
            }
            set
            {
                vector[1] = value;
            }
        }

        public int Dimension
        {
            get
            {
                return 2;
            }
        }

        public IEnumerator<float> GetEnumerator()
        {
            foreach (var item in vector)
            {
                yield return item;
            }
        }

        public float[] ToArray()
        {
            return vector;
        }

        public List<float> ToList()
        {
            return vector.ToList();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Vector3 : IVector
    {
        private float[] vector;
        public float this[int index]
        {
            get
            {
                return vector[index];
            }
        }

        public float X
        {
            get
            {
                return vector[0];
            }
            set
            {
                vector[0] = value;
            }
        }
        public float Y
        {
            get
            {
                return vector[1];
            }
            set
            {
                vector[1] = value;
            }
        }

        public float Z
        {
            get
            {
                return vector[2];
            }
            set
            {
                vector[2] = value;
            }
        }

        public int Dimension
        {
            get
            {
                return 3;
            }
        }

        public float[] ToArray()
        {
            return vector;
        }

        public List<float> ToList()
        {
            return vector.ToList();
        }
    }

    public class Quaternion { }
}
