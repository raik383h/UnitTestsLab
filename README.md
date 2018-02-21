# Unit Tests Lab

This lab introduces you to the concept of unit testing.
Unit testing is the automated testing of individual, isolated components of a system.

## Downloading the Project.
Run `git clone https://github.com/raik383h/UnitTestsLab.git`.

## The Code
Open up UnitTestsLab.sln. You should see two classes, `ModularArithmeticCalculator` and `StringManipulator`.
Each class has several methods. Take a look at the documentation for these methods to see what inputs should
produce what outputs.

## Create the Unit Tests Project
* In the menu bar, right click on the solution file (not the csproj file) and click Add > New Project.
* Under Visual C# > Test, select Unit Test Project, name it UnitTestLabTests, and click OK.
* Right click on the UnitTestLabTests csproj file (not the solution file), click Edit References, and add
the UnitTestsLab project as a reference. This will let you access the classes in the tests project.
* Take a look at the file `UnitTest1.cs`. Notice the `[TestClass]` and `[TestMethod]` annotations.
These tell Visual Studio what classes and methods contains tests.
* Delete the `UnitTest1.cs` file.
* Right click on the UnitTestLabTests csproj file (not the solution file) and click
Add > New Item > Visual C# Items > Test > Basic Unit Test. Name it ModularArithmeticCalculatorTests.cs and click Add.
* Repeat for StringManipulatorTests.

## Writing Tests
Delete the methods called `TestMethod1`. For each method in both classes in `UnitTestLab.csproj`, write some unit tests.
Each unit test should be its own method. Method names should explain exactly what they're testing. Don't
worry about them being verbose; you'll never have to call these methods yourself. You'll thank yourself later
when you're testing lots of different methods, each with multiple inputs and outputs. Don't forget to add the `[TestMethod]`
annotation on all of the methods.

Your unit tests should follow the Arrange-Act-Assert pattern. First, you _arrange_ your test, meaning you
setup any necessary components (such as instantiating the class under test). Then, you _act_, meaning you
perform the action (such as calling the method) under test. Finally, you _assert_, meaning you check
the output of your action to verify it is what you expected.

As an example, suppose we're testing the addition operator.
```
[TestMethod]
public void TestAdditionOperatorBothOperandsPositive()
{
  //This is the ARRANGE step. We're setting up our inputs.
  //If we were testing a method, this would be the step
  //where we instantiate the associated class.
  int x = 2;
  int y = 3;
  
  //This is the ACT step. We actually perform the action
  //we're trying to test.
  int result = x + y;
  
  //This is the ASSERT step. We verify that the result
  //of our action is the value with expected.
  Assert.AreEqual(5, result);
}
```

### Assertions
Assertions are the main method of verifying your tests are successful. In C#, you can use the `Assert`
class to verify your results. Note that the order of parameters is expected value first, then actual value.
Methods include
* `Assert.AreEqual`: This lets you compare two values. If they're equal, the test passes. If not, the test fails.
This method is parameterized, so you can use it with any type. Be warned however that this may compare memory addresses
when using classes.
* `Assert.AreNotEqual`: This lets you compare two values, but the test succeeds if the values _aren't_ equal.
* `Assert.IsTrue`: The test passes if the given value is true (no expected value is needed for this one).
* `Assert.IsFalse`: The test passes if the given value is _false_.
* `Assert.IsNotNull`: The test passes if the given value is not `null`.
* `Assert.IsNull`: The test passes if the given value is `null`.
There are other classes like `CollectionAssert` that work on collections of objects instead of single objects.

## The Bug
One of the methods is incorrect. Look at the documentation for each method, and see if you can figure out which
one has a bug. Once you find it, write a unit test that causes the method to fail. Then, fix the bug and see
if your test now passes.

It is good practice to write tests when you find bugs. This way, you can isolate the exact location of the bug
and determine the exact input that is causing the error. Then, once you fix the bug, you now have a regression
test. If the bug is somehow reintroduced, this lets you catch it easier.

## Code Coverage
Code coverage is a measure of how much code your tests actually cover. To see your code coverage in Visual Studio, go to the menu and click Test > Analyze Code Coverage > All Tests. This will let you see how much of your methods are actually tested.

As an example, if you have 10 methods, and you have 1 test for each method, you might have 100% code coverage. On the other hand, you might not. If those methods have if-else statements, it is possible to have multiple code paths for each method, meaning your tests don't have 100% coverage. Additionally, even if you do test each code path, you might not test each possibility. If I have `if (a && b) { ... }`, I can have a test that successfully executes the contents of the if statement, thereby achieving full code coverage, without testing all code paths. Perhaps some combination of a and b is incorrect.

Code coverage is not the be all end all metric of test quality, but it is still a good goal to reach for.
