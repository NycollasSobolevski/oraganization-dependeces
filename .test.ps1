
$dirs = Get-ChildItem -Path ".\Model" -File

# Write-Host $dirs[0].Name
# $path = $dirs[0].DirectoryName + $dirs[0].Name
# $path = Join-Path -Path $dirs[0].DirectoryName -ChildPath $dirs[0].Name;
# Write-Host $path

Write-Host $dirs[1].FullName;

foreach ($file in $dirs) {
    if($file.BaseName -notlike "*Context*"){
        continue;
    }

    $content = Get-Content -Path $file.FullName

    $search_function = "modelBuilder.Entity"

    for ($i = 0; $i -lt $content.Count; $i++) {
        if ($content[$i].Contains()) {
            <# Action to perform if the condition is true #>
        }
    }

}