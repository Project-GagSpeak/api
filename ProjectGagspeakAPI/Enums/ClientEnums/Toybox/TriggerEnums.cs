namespace GagspeakAPI.Enums;

public enum InvokableActionType
{
    TextOutput = 0, // if fired, output text to the chat. (If possible)
    Gag = 1, // if fired, interact with a gag. (If possible)
    Restriction = 6, // if fired, interact with a restriction. (If possible)
    Restraint = 2, // if fired, interact with a restraint set. (If possible)
    Moodle = 3, // if fired, apply a Moodle
    ShockCollar = 4, // if fired, perform shock collar action
    SexToy = 5, // if fired, vibrate sex toys.
}

public enum ThresholdPassType
{
    Over = 0,
    Under = 1,
}

public enum TriggerDirection
{
    Self = 0,
    SelfToOther = 1,
    Other = 2,
    OtherToSelf = 3,
    Any = 4,
}

public enum ActionSource
{
    GlobalAlias,
    PairAlias,
    TriggerAction,
}

public enum DeviceActionType
{
    Vibration = 0,
    Rotation = 1,
    Pattern = 2,
}

// Might have future expandability, or might be worth removing.
public enum SocialActionType
{
    DeathRollLoss,
}
