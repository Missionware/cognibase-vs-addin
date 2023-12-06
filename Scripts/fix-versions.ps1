$version = $args[0]
$curPath = $PSScriptRoot
$pkdDefPath = "${curPath}\..\Source\TemplatesVsix\CognibaseTemplates\Templates.pkgdef"
$vxManPath = "${curPath}\..\Source\TemplatesVsix\CognibaseTemplates\source.extension.vsixmanifest"

"The current path is: ${curPath}"
"The version is: ${version}"

$pkgdefStr = "[$RootKey$\TemplateEngine\Templates\missionware.cognibase.templates.nuspec\${version}]""`r`nInstalledPath""=""$PackageFolder$\ProjectTemplates"""

Set-Content -Encoding UTF8 $pkdDefPath $pkgdefStr

Write-Host "File " + $pkdDefPath + " was written"

# read xml content
$file2Xml = [xml](Get-Content $vxManPath)

# Locate tag
$identityNode = $file2Xml.SelectSingleNode("//Identity")

# Overwrite value
$identityNode.SetAttribute("Version", $version);

# write
$file2Xml.Save($vxManPath)

Write-Host "File " + $vxManPath + " was written"