
Set EncryptValues="oeMxVB+d6k2j6cnk4L7MHbcP62U5joMDtoajAxbvEu+K4IkW4u2+1J5R4o0j9GZ3vi0zEuwjOwVvydXpVsXQZA=="
Call  %~dp0EncryptDecryptValues.cmd Encrypt %EncryptValues% EncryptValues

Call  %~dp0EncryptDecryptValues.cmd Decrypt "%EncryptValues%" Decrypted
echo %Decrypted%



