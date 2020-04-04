using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	class TwoDPoint : Object
	{
		public readonly int x, y;

		public TwoDPoint(int x, int y)  //constructor
		{
			this.x = x;
			this.y = y;
		}

		public override bool Equals(Object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast to Point return false.
			TwoDPoint p = obj as TwoDPoint;
			if ((Object)p == null)
			{
				return false;
			}

			// Return true if the fields match:
			return (x == p.x) && (y == p.y);
		}

		public bool Equals(TwoDPoint p)
		{
			// If parameter is null return false:
			if ((object)p == null)
			{
				return false;
			}

			// Return true if the fields match:
			return (x == p.x) && (y == p.y);
		}

		public static bool operator ==(TwoDPoint a, TwoDPoint b)
		{
			// If both are null, or both are same instance, return true.
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)a == null) || ((object)b == null))
			{
				return false;
			}

			// Return true if the fields match:
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(TwoDPoint a, TwoDPoint b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			return string.Format("x:{0} y:{1}", x, y);
		}
	}
	class TwoDPointWithHash : TwoDPoint
	{
		public TwoDPointWithHash(int x, int y) : base(x, y)
		{ }

		public override int GetHashCode()
		{
			int x1 = x, y1 = y;
			/*while (true)
				if (x1 % 10 == 0) x1 = x1 / 10;
				else break;

			while (true)
				if (y1 % 10 == 0) y1 = y1 / 10;
				else break;*/

			return x1 << 10 ^ y1;
		}
	}
	class Program
    {
        static void Main(string[] args)
        {
			TwoDPoint point1 = new TwoDPoint(1, 10);
			TwoDPoint point2 = new TwoDPoint(1, 10);

			Console.WriteLine("Hash for point1: {0}; Hash for point2: {1}", point1.GetHashCode(), point2.GetHashCode());

			TwoDPointWithHash newPoint1 = new TwoDPointWithHash(1, 1);
			TwoDPointWithHash newPoint2 = new TwoDPointWithHash(10, 10);

			Console.WriteLine("Hash for point1: {0}; Hash for point2: {1}", newPoint1.GetHashCode(), newPoint2.GetHashCode());

			Console.ReadKey();
		}
    }
}
