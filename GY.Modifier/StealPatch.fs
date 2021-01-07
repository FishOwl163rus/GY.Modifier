module GY.Modifier.StealPatch

open HarmonyLib
open SDG.Unturned

[<HarmonyPatch(typeof<InteractableVehicle>, "stealBattery")>]
type StealPatch() =
    [<HarmonyPrefix>]
    static member Override(__instance : obj, player : Player) : bool =
        let res = if (__instance :? InteractableVehicle) then __instance :?> InteractableVehicle else null
        if Plugin.Cfg.Data.Exists(fun x -> x.ID = res.id && x.OverrideBattery) then false else true