﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Models;
using Xunit;
using Xunit.Sdk;

namespace UnitTests
{
    public class TypedClassDataTests
    {
        private IEnumerable<MethodResult> RunClass(Type typeUnderTest)
        {
            ITestClassCommand testClassCommand = new TestClassCommand(typeUnderTest);

            ClassResult classResult = TestClassCommandRunner.Execute(testClassCommand, testClassCommand.EnumerateTestMethods().ToList(),
                                                                     startCallback: null, resultCallback: null);

            return classResult.Results.OfType<MethodResult>();
        }

        [Fact]
        public void ShouldBeCompatibleWithObjectArrayEnumerables()
        {
            MethodResult testResult = RunClass(typeof(EnumerableObjectArrayTestModel)).Single();

            Assert.IsType<PassedResult>(testResult);
            Assert.Equal(@"UnitTests.Models.EnumerableObjectArrayTestModel.EnumerableTest(foo: 1, bar: ""bar"")", testResult.DisplayName);
        }

        [Fact]
        public void ShouldBeAbleToInjectAnonymousTypeAsObject()
        {
            MethodResult testResult = RunClass(typeof(AnonymousTypeAsObjectTestModel)).Single();

            Assert.IsType<PassedResult>(testResult);
            Assert.Equal(@"UnitTests.Models.AnonymousTypeAsObjectTestModel.AnonymousTypeTest(anonymousData: { Foo = 1, Bar = bar })", testResult.DisplayName);
        }

        [Fact]
        public void ShouldBeAbleToInjectAnonymousTypeAsDynamic()
        {
            MethodResult testResult = RunClass(typeof(AnonymousTypeAsDynamicTestModel)).Single();

            Assert.IsType<PassedResult>(testResult);
            Assert.Equal(@"UnitTests.Models.AnonymousTypeAsDynamicTestModel.AnonymousTypeTest(dynamicData: { Foo = 1, Bar = bar })", testResult.DisplayName);
        }

        [Fact]
        public void ShouldBeAbleToInjectAnonymousTypeAsParameters()
        {
            MethodResult testResult = RunClass(typeof(AnonymousTypeAsParametersTestModel)).Single();

            Assert.IsType<PassedResult>(testResult);
            Assert.Equal(@"UnitTests.Models.AnonymousTypeAsParametersTestModel.AnonymousTypeTest(foo: 1, bar: ""bar"")", testResult.DisplayName);
        }

        [Fact]
        public void ShouldBeAbleToInjectClassTypeAsObject()
        {
            MethodResult testResult = RunClass(typeof(ClassTypeAsObjectTestModel)).Single();

            Assert.IsType<PassedResult>(testResult);
            Assert.Equal(@"UnitTests.Models.ClassTypeAsObjectTestModel.ClassTypeTest(classData: UnitTests.Models.FooBar)", testResult.DisplayName);
        }

        [Fact]
        public void ShouldBeAbleToInjectClassTypeAsDynamic()
        {
            MethodResult testResult = RunClass(typeof(ClassTypeAsDynamicTestModel)).Single();

            Assert.IsType<PassedResult>(testResult);
            Assert.Equal(@"UnitTests.Models.ClassTypeAsDynamicTestModel.ClassTypeTest(dynamicData: UnitTests.Models.FooBar)", testResult.DisplayName);
        }

        [Fact]
        public void ShouldBeAbleToInjectClassTypeAsParameters()
        {
            MethodResult testResult = RunClass(typeof(ClassTypeAsParametersTestModel)).Single();

            Assert.IsType<PassedResult>(testResult);
            Assert.Equal(@"UnitTests.Models.ClassTypeAsParametersTestModel.ClassTypeTest(foo: 1, bar: ""bar"")", testResult.DisplayName);
        }

        [Fact]
        public void ShouldBeAbleToInjectClassTypeAsTypedInstance()
        {
            MethodResult testResult = RunClass(typeof(ClassTypeAsTypedInstanceTestModel)).Single();

            Assert.IsType<PassedResult>(testResult);
            Assert.Equal(@"UnitTests.Models.ClassTypeAsTypedInstanceTestModel.ClassTypeTest(data: UnitTests.Models.FooBar)", testResult.DisplayName);
        }

    }
}
