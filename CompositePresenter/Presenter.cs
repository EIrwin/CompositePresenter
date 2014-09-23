using System;
using System.Collections.Generic;

namespace CompositePresenter.Core
{
    public abstract class Presenter<TView>: IPresenter where TView:IView
    {
        protected TView View;
        protected IEventBus EventBus;
        protected IParameter Parameter;

        protected List<IPresenter> Children;

        protected Presenter()
        {
            Children = new List<IPresenter>();
        }
        protected Presenter(IEventBus eventBus)
        {
            EventBus = eventBus;
            Children = new List<IPresenter>();
        }
        protected Presenter(IEventBus eventBus, IParameter parameter)
        {
            EventBus = eventBus;
            Parameter = parameter;
            Children = new List<IPresenter>();
        }

        public TView Present()
        {
            return View;
        }

        public virtual void Dispose()
        {
            
        }

        public delegate void DisposedEventHandler(object sender, EventArgs e);
        public event DisposedEventHandler Disposed;

        protected virtual void OnDisposed()
        {
            if (Disposed != null)
                Disposed(this, EventArgs.Empty);
        }

        protected abstract void InitializeView();
        protected abstract void Render();
        protected virtual void AttachEvents()
        {
            throw new NotImplementedException();
        }

        protected IPresenter AddChild(IPresenter childPresenter)
        {
            this.Children.Add(childPresenter);
            return childPresenter;
        }
        protected TChildPresenter AddChild<TChildPresenter>(IEventBus eventBus) where TChildPresenter : IPresenter
        {
            TChildPresenter childPresenter = CreateChild<TChildPresenter>(eventBus);
            this.Children.Add(childPresenter);
            return childPresenter;
        }
        protected TChildPresenter AddChild<TChildPresenter>(IEventBus eventBus, IParameter parameter) where TChildPresenter : IPresenter
        {
            TChildPresenter childPresenter = CreateChild<TChildPresenter>(eventBus,parameter);
            this.Children.Add(childPresenter);
            return childPresenter;
        }

        //Not sure if we are going to need any of these
        protected void RemoveChild(IPresenter childPresenter)
        {
            Children.Remove(childPresenter);
        }
        protected void RemoveChildren(List<IPresenter> childPresenters)
        {
            Children.RemoveAll(childPresenters.Contains);
        }
        protected void RemoveAllChildren()
        {
            Children.Clear();
        }

        protected TChildPresenter  CreateChild<TChildPresenter>(IEventBus eventBus) where TChildPresenter: IPresenter
        {
            TChildPresenter t = (TChildPresenter)Activator.CreateInstance(typeof(TChildPresenter), new object[] { eventBus });
            return t;
        }
        protected TChildPresenter CreateChild<TChildPresenter>(IEventBus eventBus, IParameter parameter) where TChildPresenter : IPresenter
        {
            TChildPresenter t = (TChildPresenter)Activator.CreateInstance(typeof(TChildPresenter), new object[] { eventBus, parameter });
            return t;
        }
    }
}