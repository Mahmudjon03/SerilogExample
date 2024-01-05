using AutoMapper;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WebApi.Model;
using WebApi.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test
{
    public class UnitTest1 : IDisposable
    {
        private readonly IUserService _user = new UserService();

        public void Dispose()
        {
            //--------------------------------->
        }

        //User user =  new  User(1,"ali",23);
        //[Fact]
        //public void NotNullAction()
        //{
        //    var result = _user.AddUser(user);
        //    Assert.NotNull(result);
        //}
        //[Fact]
        //public void BoolingAction()
        //{
        //    Assert.True("".GetType() == typeof(string));
        //    Assert.False(1.GetType() == typeof(int));
        //}
        //[Fact]
        //public void NullAction()
        //{
        //    var result = _user.AddUser(user);
        //    Assert.NotNull(result);
        //}
        //[Fact]
        //public void ContainsAction()
        //{
        //    Assert.Contains("text", "This is a text.");

        //    var names = new List<string> { "Picard", "Kirk" };

        //    Assert.Contains(names, n => n == "Kirk");

        //    Assert.DoesNotContain("sdf", "This is a text.");
        //}
        //[Fact]
        //public void matchesTest()
        //{
        //    var regEx = @"\A[A-Z0-9+_.-]+@[A-Z0-9.-]+\Z";
        //    Assert.DoesNotMatch(regEx, "this is a text");
        //    Assert.Matches(regEx, "this is a text");
        //}
        //[Fact]
        //public void TestMethod()
        //{
        //    var result = "foo bar baz";

        //    Assert.True(Regex.IsMatch(result, "foo (.*?) baz"));
        //}
        //[Fact]
        //public void StartEndWith()
        //{
        //    Assert.StartsWith("This is a text.", "This");
        //    Assert.EndsWith("This is a text.", "text.");
        //}
        //[Fact]
        //public void Test()
        //{
        //    var set1 = new HashSet<int> { 1, 2, 3, 4, 5, 6 };
        //    var set2 = new HashSet<int> { 3, 4 };
        //    var notProperSubset = new HashSet<int> { 1, 2, 3, 4, 5, 6 };

        //    Assert.Subset(set1, set2);

        //    Assert.ProperSubset(set1, set2);

        //    // fails, https://mathinsight.org/definition/proper_subset
        //    Assert.ProperSubset(set1, notProperSubset);

        //    var set3 = new HashSet<int> { 1, 2, 3, 4, 5, 6 };
        //    var set4 = new HashSet<int> { 3, 4 };
        //    var notProperSuperSet = new HashSet<int> { 1, 2, 3, 4, 5, 6 };

        //    Assert.Superset(set4, set3);
        //    Assert.ProperSuperset(set4, notProperSuperSet);

        //    // fails
        //    Assert.ProperSuperset(set3, notProperSuperSet);
        //}
        //[Fact]
        //public void Test1()
        //{

        //    // Assert.Equal("Text", "Text");
        //    //  Assert.NotEqual("text", "Text");

        //    //  Assert.Empty(new List<int> { });
        //    //    Assert.NotEmpty(new List<int> { 1 });

        //    //    Assert.InRange(3, 1, 2);
        //    //   Assert.NotInRange(3, 1, 3);

        //    var listWithSingle = new List<int> {4};
        //    Assert.Single(listWithSingle);

        //}

        //[Fact]
        //public void Test2()
        //{
        //   // Assert.IsAssignableFrom<IEnumerable<int>>(new List<int>());
        //  // Assert.IsAssignableFrom<IDictionary<string,int>>(new List<int>());
        //}

        //[Fact]
        //public void Test3()
        //{

        //    var obj1 = 1;
        //    var obj2 = obj1;
        //    var obj3 =1;

        //    Assert.Same(obj1, obj2);

        //    Assert.NotSame(obj1, obj3);
        //}
        [Fact]
        public void Test4()
        {

        }




    }
}