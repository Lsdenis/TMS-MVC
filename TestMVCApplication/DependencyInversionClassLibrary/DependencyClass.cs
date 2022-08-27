using TestMVCApplication.Web.Interfaces;

namespace DependencyInversionClassLibrary;

public class DependencyClass : IDependencyClass
{
    public void Test()
    {
        var a = 5;
    }
}