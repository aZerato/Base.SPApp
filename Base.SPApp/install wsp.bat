@ECHO OFF

SET STSADM="C:\Program Files\Common Files\Microsoft Shared\web server extensions\12\BIN\stsadm"
SET URL="http://dev-baseapp"
SET WSP_OLD="Base.SPApp.wsp"
SET WSP_NEW="Base.SPApp.wsp"

ECHO Retracting Solution to %URL%...

%STSADM% -o retractsolution -name %WSP_OLD% -immediate -url %URL%
%STSADM% -o execadmsvcjobs

ECHO - Solution retracted (%URL%)...
ECHO.
ECHO Deleting solution...

%STSADM% -o deletesolution -name %WSP_OLD% 

ECHO - Solution deleted
ECHO.
ECHO Adding the new solution to solution store...

%STSADM% -o addsolution -filename %WSP_NEW%

ECHO - New solution added to solution store
ECHO.
ECHO Deploying new solution to %URL%...

%STSADM% -o deploysolution -name %WSP_NEW%  -immediate -allowGACdeployment -allowCASPolicies -url %URL% -force
%STSADM% -o execadmsvcjobs

ECHO - New solution deployed (%URL%)
pause