using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MVPPassiveView
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
        }

        void _view_changed(IView sender, ViewEventArgs e)
        {
            this._model.setvalue(e.value);
        }

        public void SayiyiArttir()
        {
            _model.sayiyiArttir();
            _view.ChangeValue(this._model.getValue());
        }

        public void SayiyiAzalt()
        {
            _model.sayiyiAzalt();
            _view.ChangeValue(this._model.getValue());
        }
    }
}
