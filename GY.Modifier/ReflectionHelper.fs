namespace GY.Modifier

open System
open System.Reflection
open SDG.Unturned
open SDG.Unturned

type ReflectionHelper() =
    static member DynamicSet x propName propValue =
     let property = x.GetType().GetProperty(propName)
     property.SetValue(x, propValue, null)