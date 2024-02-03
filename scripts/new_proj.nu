#!/bin/env nu

def main [
    proj_type: string,
    folder:    path
] {
    mkdir $folder
    cd $folder
    dotnet new $proj_type
    
    cd -
    dotnet sln add $folder
}
