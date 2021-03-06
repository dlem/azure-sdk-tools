# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

$scriptFolder = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
. ($scriptFolder + '.\SetupEnv.ps1')

Remove-Item -Path "$env:AzurePSRoot\..\Package" -Force -Recurse

# Build the cmdlets in debug mode
msbuild "$env:AzurePSRoot\..\build.proj" /t:"BuildDebug"

# Regenerate the installer files
&"$env:AzurePSRoot\setup\generate.ps1" 'Debug'

# Build the installer
msbuild "$env:AzurePSRoot\..\build.proj" /t:"BuildSetupDebug"

Write-Verbose "MSI file path: $env:AzurePSRoot\setup\build\Debug\x86\windowsazure-powershell.msi"