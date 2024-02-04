#!/bin/env nu

def main [
    controller_name: string
] {
    dotnet aspnet-codegenerator controller -name $controller_name -async -api -outDir Controllers

}
