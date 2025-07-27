using MessagePack;
using System.Numerics;

namespace GagspeakAPI.Network;

[MessagePackObject]
public struct SerializableVector2
{
    [Key(0)]
    public float X { get; set; }

    [Key(1)]
    public float Y { get; set; }

    public SerializableVector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static implicit operator Vector2(SerializableVector2 v) => new(v.X, v.Y);
    public static implicit operator SerializableVector2(Vector2 v) => new(v.X, v.Y);
}

[MessagePackObject]
public struct SerializableVector3
{
    [Key(0)]
    public float X { get; set; }

    [Key(1)]
    public float Y { get; set; }

    [Key(2)]
    public float Z { get; set; }

    public SerializableVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static implicit operator Vector3(SerializableVector3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator SerializableVector3(Vector3 v) => new(v.X, v.Y, v.Z);
}
