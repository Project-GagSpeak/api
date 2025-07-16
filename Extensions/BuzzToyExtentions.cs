using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using GagspeakAPI.Util;

namespace GagspeakAPI.Extensions;

/// <summary> 
///     Extentions for setting and getting BuzzToy information.
/// </summary>
public static class ToyExtensions
{
    public static ToyBrandName ToBrandName(string factoryName)
    {
        return factoryName switch
        {
            "Lovense Ambi" => ToyBrandName.Ambi,
            "Lovense Calor" => ToyBrandName.Calor,
            "Lovense Diamo" => ToyBrandName.Diamo,
            "Lovense Dolce" => ToyBrandName.Dolce,
            "Lovense Domi" => ToyBrandName.Domi,
            "Lovense Domi 2" => ToyBrandName.Domi2,
            "Lovense Edge" => ToyBrandName.Edge,
            "Lovense Edge 2" => ToyBrandName.Edge2,
            "Lovense Exomoon" => ToyBrandName.Exomoon,
            "Lovense Ferri" => ToyBrandName.Ferri,
            "Lovense Flexer" => ToyBrandName.Flexer,
            "Lovense Gemini" => ToyBrandName.Gemini,
            "Lovense Gravity" => ToyBrandName.Gravity,
            "Lovense Gush" => ToyBrandName.Gush,
            "Lovense Gush 2" => ToyBrandName.Gush2,
            "Lovense Hush" => ToyBrandName.Hush,
            "Lovense Hush 2 (1 Inch)" => ToyBrandName.Hush2,
            "Lovense Hush 2 (1.5 Inch)" => ToyBrandName.Hush2,
            "Lovense Hush 2 (1.75 Inch)" => ToyBrandName.Hush2,
            "Lovense Hush 2 (2.25 Inch)" => ToyBrandName.Hush2,
            "Lovense Hyphy" => ToyBrandName.Hyphy,
            "Lovense Lapis" => ToyBrandName.Lapis,
            "Lovense Mini Sex Machine" => ToyBrandName.MiniSexMachine,
            "Lovense Sex Machine" => ToyBrandName.SexMachine,
            "Lovense Lush" => ToyBrandName.Lush,
            "Lovense Lush 2" => ToyBrandName.Lush2,
            "Lovense Lush 3" => ToyBrandName.Lush3,
            "Lovense Lush 4" => ToyBrandName.Lush4,
            "Lovense Max" => ToyBrandName.Max,
            "Lovense Max 2" => ToyBrandName.Max2,
            "Lovense Mission" => ToyBrandName.Mission,
            "Lovense Mission 2" => ToyBrandName.Mission2,
            "Lovense Nora" => ToyBrandName.Nora,
            "Lovense Osci" => ToyBrandName.Osci,
            "Lovense Osci 2" => ToyBrandName.Osci2,
            "Lovense Osci 3" => ToyBrandName.Osci3,
            "Lovense Ridge" => ToyBrandName.Ridge,
            "Lovense Solace" => ToyBrandName.Solace,
            "Lovense Solace Pro" => ToyBrandName.SolacePro,
            "Lovense Tenera 2" => ToyBrandName.Tenera2,
            "Lovense Vulse" => ToyBrandName.Vulse,
            _ => ToyBrandName.Unknown // fallback case to tell us we failed.
        };
    }

