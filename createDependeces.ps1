$dirs = Get-ChildItem -Path ".\Model" -File
$ignorated = @();
$index_of_ignorated = 0

if ($args -contains "--ignore") {
    $index_of_ignorated = [array]::IndexOf($args, "--ignore")
    for ($i = $index_of_ignorated + 1; $i -lt ($args.Count); $i++) {
        $ignorated += $args[$i];
    }
}

foreach ($file in $dirs) {

    if ($ignorated -contains $file) {
        Write-Host "$file ignorated"
        continue  
    }

    
    # ======================= creating Domain dependences =======================

    $domain_path      = Join-Path -Path "./Domain/" -ChildPath $file;
    $model_path       = Join-Path -Path $domain_path -ChildPath "Models";
    $repositorie_path = Join-Path -Path $domain_path -ChildPath "Repositories";
    $service_path     = Join-Path -Path $domain_path -ChildPath "Services";
    
    mkdir $model_path ;
    mkdir $repositorie_path ;
    mkdir $service_path;
    
    $model_content = "//! Implements Model here!";
    $model_content | Out-File -FilePath "$model_path/Model.cs";

    $repository_content = "//! Implements IRepository here!";
    $repository_content | Out-File -FilePath "$repositorie_path/IRepository.cs";
    
    $service_content = "//! Implements Iservice here! ";
    $service_content | Out-File -FilePath "$service_path/IService.cs";



    # ======================= creating Core dependences =======================

    $core_path      = Join-Path -Path "./Core/" -ChildPath $file;
    $map_path       = Join-Path -Path $core_path -ChildPath "Mapping";
    $classmap_filename = $file + "ClassMap.cs";
    $map_path       = Join-Path -Path $map_path -ChildPath $classmap_filename;
    $repositorie_path = Join-Path -Path $core_path -ChildPath "Repository";
    $service_path     = Join-Path -Path $core_path -ChildPath "Service";
    
    mkdir $map_path ;
    mkdir $repositorie_path ;
    mkdir $service_path;
    
    $classmap_content = "//! Implements classMapping here!";
    $classmap_content | Out-File -FilePath $map_path;

    $repository_content = "//! Implements $file Repository here!";
    $repository_content | Out-File -FilePath "$repositorie_path/Repository.cs";
    
    $service_content = "//! Implements $file Service here!";
    $service_content | Out-File -FilePath "$service_path/Service.cs";


}