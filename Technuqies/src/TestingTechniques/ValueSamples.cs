using System.Security.Cryptography.X509Certificates;

namespace TestingTechniques;

public class ValueSamples
{
    public string FullName = "Baran Daşdemir";
    public int Age = 24;
    public DateOnly DateOfBirth = new(2001, 08, 11);

    public User AppUser = new()
    {
        FullName = "Baran Daşdemir",
        Age = 24,
        DateOfBirth = new(2001, 08, 11)
    };

    public IEnumerable<User> Users = new[]
    {
        new User()
        {
            FullName = "Baran Daşdemir",
            Age = 24,
            DateOfBirth = new(2001, 08, 11)
        },
        new User()
        {
            FullName = "Ali demir",
            Age = 10,
            DateOfBirth = new(2016, 09, 24)
        },
        new User()
        {
            FullName = "Veli Taş",
            Age = 50,
            DateOfBirth = new(1976, 01, 01)
        },
    };

    public IEnumerable<int> Numbers = new[]
    {
        5,
        10,
        25,
        50
    };


    public float Divide(int a,int b)
    {
        EnsureThatDivisorIsNotZero(a);
        EnsureThatDivisorIsNotZero(b);
        return a / b;
    }

    private void EnsureThatDivisorIsNotZero(int b)
    {
        if (b==0)
        {
            throw new DivideByZeroException();
        }
    }

    public event EventHandler? ExampleEvent;

    public virtual void RaiseExampleEvent()
    {
        ExampleEvent?.Invoke(this, EventArgs.Empty);
    }

    internal int InternalSecretNumber = 42;
}
