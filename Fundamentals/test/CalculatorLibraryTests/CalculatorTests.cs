using CalculatorLibrary;
using FluentAssertions;
using Xunit.Abstractions;

namespace CalculatorLibraryTests;

public class CalculatorTests:IAsyncLifetime /*IDisposable*/ /*--> bu normal yapılar için asenkron için ise=>  IAsyncLifetime kullanılır*/
{
    private readonly Calculator _sut = new();
    private readonly Guid _guid = Guid.NewGuid();

    private readonly ITestOutputHelper _outputHelper;

    public CalculatorTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _outputHelper.WriteLine("Hello From the ctor");
    }


    [Theory/*(Skip ="örnek doğrultusunda facta değilde thoerye yazılır")*/]
    [InlineData(5,4,9)]
    [InlineData(0,0,0,Skip="tek biri çalıştırılmak istenmezse ise böyle yazılır")]
    [InlineData(-5,-5,-10)]
    //bu üstteki çağırılmalar bir methodu farklı farklı çağırarak her testi rahatça ve kod kalabalığı olmadan yapmamızı sağlar
    /*[Fact]*///test olduğuunu belirtmek adına bu önemli bunu yazmazsak test explorerda gözükmez 
    public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreIntegers(int a,int b,int expected)
    {
        //arrange kısmı : classların set edildiği ve newlendiği kısımdır --> duruma göre bu kısım kaldırılabilir yukarıya alınır
        //var calculator = new Calculator();

        //act metotların çağırıldığı ve çalıştırıldığı ve sonuçların yakalandığı
        //var result = calculator.Add(5, 4);
        var result = _sut.Add(a, b);
        _outputHelper.WriteLine("Hello From the add method");

        //istediğimiz sonucu burası takip ediyor sonuçların yakalandığı sonuçların kontrol edildiği kısımdır
        Assert.Equal(expected, result);


    }

    [Fact]
    public void Subtract_ShouldSubtractTwoNumbers_WhenTwoNumbersAreIntegers()
    {
        var result = _sut.Subtract(10,7);

        _outputHelper.WriteLine("subtract metodu çalıştı");

        Assert.Equal(3, result);
    }

    //public void Dispose()
    //{
    //    _outputHelper.WriteLine("Hello From the cleanup");
    //}

    [Fact(Skip ="Bu testler geçersiz")]
    public void TestGuid1()
    {
        _outputHelper.WriteLine(_guid.ToString());
        _outputHelper.WriteLine("Hello From the guid 1 metot");
    }

    [Fact(Skip = "Bu testler geçersiz")]
    public void TestGuid2()
    {
        _outputHelper.WriteLine(_guid.ToString());
        _outputHelper.WriteLine("Hello From the guid 2 metot");
    }

    public async  Task InitializeAsync()
    {
        _outputHelper.WriteLine("Hello From the initialize");
        await Task.Delay(1);
    }

    public async Task DisposeAsync()
    {
        _outputHelper.WriteLine("Hello From the dispose async");
        await Task.Delay(2);
    }
}
