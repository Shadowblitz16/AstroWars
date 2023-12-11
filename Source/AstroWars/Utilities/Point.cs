namespace AstroWars.Utilities;

public readonly record struct Point(int X, int Y)
{
    public static readonly Point One   = new( 1, 1);
    public static readonly Point Zero  = new( 0, 0);

    public static readonly Point Up    = new( 0, -1);
    public static readonly Point Down  = new( 0, +1);
    public static readonly Point Left  = new(-1,  0);
    public static readonly Point Right = new(+1,  0);

    public static readonly Point Unit  = One;
    public static readonly Point UnitX = Right;
    public static readonly Point UnitY = Down;


    public static bool  operator <  (Point left, Size right) =>
        left.X < right.X && left.Y < right.Y;
    public static bool  operator >  (Point left, Size right) =>
        left.X > right.X && left.Y > right.Y;
    public static bool  operator <= (Point left, Size right) =>
        left.X <= right.X && left.Y <= right.Y;
    public static bool  operator >= (Point left, Size right) =>
        left.X >= right.X && left.Y >= right.Y;


    public static bool  operator <  (Point left, Point right) =>
        left.X < right.X && left.Y < right.Y;
    public static bool  operator >  (Point left, Point right) =>
        left.X > right.X && left.Y > right.Y;
    public static bool  operator <= (Point left, Point right) =>
        left.X <= right.X && left.Y <= right.Y;
    public static bool  operator >= (Point left, Point right) =>
        left.X >= right.X && left.Y >= right.Y;


    public static Point operator +  (Point left, Size right) =>
        new(left.X + right.X, left.Y + right.Y);
    public static Point operator -  (Point left, Size right) =>
        new(left.X - right.X, left.Y - right.Y);
    public static Point operator *  (Point left, Size right) =>
        new(left.X * right.X, left.Y * right.Y);
    public static Point operator /  (Point left, Size right) =>
        new(left.X / right.X, left.Y / right.Y);
    public static Point operator %  (Point left, Size right) =>
        new(left.X % right.X, left.Y % right.Y);


    public static Point operator +  (Point left, Point right) =>
        new(left.X + right.X, left.Y + right.Y);
    public static Point operator -  (Point left, Point right) =>
        new(left.X - right.X, left.Y - right.Y);
    public static Point operator *  (Point left, Point right) =>
        new(left.X * right.X, left.Y * right.Y);
    public static Point operator /  (Point left, Point right) =>
        new(left.X / right.X, left.Y / right.Y);
    public static Point operator %  (Point left, Point right) =>
        new(left.X % right.X, left.Y % right.Y);


    public static Point operator *  (Point left, int right) =>
        new(left.X * right, left.Y * right);
    public static Point operator /  (Point left, int right) =>
        new(left.X / right, left.Y / right);
    public static Point operator %  (Point left, int right) =>
        new(left.X % right, left.Y % right);

    public static Point operator *  (Point left, ushort right) =>
        new(left.X * right, left.Y * right);
    public static Point operator /  (Point left, ushort right) =>
        new(left.X / right, left.Y / right);
    public static Point operator %  (Point left, ushort right) =>
        new(left.X % right, left.Y % right);



    public static explicit operator Size(Point point) =>
        new((ushort)point.X, (ushort)point.Y);
}