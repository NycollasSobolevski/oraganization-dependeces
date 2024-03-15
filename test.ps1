foreach ($arg in $args) {
    <# $arg is the current item #>
}

$ignore = "--ignore" 
$index = 0
if ($args -contains $ignore) {
    $index = [array]::IndexOf($args, $ignore)
    
}
Write-Host "ignore "$args[$index + 1]