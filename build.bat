::@echo Off

echo start custom build

set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)

echo building solution
"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" AssemblySoft.ProcessRunner.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

echo creating nuget packages
mkdir Build
call %nuget% pack "AssemblySoft.ProcessRunner\AssemblySoft.ProcessRunner.csproj" -IncludeReferencedProjects -verbosity detailed -o Build -p Configuration=%config% %version%

echo complete custom build
