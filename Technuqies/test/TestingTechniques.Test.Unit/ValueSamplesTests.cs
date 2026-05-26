using FluentAssertions;

namespace TestingTechniques.Test.Unit;

public class ValueSamplesTests
{
    private readonly ValueSamples _sut = new();

    //string testler
    [Fact]
    public void StringAssertionExample()
    {
        var fullName = _sut.FullName;

        fullName.Should().Be("Baran Daşdemir");
        fullName.Should().NotBeEmpty();
        fullName.Should().StartWith("Baran");
        fullName.Should().EndWith("Daşdemir");
    }


    //integer testleri
    [Fact]
    public void NumberAssertionExample()
    {
        var age = _sut.Age;

        age.Should().Be(24);
        age.Should().BePositive();
        age.Should().BeGreaterThan(23);
        age.Should().BeLessThan(25);
        age.Should().BeLessThanOrEqualTo(24);
        age.Should().BeInRange(20, 50);
    }

    //date testleri
    [Fact]
    public void DateAssertionExample()
    {
        var date = _sut.DateOfBirth;

        date.Should().Be(new(2001, 08, 11));
        date.Should().BeAfter(new(1999, 09, 11));
        date.Should().BeBefore(new(2016, 09, 11));
    }

    //object testleri
    [Fact]
    public void ObjectAssentionTest()
    {
        var expected = new User
        {
            FullName = "Baran Daşdemir",
            Age = 24,
            DateOfBirth = new(2001, 08, 11)
        };

        var user = _sut.AppUser;

        user.Should().BeEquivalentTo(expected);
        //normal be da hata veriyor memoryde olduığu için ama böyle eşleştiriyor
    }

    //enumerable testleri
    [Fact]
    public void EnumerableObjectAssertionExample()
    {
        var expected = new User
        {
            FullName = "Baran Daşdemir",
            Age = 24,
            DateOfBirth = new(2001, 08, 11)
        };

        var user = _sut.Users.As<User[]>();

        user.Should().ContainEquivalentOf(expected);
        user.Should().HaveCount(3);
        user.Should().Contain(x=>x.FullName.StartsWith("Ali")&&x.Age > 9);

    }

    [Fact]
    public void EnumerableNumberAssertionExample()
    {
        var numbers = _sut.Numbers.As<int[]>();

        numbers.Should().Contain(5);

    }


    //exception örnekleri

    [Fact]
    public void ExceptionThrownAssertionExample()
    {
        Action result =() => _sut.Divide(1,0);

        result.Should().Throw<DivideByZeroException>().WithMessage("Attempted to divide by zero.");
    }

    //event örnekleri
    [Fact]
    public void EventRaisedAssertionExample() 
    {
        var monitorSubject = _sut.Monitor();

        _sut.RaiseExampleEvent();

        monitorSubject.Should().Raise("ExampleEvent");
    }

    //internal method test
    [Fact]
    public void TestingInternalMembersExample()
    {
        var number = _sut.InternalSecretNumber;

        number.Should().Be(42);
    }

}
