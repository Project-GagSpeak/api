using System.Numerics;

namespace GagspeakAPI.Profiles;

public enum PrimShapeType
{
    Circle = 0,
    Rect = 1,
    Gradient = 2,
    Quad = 3,

    Icon = 10,
    
    Line = 20,
    Path = 21,
}

/// <summary>
///   Required variables for PrimativeShapes
/// </summary>
public interface IPrimativeShape : IEquatable<IPrimativeShape>
{
    /// <summary>
    ///   The kind of PrimativeShape being drawn
    /// </summary>
    public PrimShapeType Type { get; }

    /// <summary>
    ///   Distinct Identifier for this shape. <br/>
    ///   Could've used ints but didnt want to deal with import/export id missmatch issues.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///   Shift down this shapes offset when expanded.
    /// </summary>
    public bool MoveWithExpand { get; }

    /// <summary>
    ///   If we only draw the outline, or fill it as a solid.
    /// </summary>
    public bool FillShape { get; }

    /// <summary>
    ///   The Primary color used by the primative shape.
    /// </summary>
    public uint Color1 { get; }

    /// <summary>
    ///   0 Defaults to no stroke
    /// </summary>
    public float Stroke { get; }

    /// <summary>
    ///   Creates a clone of the primative shape with a new GUID.
    /// </summary>>
    public IPrimativeShape Clone();
}

public class PrimativeCircle : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Circle;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = true;
    public uint Color1 { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF555555;

    public Vector2 Center { get; set; } = new Vector2(25);
    public float Radius { get; set; } = 10f;
    public int Edges { get; set; } = 0;
    public float Stroke { get; set; } = 0f;
    public IPrimativeShape Clone() => new PrimativeCircle
    {
        MoveWithExpand = MoveWithExpand,
        FillShape = FillShape,
        Color1 = Color1,
        Color2 = Color2,
        Center = Center,
        Radius = Radius,
        Edges = Edges,
        Stroke = Stroke
    };

    public bool Equals(IPrimativeShape? other)
    {
        if (other is not PrimativeCircle circle) return false;
        return MoveWithExpand == circle.MoveWithExpand &&
               FillShape == circle.FillShape &&
               Color1 == circle.Color1 &&
               Color2 == circle.Color2 &&
               Center.Equals(circle.Center) &&
               Radius == circle.Radius &&
               Stroke == circle.Stroke;
    }

    public override bool Equals(object? obj)
        => Equals(obj as IPrimativeShape);

    public override int GetHashCode()
        => HashCode.Combine(Id, Type);
}

public class PrimativeRect : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Rect;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = true;
    public uint Color1 { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF555555;

    public Vector2 Min { get; set; } = Vector2.Zero;
    public Vector2 Max { get; set; } = new Vector2(50);
    public float Rounding { get; set; } = 0f;
    public float Stroke { get; set; } = 0f;
    public CornerDrawFlags CornerFlags { get; set; } = CornerDrawFlags.RoundAll;
    public IPrimativeShape Clone() => new PrimativeRect
    {
        MoveWithExpand = MoveWithExpand,
        FillShape = FillShape,
        Color1 = Color1,
        Color2 = Color2,
        Min = Min,
        Max = Max,
        Rounding = Rounding,
        Stroke = Stroke,
        CornerFlags = CornerFlags
    };

    public bool Equals(IPrimativeShape? other)
    {
        if (other is not PrimativeRect rect) return false;
        return MoveWithExpand == rect.MoveWithExpand &&
               FillShape == rect.FillShape &&
               Color1 == rect.Color1 &&
               Color2 == rect.Color2 &&
               Min.Equals(rect.Min) &&
               Max.Equals(rect.Max) &&
               Rounding == rect.Rounding &&
               Stroke == rect.Stroke &&
               CornerFlags == rect.CornerFlags;
    }

    public override bool Equals(object? obj)
        => Equals(obj as IPrimativeShape);

    public override int GetHashCode()
        => HashCode.Combine(Id, Type);
}

/// <summary>
///   A rect with a color for each corner, allowing for gradients and color blending.
/// </summary>
public class PrimativeGradient : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Gradient;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = true;
    public uint Color1 { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF444444;
    public uint Color3 { get; set; } = 0xFFCCCCCC;
    public uint Color4 { get; set; } = 0xFF888888;

    public Vector2 Min { get; set; } = Vector2.Zero;
    public Vector2 Max { get; set; } = new Vector2(50);
    public float Stroke => 0f;
    public IPrimativeShape Clone() => new PrimativeGradient
    {
        MoveWithExpand = MoveWithExpand,
        FillShape = FillShape,
        Color1 = Color1,
        Color2 = Color2,
        Color3 = Color3,
        Color4 = Color4,
        Min = Min,
        Max = Max
    };

    public bool Equals(IPrimativeShape? other)
    {
        if (other is not PrimativeGradient grad) return false;
        return MoveWithExpand == grad.MoveWithExpand &&
               FillShape == grad.FillShape &&
               Color1 == grad.Color1 &&
               Color2 == grad.Color2 &&
               Color3 == grad.Color3 &&
               Color4 == grad.Color4 &&
               Min.Equals(grad.Min) &&
               Max.Equals(grad.Max) &&
               Stroke == grad.Stroke;
    }

    public override bool Equals(object? obj)
        => Equals(obj as IPrimativeShape);

    public override int GetHashCode()
        => HashCode.Combine(Id, Type);
}

