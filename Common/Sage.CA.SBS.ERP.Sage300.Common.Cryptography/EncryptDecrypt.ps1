# Find the path of current script directory
$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition

Add-Type -Path "$PSScriptRoot\Sage.CA.SBS.ERP.Sage300.Common.Cryptography.dll"
[Reflection.Assembly]::LoadWithPartialName("Sage.CA.SBS.ERP.Sage300.Common.Cryptography")

#This Function Will Encrypt  the values supplied
function Encrypt ($Value,$Thumbprint)
{
 try
    {
      $Cryptography= New-Object "Sage.CA.SBS.ERP.Sage300.Common.Cryptography.CertificateCryptography" $Thumbprint;
	  $EncryptedValue= $Cryptography.Encrypt($Value);        
       return $EncryptedValue;
	  }
    catch
    {
        #Log the problem ($_ contains the exception) and exit with a non-zero code
          $_ | Format-List * -Force | Out-String | Write-Error -ErrorAction Continue
         exit 1
    }
	}

#This Function Will Decrypt the values supplied
function Decrypt ($Value,$Thumbprint)
{
 try
    {    
	   $Cryptography= New-Object "Sage.CA.SBS.ERP.Sage300.Common.Cryptography.CertificateCryptography" $Thumbprint;
	   $DecryptedValue= $Cryptography.Decrypt($Value);    
      return $DecryptedValue;
	  }
    catch
    {
        #Log the problem ($_ contains the exception) and exit with a non-zero code
          $_ | Format-List * -Force | Out-String | Write-Error -ErrorAction Continue
         exit 1
    }
	}

