namespace GY.Modifier

open System
open HarmonyLib
open HarmonyLib
open Rocket.Core.Plugins
open SDG.Unturned
open SDG.Unturned
open SDG.Unturned
open SDG.Unturned
open SDG.Unturned
open SDG.Unturned

type Plugin() =
    static member val Cfg : Config = Config() with get, set
    [<DefaultValue>] val mutable Instance : Harmony
    inherit RocketPlugin<Config>()
    member this.OnSiphon(vehicle : InteractableVehicle, allow : byref<bool>) =
        if Plugin.Cfg.Data.Exists(fun x -> x.ID = vehicle.id && x.OverrideFuel) then
            allow <- false
    override this.Load() =
        VehicleManager.onSiphonVehicleRequested <- SiphonVehicleRequestHandler(fun vehicle player allow value -> this.OnSiphon(vehicle, &allow))
        Plugin.Cfg <- this.Configuration.Instance
        this.Instance <- Harmony("gerayoga")
        this.Instance.PatchAll()
        
    override this.Unload() =
        VehicleManager.onSiphonVehicleRequested <- SiphonVehicleRequestHandler(fun vehicle player allow value -> ())
        this.Instance.UnpatchAll()