namespace CompositePresenter.Core
{
    public interface IEvent
    {
       
    }

    public interface IEvent<T>
    {
        T EventArgs { get; set; }
    }
}