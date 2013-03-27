;//---------------------------------------------
;    Weavver Installer
;    Author: Mitchel Constantin (Weavver, Inc.)
;    Email: mythicalbox@weavver.com
;//---------------------------------------------

     !include "MUI2.nsh"
     !include "ZipDLL.nsh"
     !include x64.nsh

     Name "Weavver Alpha"
     OutFile "Weavver-Alpha-Installer.exe"
     RequestExecutionLevel admin

     InstallDir "$PROGRAMFILES\Weavver\Core\"

     ;Get installation folder from registry if available
     InstallDirRegKey HKCU "Software\Weavver\Core" ""

     ;Request application privileges for Windows Vista
     RequestExecutionLevel user

     !define MUI_ABORTWARNING
;//---------------------------------------------
;Pages

     !insertmacro MUI_PAGE_LICENSE "License.txt"
     !insertmacro MUI_PAGE_COMPONENTS
     !insertmacro MUI_PAGE_DIRECTORY
     !insertmacro MUI_PAGE_INSTFILES

     !insertmacro MUI_UNPAGE_CONFIRM
     !insertmacro MUI_UNPAGE_INSTFILES

     !define MUI_FINISHPAGE_RUN "$INSTDIR\bin\Weavver.exe"
     !define MUI_FINISHPAGE_RUN_TEXT "Launch Weavver"
     !insertmacro MUI_PAGE_FINISH
;//---------------------------------------------
;Languages
 
     !insertmacro MUI_LANGUAGE "English"
;//--------------------------------------------------------------------------------------------
; Installer OnInit
     Function .onInit
          ${If} ${RunningX64}
               ;${DisableX64FSRedirection}
               ;SetRegView 64
               ;StrCpy $INSTDIR "$PROGRAMFILES64\Weavver\Core"
          ${EndIf}

          ; Set mutexes
          System::Call 'kernel32::CreateMutexA(i 0, i 0, t "WeavverInstaller") i .r1 ?e'
          Pop $R0
          StrCmp $R0 0 +3
               MessageBox MB_OK|MB_ICONEXCLAMATION "The installer is already running."
               Abort

          System::Call 'kernel32::CreateMutexA(i 0, i 0, t "WeavverUninstaller") i .r1 ?e'
          Pop $R0
          StrCmp $R0 0 +3
               MessageBox MB_OK|MB_ICONEXCLAMATION "The uninstaller is already running on your computer. Please use the other instance instead."
               Abort

     FunctionEnd
;//---------------------------------------------
;Core
     Section "Core" Core
          SetOutPath "$INSTDIR"
          ;File test.txt

          !include "File_Install.nsh"

          ; !insertmacro ZIPDLL_EXTRACT "$TEMP\couchdb-win32-bin.zip" "$INSTDIR" "<ALL>"

          ;Store installation folder
          WriteRegStr HKCU "Software\Weavver\Core" "" $INSTDIR

          Push $INSTDIR
          Push "\"
          Push "\\"
          Call StrRep
          Pop "$R0" ;result

          WriteINIStr $INSTDIR\vendors\Apache\couchdb\bin\erl.ini erlang Bindir "$R0\\vendors\\Apache\\couchdb\\erts-5.7.2\\bin\\"
          WriteINIStr $INSTDIR\vendors\Apache\couchdb\bin\erl.ini erlang Rootdir "$R0\\vendors\\Apache\\couchdb\\"
          WriteINIStr $INSTDIR\vendors\Apache\couchdb\bin\erl.ini erlang Progname "Weavver Database"

          ;Create uninstaller
          WriteUninstaller "$INSTDIR\Uninstall.exe"
          
          CreateShortCut "$SMPROGRAMS\Weavver.lnk" "$INSTDIR\\Bin\\Weavver.exe"
     SectionEnd
;//---------------------------------------------
;Erlang
     Section "Erlang" Erlang

       SetOutPath "$INSTDIR"

     SectionEnd
;//---------------------------------------------
;Descriptions

     ;Language strings
     LangString DESC_Core ${LANG_ENGLISH} "Installs the Weavver Core framework."

     ;Assign language strings to sections
     !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
     !insertmacro MUI_DESCRIPTION_TEXT ${Core} $(DESC_Core)
     !insertmacro MUI_FUNCTION_DESCRIPTION_END

;//---------------------------------------------
;Uninstaller Section

     Section "Uninstall"
          Delete "$INSTDIR\vendors\Apache\couchdb\bin\erl.ini"
          !include "File_Uninstall.nsh"

          Delete "$INSTDIR\Uninstall.exe"
          RMDir "$INSTDIR"

          ;DeleteRegKey /ifempty HKCU "Software\Weavver\Core"

     SectionEnd
;//---------------------------------------------

Function StrRep
     Exch $R4 ; $R4 = Replacement String
     Exch
     Exch $R3 ; $R3 = String to replace (needle)
     Exch 2
     Exch $R1 ; $R1 = String to do replacement in (haystack)
     Push $R2 ; Replaced haystack
     Push $R5 ; Len (needle)
     Push $R6 ; len (haystack)
     Push $R7 ; Scratch reg
     StrCpy $R2 ""
     StrLen $R5 $R3
     StrLen $R6 $R1
     loop:
          StrCpy $R7 $R1 $R5
          StrCmp $R7 $R3 found
          StrCpy $R7 $R1 1 ; - optimization can be removed if U know len needle=1
          StrCpy $R2 "$R2$R7"
          StrCpy $R1 $R1 $R6 1
          StrCmp $R1 "" done loop
     found:
          StrCpy $R2 "$R2$R4"
          StrCpy $R1 $R1 $R6 $R5
          StrCmp $R1 "" done loop
     done:
          StrCpy $R3 $R2
          Pop $R7
          Pop $R6
          Pop $R5
          Pop $R2
          Pop $R1
          Pop $R4
          Exch $R3
FunctionEnd

;//---------------------------------------------