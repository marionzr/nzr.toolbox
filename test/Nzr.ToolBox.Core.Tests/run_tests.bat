dotnet test --logger "trx;LogFileName=TestResults.trx" --logger "xunit;LogFileName=TestResults.xml" --results-directory ./BuildReports/UnitTests /p:CollectCoverage=true /p:CoverletOutput=BuildReports\Coverage\ /p:CoverletOutputFormat=opencover /p:Exclude=\"[xunit.*]*"
dotnet %USERPROFILE%\.nuget\packages\reportgenerator\4.3.2\tools\netcoreapp2.0\ReportGenerator.dll "-reports:BuildReports\Coverage\coverage.opencover.xml" "-targetdir:BuildReports\Coverage" -reporttypes:HTML;HTMLSummary

if not "%1"=="" goto end

start BuildReports\Coverage\index.htm
exit

:end