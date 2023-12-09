# Use the current directory as the root directory of the C# solution
$solutionDir = Get-Location

# Define the output file
$outputFile = "$solutionDir\CombinedFiles.txt"

# Delete the output file if it already exists
if (Test-Path $outputFile) {
    Remove-Item $outputFile
}

# Function to handle each path
function Process-Path {
    param ($path)

    # Check if it's a directory
    if (Test-Path "$solutionDir\$path" -PathType Container) {
        Add-Content -Path $outputFile -Value "===== DIRECTORY: $path =====`r`n"
    }
    # Handle different file types
    elseif ($path -match "\.cs$") {
        # Write .cs file with content
        Add-Content -Path $outputFile -Value "===== BEGIN FILE: $path =====`r`n"
        Get-Content "$solutionDir\$path" | ForEach-Object { "    $_" } | Add-Content $outputFile
        Add-Content -Path $outputFile -Value "===== END FILE: $path =====`r`n`r`n"
    }
    elseif ($path -match "\.(sln|csproj)$") {
        # Write .sln and .csproj files without content
        Add-Content -Path $outputFile -Value "===== FILE: $path =====`r`n"
    }
}

# Use Git to list files and directories not ignored by .gitignore
$gitList = git -C $solutionDir ls-files --full-name --ignored --exclude-standard --others
$gitList += git -C $solutionDir ls-files --full-name

# Process each path
$gitList | Sort-Object -Unique | ForEach-Object { Process-Path $_ }

Write-Host "All directories and files have been listed in $outputFile"
