$dirs = Get-ChildItem -Path ".\Model" -File
$ignorated 
$index_of_ignorated = 0

if ($args -contains "--ignore") {
    $index_of_ignorated = [array]::IndexOf($args, "--ignore")
}

foreach ($file in $dirs) {

    if($index_of_ignorated -gt 0) {
        if( $file -eq $ignorated ) {
            continue;
        }
    }
    
    # ======================= creating Domain dependences =======================

    $domain_path      = Join-Path -Path "./Domain/" -ChildPath $file;
    $model_path       = Join-Path -Path $domain_path -ChildPath "Models";
    $repositorie_path = Join-Path -Path $domain_path -ChildPath "Repositories";
    $service_path     = Join-Path -Path $domain_path -ChildPath "Services";
    
    mkdir $model_path ;
    mkdir $repositorie_path ;
    mkdir $service_path;
    
    $repository_content = "//! Implements IRepository here!";
    $repository_content | Out-File -FilePath "$repositorie_path/IRepository.cs";
    
    $service_content = "//! Implements Iservice here! ";
    $service_content | Out-File -FilePath "$service_path/IService.cs";



    # ======================= creating Core dependences =======================

    $core_path      = Join-Path -Path "./Core/" -ChildPath $file;
    $map_path       = Join-Path -Path $core_path -ChildPath "Mapping";
    $repositorie_path = Join-Path -Path $core_path -ChildPath "Repository";
    $service_path     = Join-Path -Path $core_path -ChildPath "Service";
    
    mkdir $map_path ;
    mkdir $repositorie_path ;
    mkdir $service_path;
    
    $classmap_content = "//! Implements classMapping here!";
    $classmap_content | Out-File -FilePath "$map_path/$file" + "ClassMap.cs"

    $repository_content = "Implements $file"+"Repository here!";
    $repository_content | Out-File -FilePath "$repositorie_path/Repository.cs";
    
    $service_content = "//!Implements $file" + "Service here!";
    $service_content | Out-File -FilePath "$service_path/Service.cs";


}