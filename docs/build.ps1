param(
    [Switch] $disableChecks = $false,
    [Switch] $debug = $false,
    [string] $port = "8080"
)

function Cleanup() {
    if($debug) { return }
    Remove-Item -Path 'docfx.zip' -Force 2>&1 > $null
}

function GetAssemblyVersion([string] $file) {
    if(-not (Test-Path -Path $file)) { throw "Cannot find path $file because it does not exist." }
    $ver=(Get-Item -Path $file | Select-Object -ExpandProperty VersionInfo).FileVersion.Split('.')
    if($ver.Length -lt 4) {
        $ver -Join '.'
    } else {
        ($ver | Select -SkipLast 1) -Join '.'
    }
}

function FetchAndDownloadRelease([string] $repo, [string] $file, [string] $tag=$null) {
    $global:ProgressPreference='SilentlyContinue'
    if(-not $tag) {
        $tag=(Invoke-WebRequest -UseBasicParsing "https://api.github.com/repos/$repo/releases" | ConvertFrom-Json)[0].tag_name
    }
    Invoke-WebRequest -UseBasicParsing "https://github.com/$repo/releases/download/$tag/$file" -OutFile $file
    $global:ProgressPreference='Continue'
    return ([int]$? - 1)
}


function ExtractArchive([string] $path, [string] $dest) {
    if(-not (Test-Path -Path $path)) { throw "Cannot find path $path because it does not exist." }
    $file=Get-Item -Path $path
    if(!$dest) {
        $dest=$file.FullName.Substring(0, $file.FullName.LastIndexOf('.'))
    }
    $global:ProgressPreference='SilentlyContinue'
    Expand-Archive -Path $file -DestinationPath $dest -Force
    $global:ProgressPreference='Continue'
    return ([int]$? - 1)
}

function LogWrap([string] $msg, [ScriptBlock] $action, [boolean] $disResult=$false) {
    Write-Host -NoNewline "$msg . . . "
    try {
        $errcode, $msg=Invoke-Command -ScriptBlock $action
    } catch {
        $err=$true
        $errcode=1
        $msg=$_
    }
    if(-not $err) {
        if(-not ($errcode -is [int])) {
            $errcode=$LastExitCode
        }
        if(-not $msg) {
            $msg=$Error[0].Exception.Message
        }
    }
    if(-not $disResult -and $errcode -eq 0x0) {
        Write-Host -NoNewline -ForegroundColor 'green' "done`n"
    } elseif($errcode -eq -0x1) {
        Write-Host -NoNewline -ForegroundColor 'yellow' "skipped`n"
    } elseif($errcode -gt 0x0) {
        Write-Host -NoNewline -ForegroundColor 'red' "failed"
        Write-Host -ForegroundColor 'red' " with code $($errcode):`n$($msg)"
        exit
    }
}

try
{
    LogWrap "Downloading DocFx package" {
        if(Test-Path "./docfx/docfx.exe") { return -0x1 }
        FetchAndDownloadRelease "dotnet/docfx" "docfx.zip" 2>$null
    }
    LogWrap "Extracting DocFx package" {
        if(Test-Path "./docfx/docfx.exe") { return -0x1 }
        ExtractArchive "docfx.zip" 2>$null
    }

    LogWrap "Tools version" {
        $dotnetVersion=dotnet --version
        $docfxVer=GetAssemblyVersion "./docfx/docfx.exe"
        Write-Host -NoNewline -ForegroundColor "green" "done`n"
        Write-Host ".NET Core v$dotnetVersion"
        Write-Host "DocFx v$docfxVer"
    } $true

    LogWrap "Generating project metadata" {
        ./docfx/docfx metadata "docfx.json"
    }

    ./docfx/docfx build "docfx.json" --serve -p $port
}
finally
{
    Cleanup
}
