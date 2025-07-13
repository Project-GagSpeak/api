using GagspeakAPI.Attributes;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Lightweight Record for Toy Information that can be easily sent over the network.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ToyInfo(ToyBrandName BrandName, bool Interactable)
{
    public List<Motor> VibeMotors { get; set; } = [];
    public List<Motor> OscillationMotors { get; set; } = [];
    public Motor? RotateMotor { get; set; } = null;
    public Motor? ConstrictMotor { get; set; } = null;
    public Motor? InflateMotor { get; set; } = null;
}


/// <summary>
///     Represents a motor attached to a Device. (Idx is not entirely nessisary but helpful)
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record Motor(ToyMotor Type, int MotorIdx, int StepCount);
