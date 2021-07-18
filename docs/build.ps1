param(
    [string] $port="8080",
    [Switch] $cleanMetadata=$false,
    [Switch] $cleanOnly=$false
)

$requiredRepos=[Ordered]@{}
$requiredPackages=[Ordered]@{
    "docfx.zip"=@{
        "repo"="dotnet/docfx";
        "version"=$null;
        "predicate"="./docfx/docfx.exe";
        "dest"="./docfx/";
        "name"="DocFx";
    };
    "docfx-plugins-extractsearchindex.zip"=@{
        "repo"="Lhoerion/DocFx.Plugins.ExtractSearchIndex";
        "version"=$null;
        "predicate"="./templates/docfx-plugins-extractsearchindex/";
        "dest"="./templates/";
        "name"="DocFx ExtractSearchIndex";
    };
    "docfx-tmpls-discordfx.zip"=@{
        "repo"="Lhoerion/DiscordFX";
        "version"=$null;
        "predicate"="./templates/discordfx/";
        "dest"="./templates/";
        "name"="DocFx DiscordFX";
    };
}

$global:ProgressPreference='SilentlyContinue'
Invoke-WebRequest -UseBasicParsing "https://raw.githubusercontent.com/altmp/altv-docs/master/common.ps1" -OutFile "./common.ps1" 2>&1 >$null
$global:ProgressPreference='Continue'
if($err -ne $null -or -not (Test-Path "./common.ps1")) { throw "Script common.ps1 not found." }
. "./common.ps1" $true

try
{
    $cwd=(Get-Location).Path
    $tmpd="${env:TMP}/altv-docs"
    New-Item -ItemType "Directory" -Path "$tmpd" 2>&1 >$null

    if($cleanOnly) { exit }

    foreach($el in $requiredRepos.GetEnumerator()) {
        Run-Task "Checkout $($el.Value["name"]) repository" {
            if(Test-Path $el.Key) {
                Set-Location -Path $el.Key
                git fetch --depth 1 "origin" $el.Value["ref"]
                if((git status -s -b) -like "*``[*behind *``]") {
                    git clean -d -x -f
                    git reset --hard "FETCH_HEAD"
                    Set-Location $cwd
                    Exit-Task (0x0)
                } else {
                    Set-Location $cwd
                    Exit-Task (-0x1)
                }
            }
            New-Item -ItemType "directory" -Path $el.Key -Force
            Set-Location -Path $el.Key
            git init
            git remote add "origin" $el.Value["repo"]
            git fetch --depth 1 "origin" $el.Value["ref"]
            git merge "FETCH_HEAD"
            git reset --hard "HEAD"
            git branch --set-upstream-to "origin/$($el.Value["ref"])" master
            Set-Location $cwd
        }
    }

    foreach($el in $requiredPackages.GetEnumerator()) {
        Run-Task "Downloading $($el.Value["name"]) package" {
            if(Test-Path $el.Value["predicate"]) { Exit-Task (-0x1) }
            FetchAndDownloadRelease $el.Value["repo"] "$tmpd/" $el.Key $el.Value["version"]
        }
        Run-Task "Extracting $($el.Value["name"]) package" {
            if(Test-Path $el.Value["predicate"]) { Exit-Task (-0x1) }
            ExtractArchive "$tmpd/$($el.Key)" $el.Value["dest"]
        }
    }

    Run-Task "Tools version" {
        Set-Location $cwd
        $tools=[Ordered]@{
            "Node.js"=(node -v);
            "Yarn/npm"=GetNodePackageVersion;
            "Visual Studio"=GetVisualStudioVersion;
            "DocFx"=GetAssemblyVersion "./docfx/docfx.exe";
            "DocFx TypeScriptReference"=GetAssemblyVersion "./templates/docfx-plugins-typescriptreference/plugins/DocFx.*.dll";
            "DocFx ExtractSearchIndex"=GetAssemblyVersion "./templates/docfx-plugins-extractsearchindex/plugins/DocFx.*.dll";
            "TypeDoc"=GetNodePackageVersion "typedoc";
            "type2docfx"=GetNodePackageVersion "type2docfx";
        }
        Write-Information -Tags "Output" -MessageData ($tools | Format-Table | Out-String)
    }

    Run-Task "Generating project metadata" {
        if(IsVisualStudioInstalled) {
            ./docfx/docfx metadata "./coreclr-module/docs/docfx.json" --intermediateFolder "$tmpd/obj/"
        } else {
            Exit-Task (-0x1)
        }
    }

    ./docfx/docfx build "docfx.json" --intermediateFolder "$tmpd/obj/" --serve -p $port
}
finally
{
    Set-Location $cwd
    PostCleanup
}
