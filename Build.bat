
xcopy "src" "build/www" /I /E /Y /EXCLUDE:Build.exclude
xcopy "vendors" "build/www/vendors" /I /E /Y /EXCLUDE:Build.exclude
xcopy "vendors/weavver/browserphone/build" "build/www/vendors/weavver/browserphone/build" /I /E /Y /EXCLUDE:Build.exclude
xcopy "src" "build/www" /I /E /Y /EXCLUDE:Build.exclude

mkdir "build/database"
xcopy "vendors\weavver\data\database\bin\Debug" "build\database" /I /E /Y
