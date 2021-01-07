namespace GY.Modifier

open System.Collections.Generic
open System.Xml.Serialization
open Rocket.API

type VehicleMod =
     [<XmlAttribute>]
     val mutable ID : uint16
     [<XmlAttribute>]
     val mutable OverrideBattery : bool
     [<XmlAttribute>]
     val mutable OverrideFuel : bool
     public new() = {ID = 0us; OverrideBattery = false; OverrideFuel = false}
     public new(id : uint16, overrideBattery : bool, overrideFuel : bool) =
         {ID = id; OverrideBattery = overrideBattery; OverrideFuel = overrideFuel}
         
type Config() =
    [<DefaultValue>] val mutable Data : List<VehicleMod>
    interface IRocketPluginConfiguration with
     member this.LoadDefaults() = this.Data <- ResizeArray[VehicleMod(54us, true, true)]

