namespace AstroWars.Utilities;

public readonly record struct Rect(Point Min, Point Max)
{
    public Rect(int MinX, int MinY, Point Max) : this(new(MinX, MinY), Max) {}
    public Rect(Point Min, int MaxX, int MaxY) : this(Min, new(MaxX, MaxY)) {}
    public Rect(int MinX, int MinY, int MaxX, int MaxY) : this(new(MinX, MinY), new(MaxX, MaxY)) {}

    public bool Contains(Point point)
    {
        var top    = point.Y >= Min.Y;
        var bottom = point.Y <  Max.Y;
        var left   = point.X >= Min.X;
        var right  = point.X <  Max.X;

        return top && bottom && left && right;
    }
    public bool Contains(Rect rect)
    {
        var top    = rect.Max.Y >= Min.Y;
        var bottom = rect.Max.Y <  Max.Y;
        var left   = rect.Min.X >= Min.X;
        var right  = rect.Min.X <  Max.X;

        return top && bottom && left && right;
    }

    
    public Collision GetCollision     (Point position, Point velocity) 
    {
        var top    = IsCollidingTop   (position, velocity);
        var bottom = IsCollidingBottom(position, velocity);
        var left   = IsCollidingLeft  (position, velocity);
        var right  = IsCollidingRight (position, velocity);

        var snapY = 0;
        if      (top   ) snapY = Min.Y;
        else if (bottom) snapY = Max.Y;

        var snapX = 0;
        if      (left  ) snapX = Min.X;
        else if (right ) snapX = Max.X;

        return new(new(snapX,snapY), (top || bottom || left || right));
    }
    public bool      IsColliding      (Point position, Point velocity) 
    {
        return Contains(position + velocity);
    }
    public bool      IsCollidingTop   (Point position, Point velocity) 
    {
        var colliding = IsColliding(position, velocity);
        var top       = velocity.Y > 0;
        return colliding && top;
    }
    public bool      IsCollidingBottom(Point position, Point velocity) 
    {
        var colliding = IsColliding(position, velocity);
        var bottom    = velocity.Y < 0;
        return colliding && bottom;
    }
    public bool      IsCollidingLeft  (Point position, Point velocity) 
    {
        var colliding = IsColliding(position, velocity);
        var left      = velocity.X > 0;
        return colliding && left;
    }
    public bool      IsCollidingRight (Point position, Point velocity) 
    {
        var colliding = IsColliding(position, velocity);
        var right     = velocity.X < 0;
        return colliding && right;
    }
}

public readonly record struct Collision(Point Snap, bool Colliding);