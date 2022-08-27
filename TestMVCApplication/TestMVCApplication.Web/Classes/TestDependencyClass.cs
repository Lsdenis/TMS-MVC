using TestMVCApplication.Web.Interfaces;

namespace TestMVCApplication.Web.Classes;

public class TestDependencyClass
{
    private readonly IDependencyClass _dependencyClass;

    public TestDependencyClass(IDependencyClass dependencyClass)
    {
        _dependencyClass = dependencyClass;
    }
}