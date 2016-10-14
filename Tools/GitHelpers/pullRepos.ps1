function pullRepos($repoPath)
{
    Push-Location .\$repoPath

    $isGitRepo = Test-Path .git
    if($isGitRepo)
    {
        echo ----------------------------------------------
        Write-Host "Pulling the" $repoPath  "repo..."
        echo ----------------------------------------------    
        $uncommittedStatus = (@(git status --porcelain) | Out-String)
        
        
        $pullStatus = (@(git pull 2>&1) | Out-String)
        $uncommittedChanges = [string]::IsNullOrEmpty($gitStatus)
        $pullChanges = $pullStatus -like '*aborting*'
        
        if ($pullChanges)
        {
            Write-Host $repoPath " -  is not pulled because you have uncommitted changes" -foregroundcolor "red"               
        }
        else
        {
            if($uncommittedStatus)
            {
                Write-Host $repoPath  " - has been pulled, but you have uncommitted changes. You will have to commit before pushing" -foregroundcolor "Yellow"
            }
            else
            {
                Write-Host $repoPath  " - has been pulled" -foregroundcolor "green"
            }
        }
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
           pullRepos($repoPath)
        }
    }
}

else
{
   $modules = $args
   Foreach($repo in $modules)
   {
         $repoPath = "Columbus-" + $repo
         pullRepos($repoPath)
               
   }
}