    public static string ToName(this ToyBrandName intifaceItem)
    {
        return intifaceItem switch
        {
            ToyBrandName.Ambi => "Lovense Ambi",
            ToyBrandName.Calor => "Lovense Calor",
            ToyBrandName.Diamo => "Lovense Diamo",
            ToyBrandName.Dolce => "Lovense Dolce",
            ToyBrandName.Domi => "Lovense Domi",
            ToyBrandName.Domi2 => "Lovense Domi 2",
            ToyBrandName.Edge => "Lovense Edge",
            ToyBrandName.Edge2 => "Lovense Edge 2",
            ToyBrandName.Exomoon => "Lovense Exomoon",
            ToyBrandName.Ferri => "Lovense Ferri",
            ToyBrandName.Flexer => "Lovense Flexer",
            ToyBrandName.Gemini => "Lovense Gemini",
            ToyBrandName.Gravity => "Lovense Gravity",
            ToyBrandName.Gush => "Lovense Gush",
            ToyBrandName.Gush2 => "Lovense Gush 2",
            ToyBrandName.Hush => "Lovense Hush",
            ToyBrandName.Hush2 => "Lovense Hush 2 (1.75 Inch)",
            ToyBrandName.Hyphy => "Lovense Hyphy",
            ToyBrandName.Lapis => "Lovense Lapis",
            ToyBrandName.MiniSexMachine => "Lovense Mini Sex Machine",
            ToyBrandName.SexMachine => "Lovense Sex Machine",
            ToyBrandName.Lush => "Lovense Lush",
            ToyBrandName.Lush2 => "Lovense Lush 2",
            ToyBrandName.Lush3 => "Lovense Lush 3",
            ToyBrandName.Lush4 => "Lovense Lush 4",
            ToyBrandName.Max => "Lovense Max",
            ToyBrandName.Max2 => "Lovense Max 2",
            ToyBrandName.Mission => "Lovense Mission",
            ToyBrandName.Mission2 => "Lovense Mission 2",
            ToyBrandName.Nora => "Lovense Nora",
            ToyBrandName.Osci => "Lovense Osci",
            ToyBrandName.Osci2 => "Lovense Osci 2",
            ToyBrandName.Osci3 => "Lovense Osci 3",
            ToyBrandName.Ridge => "Lovense Ridge",
            ToyBrandName.Solace => "Lovense Solace",
            ToyBrandName.SolacePro => "Lovense Solace Pro",
            ToyBrandName.Tenera2 => "Lovense Tenera 2",
            ToyBrandName.Vulse => "Lovense Vulse",
            _ => string.Empty
        };
    }

    public static CoreIntifaceElement FromBrandName(this ToyBrandName intifaceItem)
    {
        return intifaceItem switch
        {
            ToyBrandName.Ambi => CoreIntifaceElement.Ambi,
            ToyBrandName.Calor => CoreIntifaceElement.Calor,
            ToyBrandName.Diamo => CoreIntifaceElement.Diamo,
            ToyBrandName.Dolce => CoreIntifaceElement.Dolce,
            ToyBrandName.Domi => CoreIntifaceElement.Domi,
            ToyBrandName.Domi2 => CoreIntifaceElement.Domi2,
            ToyBrandName.Edge => CoreIntifaceElement.Edge,
            ToyBrandName.Edge2 => CoreIntifaceElement.Edge2,
            ToyBrandName.Exomoon => CoreIntifaceElement.Exomoon,
            ToyBrandName.Ferri => CoreIntifaceElement.Ferri,
            ToyBrandName.Flexer => CoreIntifaceElement.Flexer,
            ToyBrandName.Gemini => CoreIntifaceElement.Gemini,
            ToyBrandName.Gravity => CoreIntifaceElement.Gravity,
            ToyBrandName.Gush => CoreIntifaceElement.Gush,
            ToyBrandName.Gush2 => CoreIntifaceElement.Gush2,
            ToyBrandName.Hush => CoreIntifaceElement.Hush,
            ToyBrandName.Hush2 => CoreIntifaceElement.Hush2,
            ToyBrandName.Hyphy => CoreIntifaceElement.Hyphy,
            ToyBrandName.Lapis => CoreIntifaceElement.Lapis,
            ToyBrandName.MiniSexMachine => CoreIntifaceElement.MiniSexMachine,
            ToyBrandName.SexMachine => CoreIntifaceElement.SexMachine,
            ToyBrandName.Lush => CoreIntifaceElement.Lush,
            ToyBrandName.Lush2 => CoreIntifaceElement.Lush2,
            ToyBrandName.Lush3 => CoreIntifaceElement.Lush3,
            ToyBrandName.Lush4 => CoreIntifaceElement.Lush4,
            ToyBrandName.Max => CoreIntifaceElement.Max,
            ToyBrandName.Max2 => CoreIntifaceElement.Max2,
            ToyBrandName.Mission => CoreIntifaceElement.Mission,
            ToyBrandName.Mission2 => CoreIntifaceElement.Mission2,
            ToyBrandName.Nora => CoreIntifaceElement.Nora,
            ToyBrandName.Osci => CoreIntifaceElement.Osci,
            ToyBrandName.Osci2 => CoreIntifaceElement.Osci2,
            ToyBrandName.Osci3 => CoreIntifaceElement.Osci3,
            ToyBrandName.Ridge => CoreIntifaceElement.Ridge,
            ToyBrandName.Solace => CoreIntifaceElement.Solace,
            ToyBrandName.SolacePro => CoreIntifaceElement.SolacePro,
            ToyBrandName.Tenera2 => CoreIntifaceElement.Tenera2,
            ToyBrandName.Vulse => CoreIntifaceElement.Vulse,
            _ => CoreIntifaceElement.UnknownDevice // fallback case to tell us we failed.
        };
    }

