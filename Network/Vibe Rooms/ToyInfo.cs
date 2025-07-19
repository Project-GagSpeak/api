using GagspeakAPI.Attributes;
using MessagePack;

namespace GagspeakAPI.Network;

// Remove Interactable?
/// <summary>
///     Lightweight Record for Toy Information that can be easily sent over the network.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ToyInfo(ToyBrandName BrandName, bool Interactable, Dictionary<uint, Motor> Motors);

/// <summary>
///     Represents a motor attached to a Device.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record Motor(ToyMotor Type, uint MotorIdx, int StepCount);