/// <summary>
///   A Primative 4-Point rect.
/// </summary>
public class PrimativeQuad : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Quad;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = true;

    public uint Color1  { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF555555;

    public Vector2 P1 { get; set; } = Vector2.Zero;
    public Vector2 P2 { get; set; } = new Vector2(0, 50);
    public Vector2 P3 { get; set; } = new Vector2(50);
    public Vector2 P4 { get; set; } = new Vector2(50, 0);
    public float Stroke { get; set; } = 0f;
    public IPrimativeShape Clone() => new PrimativeQuad
    {
        MoveWithExpand = MoveWithExpand,
        FillShape = FillShape,
        Color1 = Color1,
        Color2 = Color2,
        P1 = P1,
        P2 = P2,
        P3 = P3,
        P4 = P4,
        Stroke = Stroke
    };

    public bool Equals(IPrimativeShape? other)
    {
        if (other is not PrimativeQuad quad) return false;
        return MoveWithExpand == quad.MoveWithExpand &&
               FillShape == quad.FillShape &&
               Color1 == quad.Color1 &&
               Color2 == quad.Color2 &&
               P1.Equals(quad.P1) &&
               P2.Equals(quad.P2) &&
               P3.Equals(quad.P3) &&
               P4.Equals(quad.P4) &&
               Stroke == quad.Stroke;
    }

    public override bool Equals(object? obj)
        => Equals(obj as IPrimativeShape);

    public override int GetHashCode()
        => HashCode.Combine(Id, Type);
}

public class PrimativeIcon : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Icon;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape => true;
    public uint Color1 { get; set; } = 0xFFFFFFFF;

    public Vector2 Pos { get; set; } = Vector2.Zero;
    public float Size { get; set; } = 128f;
    public float Rounding { get; set; } = 90f;
    public float Stroke => 0;
    public IPrimativeShape Clone() => new PrimativeIcon
    {
        MoveWithExpand = MoveWithExpand,
        Color1 = Color1,
        Pos = Pos,
        Size = Size,
        Rounding = Rounding
    };

    public bool Equals(IPrimativeShape? other)
    {
        if (other is not PrimativeIcon icon) return false;
        return MoveWithExpand == icon.MoveWithExpand &&
               Color1 == icon.Color1 &&
               Pos.Equals(icon.Pos) &&
               Size == icon.Size &&
               Rounding == icon.Rounding;
    }

    public override bool Equals(object? obj)
        => Equals(obj as IPrimativeShape);

    public override int GetHashCode()
        => HashCode.Combine(Id, Type);
}

public class PrimativeLine : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Line;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape => false;
    public uint Color1 { get; set; } = 0xFF000000;
    public Vector2 Start { get; set; } = Vector2.Zero;
    public Vector2 End { get; set; } = new Vector2(50);
    public float Stroke { get; set; } = 1f;

    public IPrimativeShape Clone() => new PrimativeLine
    {
        MoveWithExpand = MoveWithExpand,
        Color1 = Color1,
        Start = Start,
        End = End,
        Stroke = Stroke
    };

    public bool Equals(IPrimativeShape? other)
    {
        if (other is not PrimativeLine line) return false;
        return MoveWithExpand == line.MoveWithExpand &&
               Color1 == line.Color1 &&
               Start.Equals(line.Start) &&
               End.Equals(line.End) &&
               Stroke == line.Stroke;
    }

    public override bool Equals(object? obj)
        => Equals(obj as IPrimativeShape);

    public override int GetHashCode()
        => HashCode.Combine(Id, Type);
}

public enum PrimativePathType
{
    LineTo,
    ArcBend,
    BezierTo,
}

public class PrimativePathNode : IEquatable<PrimativePathNode>
{
    public PrimativePathType Instruction;
    public Vector2 Point;
    public Vector2 CtrlPoint1;
    public Vector2 CtrlPoint2;
    public int Segments;

    public bool Equals(PrimativePathNode? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Instruction == other.Instruction &&
               Point.Equals(other.Point) &&
               CtrlPoint1.Equals(other.CtrlPoint1) &&
               CtrlPoint2.Equals(other.CtrlPoint2) &&
               Segments == other.Segments;
    }

    public override bool Equals(object? obj)
        => Equals(obj as PrimativePathNode);

    public override int GetHashCode()
        => HashCode.Combine(Instruction, Point, Segments);
}

public class PrimativePath : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Path;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = false;
    public Vector2 Start { get; set; } = Vector2.Zero;
    public List<PrimativePathNode> Nodes { get; set; } = [];
    public uint Color1 { get; set; } = 0xFF000000;
    public float Stroke { get; set; } = 1f;

    public IPrimativeShape Clone() => new PrimativePath
    {
        MoveWithExpand = MoveWithExpand,
        FillShape = FillShape,
        Start = Start,
        Color1 = Color1,
        Stroke = Stroke,
        Nodes = [.. Nodes.Select(n => new PrimativePathNode
        {
            Instruction = n.Instruction,
            Point = n.Point,
            CtrlPoint1 = n.CtrlPoint1,
            CtrlPoint2 = n.CtrlPoint2,
            Segments = n.Segments
        })]
    };

    public bool Equals(IPrimativeShape? other)
    {
        if (other is not PrimativePath path) return false;
        return MoveWithExpand == path.MoveWithExpand &&
               Start.Equals(path.Start) &&
               Color1 == path.Color1 &&
               Stroke == path.Stroke &&
               Nodes.SequenceEqual(path.Nodes);
    }

    public override bool Equals(object? obj)
        => Equals(obj as IPrimativeShape);

    public override int GetHashCode()
        => HashCode.Combine(Id, Type);
}