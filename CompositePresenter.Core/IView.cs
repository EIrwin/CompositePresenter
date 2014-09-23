using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePresenter.Core
{
    public interface IView
    {
        Guid Id { get; set; }
    }
}
