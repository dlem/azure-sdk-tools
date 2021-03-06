﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    using System;
    using System.Management.Automation;
    using Model;
    using Model.PersistentVMModel;
    using Properties;

    [Cmdlet(VerbsCommon.Get, PublicIPNoun), OutputType(typeof(AssignPublicIP))]
    public class GetAzurePublicIPCommand : VirtualMachineConfigurationCmdletBase
    {
        [Parameter(Position = 1, HelpMessage = "The Public IP Name.")]
        [ValidateNotNullOrEmpty]
        public string PublicIPName { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var networkConfiguration = GetNetworkConfiguration();
            if (networkConfiguration == null)
            {
                throw new ArgumentOutOfRangeException(Resources.NetworkConfigurationNotFoundOnPersistentVM);
            }

            WriteObject(networkConfiguration.PublicIPs, true);
        }
    }
}
