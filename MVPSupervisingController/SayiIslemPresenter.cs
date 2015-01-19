using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVPSupervisingController
{
    public class SayiIslemPresenter
    {
        IModel _model;
        IView _view;

        public SayiIslemPresenter(IModel _model, IView _view)
        {
            this._model = _model;
            this._view = _view;

            this._view.changed += _view_changed;
            this._model.AboneOl((IModelObserver)this._view);
        }

        void _view_changed(IView sender, ViewEventArgs e)
        {
            this._model.setvalue(e.value);
        }

        public void SayiyiArttir()
        {
            _model.sayiyiArttir();
        }

        public void SayiyiAzalt()
        {
            _model.sayiyiAzalt();
        }
    }
}
