net stop w3svc
del HTMLPurifier.dll
del ..\..\Bin\HTMLPurifier.dll
"C:\Program Files (x86)\Phalanger 3.0\Bin\phpc.exe" /target:dll /out:HTMLPurifier.dll Library.php

copy HTMLPurifier.dll ..\..\Bin\HTMLPurifier.dll /Y
net start w3svc