using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace LastMinuteTours.Infrastructure
{
    /// <summary>Упрощение привязок и валидации с ErrorProvider.</summary>
    public static class Extensions
    {
        /// <summary>
        /// Привязка control.Property ↔ source.Property + валидация.
        /// onValidated вызывается после каждой проверки (можно включать/выключать кнопку).
        /// </summary>
        public static void AddBinding<TControl, TSource>(
            this TControl control,
            Expression<Func<TControl, object>> destinationProperty,
            TSource source,
            Expression<Func<TSource, object>> sourceProperty,
            ErrorProvider? errorProvider = null,
            Action? onValidated = null)
            where TControl : Control
            where TSource : class
        {
            var dst = GetPropertyName(destinationProperty);
            var src = GetPropertyName(sourceProperty);

            control.DataBindings.Add(dst, source, src, true, DataSourceUpdateMode.OnPropertyChanged);

            void ValidateAndNotify()
            {
                if (errorProvider != null)
                    ValidateControl(control, source, src, errorProvider);
                onValidated?.Invoke();
            }

            control.Validating += (_, __) => ValidateAndNotify();

            switch (control)
            {
                case TextBox tb:
                    tb.TextChanged += (_, __) => ValidateAndNotify();
                    break;
                case NumericUpDown nud:
                    nud.ValueChanged += (_, __) => ValidateAndNotify();
                    break;
                case ComboBox cb:
                    cb.SelectedIndexChanged += (_, __) => ValidateAndNotify();
                    cb.TextChanged += (_, __) => ValidateAndNotify();
                    break;
                case DateTimePicker dtp:
                    dtp.ValueChanged += (_, __) => ValidateAndNotify();
                    break;
            }
        }

        private static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            var member = expression.Body as MemberExpression
                         ?? (expression.Body as UnaryExpression)?.Operand as MemberExpression;

            if (member?.Member is PropertyInfo pi) return pi.Name;
            throw new ArgumentException("Expression must be a property access", nameof(expression));
        }

        private static void ValidateControl<TControl, TSource>(
            TControl control, TSource source, string sourcePropertyName, ErrorProvider errorProvider)
            where TControl : Control
            where TSource : class
        {
            var ctx = new ValidationContext(source);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(source, ctx, results, true);

            var propertyError = results.FirstOrDefault(x => x.MemberNames.Contains(sourcePropertyName));
            errorProvider.SetError(control, propertyError?.ErrorMessage ?? string.Empty);
        }

        public static bool IsValid(this object obj)
        {
            var ctx = new ValidationContext(obj);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, ctx, results, true);
        }
    }
}
