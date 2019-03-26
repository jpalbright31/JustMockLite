﻿/*
 JustMock Lite
 Copyright © 2010-2015,2019 Progress Software Corporation

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.JustMock.Core.Context
{
    internal abstract class MockingContextResolverBase : IMockingContextResolver
    {
        private readonly string assertFailedExceptionTypeName;
        protected readonly object repositorySync = new object();

        public MockingContextResolverBase(string assertFailedExceptionTypeName, params string[] frameworkAssemblyNames)
        {
            this.assertFailedExceptionTypeName = assertFailedExceptionTypeName;
        }

        public abstract MocksRepository ResolveRepository(UnresolvedContextBehavior unresolvedContextBehavior);

        public abstract bool RetireRepository();

        public Action<string, Exception> GetFailMethod()
        {
            return LocalMockingContextResolver.GetFailMethod(Type.GetType(this.assertFailedExceptionTypeName));
        }

        protected static Type FindType(string assemblyAndTypeName, bool throwOnNotFound)
        {
            return Type.GetType(assemblyAndTypeName, throwOnNotFound);
        }
    }
}
