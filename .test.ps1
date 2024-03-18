
$dirs = Get-ChildItem -Path ".\Model" -File

# Write-Host $dirs[0].Name
# $path = $dirs[0].DirectoryName + $dirs[0].Name
# $path = Join-Path -Path $dirs[0].DirectoryName -ChildPath $dirs[0].Name;
# Write-Host $path

$dirs = Get-ChildItem -Path ".\Model" -File
$ignorated = @();
$index_of_ignorated = 0;
$base_namespace = "";

if($args -contains "--basenamespace") {
    $index_namespace = [array]::IndexOf($args, "--basenamespace");
    $base_namespace = $args[$index_namespace + 1];
}

if ($args -contains "--ignore") {
    $index_of_ignorated = [array]::IndexOf($args, "--ignore")
    for ($i = $index_of_ignorated + 1; $i -lt ($args.Count); $i++) {
        if ($args[$i].Contains("-")) {
            break
        }
        $ignorated += $args[$i];
    }
}

for ($i = 0; $i -lt $dirs.Count; $i++) {
    $file = $dirs[$i];
    
    $path = Join-Path -Path $file.DirectoryName -ChildPath $file.Name;
    $content = Get-Content -Path $path
    if($base_namespace -ne "") {
        for($line = 0; $line -lt $content.Count; $line++) {
            if($content[$line].Contains("namespace")) {
                $content[$line] = "namespace " + $base_namespace + ".Domain.Model;";
            }
        }
    }

    Write-Host $content

}
