function status($repo)
{
    Push-Location .\$repo
    $isGitRepo = Test-Path .git
      
    if($isGitRepo)
    {
        $repoPath = $repo
           
        $gitStatus = (@(git status --porcelain) | Out-String)

        $message = " - has uncommitted changes"
        $color = "red"

        if(-not$gitStatus)
        {
            $message = " - is clean"
            $color = "green"
        }

             
        Write-Host $repoPath $message -foregroundcolor $color          
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
           status($repo)
        }
    }
}

else
{
    $modules = $args
    Foreach($repo in $modules)
    {
        $repoPath = "Columbus-" + $repo
        status($repoPath)
    }
}
