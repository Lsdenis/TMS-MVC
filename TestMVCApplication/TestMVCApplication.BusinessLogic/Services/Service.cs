namespace TestMVCApplication.BusinessLogic.Services;

public class Service : IService
{
    private int _value;

    public Service(object value)
    {
        _value = (int)value;
    }

    public int ReturnValue()
    {
        return _value;
    }

    public void Increment()
    {
        _value++;
    }
}