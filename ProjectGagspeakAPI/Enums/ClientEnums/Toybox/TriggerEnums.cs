namespace GagspeakAPI.Enums;

public enum TriggerTab
{
    Detection,
    Action
}

public enum InvokableActionType
{
    TextOutput = 0, // if fired, output text to the chat. (If possible)
    Gag = 1, // if fired, interact with a gag. (If possible)
    Restriction = 2, // if fired, interact with a restriction. (If possible) [OLD = NULL]
    Restraint = 3, // if fired, interact with a restraint set. (If possible) [OLD = 2]
    Moodle = 4, // if fired, apply a Moodle [OLD = 3]
    ShockCollar = 5, // if fired, perform shock collar action [OLD = 4]
    SexToy = 6, // if fired, vibrate sex toys. [OLD = 5]
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
