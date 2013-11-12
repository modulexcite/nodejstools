﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System.Collections.Generic;
using System.Text;

namespace Microsoft.NodejsTools.Npm.SPI{
    internal class NpmUpdateCommand : NpmCommand{
        public NpmUpdateCommand(string fullPathToRootPackageDirectory, string pathToNpm = null)
            : this(fullPathToRootPackageDirectory, new List<IPackage>(), pathToNpm){}

        public NpmUpdateCommand(
            string fullPathToRootPackageDirectory,
            IEnumerable<IPackage> packages,
            string pathToNpm = null) : base(fullPathToRootPackageDirectory, pathToNpm){
            var buff = new StringBuilder("update");
            foreach (var package in packages){
                buff.Append(' ');
                buff.Append(package.Name);
            }
            buff.Append(" --save");
            Arguments = buff.ToString();
        }
    }
}