/*
 JustMock Lite
 Copyright © 2010-2015 Telerik EAD

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
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Telerik.JustMock.Core;
using Telerik.JustMock.Core.Behaviors;
using Telerik.JustMock.Core.Context;
using Telerik.JustMock.Expectations.Abstraction;
using Telerik.JustMock.Expectations.DynaMock;

namespace Telerik.JustMock.Expectations
{
	internal sealed class NonPublicExpectation : INonPublicExpectation
	{
		private readonly NonPublicRefReturnExpectation refExpectation = new NonPublicRefReturnExpectation();

		public ActionExpectation Arrange(object target, string memberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				{
					var type = target.GetType();
					var mixin = MocksRepository.GetMockMixin(target, null);
					if (mixin != null)
						type = mixin.DeclaringType;

					var method = MockingUtil.GetMethodByName(type, typeof(void), memberName, ref args);
					return MockingContext.CurrentRepository.Arrange(target, method, args, () => new ActionExpectation());
				});
		}

		public ActionExpectation Arrange(object target, MethodInfo method, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() => MockingContext.CurrentRepository.Arrange(target, method, args, () => new ActionExpectation()));
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(object target, string memberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				{
					var type = target.GetType();
					var mixin = MocksRepository.GetMockMixin(target, null);
					if (mixin != null)
						type = mixin.DeclaringType;

					var method = MockingUtil.GetMethodByName(type, typeof(TReturn), memberName, ref args);
					return MockingContext.CurrentRepository.Arrange(target, method, args, () => new FuncExpectation<TReturn>());
				});
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(object target, MethodInfo method, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() => MockingContext.CurrentRepository.Arrange(target, method, args, () => new FuncExpectation<TReturn>()));
		}

		public void Assert<TReturn>(object target, string memberName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var type = target.GetType();
					var mixin = MocksRepository.GetMockMixin(target, null);
					if (mixin != null)
						type = mixin.DeclaringType;

					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(type, typeof(TReturn), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, target, method, args, null);
				});
		}

		public void Assert(object target, MethodInfo method, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, target, method, args, null);
				});
		}

		public void Assert(object target, string memberName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var type = target.GetType();
					var mixin = MocksRepository.GetMockMixin(target, null);
					if (mixin != null)
						type = mixin.DeclaringType;

					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(type, typeof(void), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, target, method, args, null);
				});
		}

		public void Assert<TReturn>(object target, string memberName, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var type = target.GetType();
					var mixin = MocksRepository.GetMockMixin(target, null);
					if (mixin != null)
						type = mixin.DeclaringType;

					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(type, typeof(TReturn), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, target, method, args, occurs);
				});
		}

		public void Assert(object target, MethodInfo method, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, target, method, args, occurs);
				});
		}

		public void Assert(object target, string memberName, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var type = target.GetType();
					var mixin = MocksRepository.GetMockMixin(target, null);
					if (mixin != null)
						type = mixin.DeclaringType;

					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(type, typeof(void), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, target, method, args, occurs);
				});
		}

		public int GetTimesCalled(object target, MethodInfo method, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				MockingContext.CurrentRepository.GetTimesCalledFromMethodInfo(target, method, args));
		}

		public int GetTimesCalled(object target, string memberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				var type = target.GetType();
				var mixin = MocksRepository.GetMockMixin(target, null);
				if (mixin != null)
					type = mixin.DeclaringType;

				var method = MockingUtil.GetMethodByName(type, typeof(void), memberName, ref args);
				return MockingContext.CurrentRepository.GetTimesCalledFromMethodInfo(target, method, args);
			});
		}

#if !LITE_EDITION

		public FuncExpectation<TReturn> Arrange<T, TReturn>(string memberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				{
					var method = MockingUtil.GetMethodByName(typeof(T), typeof(TReturn), memberName, ref args);
					return MockingContext.CurrentRepository.Arrange(null, method, args, () => new FuncExpectation<TReturn>());
				});
		}

		public ActionExpectation Arrange<T>(string memberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				{
					var method = MockingUtil.GetMethodByName(typeof(T), typeof(void), memberName, ref args);
					return MockingContext.CurrentRepository.Arrange(null, method, args, () => new ActionExpectation());
				});
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(Type targetType, string memberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				{
					var method = MockingUtil.GetMethodByName(targetType, typeof(TReturn), memberName, ref args);
					return MockingContext.CurrentRepository.Arrange(null, method, args, () => new FuncExpectation<TReturn>());
				});
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(MethodBase method, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() => MockingContext.CurrentRepository.Arrange(null, method, args, () => new FuncExpectation<TReturn>()));
		}

		public ActionExpectation Arrange(Type targetType, string memberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				{
					var method = MockingUtil.GetMethodByName(targetType, typeof(void), memberName, ref args);
					return MockingContext.CurrentRepository.Arrange(null, method, args, () => new ActionExpectation());
				});
		}

		public ActionExpectation Arrange(MethodBase method, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() => MockingContext.CurrentRepository.Arrange(null, method, args, () => new ActionExpectation()));
		}

		public void Assert<T>(string memberName, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(typeof(T), typeof(void), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, null, method, args, occurs);
				});
		}

		public void Assert(MethodBase method, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, null, method, args, occurs);
				});
		}

		public void Assert<T, TReturn>(string memberName, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(typeof(T), typeof(TReturn), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, null, method, args, occurs);
				});
		}

		public void Assert<T>(string memberName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(typeof(T), typeof(void), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, null, method, args, null);
				});
		}

		public void Assert(MethodBase method, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, null, method, args, null);
				});
		}

		public void Assert<T, TReturn>(string memberName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(typeof(T), typeof(TReturn), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, null, method, args, null);
				});
		}

		public void Assert(Type targetType, string memberName, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(targetType, typeof(void), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, null, method, args, occurs);
				});
		}

		public void Assert<TReturn>(Type targetType, string memberName, Occurs occurs, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(targetType, typeof(TReturn), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, null, method, args, occurs);
				});
		}

		public void Assert(Type targetType, string memberName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(targetType, typeof(void), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, null, method, args, null);
				});
		}

		void INonPublicExpectation.Assert<TReturn>(Type targetType, string memberName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
				{
					var message = MockingUtil.GetAssertionMessage(args);
					var method = MockingUtil.GetMethodByName(targetType, typeof(TReturn), memberName, ref args);
					MockingContext.CurrentRepository.AssertMethodInfo(message, null, method, args, null);
				});
		}

		public int GetTimesCalled(MethodBase method, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				MockingContext.CurrentRepository.GetTimesCalledFromMethodInfo(null, method, args));

		}

		public int GetTimesCalled(Type type, string memberName, params object[] args)
		{
			return ProfilerInterceptor.GuardInternal(() =>
			{
				var method = MockingUtil.GetMethodByName(type, typeof(void), memberName, ref args);
				return MockingContext.CurrentRepository.GetTimesCalledFromMethodInfo(null, method, args);
			});
		}
#endif

		#region Raise event

		public void Raise(object instance, EventInfo eventInfo, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() => RaiseEventBehavior.RaiseEventImpl(instance, eventInfo, args));
		}

		public void Raise(EventInfo eventInfo, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() => RaiseEventBehavior.RaiseEventImpl(null, eventInfo, args));
		}

		public void Raise(object instance, string eventName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
			{
				RaiseEventBehavior.RaiseEventImpl(instance, MockingUtil.GetUnproxiedType(instance).GetEvent(eventName,
					BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance), args);
			});
		}

		public void Raise(Type type, string eventName, params object[] args)
		{
			ProfilerInterceptor.GuardInternal(() =>
			{
				RaiseEventBehavior.RaiseEventImpl(null, type.GetEvent(eventName,
					BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static), args);
			});
		}
		#endregion

		public PrivateAccessor MakePrivateAccessor(object instance)
		{
			return new PrivateAccessor(instance);
		}

		public PrivateAccessor MakeStaticPrivateAccessor(Type type)
		{
			return PrivateAccessor.ForType(type);
		}

		public dynamic Wrap(object instance)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				{
#if !LITE_EDITION
					Mock.Intercept(instance.GetType());
#endif
					return new ExpressionContainer(Expression.Constant(instance, MockingUtil.GetUnproxiedType(instance)));
				}
			);
		}

		public dynamic WrapType(Type type)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				{
#if !LITE_EDITION
					Mock.Intercept(type);
#endif
					return new ExpressionContainer(Expression.Constant(type.GetDefaultValue(), type)) { IsStatic = true };
				}
			);
		}

		public ActionExpectation Arrange(dynamic dynamicExpression)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				MockingContext.CurrentRepository.Arrange(((IExpressionContainer)dynamicExpression).ToLambda(), () => new ActionExpectation())
			);
		}

		public FuncExpectation<TReturn> Arrange<TReturn>(dynamic dynamicExpression)
		{
			return ProfilerInterceptor.GuardInternal(() =>
				MockingContext.CurrentRepository.Arrange(((IExpressionContainer)dynamicExpression).ToLambda(), () => new FuncExpectation<TReturn>())
			);
		}

		public void Assert(dynamic dynamicExpression, Occurs occurs, string message = null)
		{
			ProfilerInterceptor.GuardInternal(() =>
				MockingContext.CurrentRepository.Assert(message, null, ((IExpressionContainer)dynamicExpression).ToLambda(), null, occurs)
			);
		}

		public void Assert(dynamic dynamicExpression, Args args, Occurs occurs, string message = null)
		{
			ProfilerInterceptor.GuardInternal(() =>
				MockingContext.CurrentRepository.Assert(message, null, ((IExpressionContainer)dynamicExpression).ToLambda(), args, occurs)
			);
		}

		public INonPublicRefReturnExpectation RefReturn { get { return this.refExpectation; } }
	}
}
