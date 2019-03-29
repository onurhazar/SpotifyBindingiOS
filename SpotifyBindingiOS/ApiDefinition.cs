using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SpotifyBindingiOS
{
    [Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const NSErrorDomain _Nonnull SPTLoginErrorDomain __attribute__((visibility("default")));
        [Field("SPTLoginErrorDomain", "__Internal")]
        NSString SPTLoginErrorDomain { get; }

        // extern NSString *const SPTAppRemoteContentTypeDefault;
        [Field("SPTAppRemoteContentTypeDefault", "__Internal")]
        NSString SPTAppRemoteContentTypeDefault { get; }

        // extern NSString *const SPTAppRemoteContentTypeNavigation;
        [Field("SPTAppRemoteContentTypeNavigation", "__Internal")]
        NSString SPTAppRemoteContentTypeNavigation { get; }

        // extern NSString *const SPTAppRemoteContentTypeFitness;
        [Field("SPTAppRemoteContentTypeFitness", "__Internal")]
        NSString SPTAppRemoteContentTypeFitness { get; }

        // extern NSString *const _Nonnull SPTAppRemoteErrorDomain;
        [Field("SPTAppRemoteErrorDomain", "__Internal")]
        NSString SPTAppRemoteErrorDomain { get; }

        // extern NSString *const _Nonnull SPTAppRemoteAccessTokenKey;
        [Field("SPTAppRemoteAccessTokenKey", "__Internal")]
        NSString SPTAppRemoteAccessTokenKey { get; }

        // extern NSString *const _Nonnull SPTAppRemoteErrorDescriptionKey;
        [Field("SPTAppRemoteErrorDescriptionKey", "__Internal")]
        NSString SPTAppRemoteErrorDescriptionKey { get; }
    }

    // @protocol SPTAppRemoteDelegate <NSObject>
    [BaseType(typeof(NSObject))]
    [Model, Protocol]
    interface SPTAppRemoteDelegate
    {
        // @required -(void)appRemoteDidEstablishConnection:(SPTAppRemote * _Nonnull)appRemote;
        [Abstract]
        [Export("appRemoteDidEstablishConnection:")]
        void DidEstablishConnection(SPTAppRemote appRemote);

        // @required -(void)appRemote:(SPTAppRemote * _Nonnull)appRemote didFailConnectionAttemptWithError:(NSError * _Nullable)error;
        [Abstract]
        [Export("appRemote:didFailConnectionAttemptWithError:")]
        void DidFailConnectionAttemptWithError(SPTAppRemote appRemote, [NullAllowed] NSError error);

        // @required -(void)appRemote:(SPTAppRemote * _Nonnull)appRemote didDisconnectWithError:(NSError * _Nullable)error;
        [Abstract]
        [Export("appRemote:didDisconnectWithError:")]
        void DidDisconnectWithError(SPTAppRemote appRemote, [NullAllowed] NSError error);
    }

    interface ISPTAppRemoteDelegate { }

    // @interface SPTAppRemote : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SPTAppRemote
    {
        // -(instancetype _Nonnull)initWithConfiguration:(SPTConfiguration * _Nonnull)configuration logLevel:(SPTAppRemoteLogLevel)logLevel;
        [Export("initWithConfiguration:logLevel:")]
        IntPtr Constructor(SPTConfiguration configuration, SPTAppRemoteLogLevel logLevel);

        // -(instancetype _Nonnull)initWithConfiguration:(SPTConfiguration * _Nonnull)configuration connectionParameters:(SPTAppRemoteConnectionParams * _Nonnull)connectionParameters logLevel:(SPTAppRemoteLogLevel)logLevel __attribute__((objc_designated_initializer));
        [Export("initWithConfiguration:connectionParameters:logLevel:")]
        [DesignatedInitializer]
        IntPtr Constructor(SPTConfiguration configuration, SPTAppRemoteConnectionParams connectionParameters, SPTAppRemoteLogLevel logLevel);

        // +(void)checkIfSpotifyAppIsActive:(void (^ _Nonnull)(BOOL))completion;
        [Static]
        [Export("checkIfSpotifyAppIsActive:")]
        void CheckIfSpotifyAppIsActive(Action<bool> completion);

        // +(NSString * _Nonnull)appRemoteVersion;
        [Static]
        [Export("appRemoteVersion")]
        //[Verify(MethodToProperty)]
        string AppRemoteVersion { get; }

        // +(NSNumber * _Nonnull)spotifyItunesItemIdentifier;
        [Static]
        [Export("spotifyItunesItemIdentifier")]
        //[Verify(MethodToProperty)]
        NSNumber SpotifyItunesItemIdentifier { get; }

        // @property (readonly, nonatomic, strong) SPTAppRemoteConnectionParams * _Nonnull connectionParameters;
        [Export("connectionParameters", ArgumentSemantic.Strong)]
        SPTAppRemoteConnectionParams ConnectionParameters { get; }

        // @property (readonly, getter = isConnected, assign, nonatomic) BOOL connected;
        [Export("connected")]
        bool Connected { [Bind("isConnected")] get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        ISPTAppRemoteDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SPTAppRemoteDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)connect;
        [Export("connect")]
        void Connect();

        // -(void)disconnect;
        [Export("disconnect")]
        void Disconnect();

        // -(BOOL)authorizeAndPlayURI:(NSString * _Nonnull)URI;
        [Export("authorizeAndPlayURI:")]
        bool AuthorizeAndPlayURI(string URI);

        // -(NSDictionary<NSString *,NSString *> * _Nullable)authorizationParametersFromURL:(NSURL * _Nonnull)url;
        [Export("authorizationParametersFromURL:")]
        [return: NullAllowed]
        NSDictionary<NSString, NSString> AuthorizationParametersFromURL(NSUrl url);

        // @property (readonly, nonatomic, strong) id<SPTAppRemotePlayerAPI> _Nullable playerAPI;
        [NullAllowed, Export("playerAPI", ArgumentSemantic.Strong)]
        SPTAppRemotePlayerAPI PlayerAPI { get; }

        // @property (readonly, nonatomic, strong) id<SPTAppRemoteImageAPI> _Nullable imageAPI;
        [NullAllowed, Export("imageAPI", ArgumentSemantic.Strong)]
        SPTAppRemoteImageAPI ImageAPI { get; }

        // @property (readonly, nonatomic, strong) id<SPTAppRemoteUserAPI> _Nullable userAPI;
        [NullAllowed, Export("userAPI", ArgumentSemantic.Strong)]
        SPTAppRemoteUserAPI UserAPI { get; }

        // @property (readonly, nonatomic, strong) id<SPTAppRemoteContentAPI> _Nullable contentAPI;
        [NullAllowed, Export("contentAPI", ArgumentSemantic.Strong)]
        SPTAppRemoteContentAPI ContentAPI { get; }
    }

    // typedef void (^SPTAppRemoteCallback)(id _Nullable, NSError * _Nullable);
    delegate void SPTAppRemoteCallback([NullAllowed] NSObject obj, [NullAllowed] NSError error);

    // @interface SPTAppRemoteConnectionParams : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SPTAppRemoteConnectionParams
    {
        // @property (readwrite, copy, nonatomic) NSString * _Nullable accessToken;
        [NullAllowed, Export("accessToken")]
        string AccessToken { get; set; }

        // @property (readonly, assign, nonatomic) struct CGSize defaultImageSize;
        [Export("defaultImageSize", ArgumentSemantic.Assign)]
        CGSize DefaultImageSize { get; }

        // @property (readonly, assign, nonatomic) SPTAppRemoteConnectionParamsImageFormat imageFormat;
        [Export("imageFormat", ArgumentSemantic.Assign)]
        SPTAppRemoteConnectionParamsImageFormat ImageFormat { get; }

        // -(instancetype _Nonnull)initWithAccessToken:(NSString * _Nullable)accessToken defaultImageSize:(struct CGSize)defaultImageSize imageFormat:(SPTAppRemoteConnectionParamsImageFormat)imageFormat __attribute__((objc_designated_initializer));
        [Export("initWithAccessToken:defaultImageSize:imageFormat:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string accessToken, CGSize defaultImageSize, SPTAppRemoteConnectionParamsImageFormat imageFormat);

        // @property (readonly, assign, nonatomic) NSInteger protocolVersion;
        [Export("protocolVersion")]
        nint ProtocolVersion { get; }

        // @property (readonly, copy, nonatomic) NSDictionary * _Nonnull roles;
        [Export("roles", ArgumentSemantic.Copy)]
        NSDictionary Roles { get; }

        // @property (readonly, copy, nonatomic) NSArray * _Nonnull authenticationMethods;
        [Export("authenticationMethods", ArgumentSemantic.Copy)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] AuthenticationMethods { get; }
    }

    // @protocol SPTAppRemoteImageRepresentable <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteImageRepresentable
    {
        // @required @property (readonly, nonatomic, strong) NSString * _Nonnull imageIdentifier;
        [Abstract]
        [Export("imageIdentifier", ArgumentSemantic.Strong)]
        string ImageIdentifier { get; }
    }

    interface ISPTAppRemoteImageRepresentable { }

    // @protocol SPTAppRemoteImageAPI <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteImageAPI
    {
        // @required -(void)fetchImageForItem:(id<SPTAppRemoteImageRepresentable> _Nonnull)imageRepresentable withSize:(CGSize)imageSize callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("fetchImageForItem:withSize:callback:")]
        void FetchImageForItem(ISPTAppRemoteImageRepresentable imageRepresentable, CGSize imageSize, [NullAllowed] SPTAppRemoteCallback callback);
    }

    // @protocol SPTAppRemotePlaybackOptions <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemotePlaybackOptions
    {
        // @required @property (readonly, nonatomic) BOOL isShuffling;
        [Abstract]
        [Export("isShuffling")]
        bool IsShuffling { get; }

        // @required @property (readonly, nonatomic) SPTAppRemotePlaybackOptionsRepeatMode repeatMode;
        [Abstract]
        [Export("repeatMode")]
        SPTAppRemotePlaybackOptionsRepeatMode RepeatMode { get; }
    }

    // @protocol SPTAppRemotePlayerStateDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemotePlayerStateDelegate
    {
        // @required -(void)playerStateDidChange:(id<SPTAppRemotePlayerState> _Nonnull)playerState;
        [Abstract]
        [Export("playerStateDidChange:")]
        void PlayerStateDidChange(SPTAppRemotePlayerState playerState);
    }

    interface ISPTAppRemotePlayerStateDelegate { }

    interface ISPTAppRemotePlayerAPI { }

    // @protocol SPTAppRemotePlayerAPI <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemotePlayerAPI
    {
        //[Wrap("WeakDelegate"), Abstract]
        [Wrap("WeakDelegate")]
        [NullAllowed]
        ISPTAppRemotePlayerStateDelegate Delegate { get; set; }

        // @required @property (nonatomic, weak) id<SPTAppRemotePlayerStateDelegate> _Nullable delegate;
        //[Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @required -(void)play:(NSString * _Nonnull)entityIdentifier callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("play:callback:")]
        void Play(string entityIdentifier, [NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)playItem:(id<SPTAppRemoteContentItem> _Nonnull)contentItem callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("playItem:callback:")]
        void PlayItem(SPTAppRemoteContentItem contentItem, [NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)resume:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("resume:")]
        void Resume([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)pause:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("pause:")]
        void Pause([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)skipToNext:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("skipToNext:")]
        void SkipToNext([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)skipToPrevious:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("skipToPrevious:")]
        void SkipToPrevious([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)seekToPosition:(NSInteger)position callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("seekToPosition:callback:")]
        void SeekToPosition(nint position, [NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)seekForward15Seconds:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("seekForward15Seconds:")]
        void SeekForward15Seconds([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)seekBackward15Seconds:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("seekBackward15Seconds:")]
        void SeekBackward15Seconds([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)setShuffle:(BOOL)shuffle callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("setShuffle:callback:")]
        void SetShuffle(bool shuffle, [NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)setRepeatMode:(SPTAppRemotePlaybackOptionsRepeatMode)repeatMode callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("setRepeatMode:callback:")]
        void SetRepeatMode(SPTAppRemotePlaybackOptionsRepeatMode repeatMode, [NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)getPlayerState:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("getPlayerState:")]
        void GetPlayerState([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)subscribeToPlayerState:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("subscribeToPlayerState:")]
        void SubscribeToPlayerState([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)unsubscribeToPlayerState:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("unsubscribeToPlayerState:")]
        void UnsubscribeToPlayerState([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)enqueueTrackUri:(NSString * _Nonnull)trackUri callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("enqueueTrackUri:callback:")]
        void EnqueueTrackUri(string trackUri, [NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)getAvailablePodcastPlaybackSpeeds:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("getAvailablePodcastPlaybackSpeeds:")]
        void GetAvailablePodcastPlaybackSpeeds([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)getCurrentPodcastPlaybackSpeed:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("getCurrentPodcastPlaybackSpeed:")]
        void GetCurrentPodcastPlaybackSpeed([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)setPodcastPlaybackSpeed:(id<SPTAppRemotePodcastPlaybackSpeed> _Nonnull)speed callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("setPodcastPlaybackSpeed:callback:")]
        void SetPodcastPlaybackSpeed(SPTAppRemotePodcastPlaybackSpeed speed, [NullAllowed] SPTAppRemoteCallback callback);
    }

    // @protocol SPTAppRemoteUserAPIDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteUserAPIDelegate
    {
        // @required -(void)userAPI:(id<SPTAppRemoteUserAPI> _Nonnull)userAPI didReceiveCapabilities:(id<SPTAppRemoteUserCapabilities> _Nonnull)capabilities;
        [Abstract]
        [Export("userAPI:didReceiveCapabilities:")]
        void DidReceiveCapabilities(SPTAppRemoteUserAPI userAPI, SPTAppRemoteUserCapabilities capabilities);
    }

    interface ISPTAppRemoteUserAPIDelegate { }

    // @protocol SPTAppRemoteUserAPI <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteUserAPI
    {
        //[Wrap("WeakDelegate"), Abstract]
        [Wrap("WeakDelegate")]
        [NullAllowed]
        ISPTAppRemoteUserAPIDelegate Delegate { get; set; }

        // @required @property (readwrite, nonatomic, weak) id<SPTAppRemoteUserAPIDelegate> _Nullable delegate;
        //[Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @required -(void)fetchCapabilitiesWithCallback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("fetchCapabilitiesWithCallback:")]
        void FetchCapabilitiesWithCallback([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)subscribeToCapabilityChanges:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("subscribeToCapabilityChanges:")]
        void SubscribeToCapabilityChanges([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)unsubscribeToCapabilityChanges:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("unsubscribeToCapabilityChanges:")]
        void UnsubscribeToCapabilityChanges([NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)fetchLibraryStateForURI:(NSString * _Nonnull)URI callback:(SPTAppRemoteCallback _Nonnull)callback;
        [Abstract]
        [Export("fetchLibraryStateForURI:callback:")]
        void FetchLibraryStateForURI(string URI, SPTAppRemoteCallback callback);

        // @required -(void)addItemToLibraryWithURI:(NSString * _Nonnull)URI callback:(SPTAppRemoteCallback _Nonnull)callback;
        [Abstract]
        [Export("addItemToLibraryWithURI:callback:")]
        void AddItemToLibraryWithURI(string URI, SPTAppRemoteCallback callback);

        // @required -(void)removeItemFromLibraryWithURI:(NSString * _Nonnull)URI callback:(SPTAppRemoteCallback _Nonnull)callback;
        [Abstract]
        [Export("removeItemFromLibraryWithURI:callback:")]
        void RemoveItemFromLibraryWithURI(string URI, SPTAppRemoteCallback callback);
    }

    // @protocol SPTAppRemoteContentAPI <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteContentAPI
    {
        // @required -(void)fetchRootContentItemsForType:(SPTAppRemoteContentType _Nonnull)contentType callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("fetchRootContentItemsForType:callback:")]
        void FetchRootContentItemsForType(string contentType, [NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)fetchChildrenOfContentItem:(id<SPTAppRemoteContentItem> _Nonnull)contentItem callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("fetchChildrenOfContentItem:callback:")]
        void FetchChildrenOfContentItem(SPTAppRemoteContentItem contentItem, [NullAllowed] SPTAppRemoteCallback callback);

        // @required -(void)fetchRecommendedContentItemsForType:(SPTAppRemoteContentType _Nonnull)contentType flattenContainers:(BOOL)flattenContainers callback:(SPTAppRemoteCallback _Nullable)callback;
        [Abstract]
        [Export("fetchRecommendedContentItemsForType:flattenContainers:callback:")]
        void FetchRecommendedContentItemsForType(string contentType, bool flattenContainers, [NullAllowed] SPTAppRemoteCallback callback);
    }

    // @protocol SPTAppRemoteAlbum <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteAlbum
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Abstract]
        [Export("name")]
        string Name { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull URI;
        [Abstract]
        [Export("URI")]
        string URI { get; }
    }

    // @protocol SPTAppRemoteArtist <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteArtist
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Abstract]
        [Export("name")]
        string Name { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull URI;
        [Abstract]
        [Export("URI")]
        string URI { get; }
    }

    // @protocol SPTAppRemotePlaybackRestrictions <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemotePlaybackRestrictions
    {
        // @required @property (readonly, nonatomic) BOOL canSkipNext;
        [Abstract]
        [Export("canSkipNext")]
        bool CanSkipNext { get; }

        // @required @property (readonly, nonatomic) BOOL canSkipPrevious;
        [Abstract]
        [Export("canSkipPrevious")]
        bool CanSkipPrevious { get; }

        // @required @property (readonly, nonatomic) BOOL canRepeatTrack;
        [Abstract]
        [Export("canRepeatTrack")]
        bool CanRepeatTrack { get; }

        // @required @property (readonly, nonatomic) BOOL canRepeatContext;
        [Abstract]
        [Export("canRepeatContext")]
        bool CanRepeatContext { get; }

        // @required @property (readonly, nonatomic) BOOL canToggleShuffle;
        [Abstract]
        [Export("canToggleShuffle")]
        bool CanToggleShuffle { get; }

        // @required @property (readonly, nonatomic) BOOL canSeek;
        [Abstract]
        [Export("canSeek")]
        bool CanSeek { get; }
    }

    // @protocol SPTAppRemotePlayerState <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemotePlayerState
    {
        // @required @property (readonly, nonatomic) id<SPTAppRemoteTrack> _Nonnull track;
        [Abstract]
        [Export("track")]
        SPTAppRemoteTrack Track { get; }

        // @required @property (readonly, nonatomic) NSInteger playbackPosition;
        [Abstract]
        [Export("playbackPosition")]
        nint PlaybackPosition { get; }

        // @required @property (readonly, nonatomic) float playbackSpeed;
        [Abstract]
        [Export("playbackSpeed")]
        float PlaybackSpeed { get; }

        // @required @property (readonly, getter = isPaused, nonatomic) BOOL paused;
        [Abstract]
        [Export("paused")]
        bool Paused { [Bind("isPaused")] get; }

        // @required @property (readonly, nonatomic) id<SPTAppRemotePlaybackRestrictions> _Nonnull playbackRestrictions;
        [Abstract]
        [Export("playbackRestrictions")]
        SPTAppRemotePlaybackRestrictions PlaybackRestrictions { get; }

        // @required @property (readonly, nonatomic) id<SPTAppRemotePlaybackOptions> _Nonnull playbackOptions;
        [Abstract]
        [Export("playbackOptions")]
        SPTAppRemotePlaybackOptions PlaybackOptions { get; }

        // @required @property (readonly, nonatomic) NSString * _Nonnull contextTitle;
        [Abstract]
        [Export("contextTitle")]
        string ContextTitle { get; }

        // @required @property (readonly, nonatomic) NSURL * _Nonnull contextURI;
        [Abstract]
        [Export("contextURI")]
        NSUrl ContextURI { get; }
    }

    // @protocol SPTAppRemoteTrack <NSObject, SPTAppRemoteImageRepresentable>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteTrack : SPTAppRemoteImageRepresentable//ISPTAppRemoteImageRepresentable
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Abstract]
        [Export("name")]
        string Name { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull URI;
        [Abstract]
        [Export("URI")]
        string URI { get; }

        // @required @property (readonly, assign, nonatomic) NSUInteger duration;
        [Abstract]
        [Export("duration")]
        nuint Duration { get; }

        // @required @property (readonly, nonatomic, strong) id<SPTAppRemoteArtist> _Nonnull artist;
        [Abstract]
        [Export("artist", ArgumentSemantic.Strong)]
        SPTAppRemoteArtist Artist { get; }

        // @required @property (readonly, nonatomic, strong) id<SPTAppRemoteAlbum> _Nonnull album;
        [Abstract]
        [Export("album", ArgumentSemantic.Strong)]
        SPTAppRemoteAlbum Album { get; }

        // @required @property (readonly, getter = isSaved, assign, nonatomic) BOOL saved;
        [Abstract]
        [Export("saved")]
        bool Saved { [Bind("isSaved")] get; }

        // @required @property (readonly, getter = isEpisode, assign, nonatomic) BOOL episode;
        [Abstract]
        [Export("episode")]
        bool Episode { [Bind("isEpisode")] get; }

        // @required @property (readonly, getter = isPodcast, assign, nonatomic) BOOL podcast;
        [Abstract]
        [Export("podcast")]
        bool Podcast { [Bind("isPodcast")] get; }
    }

    // @protocol SPTAppRemoteUserCapabilities <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteUserCapabilities
    {
        // @required @property (readonly, assign, nonatomic) BOOL canPlayOnDemand;
        [Abstract]
        [Export("canPlayOnDemand")]
        bool CanPlayOnDemand { get; }
    }

    // @protocol SPTAppRemoteLibraryState <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteLibraryState
    {
        // @required @property (readonly, nonatomic, strong) NSString * _Nonnull uri;
        [Abstract]
        [Export("uri", ArgumentSemantic.Strong)]
        string Uri { get; }

        // @required @property (readonly, assign, nonatomic) BOOL isAdded;
        [Abstract]
        [Export("isAdded")]
        bool IsAdded { get; }

        // @required @property (readonly, assign, nonatomic) BOOL canAdd;
        [Abstract]
        [Export("canAdd")]
        bool CanAdd { get; }
    }

    // @protocol SPTAppRemoteContentItem <NSObject, SPTAppRemoteImageRepresentable>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemoteContentItem : SPTAppRemoteImageRepresentable//ISPTAppRemoteImageRepresentable
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nullable title;
        [Abstract]
        [NullAllowed, Export("title")]
        string Title { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable subtitle;
        [Abstract]
        [NullAllowed, Export("subtitle")]
        string Subtitle { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
        [Abstract]
        [Export("identifier")]
        string Identifier { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull URI;
        [Abstract]
        [Export("URI")]
        string URI { get; }

        // @required @property (readonly, getter = isAvailableOffline, assign, nonatomic) BOOL availableOffline;
        [Abstract]
        [Export("availableOffline")]
        bool AvailableOffline { [Bind("isAvailableOffline")] get; }

        // @required @property (readonly, getter = isPlayable, assign, nonatomic) BOOL playable;
        [Abstract]
        [Export("playable")]
        bool Playable { [Bind("isPlayable")] get; }

        // @required @property (readonly, getter = isContainer, assign, nonatomic) BOOL container;
        [Abstract]
        [Export("container")]
        bool Container { [Bind("isContainer")] get; }

        // @required @property (readonly, nonatomic, strong) NSArray<id<SPTAppRemoteContentItem>> * _Nullable children;
        [Abstract]
        [NullAllowed, Export("children", ArgumentSemantic.Strong)]
        SPTAppRemoteContentItem[] Children { get; }
    }

    // @protocol SPTAppRemotePodcastPlaybackSpeed <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SPTAppRemotePodcastPlaybackSpeed
    {
        // @required @property (readonly, nonatomic, strong) NSNumber * _Nonnull value;
        [Abstract]
        [Export("value", ArgumentSemantic.Strong)]
        NSNumber Value { get; }
    }

    // @interface SPTConfiguration : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SPTConfiguration : INSSecureCoding
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull clientID;
        [Export("clientID")]
        string ClientID { get; }

        // @property (readonly, copy, nonatomic) NSURL * _Nonnull redirectURL;
        [Export("redirectURL", ArgumentSemantic.Copy)]
        NSUrl RedirectURL { get; }

        // @property (copy, nonatomic) NSURL * _Nullable tokenSwapURL;
        [NullAllowed, Export("tokenSwapURL", ArgumentSemantic.Copy)]
        NSUrl TokenSwapURL { get; set; }

        // @property (copy, nonatomic) NSURL * _Nullable tokenRefreshURL;
        [NullAllowed, Export("tokenRefreshURL", ArgumentSemantic.Copy)]
        NSUrl TokenRefreshURL { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable playURI;
        [NullAllowed, Export("playURI")]
        string PlayURI { get; set; }

        // -(instancetype _Nonnull)initWithClientID:(NSString * _Nonnull)clientID redirectURL:(NSURL * _Nonnull)redirectURL __attribute__((objc_designated_initializer));
        [Export("initWithClientID:redirectURL:")]
        [DesignatedInitializer]
        IntPtr Constructor(string clientID, NSUrl redirectURL);

        // +(instancetype _Nonnull)configurationWithClientID:(NSString * _Nonnull)clientID redirectURL:(NSURL * _Nonnull)redirectURL;
        [Static]
        [Export("configurationWithClientID:redirectURL:")]
        SPTConfiguration ConfigurationWithClientID(string clientID, NSUrl redirectURL);
    }

    // @interface SPTError : NSError
    [BaseType(typeof(NSError))]
    interface SPTError
    {
        // +(instancetype _Nonnull)errorWithCode:(SPTErrorCode)code;
        [Static]
        [Export("errorWithCode:")]
        SPTError ErrorWithCode(SPTErrorCode code);

        // +(instancetype _Nonnull)errorWithCode:(SPTErrorCode)code description:(NSString * _Nonnull)description;
        [Static]
        [Export("errorWithCode:description:")]
        SPTError ErrorWithCode(SPTErrorCode code, string description);

        // +(instancetype _Nonnull)errorWithCode:(SPTErrorCode)code underlyingError:(NSError * _Nonnull)error;
        [Static]
        [Export("errorWithCode:underlyingError:")]
        SPTError ErrorWithCode(SPTErrorCode code, NSError error);
    }

    // @interface SPTSession : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SPTSession : INSSecureCoding
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull accessToken;
        [Export("accessToken")]
        string AccessToken { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull refreshToken;
        [Export("refreshToken")]
        string RefreshToken { get; }

        // @property (readonly, copy, nonatomic) NSDate * _Nonnull expirationDate;
        [Export("expirationDate", ArgumentSemantic.Copy)]
        NSDate ExpirationDate { get; }

        // @property (readonly, nonatomic) SPTScope scope;
        [Export("scope")]
        SPTScope Scope { get; }

        // @property (readonly, getter = isExpired, nonatomic) BOOL expired;
        [Export("expired")]
        bool Expired { [Bind("isExpired")] get; }
    }

    // @interface SPTSessionManager : NSObject
    [BaseType(typeof(NSObject))]
    //[BaseType(typeof(NSObject), Delegates = new string[] { "WeakDelegate" }, Events = new Type[] { typeof(SPTSessionManagerDelegate) })]
    [DisableDefaultCtor]
    interface SPTSessionManager
    {
        // @property (nonatomic) SPTSession * _Nullable session;
        [NullAllowed, Export("session", ArgumentSemantic.Assign)]
        SPTSession Session { get; set; }

        // @property (nonatomic, weak) id<SPTSessionManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        SPTSessionManagerDelegate Delegate { get; set; }

        // @property (readonly, getter = isSpotifyAppInstalled, nonatomic) BOOL spotifyAppInstalled;
        [Export("spotifyAppInstalled")]
        bool SpotifyAppInstalled { [Bind("isSpotifyAppInstalled")] get; }

        // @property (assign, nonatomic) BOOL alwaysShowAuthorizationDialog;
        [Export("alwaysShowAuthorizationDialog")]
        bool AlwaysShowAuthorizationDialog { get; set; }

        // -(void)initiateSessionWithScope:(SPTScope)scope options:(SPTAuthorizationOptions)options __attribute__((availability(ios, introduced=11_0)));
        [iOS(11, 0)]
        [Export("initiateSessionWithScope:options:")]
        void InitiateSessionWithScope(SPTScope scope, SPTAuthorizationOptions options);

        // -(void)initiateSessionWithScope:(SPTScope)scope options:(SPTAuthorizationOptions)options presentingViewController:(UIViewController * _Nonnull)presentingViewController __attribute__((availability(ios, introduced=9_0, deprecated=11_0)));
        [Introduced(PlatformName.iOS, 9, 0)]
        [Deprecated(PlatformName.iOS, 11, 0)]
        [Export("initiateSessionWithScope:options:presentingViewController:")]
        void InitiateSessionWithScope(SPTScope scope, SPTAuthorizationOptions options, UIViewController presentingViewController);

        // -(void)renewSession;
        [Export("renewSession")]
        void RenewSession();

        // -(instancetype _Nonnull)initWithConfiguration:(SPTConfiguration * _Nonnull)configuration delegate:(id<SPTSessionManagerDelegate> _Nullable)delegate;
        [Export("initWithConfiguration:delegate:")]
        IntPtr Constructor(SPTConfiguration configuration, [NullAllowed] ISPTSessionManagerDelegate del);

        // +(instancetype _Nonnull)sessionManagerWithConfiguration:(SPTConfiguration * _Nonnull)configuration delegate:(id<SPTSessionManagerDelegate> _Nullable)delegate;
        [Static]
        [Export("sessionManagerWithConfiguration:delegate:")]
        SPTSessionManager SessionManagerWithConfiguration(SPTConfiguration configuration, [NullAllowed] ISPTSessionManagerDelegate del);

        // -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)URL options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> * _Nonnull)options;
        [Export("application:openURL:options:")]
        bool Application(UIApplication application, NSUrl URL, NSDictionary options);
    }

    // @protocol SPTSessionManagerDelegate <NSObject>
    [BaseType(typeof(NSObject))]
    [Model, Protocol]
    interface SPTSessionManagerDelegate
    {
        // @required -(void)sessionManager:(SPTSessionManager * _Nonnull)manager didInitiateSession:(SPTSession * _Nonnull)session;
        [Abstract]
        //[Export("sessionManager:didInitiateSession:"), EventArgs("DidInitiateSession"), EventName("DidInitiateSession")]
        [Export("sessionManager:didInitiateSession:")]
        void DidInitiateSession(SPTSessionManager manager, SPTSession session);

        // @required -(void)sessionManager:(SPTSessionManager * _Nonnull)manager didFailWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("sessionManager:didFailWithError:")]
        void DidFailWithError(SPTSessionManager manager, NSError error);

        // @optional -(void)sessionManager:(SPTSessionManager * _Nonnull)manager didRenewSession:(SPTSession * _Nonnull)session;
        [Export("sessionManager:didRenewSession:")]
        void DidRenewSession(SPTSessionManager manager, SPTSession session);

        // @optional -(BOOL)sessionManager:(SPTSessionManager * _Nonnull)manager shouldRequestAccessTokenWithAuthorizationCode:(SPTAuthorizationCode _Nonnull)code;
        //[Export("sessionManager:shouldRequestAccessTokenWithAuthorizationCode:"), DelegateName("ShouldRequestAccessTokenWithAuthorizationCode"), DefaultValue(false)]
        [Export("sessionManager:shouldRequestAccessTokenWithAuthorizationCode:")]
        bool ShouldRequestAccessTokenWithAuthorizationCode(SPTSessionManager manager, string code);
    }

    interface ISPTSessionManagerDelegate { }
}
