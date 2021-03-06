; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{5360E911-BAAF-4568-BA85-34960C411777}
AppName=CSToolkit
AppVersion=1.3
;AppVerName=CSToolkit 1.3
AppPublisher=OOO, Inc.
AppPublisherURL=http://www.example.com/
AppSupportURL=http://www.example.com/
AppUpdatesURL=http://www.example.com/
DefaultDirName={pf}\CSToolkit
DefaultGroupName=CSToolkit
LicenseFile=license.txt
InfoBeforeFile=before.txt
InfoAfterFile=after.txt
OutputBaseFilename=setup
SetupIconFile=B:\Repos\CSToolkit\CSToolkit\Resources\cws_icon.ico
Compression=lzma
SolidCompression=yes

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "B:\Repos\CSToolkit\CSToolkit\bin\Debug\CSToolkit.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "B:\Repos\CSToolkit\CSToolkit\bin\Debug\bin\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs  
Source: "B:\Repos\CSToolkit\packages\WpfAnimatedGif.1.4.14\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\CSToolkit"; Filename: "{app}\CSToolkit.exe"
Name: "{commondesktop}\CSToolkit"; Filename: "{app}\CSToolkit.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\CSToolkit.exe"; Description: "{cm:LaunchProgram,CSToolkit}"; Flags: nowait postinstall skipifsilent
