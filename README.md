# NetworkPositionSync

Network Transform using Snapshot Interpolation and other techniques to best sync position and rotation over the network. 

## Usage

1) Download the code from the source folder or package on [Release](https://github.com/JamesFrowen/NetworkPositionSync/releases) page.
2) Put the code somewhere in your Assets folder
3) Add SyncPositionBehaviour to GameObjects that you want to sync
4) Add SyncPositionSystem to NetworkManager that you want to sync
    4a) call system.RegisterHandlers from OnStartClient and OnStartServer in a custom NetworkManager
5) Create SyncPositionPacker (menu path: `Assets/Create/PositionSync/Packer`)
    5a) set up packing settings for scene (mostly just position bounds)
6) Create SyncPositionBehaviourRuntimeDictionary (menu path: `Assets/Create/PositionSync/Behaviour Set`)
7) Assign ScriptableObjects in component fields (both behaviour and system need both of packer and runtimeset)

## Bugs?

Please report any bugs or issues [Here](https://github.com/JamesFrowen/NetworkPositionSync/issues)
