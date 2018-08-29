﻿using System;
using System.Reflection;
using Telerik.JustMock.Core;
using Telerik.JustMock.Expectations.Abstraction.Local;
using Telerik.JustMock.Expectations.Abstraction.Local.Function;

namespace Telerik.JustMock.Expectations
{
	internal sealed class FunctionExpectation : IFunctionExpectation
	{
		public ActionExpectation Arrange(object target, string methodName, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type[] emptyParamTypes = new Type[] { };
				return this.Arrange(target, methodName, emptyParamTypes, localFunctionName, args);
			});
		}

		public ActionExpectation Arrange(object target, string methodName, Type[] memberParamTypes, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				MethodInfo method = MockingUtil.GetMethodWithLocalFunction(target, methodName, memberParamTypes);
				return this.Arrange(target, method, localFunctionName, args);
			});
		}

		public ActionExpectation Arrange(object target, MethodInfo method, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				MethodInfo localMethod = MockingUtil.GetLocalFunction(target, method, localFunctionName);
				return Mock.NonPublic.Arrange(target, localMethod, args);
			});
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(object target, string methodName, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type[] emptyParamTypes = new Type[] { };
				return this.Arrange<TReturn>(target, methodName, emptyParamTypes, localFunctionName, args);
			});
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(object target, string methodName, Type[] memberParamTypes, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				MethodInfo method = MockingUtil.GetMethodWithLocalFunction(target, methodName, memberParamTypes);
				return this.Arrange<TReturn>(target, method, localFunctionName, args);
			});
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(object target, MethodInfo method, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = target.GetType();
				MethodInfo localMethod = MockingUtil.GetLocalFunction(type, method, localFunctionName);

				return Mock.NonPublic.Arrange<TReturn>(target, localMethod, args);
			});
		}
		
		public FuncExpectation<TReturn> Arrange<T, TReturn>(string methodName, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = typeof(T);
				return this.Arrange<TReturn>(type, methodName, localFunctionName, args);
			});
		}
		
		public FuncExpectation<TReturn> Arrange<T, TReturn>(string methodName, Type[] methodParamTypes, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = typeof(T);
				return this.Arrange<TReturn>(type, methodName, methodParamTypes, localFunctionName, args);
			});
		}

		public FuncExpectation<TReturn> Arrange<T, TReturn>(MethodInfo method, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = typeof(T);
				return this.Arrange<TReturn>(type, method, localFunctionName, args);
			});
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(Type type, string methodName, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type[] emptyParamTypes = new Type[] { };
				return this.Arrange<TReturn>(type, methodName, emptyParamTypes, localFunctionName, args);
			});
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(Type type, string methodName, Type[] methodParamTypes, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				MethodInfo method = MockingUtil.GetMethodWithLocalFunction(type, methodName, methodParamTypes);
				return this.Arrange<TReturn>(type, method, localFunctionName, args);
			});
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(Type type, MethodInfo method, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				MethodInfo localMethod = MockingUtil.GetLocalFunction(type, method, localFunctionName);
				return Mock.NonPublic.Arrange<TReturn>(type, localMethod, args);
			});
		}
		
		public ActionExpectation Arrange<T>(string methodName, string localMemberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = typeof(T);
				return this.Arrange(type, methodName, localMemberName, args);
			});
		}

		public ActionExpectation Arrange<T>(string methodName, Type[] methodParamTypes, string localMemberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = typeof(T);
				return this.Arrange(type, methodName, methodParamTypes, localMemberName, args);
			});
		}

		public ActionExpectation Arrange<T>(MethodInfo method, string localMemberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = typeof(T);
				return this.Arrange(type, method, localMemberName, args);
			});
		}

		public ActionExpectation Arrange(Type type, string methodName, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type[] emptyParamTypes = new Type[] { };
				return this.Arrange(type, methodName, emptyParamTypes, localFunctionName, args);
			});
		}

		public ActionExpectation Arrange(Type type, string methodName, Type[] methodParamTypes, string localMemberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				MethodInfo method = MockingUtil.GetMethodWithLocalFunction(type, methodName, methodParamTypes);
				return this.Arrange(type, method, localMemberName, args);
			});
		}

		public ActionExpectation Arrange(Type type, MethodInfo method, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				MethodInfo localFunction = MockingUtil.GetLocalFunction(type, method, localFunctionName);
				return Mock.NonPublic.Arrange(type, method, localFunction, args);
			});
		}

		public object Call(object target, string methodName, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = target.GetType();
				MethodInfo method = MockingUtil.GetMethodWithLocalFunction(target, methodName);
				MethodInfo localFunction = MockingUtil.GetLocalFunction(type, method, localFunctionName);

				return Mock.NonPublic.MakePrivateAccessor(target).CallMethod(localFunction, args);
			});
		}

		public T Call<T>(object target, string methodName, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type[] emptyParamTypes = new Type[] { };
				var resObject = this.Call(target, methodName, emptyParamTypes, localFunctionName, args);
				T res = (T)resObject;
				return res;
			});
		}

		public object Call(object target, string methodName, Type[] methodParamTypes, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = target.GetType();
				MethodInfo method = MockingUtil.GetMethodWithLocalFunction(target, methodName, methodParamTypes);
				MethodInfo localFunction = MockingUtil.GetLocalFunction(type, method, localFunctionName);

				return Mock.NonPublic.MakePrivateAccessor(target).CallMethod(localFunction, args);
			});
		}

		public T Call<T>(object target, string methodName, Type[] methodParamTypes, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				var resObject = this.Call(target, methodName, methodParamTypes, localFunctionName, args);
				T res = (T)resObject;
				return res;
			});
		}

		public object Call(object target, MethodInfo method, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = target.GetType();
				MethodInfo localFunction = MockingUtil.GetLocalFunction(type, method, localFunctionName);
				return Mock.NonPublic.MakePrivateAccessor(target).CallMethod(localFunction, args);
			});
		}

		public T Call<T>(object target, MethodInfo method, string localFunctionName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				var resObject = this.Call(target, method, localFunctionName, args);
				T res = (T)resObject;
				return res;
			});
		}

		public void Assert(object target, MethodInfo method, string localFunctionName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = target.GetType();
				MethodInfo localFunction = MockingUtil.GetLocalFunction(type, method, localFunctionName);

				Mock.NonPublic.Assert(target, localFunction, args);
			});
		}

		public void Assert(object target, string methodName, string localFunctionName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
			{
				Type[] emptyParamTypes = new Type[] { };
				this.Assert(target, methodName, emptyParamTypes, localFunctionName, args);
			});
		}

		public void Assert(object target, string methodName, Type[] methodParamTypes, string localFunctionName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
			{
				MethodInfo method = MockingUtil.GetMethodWithLocalFunction(target, methodName, methodParamTypes);
				this.Assert(target, method, localFunctionName, args);
			});
		}

		public void Assert(object target, MethodInfo method, string localFunctionName, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
			{
				Type type = target.GetType();
				MethodInfo localFunction = MockingUtil.GetLocalFunction(type, method, localFunctionName);

				Mock.NonPublic.Assert(target, localFunction, occurs, args);
			});
		}

		public void Assert(object target, string methodName, string localFunctionName, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
			{
				Type[] emptyParamTypes = new Type[] { };
				this.Assert(target, methodName, emptyParamTypes, localFunctionName, occurs, args);
			});
		}

		public void Assert(object target, string methodName, Type[] methodParamTypes, string localFunctionName, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
			{
				MethodInfo method = MockingUtil.GetMethodWithLocalFunction(target, methodName, methodParamTypes);

				this.Assert(target, method, localFunctionName, occurs, args);
			});
		}
	}
}