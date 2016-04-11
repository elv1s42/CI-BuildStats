﻿open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open PackageServices
open Suave.Json
open Serializers

let sleep milliseconds message: WebPart =
  fun (x : HttpContext) ->
    async {
      do! Async.Sleep milliseconds
      return! OK message x
    }



let getNuGetPackage packageName : WebPart =
    fun (x : HttpContext) ->
        async {
            let! package = getNuGetPackageAsync packageName false
            return! OK "" x
        }

let app =
  choose
    [ GET >=> choose
        [ pathScan "/nuget/%s" (fun packageName -> getNuGetPackage packageName)
          //pathScan "/nuget/%s" (fun packageName -> mapJson (fun _ -> getNuGetPackageAsync packageName false))
          path "/goodbye" >=> OK "Good bye GET" ] ]

[<EntryPoint>]
let main argv = 
    startWebServer defaultConfig app
    0