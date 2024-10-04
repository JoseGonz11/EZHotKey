[string]$TargetFramework
[string]$Platform
[string]$Configuration

$projectPath = "EZHotKey.Windows/EZHotkey.Windows.csproj"

if (Get-Variable TargetFramework -Scope 'local' -ErrorAction 'Ignore') {
} else {
    $TargetFramework = "net8.0-windows10.0.22621.0"
}

if (Get-Variable Platform -Scope 'local' -ErrorAction 'Ignore') {
} else {
    $Platform = "x64"
}

if (Get-Variable Configuration -Scope 'local' -ErrorAction 'Ignore') {
} else {
    $Configuration = "Release"
}

Function GetPackageType {
    $config = (Get-Variable -Name 'Configuration' -ValueOnly)
    if ($config -eq "Debug") {
        return "None"
    } else {
        return "MSIX"
    }
}

$packageType = GetPackageType

$buildScript = "dotnet build -p:WindowsPackageType=$packageType -p:Platform=$Platform -c $COnfiguration -v d"

$outputDir = "$PSScriptRoot/bin/$Platform/$Configuration/$TargetFramework/win-$Platform/"`

Get-AppxPackage *EZHotkey.Windows* | Remove-AppxPackage

Write-Host $outputDir

Write-Host $buildScript

Invoke-Expression $buildScript

$appxManifestPath = $outputDir + "\AppxManifest.xml"

Add-AppxPackage -Register $appxManifestPath