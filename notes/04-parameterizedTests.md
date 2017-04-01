show many tests

show parameterized example with inline data

explain why it's functional

[Theory]
[MemberData(nameof(PropertyDataDrivenTests.TestData), MemberType = typeof(DemoPropertyDataSource))]