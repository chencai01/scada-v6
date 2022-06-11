﻿/*
 * Copyright 2022 Rapid Software LLC
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 * 
 * Product  : Rapid SCADA
 * Module   : Communicator Service
 * Summary  : Service installer
 * 
 * Author   : Mikhail Shiryaev
 * Created  : 2016
 * Modified : 2022
 */

using Scada.Svc;
using System.ComponentModel;

namespace Scada.Comm.Svc
{
    /// <summary>
    /// Service installer.
    /// <para>Инсталлятор службы.</para>
    /// </summary>
    [RunInstaller(true)]
    public class SvcInstaller : SvcInstallerBase
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public SvcInstaller()
        {
            Init("ScadaCommService",
                "Rapid SCADA Communicator polls controllers and transmits data to the Server application.");
        }
    }
}
