using System.Security.Cryptography;

Point p1 = new Point(2, 2);
//Console.WriteLine(-p1);


//Console.WriteLine(p1++);
//Console.WriteLine(++p1);
//Console.WriteLine(p1--);
//Console.WriteLine(--p1);
Point p2 = new Point(2,2);
Console.WriteLine(p2!=p1);



Point3D p3D = (Point3D)p2;
Console.WriteLine(p3D);


//if (p2)
//{
//    Console.WriteLine("This point is not null");
//}

class Point3D
{
    public int x { get; set; }
    public int y { get; set; }
    public int z { get; set; }
    public Point3D(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public override string ToString()
    {
        return $"X: {x} Y : {y} Z : {z}";
    }

    //public override bool Equals(object? obj)
    //{
    //    Point p = obj as Point;
    //    return this.x == p.x && this.y == p.y;


    //    //var point = (Point)obj;
    //    //return point!=null && this.x==point.x && this.y==point.y ;

    //    //if(obj== null || GetType()!=obj.GetType())
    //    //    return false;
    //    //return true;
    //}
}
    class Point
{
    public int x { get; set; }
    public int y { get; set; }
    public Point():base(){}
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    //public override string ToString()
    //{
    //    return $"X: {x} Y : {y}";
    //}

    public override bool Equals(object? obj)
    {
        Point p = obj as Point;
        return this.x == p.x && this.y == p.y;


        //var point = (Point)obj;
        //return point!=null && this.x==point.x && this.y==point.y ;

        //if(obj== null || GetType()!=obj.GetType())
        //    return false;
        //return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }

    #region Uno operators
    public static Point operator-(Point p)
    {
        
        p.x = -p.x;
        p.y=-p.y;
        return p;
    }
    public static Point operator ++(Point p)
    {
        ++p.x;
        p.y++;
        return p;
    }
    public static Point operator --(Point p)
    {
        return new Point(p.x--, p.y--);
    }

    #endregion

    #region Binary operators

    public static Point operator+(Point p1, Point p2)
    {
        Point p3 = new Point(p1.x + p2.x, p1.y + p2.y);
        return p3;
    }

    public static Point operator -(Point p1, Point p2)
    {
        return new Point(p1.x - p2.x, p1.y - p2.y);
    }
    public static Point operator *(Point p1, Point p2)
    {
        Point p3 = new Point
        {
            x = p1.x * p2.x,
            y = p1.y * p2.y
        };
        return p3;
    }
    public static Point operator /(Point p1, Point p2)
    {
        Point p3 = new Point
        {
            x = p1.x / p2.x,
            y = p1.y / p2.y
        };
        return p3;
    }

    #endregion

    #region
    public static bool operator == (Point p1, Point p2)
    {
        return p1.Equals(p2);
        //return p1.x == p1.y && p1.y == p2.y ? true : false;
    }
    public static bool operator !=(Point p1, Point p2)
    {
        return p1.x != p1.y && p1.y != p2.y;
    }

    public static bool operator >(Point p1, Point p2)
    {
        return (p1.x + p1.y) > (p2.x + p2.y);
    }
    public static bool operator <(Point p1, Point p2)
    {
        return (p1.x + p1.y) < (p2.x + p2.y);
    }
    #endregion


    public static bool operator true(Point p)
    {
        return p.x !=0 || p.y !=0;
    }
    public static bool operator false(Point p)
    {
        return p.x == 0 && p.y == 0;
    }

    //public static explicit operator int(Point p)
    //{
    //    return p.x + p.y;
    //}
    public static implicit operator int(Point p)
    {
        return p.x + p.y;
    }

    public static explicit operator string(Point p)
    {
        return p.ToString();
    }
    public static explicit operator Point3D(Point p)
    {
        return new Point3D(p.x, p.y, 0);
    }

}
