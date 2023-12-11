namespace AstroWars.Utilities;
using SDL2;
public readonly record struct Size(ushort X, ushort Y)
{
    public static readonly Size One   = new( 1, 1);
    public static readonly Size Zero  = new( 0, 0);

    public static readonly Size Down  = new( 0, +1);
    public static readonly Size Right = new(+1,  0);

    public static readonly Size Unit  = One;
    public static readonly Size UnitX = Right;
    public static readonly Size UnitY = Down;


    public static bool  operator <  (Size left, Size right) =>
        left.X < right.X && left.Y < right.Y;
    public static bool  operator >  (Size left, Size right) =>
        left.X > right.X && left.Y > right.Y;
    public static bool  operator <= (Size left, Size right) =>
        left.X <= right.X && left.Y <= right.Y;
    public static bool  operator >= (Size left, Size right) =>
        left.X >= right.X && left.Y >= right.Y;


    public static Size operator +  (Size left, Size right) =>
        new((ushort)(left.X + right.X), (ushort)(left.Y + right.Y));
    public static Size operator -  (Size left, Size right) =>
        new((ushort)(left.X - right.X), (ushort)(left.Y - right.Y));
    public static Size operator *  (Size left, Size right) =>
        new((ushort)(left.X * right.X), (ushort)(left.Y * right.Y));
    public static Size operator /  (Size left, Size right) =>
        new((ushort)(left.X / right.X), (ushort)(left.Y / right.Y));
    public static Size operator %  (Size left, Size right) =>
        new((ushort)(left.X % right.X), (ushort)(left.Y % right.Y));

    public static Size operator *  (Size left, ushort right) =>
        new((ushort)(left.X * right), (ushort)(left.Y * right));
    public static Size operator /  (Size left, ushort right) =>
        new((ushort)(left.X / right), (ushort)(left.Y / right));
    public static Size operator %  (Size left, ushort right) =>
        new((ushort)(left.X % right), (ushort)(left.Y % right));


    public static implicit operator Point(Size size) =>
        new(size.X, size.Y);

    
}