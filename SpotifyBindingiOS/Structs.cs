using System;
using ObjCRuntime;

namespace SpotifyBindingiOS
{
    [Native]
    public enum SPTAppRemoteLogLevel : ulong
    {
        None = 0,
        Debug = 1,
        Info = 2,
        Error = 3
    }

    [Native]
    public enum SPTAppRemoteErrorCode : long
    {
        UnknownError = -1,
        BackgroundWakeupFailedError = -1000,
        ConnectionAttemptFailedError = -1001,
        ConnectionTerminatedError = -1002,
        InvalidArgumentsError = -2000,
        RequestFailedError = -2001
    }

    [Native]
    public enum SPTAppRemoteConnectionParamsImageFormat : long
    {
        Any = 0,
        Jpeg,
        Png
    }

    [Native]
    public enum SPTAppRemotePlaybackOptionsRepeatMode : long
    {
        Off = 0,
        Track = 1,
        Context = 2
    }

    [Native]
    public enum SPTErrorCode : long
    {
        UnknownErrorCode = 0,
        AuthorizationFailedErrorCode,
        RenewSessionFailedErrorCode,
        JSONFailedErrorCode
    }

    [Native]
    public enum SPTScope : long
    {
        PlaylistReadPrivateScope = (1 << 0),
        PlaylistReadCollaborativeScope = (1 << 1),
        PlaylistModifyPublicScope = (1 << 2),
        PlaylistModifyPrivateScope = (1 << 3),
        UserFollowReadScope = (1 << 4),
        UserFollowModifyScope = (1 << 5),
        UserLibraryReadScope = (1 << 6),
        UserLibraryModifyScope = (1 << 7),
        UserReadBirthDateScope = (1 << 8),
        UserReadEmailScope = (1 << 9),
        UserReadPrivateScope = (1 << 10),
        UserTopReadScope = (1 << 11),
        UGCImageUploadScope = (1 << 12),
        StreamingScope = (1 << 13),
        AppRemoteControlScope = (1 << 14),
        UserReadPlaybackStateScope = (1 << 15),
        UserModifyPlaybackStateScope = (1 << 16),
        UserReadCurrentlyPlayingScope = (1 << 17),
        UserReadRecentlyPlayedScope = (1 << 18)
    }

    [Native]
    public enum SPTAuthorizationOptions : long
    {
        DefaultAuthorizationOption = (0),
        ClientAuthorizationOption = (1 << 0)
    }
}
