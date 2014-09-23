using System.Windows.Documents;

namespace CompositePresenter.Core
{
    public class AdornerContext
    {
        #region [Public Properties]

        public AdornerLayer AdornerLayer { get; set; }

        #endregion

        #region [Constructors]

        public AdornerContext(AdornerLayer adornerLayer)
        {
            AdornerLayer = adornerLayer;
        }

        #endregion
    }
}