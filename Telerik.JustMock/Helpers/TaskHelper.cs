﻿/*
 JustMock Lite
 Copyright © 2010-2015 Telerik AD

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

using System.Threading.Tasks;
using Telerik.JustMock.Core;
using Telerik.JustMock.Expectations.Abstraction;

namespace Telerik.JustMock
{
	public static class TaskHelper
	{
		public static IAssertable TaskResult<T>(this IFunc<Task<T>> expectation, T result)
		{
			return ProfilerInterceptor.GuardInternal(() => expectation.Returns(MockingUtil.TaskFromResult(result)));
		}
	}
}
