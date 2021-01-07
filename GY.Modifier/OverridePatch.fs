namespace GY.Modifier

open HarmonyLib
open SDG.Unturned
open SDG.Unturned

[<HarmonyPatch(typeof<InteractableVehicle>, "Update")>]
type OverridePatch() =
    
    [<HarmonyPostfix>]
    static member Override(__instance : obj) =
        let res = if (__instance :? InteractableVehicle) then __instance :?> InteractableVehicle else null
        if Plugin.Cfg.Data.Exists(fun x -> x.ID = res.id && x.OverrideFuel && res.fuel < res.asset.fuel) then
            VehicleManager.sendVehicleFuel(res, 20000us)
        if Plugin.Cfg.Data.Exists(fun x -> x.ID = res.id && x.OverrideBattery && not res.isBatteryFull) then
            VehicleManager.sendVehicleBatteryCharge(res, 20000us)
             