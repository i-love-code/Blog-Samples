If(1 -eq $(gci -file -filter *.sln).count) 
{ 
    gci -Directory | foreach { gci -path $_ -Directory } | where { $_.Name.EndsWith("bin") -or $_.Name.EndsWith("obj") } | foreach { Remove-Item -path $_.FullName -rec -force; Write-Host Clearing $_.FullName ... } 

    gci -path ./Components -Directory | gci -Directory | foreach { gci -path $_.FullName -Directory } | where { $_.Name.EndsWith("bin") -or $_.Name.EndsWith("obj") } | foreach { Remove-Item -path $_.FullName -rec -force; Write-Host Clearing $_.FullName ... }
} 
Else
{
    Write-Host No solution file found in this folder. Preventing this for safety. 
}