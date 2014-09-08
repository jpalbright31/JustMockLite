﻿// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Telerik.JustMock.Core.Castle.DynamicProxy.Generators
{
	using System;
	using System.Reflection;

	internal class DelegateProxyGenerationHook : IProxyGenerationHook
	{
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			return obj.GetType() == typeof(DelegateProxyGenerationHook);
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode();
		}

		public void MethodsInspected()
		{
		}

		public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
		{
		}

		public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
		{
			return methodInfo.Name.Equals("Invoke");
		}
	}
}