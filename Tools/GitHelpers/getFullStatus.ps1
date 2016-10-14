function fullStatus($repo)
{
    Push-Location .\$repoPath
        
        $isGitRepo = Test-Path .git
        if($isGitRepo)
        {
            $gitStatus = (@(git status) | Out-String)
            
            $color = "red"
            
            if($gitStatus -like '*clean*')
            {
                $color = "green"
            }
            
            echo ----------------------------------------------
            Write-Host "Status of" $repoPath  "repo..."
            echo ----------------------------------------------    
            
            Write-Host $gitStatus -foregroundcolor $color  
        }
        Pop-Location
}


#Pulls all repos if there are no arguments
if($args.Length -eq 0)
{
    $modules = Get-ChildItem

    Foreach($repo in $modules)
    {
        if($repo.PSIsContainer)
        {
            $repoPath = $repo
            fullStatus($repoPath)
        }
    }
}
else
{
    $modules = $args
    Foreach($repo in $modules)
    {
        $repoPath = "Columbus-" + $repo
        fullStatus($repoPath)
    }
}
