using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VehendiMathematica
{
    public interface IVector : IEnumerable<float>, ICloneable
    {
        /// <summary>
        /// 次元数
        /// </summary>
        int Dimension { get; }
        float this[int index] { get; set; }

        /// <summary>
        /// 2乗ノルム
        /// </summary>
        float SqNorm { get; }
        /// <summary>
        /// ノルム
        /// </summary>
        float Norm { get; }

        /// <summary>
        /// 正規化
        /// </summary>
        void Normalize();

        List<float> ToList();
        float[] ToArray();
    }

    public class Vector2 : IVector
    {
        private float[] vector;

        public Vector2(float x = 0, float y = 0)
        {
            vector = new float[2] { x, y };
        }

        public Vector2(IEnumerable<float> enu)
        {
            vector = new float[2];
            int i = 0;
            IEnumerator e = enu.GetEnumerator();
            while (e.MoveNext() && i < 2)
            {
                vector[i] = (float)e.Current;
                i++;
            }
        }

        public Vector2(IVector vec)
        {
            if (Dimension < vec.Dimension)
                throw new DimensionException("より大きい次元のベクトルを2次元に変換しようとしました");
            vector = new float[3];
            for (int i = 0; i < vec.Dimension; i++)
            {
                vector[i] = vec[i];
            }
        }

        public object Clone()
        {
            return new Vector2(this);
        }

        public float this[int index]
        {
            get
            {
                return vector[index];
            }

            set
            {
                vector[index] = value;
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

        public float SqNorm => VectorCalculator.SqNorm(this);

        public float Norm => VectorCalculator.Norm(this);

        public void Normalize()
        {
            vector = VectorCalculator.Normalize(this).ToArray();
        }

        public float[] ToArray()
        {
            return vector;
        }

        public List<float> ToList()
        {
            return vector.ToList();
        }
        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }


        public IEnumerator<float> GetEnumerator()
        {
            foreach (var item in vector)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
        {
            return (Vector2)VectorCalculator.Add(vec1, vec2);
        }
        public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
        {
            return (Vector2)VectorCalculator.Sub(vec1, vec2);
        }
        public static Vector2 operator *(Vector2 vec, float times)
        {
            return new Vector2(vec.Select(v => v * times));
        }
        public static Vector2 operator /(Vector2 vec, float div)
        {
            return new Vector2(vec.Select(v => v / div));
        }

        /// <summary>
        /// 内積
        /// </summary>
        public float Dot(Vector2 vec)
        {
            return VectorCalculator.Dot(this, vec);
        }

        /// <summary>
        /// 外積
        /// </summary>
        public float Cross(Vector2 vec)
        {
            return X * vec.Y - Y * vec.X;
        }
    }

    public class Vector3 : IVector
    {
        private float[] vector;

        public Vector3(float x = 0, float y = 0, float z = 0)
        {
            vector = new float[3] { x, y, z };
        }

        public Vector3(IVector vec)
        {
            if (Dimension < vec.Dimension)
                throw new DimensionException("より大きい次元のベクトルを3次元に変換しようとしました");
            vector = new float[3];
            for (int i = 0; i < vec.Dimension; i++)
            {
                vector[i] = vec[i];
            }
        }

        public Vector3(IEnumerable<float> enu)
        {
            vector = new float[3];
            int i = 0;
            IEnumerator e = enu.GetEnumerator();
            while (e.MoveNext() && i < 3)
            {
                vector[i] = (float)e.Current;
                i++;
            }
        }

        public object Clone()
        {
            return new Vector3(this);
        }

        public float this[int index]
        {
            get
            {
                return vector[index];
            }
            set
            {
                vector[index] = value;
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

        public float SqNorm => VectorCalculator.SqNorm(this);

        public float Norm => VectorCalculator.Norm(this);

        public void Normalize()
        {
            vector = VectorCalculator.Normalize(this).ToArray();
        }

        public float[] ToArray()
        {
            return vector;
        }

        public List<float> ToList()
        {
            return vector.ToList();
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ", " + Z + ")";
        }

        public IEnumerator<float> GetEnumerator()
        {
            foreach (var item in vector)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
        {
            return (Vector3)VectorCalculator.Add(vec1, vec2);
        }
        public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
        {
            return (Vector3)VectorCalculator.Sub(vec1, vec2);
        }
        public static Vector3 operator *(Vector3 vec, float times)
        {
            return new Vector3(vec.Select(v => v * times));
        }
        public static Vector3 operator /(Vector3 vec, float div)
        {
            return new Vector3(vec.Select(v => v / div));
        }

        /// <summary>
        /// 内積
        /// </summary>
        public float Dot(Vector3 vec)
        {
            return VectorCalculator.Dot(this, vec);
        }

        /// <summary>
        /// 外積
        /// </summary>
        public Vector3 Cross(Vector3 vec)
        {
            return new Vector3
            {
                X = Y * vec.Z - vec.Y * Z,
                Y = Z * vec.X - vec.Z * X,
                Z = X * vec.Y - vec.X * Y
            };
        }
    }

    public static class VectorCalculator
    {
        /// <summary>
        /// 2乗ノルム
        /// </summary>
        public static float SqNorm(IVector vec)
        {
            return vec.Sum(v => v * v);
        }

        /// <summary>
        /// ノルム
        /// </summary>
        public static float Norm(IVector vec)
        {
            return (float)Math.Sqrt(SqNorm(vec));
        }

        /// <summary>
        /// 正規化
        /// </summary>
        public static IVector Normalize(IVector vec)
        {
            var v = (IVector)vec.Clone();
            var sum = v.Sum();
            for (int i = 0; i < v.Dimension; i++)
            {
                v[i] = vec[i] / sum;
            }
            return v;
        }

        /// <summary>
        /// 低次元ベクトルを拡張する
        /// </summary>
        public static IVector Extend(IVector vec, int dimension)
        {
            switch (dimension)
            {
                case 2:
                    return new Vector2(vec);
                case 3:
                    return new Vector3(vec);
                default:
                    if (1 < dimension)
                        throw new NotImplementedException("未実装の次元ベクトルに拡張しようとしました");
                    else
                        throw new DimensionException("拡張する次元数が不正です");
            }
        }

        /// <summary>
        /// 加算
        /// </summary>
        public static IVector Add(params IVector[] vec)
        {
            var v1 = (IVector)vec[0].Clone();
            foreach (var item in vec.Skip(1))
            {
                IVector v2;

                if (v1.Dimension < item.Dimension)
                    v1 = Extend(v1, item.Dimension);

                if (v1.Dimension > item.Dimension)
                    v2 = Extend(item, v1.Dimension);
                else
                    v2 = item;

                for (int i = 0; i < v1.Dimension; i++)
                {
                    v1[i] += v2[i];
                }
            }
            return v1;
        }

        /// <summary>
        /// 減算
        /// </summary>
        public static IVector Sub(params IVector[] vec)
        {
            var v1 = (IVector)vec[0].Clone();
            foreach (var item in vec.Skip(1))
            {
                IVector v2;

                if (v1.Dimension < item.Dimension)
                    v1 = Extend(v1, item.Dimension);

                if (v1.Dimension > item.Dimension)
                    v2 = Extend(item, v1.Dimension);
                else
                    v2 = item;

                for (int i = 0; i < v1.Dimension; i++)
                {
                    v1[i] -= v2[i];
                }
            }
            return v1;
        }

        /// <summary>
        /// 内積
        /// </summary>
        public static float Dot(IVector vec1, IVector vec2)
        {
            IVector v1;
            IVector v2;

            if (vec1.Dimension < vec2.Dimension)
                v1 = Extend(vec1, vec2.Dimension);
            else
                v1 = (IVector)vec1.Clone();

            if (vec1.Dimension > vec2.Dimension)
                v2 = Extend(vec2, vec1.Dimension);
            else
                v2 = vec2;

            for (int i = 0; i < v1.Dimension; i++)
            {
                v1[i] *= v2[i];
            }
            return v1.Sum();
        }
    }

    [System.Serializable]
    public class DimensionException : Exception
    {
        public DimensionException() { }
        public DimensionException(string message) : base(message) { }
        public DimensionException(string message, Exception inner) : base(message, inner) { }
        protected DimensionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
