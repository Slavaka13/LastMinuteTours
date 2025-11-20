using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace LastMinuteTours.App.Infrastructure
{
    public static class Extensions
    {
        public static void AddBinding<TControl, TModel>(
            this TControl control,
            Expression<Func<TControl, object>> dest,
            TModel model,
            Expression<Func<TModel, object>> src,
            ErrorProvider err = null,
            Action onChange = null)
            where TControl : Control
        {
            string destName = GetName(dest);
            string srcName = GetName(src);

            control.DataBindings.Add(destName, model, srcName, true, DataSourceUpdateMode.OnPropertyChanged);

            void Validate()
            {
                if (err != null)
                    ValidateControl(control, model, srcName, err);

                onChange?.Invoke();
            }

            control.Validating += (_, __) => Validate();

            if (control is TextBox tb) tb.TextChanged += (_, __) => Validate();
            if (control is NumericUpDown nud) nud.ValueChanged += (_, __) => Validate();
            if (control is ComboBox cb)
            {
                cb.SelectedIndexChanged += (_, __) => Validate();
                cb.TextChanged += (_, __) => Validate();
            }
            if (control is DateTimePicker dtp) dtp.ValueChanged += (_, __) => Validate();
        }

        private static string GetName<T>(Expression<Func<T, object>> expr)
        {
            if (expr.Body is MemberExpression m) return m.Member.Name;
            if (expr.Body is UnaryExpression u && u.Operand is MemberExpression um) return um.Member.Name;
            throw new ArgumentException("Invalid expression");
        }

        private static void ValidateControl<T>(
            Control c,
            T model,
            string prop,
            ErrorProvider err)
        {
            var ctx = new ValidationContext(model);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, ctx, results, true);

            var msg = results.FirstOrDefault(r => r.MemberNames.Contains(prop))?.ErrorMessage;

            err.SetError(c, msg ?? "");
        }
    }
}