    public static CoreIntifaceElement FromMotor(this ToyMotor motor)
    {
        return motor switch
        {
            ToyMotor.Vibration => CoreIntifaceElement.MotorVibration,
            ToyMotor.Rotation => CoreIntifaceElement.MotorRotation,
            ToyMotor.Oscillation => CoreIntifaceElement.MotorOscillation,
            ToyMotor.Constriction => CoreIntifaceElement.MotorConstriction,
            ToyMotor.Inflation => CoreIntifaceElement.MotorInflation,
            _ => CoreIntifaceElement.UnknownDevice // fallback case to tell us we failed.
        };
    }

    public static IEnumerable<(ToyMotor Motor, uint MotorIdx, uint StepCount)> GetDeviceInfo(this ToyBrandName device)
    {
        return device switch
        {
            ToyBrandName.Ambi => [],
            ToyBrandName.Calor => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Diamo => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Dolce => [(ToyMotor.Vibration, 0, 20), (ToyMotor.Vibration, 1, 20)],
            ToyBrandName.Domi => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Domi2 => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Edge => [(ToyMotor.Vibration, 0, 20), (ToyMotor.Vibration, 1, 20)],
            ToyBrandName.Edge2 => [(ToyMotor.Vibration, 0, 20), (ToyMotor.Vibration, 1, 20)],
            ToyBrandName.Exomoon => [],
            ToyBrandName.Ferri => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Flexer => [],
            ToyBrandName.Gemini => [(ToyMotor.Vibration, 0, 20), (ToyMotor.Vibration, 1, 20)],
            ToyBrandName.Gravity => [],
            ToyBrandName.Gush => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Gush2 => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Hush => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Hush2 => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Hyphy => [],
            ToyBrandName.Lapis => [],
            ToyBrandName.MiniSexMachine => [],
            ToyBrandName.SexMachine => [(ToyMotor.Oscillation, 0, 20)],
            ToyBrandName.Lush => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Lush2 => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Lush3 => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.Lush4 => [],
            ToyBrandName.Max => [(ToyMotor.Vibration, 0, 20), (ToyMotor.Constriction, 1, 3)],
            ToyBrandName.Max2 => [(ToyMotor.Vibration, 0, 20), (ToyMotor.Constriction, 1, 3)],
            ToyBrandName.Mission => [],
            ToyBrandName.Mission2 => [],
            ToyBrandName.Nora => [(ToyMotor.Vibration, 0, 20), (ToyMotor.Rotation, 1, 20)],
            ToyBrandName.Osci => [],
            ToyBrandName.Osci2 => [],
            ToyBrandName.Osci3 => [],
            ToyBrandName.Ridge => [(ToyMotor.Vibration, 0, 20), (ToyMotor.Rotation, 1, 20)],
            ToyBrandName.Solace => [(ToyMotor.Oscillation, 0, 20)],
            ToyBrandName.SolacePro => [(ToyMotor.Oscillation, 0, 20), (ToyMotor.Position, 1, 100)],
            ToyBrandName.Tenera2 => [],
            ToyBrandName.Vulse => [(ToyMotor.Vibration, 0, 20)],
            ToyBrandName.HismithSexMachine => [(ToyMotor.Oscillation, 0, 100)],
            _ => Enumerable.Empty<(ToyMotor, uint, uint)>()
        };
    }
}
