$PersonalAccessToken = $args[0]
$curPath = $PSScriptRoot
# TODO: Replace the path with the path to your VSIX file
$VsixPath = "${curPath}\..\Source\TemplatesVsix\CognibaseTemplates\bin\Release\CognibaseTemplates.vsix"
$ManifestPath = "${curPath}\..\Assets\publishManifest.json"

# Find the location of VsixPublisher
$Installation = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" -latest -prerelease -format json | ConvertFrom-Json
$Path = $Installation.installationPath

Write-Host $Path
$VsixPublisher = Join-Path -Path $Path -ChildPath "VSSDK\VisualStudioIntegration\Tools\Bin\VsixPublisher.exe" -Resolve

Write-Host $VsixPublisher
Try {

	# Publish to VSIX to the marketplace
	& $VsixPublisher publish -payload $VsixPath -publishManifest $ManifestPath -personalAccessToken $PersonalAccessToken -ignoreWarnings "VSIXValidatorWarning01,VSIXValidatorWarning02,VSIXValidatorWarning08"
}
Catch {
    # Logging the error to a file
    Write-host -f foregroundcolor red "Encountered Error:"$_.Exception.Message
}

